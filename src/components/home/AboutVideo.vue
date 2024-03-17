<template>
	<div class="about-video">
		<div class="content d-flex flex-column gap-3">
			<p class="fw-bold fs-4">
				Welcome to Leves University
			</p>

			<p class="text-body-secondary fw-bold fs-5">
				Discover a World of Knowledge and Opportunity
			</p>

			<p class="text-body-secondary">
				{{ content }}
			</p>
		</div>
		<div class="video">

			<!-- Button trigger modal -->
			<button type="button" class="intro-btn" data-bs-toggle="modal" data-bs-target="#introvideo">
				<img src="https://media.wired.com/photos/647e7400d96882f74caa3e5c/4:3/w_2132,h_1599,c_limit/Don't-Want-Students-To-Rely-On-ChatGPT-Ideas-1356557660.jpg"
					alt="">
				<div class="overlay"></div>
				<i class="fas fa-play"></i>
			</button>

			<!-- Modal -->
			<div class="modal fade" id="introvideo" tabindex="-1" aria-labelledby="exampleModalLabel"
				aria-hidden="true">
				<div class="modal-dialog modal-dialog-centered modal-lg">
					<div class="modal-content p-0">
						<video width="100%" controls>
							<source src="@/assets/videos/Intro.mp4" type="video/mp4">
							Your browser does not support the video tag.
						</video>
					</div>
				</div>
			</div>


		</div>
	</div>
</template>

<script>
export default {
	name: 'AboutVideo',
	data() {
		return {
			videoUrl: '@/assets/videos/Intro.mp4',
			content: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vestibulum nunc sit amet convallis bibendum. Nulla facilisi. Morbi consequat, mi eget sollicitudin venenatis, nunc nibh feugiat lorem, nec tincidunt ligula urna sed libero. Phasellus suscipit posuere tortor, a tristique tortor cursus non. Maecenas ultricies lectus nec dolor aliquet, non dictum ipsum tristique. Cras vehicula tincidunt quam non varius. Mauris laoreet pharetra mi. Suspendisse potenti. Quisque tempus lorem at nunc posuere scelerisque. Curabitur consequat fermentum sapien, sit amet facilisis tortor dictum eget. Duis fermentum vulputate velit eget facilisis. Vivamus sit amet commodo ligula. Fusce fringilla est a velit fermentum cursus.`,
		};
	},
};
</script>

<style scoped>
.about-video {
	display: flex;
	justify-content: space-around;
	align-items: flex-start;
	flex-wrap: wrap;
	flex-direction: row;
	gap: 16px;
}

.about-video .content {
	width: 600px;
}

.intro-btn {
	position: relative;
}

.intro-btn img {
	position: relative;
	width: 450px;
	height: 300px;
	border-radius: 8px;
}

.intro-btn .overlay {
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	border-radius: 8px;
	background: var(--primary-color);
	opacity: 0.4;
}

.intro-btn i {
	position: absolute;
	top: calc(50% - 32px);
	left: calc(50% - 20px);
	color: var(--white-color);
	font-size: 64px;
	background: linear-gradient(-45deg, var(--primary-color), var(--secondary-color), var(--secondary-color));
	background-size: 400% 400%;
	animation: gradient 5s ease infinite;
	-webkit-background-clip: text;
	-moz-background-clip: text;
	background-clip: text;
	-webkit-text-fill-color: transparent;
}

@keyframes gradient {
	0% {
		background-position: 0% 50%;
	}

	50% {
		background-position: 100% 50%;
	}

	100% {
		background-position: 0% 50%;
	}
}

.fade {
	z-index: 1000000;
	position: fixed;
	top: 0;
	left: 0;
}

@media (max-width: 768px) {
	.about-video {
		padding: 8px;
	}

	.content {
		text-align: center;
	}

	.intro-btn {
		width: 100%;
	}

	.intro-btn img {
		width: 100%;
	}
}
</style>
