<template>
	<div class="carousel carousel-dark slide" data-bs-ride="carousel">
		<swiper :spaceBetween="30" :centeredSlides="true" :autoplay="{
			delay: 5000,
			disableOnInteraction: false,
		}" :pagination="{
			clickable: true,
		}" :navigation="true" :modules="modules" @autoplayTimeLeft="onAutoplayTimeLeft" class="mySwiper">

			<swiper-slide v-for="(slide, i) in slides" :key="i">
				<img :src="slide.img" alt="" />
				<div class="overlay"></div>
				<div class="content">
					<h2>{{ slide.title }}</h2>
					<p>{{ slide.description }}</p>
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
	name: 'TopStories',
	data() {
		return {
			slides: [
				{
					title: "Groundbreaking Research in Renewable Energy",
					description: "Discover our latest advancements in renewable energy technologies aiming for a sustainable future.",
					img: "https://medicine.temple.edu/sites/medicine/files/files/hiv-labs.jpg"
				},
				{
					title: "Celebrating Student Success at Global Tech Competition",
					description: "Our students shine at the international tech competition, bringing home numerous awards and recognitions.",
					img: "https://www.its.ac.id/it/wp-content/uploads/sites/46/2021/07/andrew-1-scaled.jpg"
				},
				{
					title: "University Partners with Local Communities",
					description: "Learn about our new initiatives to engage with and support our local communities through education and volunteerism.",
					img: "https://business-school.exeter.ac.uk/v8media/facultysites/ese/businessschool/images/about/about_international0.jpg"
				},
				{
					title: "Sustainable Campus Initiative Launched",
					description: "Join us in our journey towards sustainability with the introduction of green practices across the campus.",
					img: "https://www.marhaba.qa/wp-content/uploads/2023/04/CMU-Q-EcoCampus-initiative-cover.jpg"
				},
				{
					title: "Annual Science Festival Coming Soon",
					description: "Don't miss out on a week filled with exciting workshops, lectures, and exhibitions at our Annual Science Festival.",
					img: "https://www.zewailcity.edu.eg/media-library/Cover%20Images/Science_Festival.jpg"
				}
			]
		};
	},
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
};
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