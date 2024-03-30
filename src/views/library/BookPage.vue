<template>
	<div class="book-page">
		<div class="top">
			<img :src="book.coverImage" alt="Book Cover" />
			<div class="book-info">
				<h1>{{ book.title }}</h1>
				<h3>{{ book.author }}</h3>
				<p>{{ book.description }}</p>
				<button class="btn normal">Download</button>
			</div>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'BookPage',
	data() {
		return {
			book: {}
		};
	},
	methods: {
		async getBook() {
			try {
				const res = await axios.get(`http://localhost:3000/books/${this.$route.params.bookId}`);

				if (res.status === 200) {
					this.book = res.data;
				}
			} catch (error) {
				console.error(error);
			}
		}
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		this.getBook();
	},
};
</script>

<style scoped>
.book-page {
	padding: 16px;
}

.top {
	display: flex;
	gap: 64px;
	align-items: flex-start;
}

.top img {
	width: 300px;
	height: 400px;
	object-fit: cover;
}

.top .book-info {
	display: flex;
	flex-direction: column;
	align-items: flex-start;
	gap: 8px;
	text-align: left;
}
</style>