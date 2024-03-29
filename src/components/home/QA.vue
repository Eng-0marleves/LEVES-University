<template>
	<div class="qa-container">
		<div class="title mb-3">
			<h3>FREQUENTLY ASKED QUESTIONS</h3>
		</div>
		<QA_Item :items="accordionItems" />
	</div>
</template>

<script>
import QA_Item from './QA_Item.vue';
import axios from 'axios';

export default {
	components: {
		QA_Item
	},
	data() {
		return {
			accordionItems: []
		};
	},
	methods: {
		async getFAQs() {
		}
	},
	async created() {
		console.log('Getting FAQs');
		const res = await axios.get('http://localhost:5062/api/FAQs');
		if (res.status == 200) {
			this.accordionItems = res.data.slice(0, 5);
		}
	}
}
</script>

<style scoped>
.container {
	display: flex;
	justify-content: space-between;
	align-items: center;
	flex-wrap: wrap;
	gap: 64px;
}

@media (max-width: 768px) {
	.container h1 {
		flex: 1;
	}

	.container {
		width: 300px !important;
	}

	.qa-container .title h3 {
		text-align: center !important;
	}
}
</style>