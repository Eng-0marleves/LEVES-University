<template>
	<CourseOffCanvas />
	<div class="grades-view">
		<StudentsGrades />
	</div>
</template>

<script>
import StudentsGrades from '@/components/courses/StudentsGrades.vue';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';

export default {
	name: 'CourseGrades',
	components: {
		StudentsGrades,
		CourseOffCanvas
	},
	data() {
		return {
			// Your data properties go here
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	created() {
		// Code to run when the component is created
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
/* Your CSS styles go here */
</style>
