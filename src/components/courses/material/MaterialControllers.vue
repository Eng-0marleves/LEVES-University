<template>
	<div class="controllers">
		<!-- <div class="navigation-arrows">
			<button @click="navigatePath(-1)" class="arrow"><i class="fas fa-angle-left"></i></button>
			<button @click="navigatePath(1)" class="arrow"><i class="fas fa-angle-right"></i></button>
		</div> -->
		<button type="button" class="btn normal" data-bs-toggle="modal" data-bs-target="#exampleModal">
			Add Item
		</button>

		<!-- Modal for adding new items -->
		<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-body">
						<select v-model="itemType">
							<option value="Folder">Folder</option>
							<option value="Video">Video</option>
							<option value="File">File</option>
						</select>

						<form class="mt-4 d-flex flex-column gap-3">
							<input type="text" v-model="name" placeholder="Name">
							<input v-if="itemType !== 'Folder'" type="text" v-model="src" placeholder="Src">
							<input v-if="itemType !== 'Folder'" type="text" v-model="cover" placeholder="Cover">
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

		<!-- Path navigation -->
		<div class="path">
			<span v-for="(path, i) in path" :key="i" class="route" @click="changePath(path.index, path.name)">
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
	data() {
		return {
			itemType: 'Folder',
			name: '',
			src: '',
			cover: ''
		};
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

			// Check for existing item
			const count = await this.getItemCount();
			if (count > 0) {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'An item with the same name already exists.'
				});
				return;
			}

			// Validate src for Video and File
			if ((this.itemType === 'File' || this.itemType === 'Video') && !this.src.trim()) {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Please enter a source for the item.'
				});
				return;
			}

			try {
				await axios.post(`http://localhost:3000/${this.itemType}s`, {
					name: this.name,
					src: this.src,
					cover: this.cover,
					parent_id: this.$props.currentIndex,
					user_id: '1', // Example user_id, adjust as needed
					course_code: this.$route.params.course_code
				});

				// Provide success feedback
				Swal.fire({
					icon: 'success',
					title: 'Success',
					text: `${this.itemType} added successfully.`
				});
			} catch (error) {
				console.error('Error adding item:', error);
				Swal.fire({
					icon: 'error',
					title: 'Error',
					text: 'Failed to add the item.'
				});
			} finally {
				this.closeModal();
			}
		},
		async getItemCount() {
			try {
				const response = await axios.get(`http://localhost:3000/${this.itemType}s`, {
					params: { name: this.name, parent_id: this.currentIndex }
				});
				return response.data.length;
			} catch (error) {
				console.error('Error fetching item count:', error);
				return 0;
			}
		},
		closeModal() {
			this.$refs.cancel.click();
			this.name = '';
			this.src = '';
			this.cover = '';
		},
		navigatePath(direction) {
			const currentIndex = this.path.findIndex(p => p.index === this.currentIndex);
			const newIndex = currentIndex + direction;
			if (newIndex >= 0 && newIndex < this.path.length) {
				const newPath = this.path[newIndex];
				this.changePath(newPath.index, newPath.name);
			}
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

.controllers {
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.navigation-arrows .btn {
	margin-right: 10px;
}

.modal-body select,
.modal-body input {
	width: 100%;
	padding: 8px;
	margin-top: 5px;
}

.path .route {
	cursor: pointer;
	user-select: none;
}
</style>
