<template>
	<div class="search-wrapper">
		<input type="text" v-model="search" @input="filterData" placeholder="Search title.." />
	</div>
</template>

<script>
export default {
	name: "SearchBar",
	props: {
		data: Array // Data to be filtered
	},
	data() {
		return {
			search: '' // Search query
		}
	},
	methods: {
		filterData() {
			// Emit an event to pass the filtered data to the parent component
			this.$emit('filtered', this.filter(this.data, this.search));
		},
		filter(data, search) {
			// Filter the data based on the search query
			return data.filter(item => {
				// Use optional chaining to safely access nested properties and methods
				return item.title?.toLowerCase().includes(search.toLowerCase());
			});
		}
	}
}
</script>


<style scoped></style>
