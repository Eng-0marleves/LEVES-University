<template>
	<div class="material-files">
		<MaterialFile v-for="file in files" :key="file.id" :name="file.name" :src="file.src" :cover="file.cover" />
	</div>
</template>

<script>
import MaterialFile from './MaterialFile.vue';

export default {
	name: 'MaterialFiles',
	components: {
		MaterialFile
	},
	data() {
		return {
			// Your data properties go here
		};
	},
	props: {
		files: {
			type: Array,
			required: true
		}
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
.material-files {
	display: flex;
	/* justify-content: space-between; */
	align-items: center;
	flex-wrap: wrap;
	gap: 16px;
}
</style>
