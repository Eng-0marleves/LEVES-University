<template>
	<button class="edit-btn btn btn-primary me-2" @click="onEditBook">Edit</button>
</template>

<script>
export default {
	name: "EditButton",
	props: {
		bookId: Number
	},
	methods: {
		onEditBook() {
			console.log('Edit Book ID:', this.$props.bookId);
			// Implement edit logic here (e.g., emit event with bookId)
			this.$emit('editBook', this.bookId); // Emit event with bookId
		}
	}
};
</script>

<style scoped>
/* Add your button styles here if needed */
</style>
