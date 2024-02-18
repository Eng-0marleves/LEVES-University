<template>
	<div class="navbar-controllers">
		<button v-if="navOpen" @click="toggleNav">
			<i v-if="navOpen" class="fa-solid fa-xmark"></i>
			<i v-else class="fa-solid fa-bars"></i>
		</button>
		<button v-else @click="toggleNav">
			<i v-if="!navOpen" class="fa-solid fa-bars"></i>
			<i v-else class="fa-solid fa-bars"></i>
		</button>
		<button class="title-controller" v-if="!hidTitle && navOpen" @click="toggleTitle">
			<i class="fa-solid fa-chevron-left"></i>
		</button>
		<button class="title-controller" v-if="hidTitle && navOpen" @click="toggleTitle">
			<i class="fa-solid fa-chevron-right"></i>
		</button>
	</div>
</template>

<script>
export default {
	props: {
		navOpen: Boolean,
		hidTitle: Boolean,
		toggleNav: Function,
		toggleTitle: Function
	}
};
</script>

<style scoped>
.navbar-controllers {
	display: flex;
	gap: 16px;
}

.navbar-controllers button {
	width: 56px;
	height: 56px;
	color: var(--secondary-color);
	transition: var(--transition);
	border-radius: 50%;
	cursor: pointer;
	display: flex;
	justify-content: center;
	align-items: center;
}

.navbar-controllers button i {
	font-size: 24px;
	font-weight: bold;
}

.navbar-controllers button:hover {
	background: var(--Black-color-light);
}

@media (max-width: 768px) {

	/* i:not(.fa-bars) {
		display: none;
	} */
	.title-controller {
		display: none;
	}
}
</style>
