<template>
	<div class="course-faculty-management">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'Course Catalog'">
				<CourseCatalog />
			</div>
			<div v-if="currentTab === 'Faculty Management'">
				<FacultyManagement />
			</div>
			<div v-if="currentTab === 'Analytics'">
				<AnalyticsReporting />
			</div>
		</div>
	</div>
</template>

<script>
import CourseCatalog from '@/components/dashboard/semester/CourseCatalog.vue';
import FacultyManagement from '@/components/dashboard/semester/FacultyManagement.vue';
import AnalyticsReporting from '@/components/dashboard/semester/Analytics&Reporting.vue';

export default {
	name: 'CourseFacultyManagement',
	components: {
		CourseCatalog,
		FacultyManagement,
		AnalyticsReporting,
	},
	data() {
		return {
			currentTab: 'Course Catalog',
			tabs: ['Course Catalog', 'Faculty Management', 'Analytics']
		};
	},
	methods: {

	},
	mounted() {

	},
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
