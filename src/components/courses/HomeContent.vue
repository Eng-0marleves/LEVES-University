<template>
	<div class="CourseHome">
		<div class="content" v-if="course">
			<div class="about">
				<div class="left d-flex flex-column gap-3">
					<p><i class="fa-solid fa-angles-right"></i> Course Code</p>
					<p><i class="fa-solid fa-angles-right"></i> Course Name</p>
					<p v-for="(grade, key) in course.grades" :Key="key"><i class="fa-solid fa-angles-right"></i> {{ key
						}}</p>
				</div>
				<div class="right d-flex flex-column gap-3">
					<p>{{ course.course_code }}</p>
					<p>{{ course.course_name }}</p>
					<p v-for="(grade, key) in course.grades" :Key="key">{{ grade }} marks</p>
				</div>
			</div>
			<div class="discription">
				<p class="title mb-1"><i class="fa-solid fa-angles-right"></i> Description</p>
				<p>{{ course.description }}</p>
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

.content {
	width: 100%;
	padding: 8px;
	color: var(--white-color);
	background: var(--primary-color);
	display: flex;
	flex-direction: column;
	gap: 32px;
}

.content .about {
	display: flex;
	align-items: center;
	gap: 40px;
}

i {
	color: var(--secondary-color);
}
</style>
