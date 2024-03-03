<template>
	<div class="top-articles">
		<div class="section-title">
			<h1>TopArticles</h1>
			<div class="line"></div>
		</div>
		<swiper class="swiper" :modules="modules" :space-between="20" :loop="true" :pagination="{ clickable: true }"
			:autoplay="{
				delay: 5000,
				disableOnIntersection: false,
				pauseOnMouseEnter: true
			}">

			<swiper-slide class="artical" v-for="(article, i) in articles" :key="i">
				<div class="content">
					<img class="col-4" :src="article.cover" alt="">

					<div class="info col-8">
						<h1> {{ article.name }} </h1>
						<h5 class="intro"> {{ article.intro }} </h5>
						<p> {{ article.publisher }} </p>
						<p> {{ article.publisheDate }} </p>
						<button class="btn btn-success"><router-link class="text-white" :to="`/articles/${i}`">Read
								Article</router-link></button>
					</div>
				</div>
			</swiper-slide>
		</swiper>
	</div>
</template>

<script>
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Autoplay, Pagination } from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/pagination';
import { ref } from 'vue';

export default {
	name: 'TopArticles',
	components: {
		Swiper,
		SwiperSlide
	},
	setup() {
		const articles = ref([
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
		]);


		return {
			modules: [
				Pagination,
				Autoplay
			],

			articles
		}
	}
};
</script>

<style scoped>
.artical {
	height: 400px;
}

.artical .content {
	height: 300px;
	display: flex;
	margin: 24px 0;
}

.artical .content img {
	height: 100%;
	object-fit: cover;
	margin-right: 24px;
}

.artical .content .info {
	display: flex;
	flex-direction: column;
	gap: 24px;
}

.btn {
	width: fit-content;
}
</style>
