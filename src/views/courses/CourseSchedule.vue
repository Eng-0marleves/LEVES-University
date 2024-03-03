<template>
	<div class="course-schedule">
		<ScheduleTable name="lectures" />

	</div>
</template>

<script>
import ScheduleTable from '@/components/courses/ScheduleTable.vue';

export default {
	name: 'CourseSchedule',
	components: {
		ScheduleTable
	},
};
</script>

<style scoped></style>
