<template>
	<div class="folder">
		<i class="fas fa-folder-open"></i>
		<p>Folder</p>
	</div>
</template>

<script>
export default {
	name: 'MaterialFolder',
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
	},
};
</script>

<style scoped>
.folder {
	display: flex;
	align-items: center;
	gap: 8px;
	color: #fff;
	font-weight: bold;
	background-color: var(--primary-color);
	width: calc(8 * 22px);
	padding: 8px;
	transition: var(--transition);
	border-radius: 5px;
	cursor: pointer;
}

.folder:hover {
	box-shadow: 0 0 16px rgba(0, 0, 0, 0.2);
}
</style>
