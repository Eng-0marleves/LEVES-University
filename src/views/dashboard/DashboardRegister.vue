<template>
	<div class="dashboard-register">
		<StudyPlan />
		<CoursesRegistration />
	</div>
</template>

<script>
import StudyPlan from '@/components/dashboard/register/StudyPlan.vue';
import CoursesRegistration from '@/components/dashboard/register/CoursesRegistration.vue';

export default {
	name: 'DashboardRegister',
	data() {
		return {
		};
	},
	components: {
		StudyPlan,
		CoursesRegistration
	},
	methods: {
	},
};
</script>

<style>
.dashboard-register {
	padding: 16px;
}

.ag-header-row {
	background: var(--primary-color);
}

.ag-header-cell {
	color: var(--white-color);
}

.ag-header-cell-label {
	display: flex;
	justify-content: center;
	align-items: center;
}

.ag-theme-quartz {
	width: 100%;
	height: 100%;
	overflow-y: auto !important;
	margin-top: 24px;
	--ag-borders: none;
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;
	--ag-borders: none;

	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
}

.ag-center-cols-container {
	overflow: hidden;
}

.ag-root-wrapper {
	border: 2px solid #DCDCDC;
	border-radius: 5px;
}

.ag-ltr .ag-cell {
	text-align: center;
	padding: 0;
}

.ag-ltr .ag-cell span {
	width: 100%;
	height: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
	position: relative;
}

.is_3d {
	width: 25px;
	height: 25px;
}

.ag-ltr .ag-cell {
	border-right: 2px solid #DCDCDC;
}

.ag-header-cell {
	border-bottom-color: #DCDCDC;
}

.ag-header-cell:not(:last-child) {
	border-right: 2px solid #DCDCDC;
}

.ag-body-vertical-scroll-viewport {
	width: 24px;
}

.ag-header-cell-filter input {
	width: 80%;
	/* Adjust the width as needed */
	margin: 5px;
	/* Add margin for spacing */
	padding: 5px;
	/* Add padding for better appearance */
	border-radius: 5px;
	/* Add border-radius for rounded corners */
	border: 1px solid #ccc;
	/* Add border for clarity */
}
</style>