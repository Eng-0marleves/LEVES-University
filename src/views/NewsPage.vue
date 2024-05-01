<template>
	<div class="news">

		<TopStories />

		<PostsSection />

		<!-- <AnnouncementsSection />

		<AcademicAchievements />

		<AlumniNews />

		<InnovationTechnology />

		<SportsSection />

		<MultiMedia /> -->

	</div>
</template>

<script>
import TopStories from '@/components/news/TopStories.vue';
import PostsSection from '@/components/news/PostsSection.vue';
// import AnnouncementsSection from '@/components/news/AnnouncementsSection.vue';
// import AcademicAchievements from '@/components/news/AcademicAchievements.vue';
// import AlumniNews from '@/components/news/AlumniNews.vue';
// import InnovationTechnology from '@/components/news/Innovation&Technology.vue';
// import SportsSection from '@/components/news/SportsSection.vue';
// import MultiMedia from '@/components/news/MultiMedia.vue';

export default {
	name: 'NewsPage',
	data() {
		return {
			// Your data goes here
		};
	},
	methods: {
		// Your methods go here
	},
	components: {
		PostsSection,
		TopStories,
		// AnnouncementsSection,
		// AcademicAchievements,
		// AlumniNews,
		// InnovationTechnology,
		// SportsSection,
		// MultiMedia
	},
};
</script>

<style scoped>
.news {
	display: flex;
	flex-direction: column;
	gap: 32px;
}
</style>