<template>
	<div class="course-schedule">
		<ScheduleTable name="lectures" />
	</div>
	<CourseOffCanvas />
</template>

<script>
import ScheduleTable from '@/components/courses/ScheduleTable.vue';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';

export default {
	name: 'CourseSchedule',
	components: {
		ScheduleTable,
		CourseOffCanvas
	},
};
</script>

<style scoped>
.course-schedule {
	padding: 16px;
}
</style>
