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
import accordionData from './QA.json';

export default {
	components: {
		QA_Item
	},
	data() {
		return {
			accordionItems: accordionData
		};
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
}
</style>