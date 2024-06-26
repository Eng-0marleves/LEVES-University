<template>
	<div class="material">
		<CourseOffCanvas />
		<MaterialControllers :currentIndex="currentIndex" :path="path" @changePath="updateIndex" />
		<div v-if="folders.length !== 0" class="title">
			<h3>Folders</h3>
			<div class="line"></div>
		</div>
		<MaterialFolders :folders="folders" @updateIndex="updateIndex" />
		<div v-if="videos.length !== 0" class="title">
			<h3>Videos</h3>
			<div class="line"></div>
		</div>
		<MaterialVideos :videos="videos" />
		<div v-if="files.length !== 0" class="title">
			<h3>Files</h3>
			<div class="line"></div>
		</div>
		<MaterialFiles :files="files" />
	</div>
</template>

<script>
import MaterialControllers from '@/components/courses/material/MaterialControllers.vue';
import MaterialFolders from '@/components/courses/material/folders/MaterialFolders.vue';
import MaterialVideos from '@/components/courses/material/videos/MaterialVideos.vue';
import MaterialFiles from '@/components/courses/material/files/MaterialFiles.vue';
import CourseOffCanvas from '@/components/courses/CourseOffCanvas.vue';
import axios from 'axios';

export default {
	name: 'CourseMaterial',
	components: {
		MaterialControllers,
		MaterialFolders,
		MaterialVideos,
		MaterialFiles,
		CourseOffCanvas,
	},
	data() {
		return {
			folders: [],
			videos: [],
			files: [],
			currentIndex: localStorage.getItem('currentIndex') || '0',
			path: JSON.parse(localStorage.getItem('path')) || [{ index: '0', name: "Home" }],
		};
	},
	methods: {
		async getFolders() {
			try {
				const response = await axios.get(`http://localhost:3000/Folders/?course_code=${this.$route.params.course_code}&&parent_id=${this.currentIndex}`);
				this.folders = response.data;
			} catch (error) {
				console.log(error);
			}
		},
		async getVideos() {
			try {
				const response = await axios.get(`http://localhost:3000/Videos/?course_code=${this.$route.params.course_code}&&parent_id=${this.currentIndex}`);
				this.videos = response.data;
			} catch (error) {
				console.log(error);
			}
		},
		async getFiles() {
			try {
				const response = await axios.get(`http://localhost:3000/Files/?course_code=${this.$route.params.course_code}&&parent_id=${this.currentIndex}`);
				this.files = response.data;
			} catch (error) {
				console.log(error);
			}
		},
		updateIndex(index, name) {
			const position = this.path.findIndex(p => p.index === index);
			if (position === -1) {
				this.path.push({ index, name });
			} else {
				this.path = this.path.slice(0, position + 1);
			}
			this.currentIndex = index;
			localStorage.setItem('currentIndex', index);
			localStorage.setItem('path', JSON.stringify(this.path));
			this.getFolders();
			this.getVideos();
			this.getFiles();
		},
	},
	mounted() {
		this.getFolders();
		this.getVideos();
		this.getFiles();
	},
	watch: {
		currentIndex: {
			handler() {
				this.getFolders();
				this.getVideos();
				this.getFiles();
			},
			immediate: true,
		},
	},
	beforeUnmount() {
		localStorage.removeItem('currentIndex');
		localStorage.removeItem('path');
	},
};
</script>

<style scoped>
.material {
	padding: 16px;
}

.title {
	display: flex;
	align-items: center;
	gap: 16px;
	color: #ccc;
	margin-top: 32px;
	margin-bottom: 16px;
}

.title .line {
	width: 100%;
	height: 3px;
	background: #ccc;
}
</style>
