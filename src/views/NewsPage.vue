<template>
	<div class="news">
		<TopStories />

		<AnnouncementsSection />

		<AcademicAchievements />

		<PostsSection />

		<AlumniNews />

	</div>
</template>

<script>
import TopStories from '@/components/news/TopStories.vue';
import AnnouncementsSection from '@/components/news/AnnouncementsSection.vue';
import AcademicAchievements from '@/components/news/AcademicAchievements.vue';
import PostsSection from '@/components/news/PostsSection.vue';
import AlumniNews from '@/components/news/AlumniNews.vue';

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
		TopStories,
		AnnouncementsSection,
		AcademicAchievements,
		PostsSection,
		AlumniNews
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