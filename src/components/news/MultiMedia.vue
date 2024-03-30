<template>
	<div class="multi-media">
		<section class="photo-essays">
			<h2>Photo Essays</h2>
			<div class="content-grid">
				<div v-for="essay in photoEssays" :key="essay.title" class="media-item">
					<img :src="essay.imageUrl" :alt="essay.title">
					<h3>{{ essay.title }}</h3>
				</div>
			</div>
		</section>
		<section class="videos">
			<h2>Videos</h2>
			<div class="content-grid">
				<div v-for="video in videos" :key="video.title" class="media-item">
					<video :src="video.videoUrl" controls></video>
					<h3>{{ video.title }}</h3>
				</div>
			</div>
		</section>
		<section class="podcasts">
			<h2>Podcasts</h2>
			<div class="content-list">
				<div v-for="podcast in podcasts" :key="podcast.title" class="podcast-item">
					<audio :src="podcast.podcastUrl" controls></audio>
					<h3>{{ podcast.title }}</h3>
				</div>
			</div>
		</section>
	</div>
</template>

<script>
export default {
	name: 'MultiMedia',
	data() {
		return {
			photoEssays: [
				{ title: "Spring Festivities", imageUrl: "https://i.ytimg.com/vi/bEWvQOK7s2s/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLBYMWkWf4qWJUEKf8yVdmhR3nu92Q" },
				{ title: "Graduation Day", imageUrl: "https://images.squarespace-cdn.com/content/v1/5fc463b9df132613bbd422a5/1607556474389-XW6KR2XHAYBCUINGYBZM/Graduations+Now+Blog+Graduation+day+Why+is+it+such+a+big+deal.jpg" },
				// More photo essays
			],
			videos: [
				{ title: "Campus Tour", videoUrl: "path/to/video1.mp4" },
				{ title: "Alumni Interview", videoUrl: "path/to/video2.mp4" },
				// More videos
			],
			podcasts: [
				{ title: "Innovations in Education", podcastUrl: "path/to/podcast1.mp3" },
				{ title: "Student Life Experience", podcastUrl: "path/to/podcast2.mp3" },
				// More podcasts
			],
		};
	},
};
</script>

<style scoped>
.multi-media {
	padding: 16px;
}

.multi-media h2 {
	margin-bottom: 20px;
}

.content-grid {
	display: flex;
	flex-wrap: wrap;
	gap: 16px;
}

.content-grid>div,
.content-list>div {
	border: 1px solid #ccc;
	border-radius: 8px;
	overflow: hidden;
}

.content-grid>div {
	width: calc(33.333% - 10px);
	/* Adjust based on preference */
	position: relative;
}

.content-list {
	display: flex;
	flex-direction: column;
	gap: 10px;
}

.content-list>div {
	display: flex;
	align-items: center;
	padding: 10px;
}

img,
video {
	width: 100%;
	height: 200px;
}

.media-item,
.podcast-item {
	margin-bottom: 20px;
}

video {
	max-width: 100%;
	height: auto;
	/* Ensures the video is responsive */
}

audio {
	width: 100%;
	/* Ensures the audio player spans the full width of its container */
}

h3 {
	padding: 12px;
}

@media (max-width: 768px) {
	.content-grid>div {
		width: calc(50% - 10px);
		/* Adjust for smaller screens */
	}
}
</style>
