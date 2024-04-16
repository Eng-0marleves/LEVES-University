<template>
	<div class="assignment-generator">
		<h2>Create Assignment</h2>
		<form @submit.prevent="submitAssignment">
			<div class="form-group">
				<label for="title">Title:</label>
				<input id="title" v-model="assignment.title" maxlength="100" type="text" required class="input">
			</div>
			<div class="form-group">
				<label for="description">Description:</label>
				<textarea id="description" v-model="assignment.description" maxlength="300" class="input"></textarea>
			</div>

			<div class="form-group">
				<label for="dueDate">Due Date:</label>
				<input id="dueDate" v-model="assignment.dueDate" type="date" required class="input">
			</div>

			<div class="form-group">
				<label for="fileType">Allowed File Types:</label>
				<select :onChange="console.log(selectedFileTypes)" id="fileType" v-model="selectedFileTypes" multiple
					class="multiselect">
					<option v-for="(type, i) in fileTypes" :key="i" :value="type.value">{{ type.text }}</option>
				</select>
			</div>


			<div class="form-group">
				<label for="fileLimit">File Upload Limit:</label>
				<input type="number" v-model="fileLimit" min="1" class="input">
			</div>
			<div class="form-group file-upload text-center">
				<div class="file-upload-container">
					<div class="header-section">
						<h1>Upload Attachment Files</h1>
						<p>Upload files you want to share with your students.</p>
						<p>PDF, Images & Videos are allowed.</p>
					</div>
					<div ref="dropSection" class="drop-section" :class="{ 'drag-over-effect': isDraggingOver }"
						@dragover.prevent="dragOver" @dragenter.prevent="dragEnter" @dragleave.prevent="dragLeave"
						@drop.prevent="handleDrop">
						<div class="col" v-show="!isDraggingOver">
							<div class="cloud-icon">
								<i class="fas fa-cloud-upload-alt"></i>
							</div>
							<span>Drag & Drop your files here</span>
							<span>OR</span>
							<button ref="fileSelector" class="btn normal" @click="browseFiles">Browse Files</button>
							<input ref="fileSelectorInput" type="file" multiple @change="handleFileInput"
								class="file-selector-input" hidden>
						</div>
						<div class="col w-100" v-show="isDraggingOver">
							<div class="drop-here">Drop Here</div>
						</div>
					</div>
					<div ref="listSection" class="list-section">
						<div class="list-title">Uploaded Files</div>
						<ul class="list align-items-center">
							<li v-for="(file, index) in assignment.files" :key="file.name">
								<div class="col">
									<img :src="getFileIcon(file.type)" alt="file icon">
								</div>
								<div class="col">
									<div class="file-name">
										<div class="name">{{ file.name }}</div>
									</div>
									<div class="file-size">{{ (file.size / 1024 / 1024).toFixed(2) }} MB</div>
								</div>
								<div class="col btns d-flex">
									<button @click="downloadFile(file)"><i class="fas fa-download"></i></button>
									<button @click="deleteFile(index)"><i class="fas fa-trash"></i></button>
								</div>
							</li>
						</ul>
					</div>
				</div>
			</div>
			<div class="button-group">
				<button type="button" @click="saveDraft" class="btn btn-danger">Cancle</button>
				<button type="button" @click="saveDraft" class="btn btn-primary">Save Draft</button>
				<button type="button" @click="publishAssignment" class="btn btn-success">Publish</button>
			</div>
		</form>
	</div>
</template>

<script>
import Swal from 'sweetalert2';

export default {
	name: 'AssignmentGenerator',
	data() {
		return {
			assignment: {
				title: '',
				description: '',
				dueDate: '',
				files: []
			},
			savedDrafts: [],
			fileTypes: [
				{ text: 'Text File', value: 'text/plain' },
				{ text: 'Microsoft Word', value: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' },
				{ text: 'Microsoft PowerPoint', value: 'application/vnd.openxmlformats-officedocument.presentationml.presentation' },
				{ text: 'PDF', value: 'application/pdf' },
				{ text: 'JPEG Image', value: 'image/jpeg' },
				{ text: 'PNG Image', value: 'image/png' },
				{ text: 'MP4 Video', value: 'video/mp4' },
				{ text: 'AVI Video', value: 'video/avi' },
			],
			selectedFileTypes: [],
			fileLimit: 1,
			images: {
				pdf: require('@/assets/images/pdf_file_logo.png'),
				img: require('@/assets/images/image_file_logo.png'),
				video: require('@/assets/images/video_file_logo.png')
			},
			isDraggingOver: false
		};
	},
	methods: {
		dragEnter(e) {
			e.preventDefault();
			this.isDraggingOver = true;
		},
		dragOver(e) {
			e.preventDefault();
		},
		dragLeave(e) {
			e.preventDefault();
			this.isDraggingOver = false;
		},
		handleDrop(e) {
			const files = e.dataTransfer.files;
			this.handleFileUpload(files);
			this.isDraggingOver = false;
		},
		browseFiles() {
			this.$refs.fileSelectorInput.click();
		},
		handleFileInput(e) {
			const files = e.target.files;
			this.handleFileUpload(files);
		},
		handleFileUpload(files) {
			Array.from(files).forEach(file => {
				if (this.validateFile(file)) {
					file.complete = false;
					file.error = false;
					this.assignment.files.push(file);
				}
			});
		},
		validateFile(file) {
			const allowedTypes = [
				'application/pdf',
				'image/jpeg',
				'image/png',
				'video/mp4',
				'video/avi',
				'video/quicktime',
				'video/x-ms-wmv',
				'video/x-matroska'
			];
			const maxSizeMB = 100;
			if (!allowedTypes.includes(file.type) || file.size > maxSizeMB * 1024 * 1024) {
				Swal.fire({
					title: 'Error!',
					text: `Invalid file type or size! Allowed types are PDF, images (JPEG, PNG), and videos (MP4, AVI, MOV, WMV). Maximum size is ${maxSizeMB} MB.`,
					icon: 'error',
					confirmButtonText: 'Ok'
				});
				return false;
			}
			return true;
		},
		getFileIcon(type) {
			if (type.includes('pdf')) return this.images.pdf;
			if (type.includes('image')) return this.images.img;
			if (type.includes('video')) return this.images.video;
			return this.images.img; // Default icon
		},
		downloadFile(file) {
			// Simulated download function; adjust as needed for actual file handling
			const url = window.URL.createObjectURL(new Blob([file.content]));
			const link = document.createElement('a');
			link.href = url;
			link.setAttribute('download', file.name);
			document.body.appendChild(link);
			link.click();
			link.parentNode.removeChild(link);
		},
		deleteFile(index) {
			Swal.fire({
				title: 'Are you sure?',
				text: 'You will not be able to recover this file!',
				icon: 'warning',
				showCancelButton: true,
				confirmButtonColor: '#3085d6',
				cancelButtonColor: '#d33',
				confirmButtonText: 'Yes, delete it!',
				cancelButtonText: 'No, keep it'
			}).then((result) => {
				if (result.isConfirmed) {
					this.assignment.files.splice(index, 1);
					Swal.fire(
						'Deleted!',
						'The file has been successfully deleted.',
						'success'
					);
				}
			});
		},
		saveDraft() {
			this.savedDrafts.push({ ...this.assignment, files: [...this.assignment.files] });
			Swal.fire({
				title: 'Success!',
				text: 'Draft saved successfully!',
				icon: 'success',
				confirmButtonText: 'Ok'
			});
		},
		publishAssignment() {
			console.log('Publishing:', this.assignment);
			Swal.fire({
				title: 'Published!',
				text: 'Your assignment has been published successfully!',
				icon: 'success',
				confirmButtonText: 'Great'
			});
		},
		submitAssignment() {
			console.log('Submitting assignment:', this.assignment);
			this.resetForm();
		},
		resetForm() {
			this.assignment = { title: '', description: '', dueDate: '', files: [] };
		}
	}
};
</script>

<style scoped>
.assignment-generator {
	max-width: 800px;
	margin: 20px auto;
	padding: 20px;
	background: #fff;
	border-radius: 8px;
	box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
	font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.form-group {
	margin-bottom: 20px;
}

.label,
.input,
.btn {
	display: block;
	width: 100%;
	padding: 10px;
}

.label {
	margin-bottom: 5px;
	font-size: 16px;
	color: #333;
}

.input {
	border: 1px solid #ccc;
	border-radius: 4px;
}

.file-upload {
	position: relative;
	overflow: hidden;
}

.file-input {
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	opacity: 0;
	cursor: pointer;
}

.file-name {
	display: block;
	margin-top: 5px;
}

.button-group {
	display: flex;
	justify-content: space-between;
	align-items: center;
	gap: 16px;
}

.file-uploade-container {
	text-align: center;
	width: 100%;
	max-width: 500px;
	min-height: 400px;
	margin: auto;
	background: var(--white-color);
	border-radius: 16px;
}

.header-section {
	padding: 25px 0;
}

.header-section h1 {
	font-weight: 500;
	font-size: 1.7rem;
	text-transform: uppercase;
	color: #333;
	margin-bottom: 8px;
}

.header-section p {
	margin: 5px;
	font-size: 1rem;
}

.drop-section {
	min-height: 250px;
	border: 1px dashed var(--secondary-color);
	background: linear-gradient(180deg, #fff, #f1f1f1);
	margin: 35px;
	margin-top: 5px;
	border-radius: 12px;
	position: relative;
	transition: all .2s ease-in-out;
}

.drop-section .col:first-child {
	opacity: 1;
	visibility: visible;
	transition: all .2s ease-in-out;
	transform: scale(1);
	width: 200px;
	margin: auto;
}

.drop-section .col:last-child {
	font-size: 40px;
	font-weight: 700;
	color: #c0cae1;
	position: absolute;
	top: 0;
	bottom: 0;
	left: 0;
	right: 0;
	margin: auto;
	width: 200px;
	height: 55px;
	pointer-events: none;
	opacity: 0;
	visibility: hidden;
	transform: scale(0.6);
	transition: all .2s ease-in-out;
}

.drop-section .cloud-icon {
	color: var(--primary-color);
	font-size: 64px;
	margin-top: 25px;
	margin-bottom: 20px;
}

.drop-section span,
.drop-section button {
	display: block;
	margin: auto;
	color: var(--primary-color);
	margin-bottom: 20px;
}

.drop-section button {
	color: var(--white-color);
	background: var(--primary-color);
	padding: 7px 20px;
	border-radius: 8px;
	margin-top: 20px;
	cursor: pointer;
}

.drop-section input {
	display: none;
}

.drag-over-effect .col:first-child {
	opacity: 0;
	visibility: hidden;
	pointer-events: none;
	transform: scale(1.1);
}

.drag-over-effect .col:last-child {
	opacity: 1;
	visibility: visible;
	transform: scale(1);
}

.list-section {
	text-align: left;
	margin: 0 35px;
	padding-bottom: 20px;
}

.list-title {
	font-size: .95rem;
	font-weight: 500;
	color: #333;
}

.list-section .list li {
	display: flex;
	align-items: center;
	margin: 15px 0;
	padding-top: 4px;
	padding-bottom: 2px;
	padding: 8px;
	border-radius: 8px;
	transition: all .2s ease-in-out;
	border: 1px solid rgba(0, 0, 0, 0.1);
}

.list-section .list li:hover {
	background: #f1f1f155;
}

.list-section .list li img {
	width: 64px;
	object-fit: cover;
}

.list-section .list li .col {
	flex: .1;
}

.list-section .list li .col:nth-child(1) {
	flex: 0.15;
	text-align: center;
}

.list-section .list li .col:nth-child(2) {
	flex: 0.75;
	text-align: left;
	font-size: 0.9rem;
	color: #3e4046;
	padding: 8px 10px;
}

.list-section .list li .col:nth-child(2) .name {
	overflow: hidden;
	white-space: nowrap;
	text-overflow: ellipsis;
	max-width: 250px;
	display: inline-block;
}

.list-section .list li .col .file-size {
	font-size: 0.8rem;
	margin-top: 3px;
	color: #333;
}

.list-section .list li .col i {
	color: var(--primary-color);
	font-size: 24px;
	position: relative;
	left: 50%;
	top: 50%;
	transform: translate(-50%, -50%);
	padding: 8px;
	margin-top: 50%;
}

.btns {
	display: flex;
	justify-content: center;
	align-items: center;
	flex-direction: row;
}


.multiselect {
	border: 1px solid #ccc;
	border-radius: 4px;
	display: block;
	width: 100%;
	padding: 0.5rem;
	height: auto;
	overflow: auto;
}
</style>
