<template>
	<div class="material">

		<MaterialControllers />

		<div class="title">
			<h3>Folders</h3>
			<div class="line"></div>
		</div>

		<MaterialFolders />

		<div class="title">
			<h3>Videos</h3>
			<div class="line"></div>
		</div>

		<MaterialVideos />

		<div class="title">
			<h3>Files</h3>
			<div class="line"></div>
		</div>

		<MaterialFiles />

	</div>
</template>

<script>
import MaterialControllers from '@/components/courses/material/MaterialControllers.vue';
import MaterialFolders from '@/components/courses/material/folders/MaterialFolders.vue';
import MaterialVideos from '@/components/courses/material/videos/MaterialVideos.vue';
import MaterialFiles from '@/components/courses/material/files/MaterialFiles.vue';

export default {
	name: 'CourseMaterial',
	components: {
		MaterialControllers,
		MaterialFolders,
		MaterialVideos,
		MaterialFiles
	},
	data() {
		return {
			// Your data properties here
		};
	},
	methods: {
		// Your methods here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
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
