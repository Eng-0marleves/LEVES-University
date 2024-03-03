<template>
	<div class="controllers">
		<div class="add-controllers">
			<button class="add-folder">Add Folder</button>
			<button class="add-file">Add File</button>
		</div>

		<div class="path">
			<router-link class="direcrorty" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="direcrorty" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="direcrorty" to="/courses">Courses</router-link>
			<p>/</p>
			<router-link class="direcrorty" to="/courses">Courses</router-link>
		</div>
	</div>
</template>

<script>
export default {
	name: 'MaterialControllers',
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
.controllers {
	display: flex;
	justify-content: space-between;
	align-items: center;
	width: 100%;
}

.controllers .add-controllers {
	width: 20%;
	display: flex;
	align-items: center;
	gap: 20px;
}

.controllers .path {
	display: flex;
	align-items: center;
	gap: 16px;
}

.controllers .path .direcrorty {
	color: rgb(0, 21, 180);
	text-decoration: none;
}

.controllers .path p {
	color: #000;
}
</style>
