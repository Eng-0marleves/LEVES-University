<template>
	<header v-if="isAuthenticated" :class="{ fit: navOpen && hidTitle }"
		:style="{ width: 'calc(100% - ' + (navOpen ? navWidth : 0) + 'px' + ')' }">
		<NavbarControllers :navOpen="navOpen" :hidTitle="hidTitle" :toggleNav="toggleNav" :toggleTitle="toggleTitle" />
		<UserInfo :user_img="user_img" :showNotifications="showNotifications" :toggleNotifications="toggleNotifications"
			:splitNotification="splitNotification" :userData="userData" @toggle-notifications="toggleNotifications" />
	</header>
</template>

<script>
import NavbarControllers from '@/components/header/NavbarControllers.vue';
import UserInfo from '@/components/header/UserInfo.vue';
import userImg from "@/assets/images/user_img.jpg";
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: "NavHeader",
	components: {
		NavbarControllers,
		UserInfo
	},
	data() {
		return {
			navWidth: 0,
			navOpen: true,
			hidTitle: false,
			isSmallScreen: false,
			user_img: userImg,
			showNotifications: false,
			userData: {},
			isAuthenticated: false
		};
	},
	mounted() {
		this.navWidth = document.querySelector("nav").getBoundingClientRect().width;
		this.isSmallScreen = window.innerWidth <= 768;
		window.addEventListener("resize", this.updateScreenSize);
		const authToken = Cookies.get('user-auth-token');
		if (authToken) {
			this.isAuthenticated = true;
			try {
				const decodedToken = jwtDecode(authToken);
				this.userData = decodedToken;
				console.log("Decoded authentication token:", this.userData);
			} catch (error) {
				console.error("Error decoding authentication token:", error);
			}
		}
	},
	methods: {
		toggleNav() {
			this.navOpen = !this.navOpen;
			document.querySelector("nav").classList.toggle("open");
			this.updateBodyPadding();
			if (document.getElementById("nav-overlayer")) {
				document.getElementById("nav-overlayer").classList.toggle("hide");
			}
		},
		toggleTitle() {
			this.hidTitle = !this.hidTitle;
			document.querySelectorAll(".router-title").forEach(el => {
				el.classList.toggle("hidTitle");
				this.updateBodyPadding();
			});
			document.querySelector("nav").classList.toggle("fit");
			if (this.hidTitle && this.navOpen) {
				this.toggleHeaderFit();
				this.updateBodyPadding();
			}
		},
		toggleHeaderFit() {
			const header = document.querySelector("header");
			header.classList.toggle("fit");
			this.updateBodyPadding();
		},
		updateBodyPadding() {
			const body = document.querySelector("body");
			if (this.navOpen && !this.hidTitle) {
				body.classList.add("menuOpen");
				body.classList.remove("fit");
				body.style.paddingLeft = this.navWidth + "px";
			} else if (this.navOpen && this.hidTitle) {
				body.classList.add("menuOpen", "fit");
				body.style.paddingLeft = "61.96px";
			} else {
				body.classList.remove("menuOpen", "fit");
				body.style.paddingLeft = "0";
			}
		},
		updateScreenSize() {
			this.isSmallScreen = window.innerWidth <= 768;
		},
		toggleNotifications() {
			this.showNotifications = !this.showNotifications;
		},
		splitNotification(index) {
			this.notifications.splice(index, 1);
		},
	},
	// eslint-disable-next-line vue/no-deprecated-destroyed-lifecycle
	unmounted() {
		window.removeEventListener("resize", this.updateScreenSize);
	},
};
</script>

<style scoped>
header {
	position: fixed;
	top: 0;
	right: 0;
	background: #eee !important;
	padding: 8px;
	height: var(--header-height);
	display: flex;
	justify-content: space-between;
	align-items: center;
	border-bottom: 2px solid var(--primary-color);
	z-index: 10;
	transition: var(--transition);
}

header.fit {
	width: calc(100% - 61.96px) !important;
}

@media (max-width: 768px) {
	header {
		width: 100% !important;
	}
}
</style>
