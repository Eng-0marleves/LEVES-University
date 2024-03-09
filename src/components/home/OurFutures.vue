<template>
	<div class="our-futures d-flex flex-column gap-3 align-items-center">
		<h3 class="title">WELECOME TO LEVES UNIVERSITY</h3>
		<p class="desctiption">Discover innovative opportunities at our university.</p>
		<div class="futures-container">
			<div v-for="(future, index) in futures" :key="index" class="future d-flex gap-3 align-items-center">
				<div class="icon">
					<i :class="future.icon"></i>
				</div>
				<div class="content">
					<h5>{{ future.title }}</h5>
					<p>{{ future.description }}</p>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'OurFutures',
	data() {
		return {
			futures: [
				{
					title: 'Virtual Campus',
					description: 'Experience lectures, projects, and activities online.',
					icon: 'fas fa-globe'
				},
				{
					title: 'Personalized Learning',
					description: 'Tailored learning experiences for academic success.',
					icon: 'fas fa-brain'
				},
				{
					title: 'Sustainable Campus',
					description: 'Join us in eco-friendly initiatives for a greener future.',
					icon: 'fas fa-leaf'
				}
			]
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
};
</script>

<style scoped>
.futures-container {
	display: flex;
	justify-content: space-around;
	flex-wrap: wrap;
	gap: 0px;
	width: 100%;
}

.title {
	color: var(--primary-color);
}

.desctiption {
	color: #666;
}

.future {
	width: 360px;
}

.icon {
	font-size: 64px;
	color: var(--secondary-color);
}
</style>
