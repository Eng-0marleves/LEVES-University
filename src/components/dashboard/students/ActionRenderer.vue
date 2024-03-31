<template>
	<div class="actions-cell">
		<button @click="onEditClicked">Edit</button>
		<button @click="onDeleteClicked">Delete</button>
	</div>
</template>

<script>
export default {
	name: 'ActionRenderer',
	props: ['data'], // Access row data with this prop
	methods: {
		onEditClicked() {
			// Handle edit
			console.log('Edit clicked', this.data);
		},
		onDeleteClicked() {
			// Handle delete
			console.log('Delete clicked', this.data);
		},
	},
};
</script>

<style scoped>
/* Styles for your buttons */
</style>
