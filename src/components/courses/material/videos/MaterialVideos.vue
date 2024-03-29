<template>
	<div class="material-videos">
		<MaterialVideo v-for="video in videos" :key="video.id" :id="video.id" :src="video.src" :name="video.name"
			:cover="video.cover" />
	</div>
</template>

<script>
import MaterialVideo from './MaterialVideo.vue';

export default {
	name: 'MaterialVideos',
	components: {
		MaterialVideo
	},
	data() {
		return {
			// Your data properties go here
		};
	},
	props: {
		videos: {
			type: Array,
			required: true
		}
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	}
};
</script>

<style scoped>
.material-videos {
	display: flex;
	align-items: center;
	flex-wrap: wrap;
	gap: 32px;
	margin-top: 24px;
}
</style>
