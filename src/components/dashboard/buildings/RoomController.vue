<template>
	<span>
		<button @click="onEdit">Edit</button>
		<button @click="onDelete">Delete</button>
		<button @click="onAdd">Add</button>
	</span>
</template>

<script>
export default {
	name: "RoomController",
	/* eslint-disable */
	props: {
		data: Object,
		onEdit: Function,
		onDelete: Function,
		onAdd: Function,
	},
	methods: {
		onEdit() {
			if (this.onEdit) this.onEdit(this.data.id);
		},
		onDelete() {
			if (this.onDelete) this.onDelete(this.data.id);
		},
		onAdd() {
			if (this.onAdd) this.onAdd(this.data.buildingId);
		},
	},
};
</script>
