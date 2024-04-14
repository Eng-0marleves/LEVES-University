<template>
	<div class="enrollment-student-management">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'Enrollment Management'">
				<EnrollmentManagement />
			</div>
			<div v-if="currentTab === 'Student Tracking'">
				<StudentTracking />
			</div>
		</div>
	</div>
</template>

<script>
import EnrollmentManagement from '@/components/dashboard/semester/EnrollmentManagement.vue';
import StudentTracking from './StudentTracking.vue';

export default {
	name: 'EnrollmentStudentManagement',
	data() {
		return {
			currentTab: 'Enrollment Management',
			tabs: ['Enrollment Management', 'Student Tracking']
		};
	},
	components: {
		EnrollmentManagement,
		StudentTracking,
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	}
};
</script>

<style scoped>
.nav-tabs {
	list-style-type: none;
	padding: 0;
	display: flex;
	margin-bottom: 20px;
}

.nav-tabs li {
	cursor: pointer;
	padding: 5px 10px;
	border: 1px solid #ccc;
	margin: 0 5px;
	transition: background-color 0.3s;
}

.nav-tabs li:hover,
.nav-tabs li.active {
	background-color: var(--secondary-color);
	color: var(--white-color);
}
</style>