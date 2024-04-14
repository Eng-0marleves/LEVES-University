<template>
	<div class="material-video">
		<!-- Button trigger modal -->
		<button type="button" class="btn" data-bs-toggle="modal" :data-bs-target="`#${id}`">
			<div class="card" style="width: 14rem;">
				<img :src="$props.cover" class="card-img-top" alt="...">
				<div class="card-body">
					<p>{{ $props.name }}</p>
				</div>
			</div>
		</button>

		<!-- Modal -->
		<div class="modal fade" :id="id" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-lg">
				<div class="modal-content p-0">
					<div class="modal-body p-0">
						<video v-bind:src="url" width="100%" height="100%" controls></video>

						<p>{{ $props.name }}</p>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
export default {
	name: 'MaterialVideo',
	props: {
		id: {
			typeof: 'string',
			required: true
		},
		name: {
			type: String,
			required: true
		},
		cover: {
			type: String,
			required: true
		},
		src: {
			type: String,
			required: true
		}
	},
	data() {
		return {
			url: '@/assets/videos/video.mp4',
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
	/* font-weight: bold; */
	padding: 8px;
}

.card-body p {
	white-space: nowrap;
	overflow: hidden;
	text-overflow: ellipsis;
}

.modal-body {
	color: var(--white-color);
	background: var(--primary-color);
}

.modal-body p {
	padding: 8px;
}
</style>