<template>
	<div class="testimonials">
		<div class="title mb-3">
			<h3>TESTIMONIALS</h3>
		</div>
		<div class="testimonials-container">
			<swiper class="swiper" :modules="modules" :space-between="20" :loop="true" :pagination="{ clickable: true }"
				:autoplay="{
				delay: 5000,
				disableOnIntersection: false,
				pauseOnMouseEnter: true
			}">
				<swiper-slide v-for="(testimonial, i) in testimonials" :key="i">
					<div class="author">
						<div class="img">
							<img :src="testimonial.authorImage" alt="">
							<i class="fas fa-quote-left"></i>
						</div>

						<h5>{{ testimonial.author }}</h5>
					</div>

					<p class="testimonial">{{ testimonial.testimonial }}</p>

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
.testimonials .testimonials-container {
	width: 500px;
	display: flex;
	align-items: stretch;
}

.testimonials .testimonials-container .swiper-slide {
	height: auto;
	min-height: 100%;
	background: var(--primary-color);
	color: var(--white-color);
	padding: 21px;
	display: flex;
	justify-content: flex-start;
	gap: 24px;
	flex-direction: column;
	box-shadow: 0 0 10px rgba(0, 0, 0, 0.01);
	border: none !important;
}

.testimonials .swiper img {
	width: 96px;
	height: 96px;
	border-radius: 50%;
	object-fit: cover;
}

.testimonials .swiper .author {
	position: relative;
	width: 100%;
	display: flex;
	justify-content: left;
	align-items: center;
	gap: 20px;
}

.testimonials .swiper .author .img {
	position: relative;
}

.testimonials .swiper .author .img i {
	position: absolute;
	bottom: -7px;
	right: -7px;
	font-size: 20px;
	padding: 8px;
	border-radius: 50%;
	color: var(--primary-color);
	background: var(--white-color);
}

.testimonials .swiper .testimonial {
	color: var(--white-color);
	font-size: 16px;
	text-align: left;
}

.testimonials .swiper h5 {
	font-style: italic;
	text-align: left;
}



.testimonials .swiper-pagination-bullet {
	width: 12px;
	height: 12px;
	margin-top: 24px;
	background-color: var(--primary-color);
}

.testimonials .swiper-pagination-bullet-active {
	background-color: var(--secondary-color);
}

.swiper-pagination-bullets,
.swiper-pagination-bullets.swiper-pagination-horizontal {
	margin-top: 16px;
	position: relative !important;
}
</style>
