<template>
	<div class="innovation-technology">
		<div class="latest-innovations">
			<h2>Latest Innovations</h2>
			<div class="innovations-container">
				<div class="innovation-card" v-for="(innovation, index) in innovations" :key="index">
					<img :src="innovation.img" alt="Icon" class="innovation-icon">
					<div class="innovation-content">
						<h3>{{ innovation.title }}</h3>
						<p>{{ innovation.description }}</p>
						<a :href="innovation.link" target="_blank" class="btn normal mt-2">Read More</a>
					</div>
				</div>
			</div>
		</div>

		<div class="tech-collaborations">
			<h2>Collaborations with Tech Companies</h2>
			<div class="collaborations-container">
				<div class="collaboration-card" v-for="(collaboration, index) in collaborations" :key="index">
					<img :src="collaboration.logo" alt="Company logo" class="company-logo">
					<div class="collaboration-content">
						<h3>{{ collaboration.name }}</h3>
						<p>{{ collaboration.description }}</p>
						<a :href="collaboration.link" target="_blank" class="btn normal mt-2">Learn More</a>
					</div>
				</div>
			</div>
		</div>

		<div class="student-projects">
			<h2>Student Projects</h2>
			<div class="projects-carousel">
				<swiper :spaceBetween="30" :centeredSlides="true" :autoplay="{
					delay: 5000,
					disableOnInteraction: false,
				}" :pagination="{
					clickable: true,
				}" :navigation="true" :modules="modules" @autoplayTimeLeft="onAutoplayTimeLeft" class="carousel">

					<swiper-slide v-for="(project, index) in studentProjects" :key="index">
						<img :src="project.img" alt="Project image" />
						<div class="overlay"></div>
						<div class="content">
							<h3>{{ project.title }}</h3>
							<p>{{ project.summary }}</p>
							<a :href="project.link" target="_blank" class="btn rounded">Project Details</a>
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
		</div>

	</div>
</template>

<script>
import { ref } from 'vue';

import { Swiper, SwiperSlide } from 'swiper/vue';
// Import Swiper styles
import 'swiper/css';

import 'swiper/css/pagination';
import 'swiper/css/navigation';

import '@/assets/css/swiper.css';

// import required modules
import { Autoplay, Pagination, Navigation } from 'swiper/modules';

export default {
	name: 'InnovationTechnology',
	data() {
		return {
			innovations: [
				{ img: "https://www.computeam.co.uk/image/education-virtual-reality.webp?size=600&constrain=null&quality=70", title: 'Virtual Reality Classroom', description: 'An immersive learning experience for remote education.', link: '#' },
				{ img: "https://www.sciencefriday.com/wp-content/uploads/2023/12/shutterstock_2283147071.jpg", title: 'AI Tutoring System', description: 'A personalized tutoring system powered by AI.', link: '#' }
			],
			collaborations: [
				{ logo: "https://media.licdn.com/dms/image/C4D0BAQG3w09vtwDxCg/company-logo_200_200/0/1630453809094?e=2147483647&v=beta&t=qjcTGJ4QiY8sGZSBQqjSIENjg5UkQeskV2IGYpy868I", name: 'Tech Giant Co.', description: 'A partnership to develop AI-driven educational tools.', link: '#' },
				{ logo: "https://www.eiturbanmobility.eu/wp-content/uploads/2021/03/xyz.jpg", name: 'Startup XYZ', description: 'Collaboration on sustainable energy solutions for campus.', link: '#' }
			],
			studentProjects: [
				{
					title: "Smart Campus App",
					summary: "An app for navigation and resource management on campus.",
					img: "https://www.unical.it/media/medias/2021/web396.webp",
					link: "#"
				},
				{
					title: "Eco-Friendly Packaging",
					summary: "A student initiative to develop biodegradable packaging.",
					img: "https://meyers.com/wp-content/uploads/2023/04/shutterstock_2152470619.jpg",
					link: "#"
				},
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
.innovation-technology h2 {
	margin: 20px 0;
	text-align: center;
}

.innovations-container {
	display: flex;
	flex-wrap: wrap;
	justify-content: space-around;
	gap: 20px;
}

.innovation-card {
	width: 280px;
	background-color: #f9f9f9;
	border: 1px solid #e1e1e1;
	border-radius: 10px;
	overflow: hidden;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
	transition: transform 0.3s ease;
}

.innovation-card:hover {
	transform: translateY(-5px);
}

.innovation-icon {
	width: 100%;
	height: 180px;
	object-fit: cover;
}

.innovation-content {
	padding: 15px;
}

.innovation-content h3 {
	margin-top: 0;
	font-size: 18px;
}

.innovation-content p {
	font-size: 14px;
}

.collaborations-container {
	display: flex;
	flex-wrap: wrap;
	justify-content: space-around;
	gap: 20px;
}

.collaboration-card {
	width: 350px;
	display: flex;
	gap: 20px;
	align-items: center;
	padding: 20px;
	background-color: #f9f9f9;
	border-radius: 10px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.company-logo {
	width: 80px;
	height: 80px;
	object-fit: contain;
	/* Keeps the company logo aspect ratio */
}

.collaboration-content h3,
.collaboration-content p {
	margin: 0;
}

.projects-carousel {
	position: relative;
	width: 100%;
	height: auto;
	/* Adjust based on your content */
}

.carousel {
	width: 100%;
	height: 400px;
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
