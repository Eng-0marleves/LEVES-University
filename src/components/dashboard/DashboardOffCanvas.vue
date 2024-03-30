<template>
	<div class="dashboard-off-canvas">
		<OffCanvas :routers="routers" />
	</div>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';

export default {
	name: 'DashboardOffCanvas',
	components: {
		OffCanvas
	},
	data() {
		return {
			routers: [
				{
					title: "Profile",
					path: `/dashboard/profile`,
				},
				{
					title: "Time Table",
					path: `/dashboard/time_table`,
				},
				{
					title: "Register",
					path: `/dashboard/register`,
				},
				{
					title: "Financials",
					path: `/dashboard/financials`,
				},
				{
					title: "Report",
					path: `/dashboard/report`,
				},
				{
					title: "Analysis",
					path: `/dashboard/analysis`,
				},
				{
					title: "Students",
					path: `/dashboard/students`,
				},
				// {
				// 	title: "Notes",
				// 	path: `/dashboard/`,
				// }
			]
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
.dashboard-off-canvas {
	/* Your styles go here */
}
</style>