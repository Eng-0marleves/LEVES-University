<template>
	<div class="library-home">
		<HomeCarousel />

		<div class="new-books mt-5">
			<h2>New Books</h2>
			<div class="books-conatiner">
				<BookCard v-for="(book, i) in books.slice(0, 5)" :key="i" :title="book.title" :author="book.author"
					:cover="book.coverImage" :bookId="book.id" />
			</div>
		</div>

		<div class="all-books mt-5">
			<h2>All Books</h2>
			<div class="books-conatiner">
				<BookCard v-for="(book, i) in books" :key="i" :title="book.title" :author="book.author"
					:cover="book.coverImage" :bookId="book.id" />
			</div>
		</div>
	</div>
</template>

<script>
import HomeCarousel from '@/components/library/HomeCarousel.vue';
import BookCard from '@/components/library/BookCard.vue';
import axios from 'axios';

export default {
	name: 'LibraryHome',
	data() {
		return {
			books: []
		};
	},
	components: {
		HomeCarousel,
		BookCard
	},
	methods: {
		async getBooks() {
			try {
				const res = await axios.get('http://localhost:3000/books');

				if (res.status === 200) {
					this.books = res.data;
				}

			} catch (error) {
				console.error(error);
			}
		}
	},
	computed: {
		// Your computed properties go here
	},
	created() {
		this.getBooks();
	},
};
</script>

<style scoped>
.library-home {
	padding-bottom: 10px;
}

.books-conatiner {
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: wrap;
}

h2 {
	text-align: center;
}
</style>