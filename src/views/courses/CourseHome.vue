<template>
	<div class="courseHome">
		<PostGenerator />

		<HomeContent />
	</div>
</template>

<script>
import PostGenerator from '@/components/global/PostGenerator.vue';
import HomeContent from '@/components/courses/HomeContent.vue';

export default {
	name: "CourseHome",
	components: {
		PostGenerator,
		HomeContent
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