<template>
	<div class="course-attendance">
		<div class="controllers">
			<QrGenerator />
			<QrReader />
		</div>
		<AttendanceTable />
	</div>

	<CourseOffCanvas />
</template>

<script>
import AttendanceTable from '@/components/courses/attendance/AttendanceTable.vue';
import QrGenerator from '@/components/courses/attendance/QrGenerator.vue';
import QrReader from '@/components/courses/attendance/QrReader.vue';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';
export default {
	name: 'CourseAttendance',
	components: {
		AttendanceTable,
		QrGenerator,
		QrReader,
		CourseOffCanvas
	},
	data() {
		return {
			// Your data properties go here
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
.course-attendance {
	padding: 8px;
}

.controllers {
	display: flex;
	gap: 16px;
	align-items: center;
}
</style>
