<template>
	<div class="courses-registration">
		<h3>Courses Registeration</h3>

		<ag-grid-vue style="width: 100%;" class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="rowData"
			:domLayout="'autoHeight'" v-if="rowData.length"></ag-grid-vue>
	</div>
</template>

<script>
export default {
	name: 'CoursesRegistration',
	data() {
		return {
			// Your data goes here
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
/* Your CSS goes here */
</style>