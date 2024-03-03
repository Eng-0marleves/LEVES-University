<template>
	<div class="section-title">
		<h1>UserArticles</h1>
		<div class="line"></div>
	</div>
	<div class="user-articles">
		<div class="card" style="width: 18rem;" v-for="(article, i) in articles" :key="i">
			<img :src="article.cover" class="card-img-top" alt="...">
			<div class="card-body">
				<h5 class="card-title">{{ article.name }}</h5>
				<p class="card-text">{{ article.intro }}</p>
				<div class="publish-info">
					<small>{{ article.publisher }}</small>
					<small>{{ article.publisheDate }}</small>
				</div>
				<button class="btn btn-success"><router-link class="text-white" :to="`/articles/${i}`">Read
						Article</router-link></button>
			</div>
		</div>
	</div>
</template>

<script>
import { ref } from 'vue';

export default {
	name: 'UserArticles',
	data() {
		return {
			articles: ref([
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
				{
					cover: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
					name: "Book Name",
					publisher: "Peter Drucke",
					publisheDate: "2021-10-10",
					intro: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
				},
			]),
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
	}
}
</script>

<style scoped>
.user-articles {
	display: flex;
	justify-content: space-around;
	flex-wrap: wrap;
	margin: 24px 0;
	gap: 24px;
}

.user-articles .card .card-body {
	display: flex;
	flex-direction: column;
	gap: 16px;
}

.user-articles .card .publish-info {
	color: var(--secondary-color);
	display: flex;
	flex-direction: column;
}

.user-articles .card img {
	height: 250px;
	object-fit: cover;
}
</style>
