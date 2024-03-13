<template>
	<div class="material-folders">
		<MaterialFolder v-for="folder in $props.folders" :key="folder.id" :name="folder.name"
			@click="updateIndex(folder.id)" />
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
		updateIndex(index) {
			this.$emit('updateIndex', index);
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
