<template>
	<div class="home-off-canvas">
		<OffCanvas :routers="routers" />
	</div>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';

export default {
	name: 'CourseOffCanvas',
	components: {
		OffCanvas
	},
	data() {
		return {
			routers: [
				{
					title: "Home",
					path: `/courses/${this.$route.params.course_code}`,
				},
				{
					title: "Materials",
					path: `/courses/${this.$route.params.course_code}/CourseMaterials`,
				},
				{
					title: "Attendance",
					path: `/courses/${this.$route.params.course_code}/CourseAttendance`,
				},
				{
					title: "Grades",
					path: `/courses/${this.$route.params.course_code}/CourseGrades`,
				},
				{
					title: "Quizzes",
					path: `/courses/${this.$route.params.course_code}/CourseQuizzes`,
				},
				{
					title: "Assigmnents",
					path: `/courses/${this.$route.params.course_code}/CourseAssigments`,
				},
				{
					title: "Schedule",
					path: `/courses/${this.$route.params.course_code}/CourseSchedule`,
				}
			]
		};
	},
};
</script>