<template>
	<div class="students-page">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'All Students'">
				<!-- All Students Content -->
				<AllStudents />
			</div>
			<div v-if="currentTab === 'Add Student'">
				<!-- Add Student Form -->
				<p>Add a new student form...</p>
			</div>
			<div v-if="currentTab === 'Student Attendance'">
				<!-- Student Attendance -->
				<p>Student attendance records...</p>
			</div>
		</div>
	</div>
</template>

<script>
import AllStudents from '@/components/dashboard/students/AllStudents.vue';

export default {
	name: 'StudentsPage',
	data() {
		return {
			currentTab: 'All Students',
			tabs: ['All Students', 'Add Student', 'Student Attendance']
		};
	},
	components: {
		AllStudents
	}
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
