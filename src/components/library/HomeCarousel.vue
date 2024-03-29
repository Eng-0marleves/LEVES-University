<template>
	<div class="carousel carousel-dark slide" data-bs-ride="carousel">
		<swiper :spaceBetween="30" :centeredSlides="true" :autoplay="{
			delay: 5000,
			disableOnInteraction: false,
		}" :pagination="{
			clickable: true,
		}" :navigation="true" :modules="modules" @autoplayTimeLeft="onAutoplayTimeLeft" class="mySwiper">

			<!-- Welcome Slide -->
			<swiper-slide>
				<img src="https://www.bodleian.ox.ac.uk/sites/default/files/styles/mt_image_6_4/public/bodreader/images/media/student-solo.jpg?itok=fY_TSs3-"
					alt="Welcome to the University Library" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Welcome to the University Library</h2>
					<p>Discover a world of academic resources and support services.</p>
				</div>
			</swiper-slide>

			<!-- Research Resources Slide -->
			<swiper-slide>
				<img src="https://www.smu.edu/-/media/Site/Libraries/_homepage/research-guides-box-600x400.jpg?h=400&iar=0&w=600&hash=70B9F40E6364F7AEF38D43E95D5FE0DE"
					alt="Research Resources" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Explore Research Resources</h2>
					<p>Access thousands of journals, databases, and academic papers.</p>
				</div>
			</swiper-slide>

			<!-- Study Spaces Slide -->
			<swiper-slide>
				<img src="https://www.wework.com/ideas/wp-content/uploads/sites/4/2021/08/20191111_WeWork_400-Concar-Drive-San-Mateo_004_v1-scaled.jpg"
					alt="Study Spaces" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Find Your Perfect Study Spot</h2>
					<p>From quiet zones to collaborative spaces, find the best place to study.</p>
				</div>
			</swiper-slide>

			<!-- Digital Library Services Slide -->
			<swiper-slide>
				<img src="https://www.calstate.edu/csu-system/administration/sdls/PublishingImages/Pages/default/sys-digital-library-services-hero.jpg"
					alt="Digital Library Services" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Digital Library Services</h2>
					<p>Explore e-books, online journals, and more from anywhere, anytime.</p>
				</div>
			</swiper-slide>

			<!-- Library Workshops and Events Slide -->
			<swiper-slide>
				<img src="https://www.score.org/sites/default/files/styles/responsive_16_9_500w/public/2022-10/smallWorkshop_481872003.png?h=708741af&itok=o02x_R_a"
					alt="Library Workshops and Events" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Join Workshops and Events</h2>
					<p>Enhance your skills and knowledge through our library events.</p>
				</div>
			</swiper-slide>

			<!-- Technology and Equipment Slide -->
			<swiper-slide>
				<img src="https://blogs.library.duke.edu/bitstreams/files/2018/09/IMG_20180921_094600.jpg"
					alt="Technology and Equipment" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Access Technology and Equipment</h2>
					<p>Utilize our computers, printers, scanners, and more for your academic needs.</p>
				</div>
			</swiper-slide>

			<!-- Special Collections and Archives Slide -->
			<swiper-slide>
				<img src="https://library.wustl.edu/wp-content/uploads/2021/01/SATO_190801_wustl_libraries_0432.jpg"
					alt="Special Collections and Archives" />
				<div class="overlay"></div>
				<div class="content">
					<h2>Special Collections and Archives</h2>
					<p>Discover rare books and historical documents in our special collections.</p>
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
