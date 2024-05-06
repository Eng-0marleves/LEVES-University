<template>
	<div class="semester-dashboard">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'Semester Information'">
				<SemesterManagement v-model:isSemesterHasEnded="isSemesterHasEnded" />
			</div>
			<div v-if="currentTab === 'Semester Courses'">
				<CourseCatalog />
			</div>
			<div v-if="currentTab === 'Courses Schedule'">
				<CoursesSchedule />
			</div>
			<div v-if="currentTab === 'Courses Enrollments'">
				<CoursesEnrollments />
			</div>
		</div>

	</div>
</template>

<script>
import SemesterManagement from './SemesterManagement.vue';
import CourseCatalog from '@/components/dashboard/semester/CourseCatalog.vue';
import CoursesSchedule from './CoursesSchedule.vue';
import CoursesEnrollments from './CoursesEnrollments.vue';
import axios from 'axios';

export default {
	name: 'SemesterDashboard',
	components: {
		SemesterManagement,
		CourseCatalog,
		CoursesSchedule,
		CoursesEnrollments
	},
	data() {
		return {
			currentTab: 'Semester Information',
			tabs: ['Semester Information', 'Semester Courses', 'Courses Schedule', 'Courses Enrollments'],
			currentSemester: {},
			isSemesterHasEnded: false
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
		},
		async getCurrentSemester() {
			try {
				const res = await axios.get('https://localhost:44303/CurrentSemester');
				this.currentSemester = res.data;
				console.log(this.currentSemester.endDate > new Date())
				this.isSemesterHasEnded = new Date(this.semester.endDate) > new Date();
				console.log(this.currentSemester)
			} catch (error) {
				console.log(error);
			}
		}
	}
};
</script>

<style scoped>
/* .semester-dashboard {
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
} */


/* ------------------------------------------------------------------ */

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
