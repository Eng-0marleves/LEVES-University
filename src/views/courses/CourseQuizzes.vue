<template>
	<CourseOffCanvas />
	<section class="CourseQuizzes d-flex flex-column gap-4">
		<router-link :to="`CourseQuizzes/quizz_generator`" class="btn normal generator">Quizz Generator</router-link>

		<div class="card" v-for="quiz in quizzes" :key="quiz.quizId">
			<div class="card-body">
				<h6>{{ quiz.title }}</h6>

				<div class="controllers d-flex flex-row flex-wrap gap-2 align-items-center">
					<div class="status me-3">{{ quiz.isPublished ? 'Open' : 'In Design' }}</div>
					<router-link :to="`CourseQuizzes/quizzDetails/${quiz.quizId}`" class="action-btn">Open</router-link>
					<router-link to="" class="action-btn" v-if="!quiz.isPublished">Preview</router-link>
					<router-link to="" class="action-btn" v-if="quiz.showResult">Result</router-link>
					<router-link to="" class="action-btn" v-if="!quiz.isPublished">Analysis</router-link>

					<a class="action-btn dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
						aria-expanded="false">
						Action
					</a>

					<ul class="dropdown-menu">
						<li><a class="dropdown-item" href="#">Edit</a></li>
						<li><a class="dropdown-item" href="#">Delete</a></li>
						<li><a class="dropdown-item" href="#">Rename</a></li>
					</ul>
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

.card-body {
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.loading {
	text-align: center;
	padding: 20px;
}

.CourseQuizzes .generator {
	margin: 0 auto;
}

.action-btn {
	color: var(--white-color);
	background: var(--primary-color);
	padding: 4px 8px;
	transition: var(--transition);
}

.action-btn:hover {
	opacity: 0.9;
}
</style>
