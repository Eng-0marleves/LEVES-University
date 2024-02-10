<template>
	<header class="header" id="header">
		<nav class="nav">

			<i class="fas fa-bars" @click="toggleMenu"></i>

			<div class="nav-menu" id="nav-menu">
				<i class="fas fa-close" @click="toggleMenu"></i>
				<ul class="nav-list">
					<li class="nav-item">
						<router-link to="/" class="nav-link active-link">Home</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Courses</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Dashboard</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/" class="nav-link">Posts</router-link>
					</li>
				</ul>
			</div>

			<div class="nav-btns">
				<p>std.Ahmed</p>
				<i class="fa-solid fa-user"></i>
				<span class="bell">
					<i class="fas fa-bell"></i>
				</span>
			</div>

		</nav>
	</header>
</template>

<script>
export default {
	name: "NavBar",
	methods: {
		handleScroll() {
			const header = document.querySelector("header");
			if (header) {
				header.classList.toggle("scroll-header", window.scrollY > 0);
			}
		},
		toggleMenu(event) {
			event.stopPropagation();
			const navMenu = document.getElementById("nav-menu");
			navMenu.classList.toggle("show-menu");
			if (navMenu.classList.contains("show-menu")) {
				document.addEventListener("click", this.handleClickOutside);
			} else {
				document.removeEventListener("click", this.handleClickOutside);
			}
		},
		handleClickOutside(event) {
			const navMenu = document.getElementById("nav-menu");
			if (!navMenu.contains(event.target)) {
				navMenu.classList.remove("show-menu");
				document.removeEventListener("click", this.handleClickOutside);
			}
		}
	},
	mounted() {
		window.addEventListener("scroll", this.handleScroll);
	},
	beforeUnmount() {
		window.removeEventListener("scroll", this.handleScroll);
	}
};
</script>

<style scoped>
.header {
	background: transparent;
	position: fixed;
	top: 0;
	left: 0;
	width: 100%;
	z-index: var(--z-fixed);
	padding: 1rem;
}

.nav {
	display: flex;
	justify-content: space-between;
	align-items: center;
	column-gap: 3rem;
	margin: 0;
	padding: 0;
	width: 100% !important;
	flex: 1;
}

.nav-menu {
	color: var(--title-color);
	align-items: center;
	margin-bottom: 0;
}

.nav-btns {
	display: flex;
	align-items: center;
	column-gap: 2rem;
	font-size: var(--h2-font-size);
}

.nav-btns i {
	cursor: pointer;
	transition: all .2s ease-in-out;
}

.nav-btns p {
	margin: 0;
}

.nav-btns i:hover {
	color: var(--main-color);
}

.nav-list {
	display: flex;
	align-items: center;
	column-gap: 1rem;
	margin: 0;
	padding: 0;
}

.nav-link {
	height: 100%;
	color: var(--title-color);
	font-weight: var(--font-medium);
	font-size: var(--h3-font-size);
	transition: all 0.2s;
}

.nav-link:hover,
.fa-bars:hover,
.fa-close:hover {
	color: var(--main-color);
}

#nav-close {
	font-size: 2rem;
	position: absolute;
	top: .9rem;
	right: 1.25rem;
	cursor: pointer;
}

#nav-close,
.nav-toggle {
	display: none;
}

.fa-bars,
.fa-close {
	display: none;
}

.nav-menu.show-menu {
	left: 0;
}

.scroll-header {
	background: var(--body-color);
	box-shadow: 0 1px 4px var(--shadow);
}

@media only screen and (max-width: 768px) {

	.fa-bars,
	.fa-close {
		display: block;
		font-size: var(--h1-font-size);
		cursor: pointer;
		transition: all .2s ease-in-out;
	}

	.fa-close {
		position: absolute;
		top: 1.25rem;
		right: .9rem;
	}

	.nav-menu {
		background: var(--body-color) !important;
		width: 60%;
		height: 100%;
		position: fixed;
		top: 0;
		left: -65%;
		box-shadow: -6px 1px 20px 20px var(--shadow);
		z-index: 3;
		transition: all .3s ease-in-out;
	}

	.nav-menu .nav-list {
		height: 100%;
		flex-direction: column;
		align-items: center;
		padding: 6rem 2rem 3.5rem;
		gap: 2rem;
	}
}
</style>