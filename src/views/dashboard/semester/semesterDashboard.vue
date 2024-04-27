<template>
	<div class="semester-dashboard">
		<!-- Trigger Button -->
		<button class="toggle" type="button" data-bs-toggle="offcanvas" data-bs-target="#semesterDashboardOffcanvas"
			aria-controls="semesterDashboardOffcanvas">
			<i class="fas fa-angle-down"></i>
		</button>

		<!-- Top Offcanvas -->
		<div class="offcanvas offcanvas-top" tabindex="-1" id="semesterDashboardOffcanvas"
			aria-labelledby="offcanvasTopLabel">
			<div class="offcanvas-header">
				<h5 class="offcanvas-title" id="offcanvasTopLabel">Semester Dashboard</h5>
				<button type="button" data-bs-dismiss="offcanvas" ref="close"><i class="fas fa-xmark"></i></button>
			</div>
			<div class="offcanvas-body">
				<!-- Navigation Links -->
				<ul class="nav flex-column">
					<li class="nav-item" v-for="tab in tabs" :key="tab" @click="changeTab(tab)">
						<button class="nav-link active" @click="toggleOffcanvas">{{ tab }}</button>
					</li>
				</ul>
			</div>
		</div>

		<div class="tab-content">
			<semester-management v-if="currentTab === 'Semester Management'"
				@selectedSemesterChanged="handleSemesterChange" />
			<course-faculty-management v-if="currentTab === 'Course and College Management'"
				:semester="selectedSemester" />
			<enrollment-student-management v-if="currentTab === 'Enrollment and Student Management'" />
			<analytics-reporting v-if="currentTab === 'Analytics and Reporting'" />
			<system-administration v-if="currentTab === 'System Administration'" />
		</div>
	</div>
</template>

<script>
import SemesterManagement from './SemesterManagement.vue';
import CourseFacultyManagement from './CourseFacultyManagement.vue';
import EnrollmentStudentManagement from './EnrollmentStudentManagement.vue';
import AnalyticsReporting from './AnalyticsReporting.vue';
import SystemAdministration from './SystemAdministration.vue';

export default {
	name: 'SemesterDashboard',
	components: {
		SemesterManagement,
		CourseFacultyManagement,
		EnrollmentStudentManagement,
		AnalyticsReporting,
		SystemAdministration,
	},
	data() {
		return {
			currentTab: 'Course and College Management',
			tabs: [
				'Semester Management',
				'Course and College Management',
				'Enrollment and Student Management',
				'Analytics and Reporting',
				'System Administration'
			],
			selectedSemester: null
		};
	},
	methods: {
		changeTab(tab) {
			this.currentTab = tab;
		},
		toggleOffcanvas() {
			this.$refs.close.click();
		},
		handleSemesterChange(selectedSemester) {
			this.selectedSemester = selectedSemester;
		}
	}
};
</script>

<style scoped>
.semester-dashboard {
	width: 100%;
	display: flex;
	align-items: center;
	flex-direction: column;
}

.toggle {
	width: 40px;
	height: 40px;
	margin: 0 auto;
	padding: 8px;
	margin-top: -20px;
	padding-top: 16px;
	text-align: center;
	color: var(--white-color);
	border-radius: 50%;
	background: var(--primary-color);
}

.nav-tabs {
	font-size: 16px;
	color: var(--white-color);
	list-style-type: none;
	padding: 0;
	display: flex;
	margin-bottom: 20px;
}

.nav-tabs li {
	cursor: pointer;
	padding: 10px 5px;
	border: 1px solid #ccc;
	margin: 0 5px;
	transition: background-color 0.3s;
}

.nav-tabs li:hover,
.nav-tabs li.active {
	background-color: var(--secondary-color);
}

.offcanvas {
	z-index: 10000000000;
	height: fit-content;
	background: var(--primary-color);
}

.offcanvas-header {
	display: flex;
	justify-content: space-between;
	align-items: center;
	color: var(--white-color);
	background: var(--primary-color);
	border-bottom: 1px solid var(--secondary-color);
}


.offcanvas-header button {
	color: var(--white-color);
	font-size: 24px;
}

.nav-link {
	color: var(--white-color);
}

.nav-link:hover {
	color: var(--secondary-color);
}

.tab-content {
	width: 100%;
	padding: 8px 0;
}
</style>
