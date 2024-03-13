<template>
	<CourseOffCanvas />
	<div class="courseHome d-flex flex-column gap-5">
		<!-- <PostGenerator /> -->
		<HomeContent />
		<CoursePosts />
	</div>
</template>

<script>
// import PostGenerator from '@/components/global/PostGenerator.vue';
import HomeContent from '@/components/courses/HomeContent.vue';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';
import CoursePosts from '@/components/courses/CoursePosts.vue';

export default {
	title: "CourseHome",
	components: {
		// PostGenerator,
		HomeContent,
		CourseOffCanvas,
		CoursePosts
	}
}
</script>

<style scoped>
.courseHome {
	padding: 16px;
}
</style>