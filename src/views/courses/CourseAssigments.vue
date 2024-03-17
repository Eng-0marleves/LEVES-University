<template>
	<div class="course-assignments">
		<h1>course-assignments</h1>
	</div>

	<CourseOffCanvas />
</template>

<script>
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';

export default {
	name: 'CourseAssignments',
	data() {
		return {
			// Your data goes here
		};
	},
	methods: {
		// Your methods go here
	},
	components: {
		CourseOffCanvas
	},
};
</script>

<style scoped>
/* Your styles go here */
</style>