<template>
	<div class="schedule-view">
		<OffCanvas :routers="routers" />
		<router-view></router-view>
	</div>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';

export default {
	name: 'ScheduleView',
	components: {
		OffCanvas
	},
	data() {
		return {
			routers: [
				{
					title: "Home",
					path: `/schedule/scheduleHome`
				},
				{
					title: "Schedules",
					path: `/schedule/schedules`
				},
				{
					title: "Automation",
					path: `/schedule/automation`
				},
				{
					title: "Scheduling",
					path: `/schedule/scheduling`
				},
				{
					title: "Events",
					path: `/schedule/events`
				},
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
/* Your CSS styles go here */
</style>