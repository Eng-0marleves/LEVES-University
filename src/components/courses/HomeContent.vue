<template>
	<div class="CourseHome">
		<div class="content" v-if="course">
			<div class="about">
				<div class="left d-flex flex-column gap-3">
					<p><i class="fa-solid fa-angles-right"></i> Course Code</p>
					<p><i class="fa-solid fa-angles-right"></i> Course Name</p>
					<p><i class="fa-solid fa-angles-right"></i> Credit Hours</p>
					<p><i class="fa-solid fa-angles-right"></i> Course Description</p>
					<p v-for="(grade, key) in course.grades" :Key="key"><i class="fa-solid fa-angles-right"></i> {{ key
						}}</p>
				</div>
				<div class="right d-flex flex-column gap-3">
					<p>{{ course.courseCode }}</p>
					<p>{{ course.courseTitle }}</p>
					<p>{{ course.creditHours }}</p>
					<p>{{ course.courseDescription }}</p>
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
			const response = await axios.get(`https://localhost:44303/api/Courses/getcourse?courseCode=${courseCode}`);
			if (response.status === 200) {
				this.course = response.data;
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
