<template>
	<div class="about-counts">
		<div class="item d-flex flex-column gap-3">
			<i class="fas fa-book"></i>
			<h4>Available Courses</h4>
			<h5>254</h5>
		</div>

		<div class="item d-flex flex-column gap-3">
			<i class="fas fa-user-graduate"></i>
			<h4>Students</h4>
			<h5>51568</h5>
		</div>

		<div class="item d-flex flex-column gap-3">
			<i class="fas fa-chalkboard-teacher"></i>
			<h4>Teachers</h4>
			<h5>841</h5>
		</div>

		<div class="item d-flex flex-column gap-3">
			<i class="fas fa-calendar-alt"></i>
			<h4>Scheduled Events</h4>
			<h5>37</h5>
		</div>

		<div class="item d-flex flex-column gap-3">
			<i class="fas fa-university"></i>
			<h4>Colleges</h4>
			<h5>5</h5>
		</div>
	</div>
</template>

<script>
export default {
	name: 'AboutCounts',
	data() {
		return {
			// Your data goes here
		}
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
}
</script>

<style scoped>
.about-counts {
	width: 100%;
	display: flex;
	justify-content: space-around;
	align-items: flex-start;
	gap: 16px;
	text-align: center;
	color: var(--primary-color);
}

.about-counts i {
	font-size: 46px;
	color: var(--secondary-color);
}
</style>
