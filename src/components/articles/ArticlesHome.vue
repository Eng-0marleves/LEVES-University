<template>
	<section class="articles-home">
		<TopArticles />
		<UserArticles />
		<AllArticles />
	</section>
</template>

<script>
import TopArticles from '@/components/articles/TopArticles.vue';
import UserArticles from './UserArticles.vue';
import AllArticles from './AllArticles.vue';

export default {
	name: 'ArticlesHome',
	components: {
		TopArticles,
		UserArticles,
		AllArticles
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
/* Your CSS styles go here */
</style>
