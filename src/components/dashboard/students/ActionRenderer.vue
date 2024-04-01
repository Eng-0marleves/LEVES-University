<template>
	<div class="actions-cell">
		<button class="edit --bs-primary-text-emphasis" @click="onEditClicked">
			<i class="fa-regular fa-pen-to-square "></i>
		</button>
		<button class="delete" @click="onDeleteClicked">
			<i class="fa-solid fa-trash --bs-danger-text-emphasis"></i>
		</button>
	</div>
</template>

<script>
export default {
	name: 'ActionRenderer',
	props: ['data'], // Access row data with this prop
	methods: {
		onEditClicked() {
			// Handle edit
			console.log('Edit clicked', this);
		},
		onDeleteClicked() {
			// Handle delete
			console.log('Delete clicked', this);
		},
	},
};
</script>

<style scoped>
.edit {
	margin-right: 8px;
}

.edit i {
	color: rgb(2, 2, 91);
	font-weight: bold;
	margin-right: 8px;
}

.delete i {
	color: crimson;
}
</style>
