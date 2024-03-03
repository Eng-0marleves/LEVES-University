<template>
	<div class="post_generator">
		<!-- Button trigger modal -->
		<button type="button" tooltip class="btn btn-fixed newPost" data-bs-toggle="modal" title="New Post"
			data-bs-target="#staticBackdrop">
			<i class="fas fa-plus"></i>
		</button>

		<!-- Modal -->
		<div class="modal fade p-5" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
			aria-labelledby="staticBackdropLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered-top modal-fullscreen-lg">
				<div class="modal-content">
					<div class="modal-body">
						<TextEditor v-model="postData.content" />
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancel</button>
						<button type="button" class="btn btn-success" @click="handleSave">Save</button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import TextEditor from './TextEditor.vue';
import axios from 'axios';

export default {
	name: "PostGenerator",
	components: {
		TextEditor
	},
	data() {
		return {
			postData: {
				"title": "<h1> Omar </h1>",
				"home": "<p> Home </p>"
			}
		}
	},
	methods: {
		handleSave() {
			axios.post('http://localhost:3000/posts', {
				content: this.postData.content
			})
			// .then(response => {
			// 	console.log('Post successful:', response.data);
			// })
			// .catch(error => {
			// 	console.error('Error posting data:', error);
			// });
		}
	}
}
</script>

<style scoped>
.btn-fixed {
	bottom: 72px !important;
	z-index: 10 !important;
}

.newPost:hover {
	background: var(--secondary-color);
	color: #fff;
}

.newPost i {
	margin: auto;
}

.btn-primary {
	background: var(--primary-color);
}

.modal-dialog {
	width: 100%;
}

.modal-content {
	border-radius: 0;
}

.modal-fullscreen-lg {
	max-width: none;
}
</style>
