<template>
	<nav class="open small-scrollbar">
		<ul>
			<li v-for="router in routers" :key="router.route">
				<router-link :to="router.route" class="router"
					:class="{ 'active': $route.path.includes(router.route) }">
					<i :class="'fa-solid ' + router.icon"></i>
					<p class="router-title">{{ router.title }}</p>
				</router-link>
			</li>
			<li>
				<button @click="logout" class="router" style="cursor: pointer;">
					<i class="fa-solid fa-arrow-right-from-bracket"></i>
					<p class="router-title">Logout</p>
				</button>
			</li>
		</ul>
	</nav>
</template>

<script>
export default {
	name: "NavBar",

	data: () => {
		return {
			routers: [
				{ route: "/home", icon: "fa-house", title: "Home" },
				{ route: "/courses", icon: "fa-book-open", title: "Courses" },
				{ route: "/dashboard", icon: "fa-chart-simple", title: "Dashboard" },
				{ route: "/schedule", icon: "fa-calendar-days", title: "Schedule" },
				{ route: "/library", icon: "fa-book-open-reader", title: "Library" },
				{ route: "/news", icon: "fa-newspaper", title: "News" },
				{ route: "/articals", icon: "fa-atom", title: "Articals" },
				// { route: "/about", icon: "fa-circle-info", title: "About" },
				{ route: "/Support", icon: "fa-brands fa-rocketchat", title: "Support" },
				{ route: "/AI", icon: "fa-robot", title: "AI" },
			]
		}
	},
	methods: {
		logout() {
			localStorage.removeItem("user-info");
			this.$router.push({ name: "Login" });
		},
	}
}
</script>


<style scoped>
nav {
	position: fixed;
	top: 0;
	left: 0;
	height: 100vh;
	width: var(--navbar-width);
	color: var(--white-color);
	padding: 16px 0;
	background: var(--primary-color);
	overflow: auto;
	transition: all .2s ease-in-out;
	overflow-x: hidden;
	transform: translateX(-100%);
	display: flex;
	align-items: center;
	flex-direction: column;
	z-index: 100000;
}

nav.open {
	transform: translateX(0%);
	transition: all .2s ease-in-out;
}

nav.fit {
	width: 61.96875px;
	transition: all .2s ease-in-out;
}

nav ul {
	width: 100%;
	display: flex;
	flex-direction: column;
	gap: 16px;
}

nav ul li {
	width: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
}

nav ul li .router {
	width: 90%;
	padding: 8px;
	display: flex;
	align-items: center;
	gap: 8px;
	border-radius: 4px;
	color: var(--white-color);
	font-size: 16px;
	transition: var(--transition);
}

nav.fit .router {
	width: fit-content;
}

nav ul li .router:hover {
	background: var(--light-white-color);
	color: var(--white-color);
}

nav ul li .router.active {
	border-left: 4px solid var(--secondary-color);
	background: linear-gradient(to right, #ffffff6f, #ffffff29);
}

.router-title.hidTitle {
	display: none;
}

@media (max-width: 768px) {
	nav.open {
		transform: translateX(-100%);
		transition: all .2s ease-in-out;
	}

	nav {
		transform: translateX(0%);
	}
}
</style>