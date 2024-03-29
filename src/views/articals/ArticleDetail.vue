<template>
	<div class="article-detail">
		<!-- Your code goes here -->
		<div class="article-content">
			{{ $props.id }}
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'ArticleDetail',
	props: {
		id: {
			require: true,
			type: Number
		}
	},
	methods: {
		async getArtical() {
			const res = await axios.get(`http://localhost:3000/articles/${this.id}`);
			if (res.status == 200) {
				this.article = res.data;
			} else {
				console.log("Error fetching article");
			}
		},
	},
	// Plus any additional setup needed for your component
};
</script>

<style scoped>
/* Your styles go here */
</style>