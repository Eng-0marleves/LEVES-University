<template>
	<div class="dropdown">
		<button @click="toggleDropdown" class="dropbtn"><i class="fa-solid fa-filter"></i></button>
		<div v-if="dropdownOpen" class="dropdown-content">
			<input type="text" placeholder="Search.." v-model="searchQuery" @input="filterFunction">
			<div v-for="(item, index) in filteredItems" :key="index" class="dropdown-item">
				<input type="checkbox" :id="`checkbox-${index + 1}`" v-model="item.isChecked" @change="emitFilter">
				<label :for="`checkbox-${index + 1}`">{{ item.text }}</label>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'FilterComponent',
	emits: ['filter'],
	data() {
		return {
			dropdownOpen: false,
			searchQuery: '',
			items: [
				{ text: 'About', isChecked: false },
				{ text: 'Base', isChecked: false },
				{ text: 'wd', isChecked: false },
				// Add more items as needed
			],
		};
	},
	computed: {
		filteredItems() {
			return this.items.filter(item =>
				item.text.toUpperCase().includes(this.searchQuery.toUpperCase())
			);
		},
	},
	methods: {
		toggleDropdown() {
			this.dropdownOpen = !this.dropdownOpen;
		},
		filterFunction() {
			// Additional filtering logic if needed
		},
		emitFilter() {
			// Emit an event with the currently selected options
			this.$emit('filter', this.items.filter(item => item.isChecked).map(item => item.text));
		}
	},
};
</script>

<style scoped>
/* .dropbtn {
	background-color: #04AA6D;
	color: white;
	padding: 16px;
	font-size: 16px;
	border: none;
	cursor: pointer;
} */

.dropbtn:hover,
.dropbtn:focus {
	background-color: #3e8e41;
}

.dropdown-content {
	position: absolute;
	right: 0;
	background-color: #fff;
	min-width: 230px;
	overflow: auto;
	border: 1px solid #ddd;
	z-index: 2;
}

.dropdown-item {
	padding: 12px 16px;
	display: flex;
	align-items: center;
	z-index: 3 !important;
}

.dropdown-item label {
	margin-left: 8px;
}
</style>
