<template>
	<div class="container">
		<div class="row" v-if="course">
			<div class="col-md-6">
				<div class="card">
					<div class="card-header">
						<h2 class="card-title">Course Information</h2>
					</div>
					<div class="card-body">
						<p><strong>Course Code:</strong> {{ course.course_code }}</p>
						<p><strong>Course Name:</strong> {{ course.course_name }}</p>
					</div>
				</div>
			</div>
			<div class="col-md-6">
				<div class="card">
					<div class="card-header">
						<h2 class="card-title">Course Grades</h2>
					</div>
					<div class="card-body">
						<p><strong>Midterm:</strong> {{ course.grades.midterm }}/25</p>
						<p><strong>Assignment:</strong> {{ course.grades.assignment }}/20</p>
						<p><strong>Attendance:</strong> {{ course.grades.attendance }}/5</p>
						<p><strong>Final:</strong> {{ course.grades.final }}/50</p>
					</div>
				</div>
			</div>
		</div>
		<div v-else>
			<p>Loading...</p>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'CourseHome',
	data() {
		return {
			course: null
		};
	},
	async mounted() {
		const courseCode = this.$route.params.course_code;
		try {
			const response = await axios.get(`http://localhost:3000/courses`);
			if (response.status === 200) {
				const courses = response.data;
				this.course = courses.find(course => course.course_code === courseCode);
			} else {
				console.error('Failed to fetch course data:', response.statusText);
			}
		} catch (error) {
			console.error('Error fetching course data:', error);
		}
	}
};
</script>

<style scoped>
.container {
	margin-top: 20px;
}

.card {
	margin-bottom: 20px;
}

.card-header {
	background-color: var(--primary-color);
	color: #fff;
	padding: 10px;
}

.card-title {
	margin: 0;
}

.card-body {
	padding: 20px;
}

p {
	margin-bottom: 10px;
}
</style>
