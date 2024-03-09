<template>
	<div class="courseHome">
		<!-- <PostGenerator /> -->
		<OffCanvas :routers="routers" />
		<HomeContent />
	</div>
</template>

<script>
// import PostGenerator from '@/components/global/PostGenerator.vue';
import HomeContent from '@/components/courses/HomeContent.vue';
import OffCanvas from '@/components/global/OffCanvas.vue';

export default {
	title: "CourseHome",
	components: {
		// PostGenerator,
		HomeContent,
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
					path: `/courses/${this.$route.params.course_code}/attendance`,
				},
				{
					title: "Grades",
					path: `/courses/${this.$route.params.course_code}/grades`,
				},
				{
					title: "Quizzes",
					path: `/courses/${this.$route.params.course_code}/CourseQuizzes`,
				},
				{
					title: "Assigmnents",
					path: `/courses/${this.$route.params.course_code}/assigmnents`,
				},
				{
					title: "Schedule",
					path: `/courses/${this.$route.params.course_code}/schedule`,
				}
			]
		}
	}
}
</script>

<style scoped>
/* .courseHome {
	width: 100%;
	height: 100%;
	background: red;
	height: 100vh;
} */
</style>