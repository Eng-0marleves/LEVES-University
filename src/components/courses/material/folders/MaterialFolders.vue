<template>
	<div class="material-folders">
		<MaterialFolder v-for="folder in $props.folders" :key="folder.id" :name="folder.name"
			@click="updateIndex(folder.id, folder.name)" />
	</div>
</template>

<script>
import MaterialFolder from '@/components/courses/material/folders/MaterialFolder.vue';

export default {
	name: 'MaterialFolders',
	components: {
		MaterialFolder
	},
	props: {
		folders: {
			type: Array,
			required: true
		}
	},
	data() {
		return {

		};
	},
	methods: {
		updateIndex(index, name) {
			this.$emit('updateIndex', index, name);
		}
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
	gap: 24px;
	margin-top: 24px;
}
</style>
