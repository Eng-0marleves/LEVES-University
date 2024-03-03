<template>
	<div class="material-videos">
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
		<MaterialVideo />
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
	methods: {
		// Your methods go here
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
	gap: 48px;
	margin-top: 24px;
}
</style>
