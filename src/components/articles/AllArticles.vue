<template>
	<div class="section-title">
		<h1>AllArticles</h1>
		<div class="line"></div>
	</div>

	<div class="search">
		<div class="search-bar">
			<input type="text" placeholder="Search For Artical" name="srach" id="srach">
			<label for="srach"><i class="fa-solid fa-magnifying-glass"></i></label>
		</div>

		<div class="dropdown">
			<button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
				<i class="fa-solid fa-filter"></i>
			</button>
			<ul class="dropdown-menu">
				<li>
					<button class="dropdown-item">
						<input type="checkbox" name="Newst" id="Newst"><label for="Newst">Newst</label>
					</button>
				</li>
				<li>
					<button class="dropdown-item">
						<input type="checkbox" name="Popular" id="Popular">
						<label for="Popular">Popular</label>
					</button>
				</li>
				<li>
					<button class="dropdown-item">
						<input type="checkbox" name="Digital" id="Digital">
						<label for="Digital">Digital</label>
					</button>
				</li>
				<li>
					<button class="dropdown-item">
						<input type="checkbox" name="Business" id="Business">
						<label for="Business">Business</label>
					</button>
				</li>
			</ul>
		</div>
	</div>

	<div class="all-articles">
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
	name: 'AllArticles',
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
.all-articles {
	display: flex;
	justify-content: space-around;
	flex-wrap: wrap;
	margin: 24px 0;
	gap: 24px;
}

.all-articles .card .card-body {
	display: flex;
	flex-direction: column;
	gap: 16px;
}

.all-articles .card .publish-info {
	color: var(--secondary-color);
	display: flex;
	flex-direction: column;
}

.all-articles .card img {
	height: 250px;
	object-fit: cover;
}

.search {
	display: flex;
	align-items: center;
	gap: 16px;
}

.search .search-bar {
	width: 100%;
	display: flex;
	align-items: center;
	margin: 16px 0;
}

.search .search-bar input {
	width: 100%;
	border-top-left-radius: 16px;
	border-bottom-left-radius: 16px;
	padding: 8px 16px;
	background: var(--white-color);
}

.search .search-bar label {
	color: #fff;
	background: var(--primary-color);
	border-top-right-radius: 16px;
	border-bottom-right-radius: 16px;
	padding: 8px;
	font-size: 16px;
}
</style>
