<template>
	<div class="dashboard-home">
		<router-view></router-view>
		<DashboardOffCanvas />
	</div>
</template>

<script>
import DashboardOffCanvas from '@/components/dashboard/DashboardOffCanvas.vue';
export default {
	name: 'DashboardHome',
	data() {
		return {
			// Your data goes here
		};
	},
	components: {
		DashboardOffCanvas
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
.dashboard-home {
	/* Your styles go here */
}
</style>