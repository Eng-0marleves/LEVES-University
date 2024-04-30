<template>
	<div>
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'Employees'">
				<AllEmployees />
			</div>
			<div v-if="currentTab === 'Add Employeer'">
				<AddEmployeer />
			</div>
			<div v-if="currentTab === 'Jop Titles'">
				<JobTitles />
			</div>
			<div v-if="currentTab === 'Add Jop Title'">
				<AddJopTitle />
			</div>
		</div>
	</div>
</template>

<script>
import AllEmployees from './AllEmployees.vue';
import AddEmployeer from './AddEmployeer.vue';
import JobTitles from './JobTitles.vue';
import AddJopTitle from './AddJopTitle.vue';

export default {
	name: 'EmployeesDashboard',
	components: {
		AllEmployees,
		AddEmployeer,
		JobTitles,
		AddJopTitle
	},
	data() {
		return {
			currentTab: 'Employees',
			tabs: ['Employees', 'Add Employeer', 'Jop Titles', 'Add Jop Title'],
		};
	},
	methods: {
		// Your methods go here
	},
	mounted() {
		// Code to run when the component is mounted goes here
	},
};
</script>

<style scoped>
.nav-tabs {
	color: var(--white-color);
	list-style-type: none;
	padding: 0;
	display: flex;
	margin-bottom: 20px;
	background: var(--primary-color);
}

.nav-tabs li {
	cursor: pointer;
	padding: 10px 20px;
	border: 1px solid #ccc;
	margin: 0 5px;
	transition: background-color 0.3s;
}

.nav-tabs li:hover,
.nav-tabs li.active {
	background-color: var(--secondary-color);
}

.tab-content {
	border: 1px solid #ccc;
	padding: 20px;
}
</style>