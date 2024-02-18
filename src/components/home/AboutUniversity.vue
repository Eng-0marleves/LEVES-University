<template>
	<div class="about">
		<div class="row">
			<div class="left">
				<nav id="navbar-example3" class="h-100 flex-column align-items-stretch">
					<nav class="nav nav-pills flex-column">
						<a v-for="(topic, i) in universityData" :key="'topic-' + i" :href="'#topic-' + i" class="nav-link"
							@click="scrollToTopic(i)">{{ topic.title }}</a>
					</nav>
				</nav>
			</div>

			<div class="right h-100">
				<div data-bs-spy="scroll" data-bs-target="#navbar-example3" data-bs-offset="0"
					class="scrollspy-example-2 h-100" tabindex="0">
					<template v-for="(topic, i) in universityData" :key="'t-' + i">
						<div :id="'topic-' + i" class="item">
							<h1>{{ topic.title }}</h1>
							<pre>{{ topic.content }}</pre>
						</div>
					</template>
				</div>
			</div>

			<div class="controllers">
				<button class="open"><i class="fa-solid fa-bars"></i></button>
				<button class="close"><i class="fa-solid fa-xmark"></i></button>
				<button class="full_screen"><i class="fa-solid fa-expand"></i></button>
				<button class="mini_screen"><i class="fa-solid fa-compress"></i></button>
			</div>
		</div>
	</div>
</template>


<script>
import about from "./about.json";
export default {
	name: "AboutUniversity",
	data() {
		return {
			universityData: about
		};
	},
	methods: {
		scrollToTopic(index) {
			const topicId = `topic-${index}`;
			const topicElement = document.getElementById(topicId);
			if (topicElement) {
				const offsetTop = topicElement.offsetTop - 20;
				window.scrollTo({
					top: offsetTop,
					behavior: 'smooth'
				});
			}
		}
	}
};
</script>

<style scoped>
.about {
	display: flex;
	justify-content: center;
	flex-direction: row;
	height: 80vh;
	margin-top: 20px;
	box-shadow: 0 0 10px #00000061;
	position: relative;
}

.about .row {
	width: 100%;
}

.about .scrollspy-example-2 {
	padding: 0px !important;
}

.about .row .left {
	width: 300px;
	padding-left: 0px !important;
}

.about .row .right {
	width: calc(100% - 300px) !important;
	padding: 0px;
}

.about nav {
	background: var(--primary-color);
	color: #fff;
}

.about nav a {
	color: #fff !important;
}

.about nav a.active {
	background: var(--secondary-color) !important;
	border-radius: 0px !important;
}

.about .col-4 {
	height: 100%;
	padding-right: 15px;
	padding-left: 15px;
}

.about #navbar-example3 {
	position: sticky;
	top: 20px;
}

.about .nav-link {
	color: #333;
}

.about .scrollspy-example-2 {
	padding-top: 20px;
	overflow-y: scroll;
	height: 400px;
}

.about .item {
	min-height: 100%;
}

.about .item:not(:first-child) {
	margin-top: 96px;
}

.about h4,
.about h5 {
	margin-top: 10px;
}

.about p {
	margin-bottom: 20px;
}

.about pre {
	word-break: break-all;
	white-space: -moz-pre-wrap;
	white-space: -o-pre-wrap;
	white-space: pre-wrap;
	white-space: pre-line;
	word-wrap: break-word;

	margin-top: 24px;
	font-size: 24px;
}

.about .border-end {
	border: none;
}

.about .controllers {
	position: absolute;
	bottom: 0;
	right: 15px;
	width: fit-content;
	background: var(--primary-color);
	padding: 0;
	display: flex;
	flex-direction: row;
	gap: 4px;
}

.about .controllers button {
	width: 64px;
	height: 64px;
	overflow: hidden;
	transition: var(--transition);
}

.about .controllers button:hover {
	background: var(--secondary-color);
}

.about .controllers button i {
	color: #fff;
	font-size: 32px !important;
	padding: 8px;
}
</style>
