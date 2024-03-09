<template>
	<section class="course">
		<OffCanvas :routers="routers" />
		<!-- <h1>{{ $route.params.course_code }}</h1> -->
		<!-- <PostGenerator /> -->
		<!-- <NavTabs /> -->
		wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
		<!-- <router-view></router-view> -->
	</section>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';
// import PostGenerator from '@/components/global/PostGenerator.vue';
// import NavTabs from '@/components/global/NavTabs.vue';

export default {
	name: "CourseView",
	components: {
		OffCanvas,
		// PostGenerator,
		// NavTabs
	},
	data() {
		return {
			routers: [
				{ route: `/courses/${this.$route.params.course_code}/`, title: "Home" },
				{ route: `/courses/${this.$route.params.course_code}/course_attendance`, title: "Attendance" },
				{ route: `/courses/${this.$route.params.course_code}/course_material`, title: "Material" },
				{ route: `/courses/${this.$route.params.course_code}/course_grades`, title: "Grades" },
				{ route: `/courses/${this.$route.params.course_code}/CourseQuizzes`, title: "CourseQuizzes" },
				{ route: `/courses/${this.$route.params.course_code}/course_assignment`, title: "Assignments" },
				{ route: `/courses/${this.$route.params.course_code}/course_schedule`, title: "Schedule" },
				{ route: `/courses/${this.$route.params.course_code}/course_analysis`, title: "Analysis" }
			]
		}
	}
}
</script>

<style scoped>
.course {
	padding-top: 0px;
}

.course .routes .container {
	width: 100%;
	background: var(--primary-color);
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: wrap;
	margin-bottom: 24px;
}

.course .routes .container .route {
	color: #fff;
	font-size: 24px;
	padding: 16px 24px;
	width: fit-content;
}

.course .routes .container .route.active {
	background: var(--secondary-color);
}

.mini .route {
	font-size: 18px;
	/* Adjust font size for mini mode */
	padding: 12px 18px;
	/* Adjust padding for mini mode */
}


.course .routes.mini .container {
	width: 100%;
}
</style>
