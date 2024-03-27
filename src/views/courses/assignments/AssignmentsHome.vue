<template>
	<CourseOffCanvas />
	<div>
		<router-view></router-view>
	</div>
</template>

<script>
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';

export default {
	name: 'AssignmentsHome',
	data() {
		return {
			// Your data properties go here
		};
	},
	components: {
		CourseOffCanvas
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
	}
};
</script>

<style scoped>
/* Your CSS styles go here */
</style>