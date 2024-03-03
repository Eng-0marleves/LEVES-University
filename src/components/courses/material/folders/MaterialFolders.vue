<template>
	<div class="material-folders">
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
		<MaterialFolder />
	</div>
</template>

<script>
import MaterialFolder from '@/components/courses/material/folders/MaterialFolder.vue';

export default {
	name: 'MaterialFolders',
	components: {
		MaterialFolder
	},
	data() {
		return {
			// Your data here
		};
	},
	methods: {
		// Your methods here
	},
	computed: {
		// Your computed properties here
	},
};
</script>

<style scoped>
.material-folders {
	display: flex;
	align-items: center;
	flex-wrap: wrap;
	gap: 64px;
	margin-top: 24px;
}
</style>
