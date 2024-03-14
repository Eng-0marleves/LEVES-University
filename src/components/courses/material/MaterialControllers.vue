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
						<button type="button" ref="cancel" class="btn btn-danger"
							data-bs-dismiss="modal">Cancel</button>
						<button type="button" class="btn btn-success" @click="addItem">Save</button>
					</div>
				</div>
			</div>
		</div>

		<div class="path">
			<span v-for="(path, i) in $props.path" :key="i" class="route" @click="changePath(path.index, path.name)">
				{{ path.name + '/ ' }}
			</span>
		</div>
	</div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

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
		},
		path: {
			type: Array,
			required: true
		}
	},
	methods: {
		async addItem() {
			if (!this.name.trim()) {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Please enter a name for the item.'
				});
				return;
			}

			const count = await this.getItemCount();

			if (count > 0) {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'An item with the same name already exists.'
				});
				return;
			}

			if ((this.itemType === 'File' || this.itemType === 'Video') && !this.src.trim()) {
				await axios.post(`http://localhost:3000/${this.itemType}s`, {
					name: this.name,
					src: this.src,
					cover: this.cover,
					parent_id: this.$props.currentIndex,
					user_id: '1',
					course_code: this.$route.params.course_code
				});
			} else if (this.itemType === 'Folder') {
				await axios.post(`http://localhost:3000/${this.itemType}s`, {
					name: this.name,
					parent_id: this.$props.currentIndex,
					user_id: '1',
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
			this.$refs.cancel.click();

			// Reset input fields
			this.name = '';
			this.src = '';
			this.cover = '';
		},
		changePath(index, name) {
			this.$emit('changePath', index, name);
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

.path {
	width: 80%;
	text-align: right;
	display: flex;
	justify-content: flex-end;
	gap: 0px;
	overflow: hidden;
}

.route {
	width: fit-content;
	flex-wrap: nowrap;
	cursor: pointer;
}
</style>
