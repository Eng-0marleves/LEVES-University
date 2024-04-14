<template>
	<div class="alumni-news">
		<h2 class="section-title">Alumni News</h2>

		<div class="news-item" v-for="(newsItem, index) in newsArticles" :key="index">
			<div class="news-header">
				<img :src="newsItem.image" alt="News image" class="news-image">
				<h2>{{ newsItem.title }}</h2>
			</div>
			<p>{{ newsItem.date }}</p>
			<p>{{ newsItem.summary }}</p>
			<a href="#" class="read-more">Read More</a>
		</div>
	</div>
</template>

<script>
export default {
	name: 'AlumniNews',
	data() {
		return {
			// Enhanced list of news articles with images
			newsArticles: [
				{
					title: "Alumni Reunion 2024",
					date: "2024-05-15",
					summary: "Join us for the annual Alumni Reunion event, a chance to reconnect with classmates and make new connections.",
					image: "https://www.em.muni.cz/cache-thumbs/Homecoming_title-790x395-1705896555.jpg"
				},
				{
					title: "Alumni Spotlight: Jane Doe",
					date: "2024-04-20",
					summary: "Discover the inspiring career journey of Jane Doe, from graduate to CEO of Tech Innovations.",
					image: "https://gradschool.psu.edu/sites/GradSchool/assets/Image/alumni-spotlight-series-square-shin.jpg"
				},
				{
					title: "New Alumni Mentorship Program",
					date: "2024-03-10",
					summary: "We're excited to launch a new mentorship program designed to support recent graduates in their career paths.",
					image: "https://www.evidencebasedmentoring.org/wp-content/uploads/2022/07/Screen-Shot-2022-07-11-at-10.55.58-PM-1024x676.png"
				}
			]
		};
	}
};
</script>

<style scoped>
.alumni-news {
	display: flex;
	flex-direction: column;
	gap: 20px;
	padding: 16px;

}

.section-title {
	text-align: center;
	margin-bottom: 20px;
}

.news-item {
	background-color: #f9f9f9;
	padding: 20px;
	border-radius: 8px;
	position: relative;
}

.news-header {
	display: flex;
	gap: 15px;
	align-items: center;
}

.news-image {
	width: 100px;
	height: 100px;
	object-fit: cover;
	border-radius: 50%;
}

.news-item h2 {
	margin: 0;
	font-size: 24px;
}

.news-item p {
	margin: 10px 0;
}

.read-more {
	display: inline-block;
	margin-top: 10px;
	color: #007bff;
	text-decoration: none;
}
</style>
