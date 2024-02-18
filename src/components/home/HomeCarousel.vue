<template>
	<div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">
		<div class="carousel-indicators">
			<button v-for="(item, index) in carouselItems" :key="index" type="button"
				:data-bs-target="'#carouselExampleDark'" :data-bs-slide-to="index" :class="{ 'active': index === 0 }"
				aria-current="true" :aria-label="'Slide ' + (index + 1)"></button>
		</div>
		<div class="carousel-inner">
			<div v-for="(item, index) in carouselItems" :key="index" :class="['carousel-item', { 'active': index === 0 }]">
				<div class="overlay"></div> <!-- Overlay -->
				<img :src="item.image" class="d-block w-100" :alt="'Slide ' + (index + 1)">
				<div class="carousel-caption d-none d-md-block">
					<h5>{{ item.title }}</h5>
					<p>{{ item.content }}</p>
				</div>
			</div>
		</div>
		<button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
			<span class="controller" aria-hidden="true"><i class="fa-solid fa-chevron-left"></i></span>
			<span class="visually-hidden">Previous</span>
		</button>
		<button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
			<span class="controller" aria-hidden="true"><i class="fa-solid fa-chevron-right"></i></span>
			<span class="visually-hidden">Next</span>
		</button>
	</div>
</template>

<script>
export default {
	name: "HomeCarousel",
	data() {
		return {
			carouselItems: [
				{ image: 'https://i.pinimg.com/564x/b6/c3/f4/b6c3f4effb2a1da5b489cf8985fe5884.jpg', title: "First slide label", content: "Some representative placeholder content for the first slide." },
				{ image: 'https://i.pinimg.com/564x/b6/c3/f4/b6c3f4effb2a1da5b489cf8985fe5884.jpg', title: "Second slide label", content: "Some representative placeholder content for the second slide." },
				{ image: 'https://i.pinimg.com/564x/b6/c3/f4/b6c3f4effb2a1da5b489cf8985fe5884.jpg', title: "Third slide label", content: "Some representative placeholder content for the third slide." }
			]
		}
	}
}
</script>

<style scoped>
#carouselExampleDark {
	position: relative;
}

#carouselExampleDark .carousel-item {
	position: relative;
}

#carouselExampleDark .overlay {
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	background-color: rgba(0, 0, 0, 0.1);
}

#carouselExampleDark .carousel-item img {
	width: 100%;
	height: 500px;
	object-fit: cover;
}

#carouselExampleDark button {
	height: fit-content;
	margin: auto 0;
}

#carouselExampleDark button .controller {
	font-size: 48px;
	color: #fff;
	background: var(--primary-color);
	padding: 16px;
	/* border-radius: 50%; */
	width: fit-content;
	height: fit-content;
	display: flex;
	justify-content: center;
}

.carousel-indicators button {
	z-index: 5;
	background: #fff !important;
	margin: 0 16px !important;
	border-radius: 50%;
	width: 16px;
	height: 8px;
}
</style>
