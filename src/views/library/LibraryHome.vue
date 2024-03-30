<template>
	<div class="library-home">
		<HomeCarousel />

		<div class="new-books mt-5">
			<h2>New Books</h2>
			<div class="books-conatiner">
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
			</div>
		</div>

		<div class="all-books mt-5">
			<h2>All Books</h2>
			<div class="books-conatiner">
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
				<BookCard title="title" author="author" cover="https://i.huffpost.com/gen/1039678/original.jpg" />
			</div>
		</div>
	</div>
</template>

<script>
import HomeCarousel from '@/components/library/HomeCarousel.vue';
import BookCard from '@/components/library/BookCard.vue';

export default {
	name: 'LibraryHome',
	data() {
		return {
			// Your data goes here
		};
	},
	components: {
		HomeCarousel,
		BookCard
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	created() {
		// Code to run when the component is created
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