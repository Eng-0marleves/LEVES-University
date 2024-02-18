<template>
	<div class="testimonials">
		<div class="testimonials-container">
			<swiper class="swiper" :modules="modules" :space-between="20" :loop="true" :pagination="{ clickable: true }"
				:autoplay="{
					delay: 5000,
					disableOnIntersection: false,
					pauseOnMouseEnter: true
				}">
				<swiper-slide v-for="(testimonial, i) in testimonials" :key="i">
					<img :src="testimonial.authorImage" alt="">

					<p class="testimonial">{{ testimonial.testimonial }}</p>

					<i class="fas fa-quote-left"></i>

					<h2>{{ testimonial.author }}</h2>
				</swiper-slide>
			</swiper>
		</div>
	</div>
</template>

<script>
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Autoplay, Pagination } from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/pagination';
import { ref } from 'vue';

export default {
	name: "TestimonialsPart",

	components: {
		Swiper,
		SwiperSlide
	},

	setup() {
		const testimonials = ref([
			{
				author: "Michael J. Gelb",
				authorImage: "https://www.eomega.org/sites/default/files/person/gelb_michael_11_web_2.jpg",
				testimonial: "Research shows that you begin learning in the womb and go right on learning until the moment you pass on. Your brain has a capacity for learning that is virtually limitless, which makes every human a potential genius.",
			},
			{
				author: "Earl Nightingale",
				authorImage: "https://www.newtraderu.com/wp-content/uploads/BDA82F3B-7F45-4DAA-A9EC-C09284E4397E.jpeg",
				testimonial: "One hour per day of study in your chosen field is all it takes. One hour per day of study will put you at the top of your field within three years. Within five years you'll be a national authority. In seven years, you can be one of the best people in the world at what you do.",
			},
			{
				author: "Peter Drucke",
				authorImage: "https://media.licdn.com/dms/image/C5112AQGE6-IuP0QOzg/article-cover_image-shrink_600_2000/0/1520173640454?e=2147483647&v=beta&t=d_vQW3Wp2bxh2VJEntR7fkCWCmBFxnoCyezUVjAHCMw",
				testimonial: "We now accept the fact that learning is a lifelong process of keeping abreast of change. And the most pressing task is to teach people how to learn.",
			},
		]);


		return {
			modules: [
				Pagination,
				Autoplay
			],

			testimonials
		}
	}
}
</script>


<style>
.testimonials {
	width: 100%;
	display: flex;
	justify-content: center;
	margin: 0 auto;
	min-width: 700px;
	max-width: 900px;
	padding-bottom: 24px;
}

.testimonials .testimonials-container {
	display: flex;
	justify-content: center;
	width: 100%;
}

.testimonials .testimonials-container .swiper-slide {
	width: 100%;
	min-height: fit-content;
	padding: 16px;
	display: flex;
	justify-content: space-around;
	align-items: center;
	gap: 24px;
	flex-direction: column;
	box-shadow: 0 0 10px rgba(0, 0, 0, 0.01);
	border: none !important;
}

.testimonials .swiper img {
	width: 170px;
	height: 170px;
	border-radius: 50%;
	object-fit: cover;
}

.testimonials .swiper .testimonial {
	color: var(--primary-color);
	font-size: 24px;
	text-align: center;
}

.testimonials .swiper i {
	font-size: 64px;
	color: var(--secondary-color);
}

.testimonials .swiper h2 {
	font-style: italic;
	width: 100%;
	text-align: left;
}

.testimonials .swiper-pagination-bullet {
	width: 16px;
	height: 16px;
	background-color: var(--primary-color);
}

.testimonials .swiper-pagination-bullet-active {
	background-color: var(--secondary-color);
}
</style>
