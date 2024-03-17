<template>
	<CourseOffCanvas />
	<section class="CourseQuizzes">
		<router-link :to="`CourseQuizzes/quizz_generator`" class="btn normal">Quizz Generator</router-link>

		<div class="card" v-for="quiz in quizzes" :key="quiz.quizId">
			<div class="card-header">
				{{ quiz.title }}
			</div>
			<div class="card-body d-flex flex-column gap-2">
				<h6>Dr: {{ quiz.doctorName }}</h6>
				<h6>Grades: {{ quiz.totalGrade }}</h6>
				<h6>Duration: {{ quiz.duration }}</h6>
				<h6>Start Date: {{ formatDate(quiz.publishDate) }}</h6>
				<h6>End Date: {{ formatDate(quiz.endDate) }}</h6>
				<div class="controllers d-flex flex-row flex-wrap gap-2">
					<router-link :to="`CourseQuizzes/${quiz.quizId}`" v-if="!isPastDate(quiz.endDate)"
						class="btn normal">Start</router-link>
					<a href="#" class="btn normal">Result</a>
					<a href="#" class="btn normal">Analysis</a>
				</div>
			</div>
		</div>
	</section>
</template>

<script>
import axios from 'axios';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';

export default {
	name: 'CourseQuizzes',
	components: {
		CourseOffCanvas
	},
	data() {
		return {
			quizzes: [],
			quizzesLoading: true
		};
	},
	async mounted() {
		try {
			const response = await axios.get('http://localhost:3000/quizzes');
			this.quizzes = response.data;
		} catch (error) {
			console.error('Error fetching quizzes:', error);
		} finally {
			this.quizzesLoading = false;
		}
	},
	methods: {
		formatDate(dateString) {
			const date = new Date(dateString);
			return date.toLocaleString();
		},
		isPastDate(dateString) {
			const currentDate = new Date();
			const endDate = new Date(dateString);
			return currentDate > endDate;
		},
		// async enrollStudent(quiz) {
		// 	try {
		// 		const studentId = 12; // Assuming the student ID is known or retrieved from authentication
		// 		// const response = await axios.post(`http://localhost:3000/quizzes?quizId=${quiz.quizId}/enrolls`, { studentId });
		// 		// Handle successful enrollment, e.g., show a success message
		// 		console.log('Student enrolled successfully:', response.data);
		// 	} catch (error) {
		// 		console.error('Error enrolling student:', error);
		// 		// Handle enrollment error, e.g., show an error message
		// 	}
		// }
	}
};
</script>

<style scoped>
.CourseQuizzes {
	padding: 16px;
}

.card-header {
	background: var(--primary-color);
	color: var(--white-color);
}

.loading {
	text-align: center;
	padding: 20px;
}
</style>
