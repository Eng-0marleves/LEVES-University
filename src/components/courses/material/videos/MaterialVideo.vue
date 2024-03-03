<template>
	<div class="material-video">
		<!-- Button trigger modal -->
		<button type="button" class="btn" data-bs-toggle="modal" data-bs-target="#exampleModal">
			<div class="card" style="width: 18rem;">
				<img src="https://www.keytechinc.com/wp-content/uploads/2022/01/video-thumbnail.jpg" class="card-img-top"
					alt="...">
				<div class="card-body">
					<p>Some quick example text to build on the card title and make up the bulk of the
						card's content.</p>
				</div>
			</div>
		</button>

		<!-- Modal -->
		<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl">
				<div class="modal-content p-0">
					<div class="modal-body p-0">
						<video src="@/assets/videos/video.mp4" width="100%" height="100%" controls></video>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'MaterialVideo',
	data() {
		return {
			video: {
				title: 'Video Title',
				thumbnail: 'https://www.keytechinc.com/wp-content/uploads/2022/01/video-thumbnail.jpg',
				url: '@/assets/videos/video.mp4'
			}
		};
	},
}
</script>

<style scoped>
.modal-content {
	background: transparent;
}

.btn {
	transition: var(--transition);
	padding: 0;
}

.btn:hover {
	box-shadow: 0 0 16px rgba(0, 0, 0, 0.2);
}

.card-body {
	text-align: left;
	background: var(--primary-color);
	color: #fff;
	font-weight: bold;
	padding: 8px;
}

.card-body p {
	white-space: nowrap;
	overflow: hidden;
	text-overflow: ellipsis;
}
</style>