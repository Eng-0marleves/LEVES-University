<template>
	<div class="controllers">

		<button type="button" class="btn normal" data-bs-toggle="modal" data-bs-target="#exampleModal">
			Add Item
		</button>

		<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">

					<div class="modal-body">
						<select v-model="itemType">
							<option value="Folder" class="add-folder">Folder</option>
							<option value="Video" class="add-video">Video</option>
							<option value="File" class="add-file">File</option>
						</select>

						<form class="mt-4 d-flex flex-column gap-3">
							<input type="text" v-model="name" placeholder="Name">
							<input v-if="itemType != 'Folder'" type="text" v-model="src" placeholder="Src">
							<input v-if="itemType != 'Folder'" type="text" v-model="cover" placeholder="Cover">
						</form>
					</div>

					<div class="modal-footer">
						<button type="button" ref="cancle" class="btn btn-danger"
							data-bs-dismiss="modal">Cancle</button>
						<button type="button" class="btn btn-success" @click="addItem">Save</button>
					</div>

				</div>
			</div>
		</div>








		<div class="path">
			<router-link class="directory" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="directory" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="directory" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="directory" to="/courses">Courses</router-link>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'MaterialControllers',
	data() {
		return {
			itemType: 'Folder',
			name: '',
			src: '',
			cover: ''
		};
	},
	props: {
		currentIndex: {
			type: String,
			required: true
		}
	},
	methods: {
		async addItem() {
			if (!this.name.trim()) {
				alert('Please enter a name for the item.');
				return;
			}

			console.log(this.itemType);

			if ((this.itemType === 'File' || this.itemType === 'Video') && !this.src.trim()) {

				const res = await axios.post(`http://localhost:3000/${this.itemType}s`, {
					name: this.name,
					src: this.src,
					cover: this.cover,
					parent_id: this.$props.currentIndex,
					user_id: "1",
					course_code: this.$route.params.course_code
				});
				console.log(res.status);
			}
			else if (this.itemType === 'Folder') {
				await axios.post(`http://localhost:3000/${this.itemType}s`, {
					name: this.name,
					parent_id: this.$props.currentIndex,
					user_id: "1",
					course_code: this.$route.params.course_code
				});
			}

			// Close the modal after saving
			this.closeModal();
		},
		async getItemCount() {
			try {
				const response = await axios.get(`http://localhost:3000/${this.itemType}s`, {
					params: {
						name: this.name,
						parent_id: this.currentIndex
					}
				});
				return response.data.length;
			} catch (error) {
				console.error('Error fetching item count:', error);
				return 0;
			}
		},
		closeModal() {
			this.$refs.cancle.click();

			// Reset input fields
			this.name = '';
			this.src = '';
			this.cover = '';
		}
	}
};
</script>


<style scoped>
.controllers {
	display: flex;
	justify-content: space-between;
	align-items: center;
	width: 100%;
}

.popup {
	position: absolute;
	top: 40px;
	right: 0;
	background-color: white;
	border: 1px solid #ccc;
	border-radius: 5px;
	padding: 10px;
}

.popup button {
	margin-bottom: 5px;
}

.controllers .path {
	display: flex;
	align-items: center;
	gap: 16px;
}

.controllers .path .directory {
	color: rgb(0, 21, 180);
	text-decoration: none;
}

.controllers .path p {
	color: #000;
}

.modal-body select {
	background: var(--primary-color);
	color: var(--white-color);
	padding: 4px 16px;
	border-radius: 8px;
}

input {
	border-bottom: 2px solid var(--primary-color);
}
</style>
