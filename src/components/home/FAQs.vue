<template>
	<div class="faqs d-flex flex-column gap-4 align-center">
		<div class="title text-center d-flex flex-column gap-2 align-center">
			<h1>FAQs</h1>
			<p>
				Welcome to our FAQ section! Here, you'll find answers to common questions about our services, products,
				and policies. Feel free to explore and discover valuable information to enhance your experience with us.
			</p>
		</div>

		<div class="controllers d-flex justify-content-between align-center w-100">
			<button class="btn normal">Add Item</button>
			<SearchBar @search="handleSearch" />
		</div>

		<QA_Item class="items" :items="filteredItems" :all="true" />
	</div>
</template>

<script>
import accordionData from '@/components/home/QA.json';
import QA_Item from '@/components/home/QA_Item.vue';
import SearchBar from '../global/SearchBar.vue';

export default {
	name: 'FAQs',
	components: {
		QA_Item,
		SearchBar
	},
	data() {
		return {
			accordionItems: accordionData,
			searchQuery: ''
		};
	},
	computed: {
		filteredItems() {
			if (!this.searchQuery.trim()) {
				return this.accordionItems;
			}
			return this.accordionItems.filter(item => {
				// You can customize the search logic based on your requirements
				return item.header.toLowerCase().includes(this.searchQuery.toLowerCase());
			});
		}
	},
	methods: {
		handleSearch(query) {
			this.searchQuery = query;
		}
	},
	mounted() {
		console.log(this.accordionItems);
	}
};
</script>

<style scoped>
.faqs {
	padding: 16px;
}

.accordion-btn {
	width: 100% !important;
}
</style>
