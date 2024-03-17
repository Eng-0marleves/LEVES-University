<template>
	<div v-if="isSmallScreen" id="nav-overlayer" class="overlayer hide" @click="toggleNav"></div>
	<div class="navbar-controllers">
		<button v-if="navOpen" @click="toggleNav">
			<i v-if="navOpen && !isSmallScreen" class="fa-solid fa-xmark"></i>
			<i v-else class="fa-solid fa-bars"></i>
		</button>
		<button v-else @click="toggleNav">
			<i v-if="!navOpen || isSmallScreen" class="fa-solid fa-bars"></i>
			<i v-else class="fa-solid fa-bars"></i>
		</button>
		<button class="title-controller" v-if="!hidTitle && navOpen && !isSmallScreen" @click="toggleTitle">
			<i class="fa-solid fa-chevron-left"></i>
		</button>
		<button class="title-controller" v-if="hidTitle && navOpen && !isSmallScreen" @click="toggleTitle">
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
	},
	data() {
		return {
			isSmallScreen: window.innerWidth <= 768
		}
	}
};
</script>

<style scoped>
.navbar-controllers {
	display: flex;
	gap: 16px;
}

.navbar-controllers button {
	width: 40px;
	height: 40px;
	color: var(--secondary-color);
	transition: var(--transition);
	border-radius: 50%;
	cursor: pointer;
	display: flex;
	justify-content: center;
	align-items: center;
}

.navbar-controllers button i {
	font-size: 16px;
	font-weight: bold;
}

.navbar-controllers button:hover {
	background: var(--Black-color-light);
}

.overlayer {
	position: fixed;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	background: rgba(0, 0, 0, 0.5);
}

.overlayer.hide {
	display: none;
}

@media (max-width: 768px) {

	.title-controller {
		display: none;
	}
}
</style>
