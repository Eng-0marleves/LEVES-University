<template>
	<div class="search-wrapper">
		<input type="text" v-model="search" placeholder="Search..." />
		<button type="button" class="btn normal" @click="handleSearch">Search</button>
	</div>
</template>

<script>
export default {
	name: "SearchBar",
	data() {
		return {
			search: ''
		};
	},
	methods: {
		handleSearch() {
			this.$emit('search', this.search);
		}
	}
};
</script>

<style scoped>
.search-wrapper {
	width: 300px;
	display: flex;
	align-items: center;
	gap: 0px;
	/* margin: 16px auto; */
}

.search-wrapper input {
	background: var(--white-color);
	padding: 7px;
	font-size: 16px;
}

.search-wrapper button {
	border-radius: 0px;
}
</style>
