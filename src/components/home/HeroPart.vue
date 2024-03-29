<template>
	<div class="hero">
		<!-- Background Image -->
		<div class="background-image"></div>

		<!-- Overlay -->
		<div class="overlay"></div>

		<!-- Content -->
		<div class="content">
			<div class="left">
				<img :src="images.u_logo" alt="">
			</div>

			<div class="right">
				<h1>LEVES University</h1>
				<h3>Enhanced University System Services</h3>
			</div>
		</div>
	</div>
</template>

<script>
import logo from "@/assets/images/white_logo_full.png";

export default {
	name: "HeroPart",
	data() {
		return {
			images: {
				u_logo: logo
			}
		}
	}
}
</script>

<style scoped>
/* hero */
.hero {
	position: relative;
	width: 100%;
	height: 100vh;
	overflow: hidden;
}

.background-image {
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	background: url('https://brescia.uwo.ca/communications/img/wallpaper/buc_wallpaper_desktop_01.jpg') center/cover;
}

.content {
	position: relative;
	z-index: 1;
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: wrap;
	color: white;
	height: 100%;
}

.content .right {
	background: var(--primary-color);
	padding: 24px;
}

.content .right h1 {
	font-size: 96px;
	color: var(--secondary-color);
}
</style>