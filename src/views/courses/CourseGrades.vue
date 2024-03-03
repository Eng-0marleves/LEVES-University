<template>
	<div class="grades-view">
		<h1>For Doctors</h1>
		<StudentsGrades />
	</div>
</template>

<script>
import StudentsGrades from '@/components/courses/StudentsGrades.vue';

export default {
	name: 'CourseGrades',
	components: {
		StudentsGrades
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
