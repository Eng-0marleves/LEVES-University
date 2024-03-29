<template>
	<div class="carousel carousel-dark slide" data-bs-ride="carousel">
		<swiper :spaceBetween="30" :centeredSlides="true" :autoplay="{
			delay: 5000,
			disableOnInteraction: false,
		}" :pagination="{
			clickable: true,
		}" :navigation="true" :modules="modules" @autoplayTimeLeft="onAutoplayTimeLeft" class="mySwiper">

			<swiper-slide>
				<img src="https://image.cnbcfm.com/api/v1/image/106918576-1627532474886-gettyimages-871203832-pi-1589476.jpeg?v=1627532520&w=1600&h=900"
					alt="..." />
				<div class="overlay"></div>
				<div class="content">
					<h2>Welcome to Leves University</h2>
					<p>Access all Courses</p>
					<button class="btn rounded" @click="console.log('test')">All Courses</button>
				</div>
			</swiper-slide>
			<swiper-slide>
				<img src="https://agcdn-1d97e.kxcdn.com/wp-content/uploads/2015/12/13-must-attend-business-student-events-in-2016-1024x438.jpg"
					alt="..." />
				<div class="overlay"></div>
				<div class="content">
					<h2>Welcome to Leves University</h2>
					<p>Show all Events</p>
					<button class="btn rounded" @click="console.log('test')">All Events</button>
				</div>
			</swiper-slide>
			<swiper-slide>
				<img src="https://www.questrade.com/images/learninglibraries/default-album/lessons-content/investing-foundations/data-analysis/technical-analysis/banner-man-checking-charts-on-computer.png?sfvrsn=c24f74bf_4"
					alt="..." />
				<div class="overlay"></div>
				<div class="content">
					<h2>Welcome to Leves University</h2>
					<p>Access your info</p>
					<button class="btn rounded" @click="console.log('test')">Dashboard</button>
				</div>
			</swiper-slide>
			<swiper-slide>
				<img src="https://blog.efmdglobal.org/wp-content/uploads/2022/07/news-gf4e98bdee_1920-1024x768.jpg"
					alt="..." />
				<div class="overlay"></div>
				<div class="content">
					<h2>Welcome to Leves University</h2>
					<p>Show all University News</p>
					<button class="btn rounded" @click="console.log('test')">All News</button>
				</div>
			</swiper-slide>

			<template #container-end>
				<div class="autoplay-progress">
					<svg viewBox="0 0 48 48" ref="progressCircle">
						<circle cx="24" cy="24" r="20"></circle>
					</svg>
					<span ref="progressContent"></span>
				</div>
			</template>
		</swiper>


	</div>
</template>

<script>
import { ref } from 'vue';
// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from 'swiper/vue';
// Import Swiper styles
import 'swiper/css';

import 'swiper/css/pagination';
import 'swiper/css/navigation';

import '@/assets/css/swiper.css';

// import required modules
import { Autoplay, Pagination, Navigation } from 'swiper/modules';

export default {
	name: "HomeCarousel",
	components: {
		Swiper,
		SwiperSlide,
	},
	setup() {
		const progressCircle = ref(null);
		const progressContent = ref(null);
		const onAutoplayTimeLeft = (s, time, progress) => {
			progressCircle.value.style.setProperty('--progress', 1 - progress);
			progressContent.value.textContent = `${Math.ceil(time / 1000)}s`;
		};
		return {
			onAutoplayTimeLeft,
			progressCircle,
			progressContent,
			modules: [Autoplay, Pagination, Navigation],
		};
	},
}
</script>

<style scoped>
.carousel {
	width: 100%;
	height: calc(100vh - var(--header-height));
}

.content {
	display: flex;
	justify-content: center;
	align-items: center;
	flex-direction: column;
	gap: 16px;
}

.btn.rounded {
	border-radius: 24px !important;
	border: 2px solid var(--white-color);
	color: var(--white-color);
	font-size: 1.2rem;
	padding: 8px 32px !important;
}

.btn.rounded:hover {
	border-color: var(--secondary-color);
	background: var(--secondary-color);
}

.swiper-slide {
	position: relative;
}

.swiper-slide img {
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
}

.swiper-slide .content {
	color: var(--white-color);
	z-index: 1900;
}
</style>
