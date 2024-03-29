<template>
	<div class="news-page">
		<header class="news-header">
			<h1>University News</h1>
		</header>
		<main class="news-main">
			<section class="featured-news">
				<h2>Featured News</h2>
				<div class="news-article" v-for="article in featuredNews" :key="article.id">
					<h3>{{ article.title }}</h3>
					<img :src="article.image" :alt="article.title">
					<p>{{ article.summary }}</p>
					<router-link :to="`/news/${article.id}`">Read More</router-link>
				</div>
			</section>
			<aside class="news-sidebar">
				<h2>Recent News</h2>
				<ul>
					<li v-for="article in recentNews" :key="article.id">
						<router-link :to="`/news/${article.id}`">{{ article.title }}</router-link>
					</li>
				</ul>
			</aside>
		</main>
		<section class="upcoming-events">
			<h2>Upcoming Events</h2>
			<div class="event" v-for="event in upcomingEvents" :key="event.id">
				<h3>{{ event.name }}</h3>
				<p>{{ event.date }}</p>
				<p>{{ event.location }}</p>
			</div>
		</section>
		<footer class="news-footer">
			<p>&copy; {{ new Date().getFullYear() }} University Name. All rights reserved.</p>
		</footer>
	</div>
</template>

<script>
export default {
	name: 'NewsPage',
	data() {
		return {
			featuredNews: [], // Placeholder for featured news articles
			recentNews: [], // Placeholder for recent news articles
			upcomingEvents: [], // Placeholder for upcoming events
		};
	},
	methods: {
		// Placeholder methods to fetch news articles and events from an API or data source
		fetchFeaturedNews() { },
		fetchRecentNews() { },
		fetchUpcomingEvents() { },
	},
	mounted() {
		this.fetchFeaturedNews();
		this.fetchRecentNews();
		this.fetchUpcomingEvents();
	},
};
</script>

<style scoped>
.news-page {
	display: grid;
	grid-template-areas:
		"header header"
		"main sidebar"
		"events events"
		"footer footer";
	grid-template-columns: 2fr 1fr;
	gap: 20px;
}

.news-header,
.news-main,
.upcoming-events,
.news-footer {
	padding: 20px;
}

.featured-news .news-article,
.upcoming-events .event {
	margin-bottom: 20px;
}

.news-sidebar {
	grid-area: sidebar;
}

.news-article img {
	width: 100%;
	height: auto;
}

.news-footer {
	grid-area: footer;
	text-align: center;
}
</style>
