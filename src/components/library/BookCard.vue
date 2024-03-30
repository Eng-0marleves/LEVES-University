<template>
	<div class="book-card">
		<div class="book-cover">
			<img :src="cover" :alt="title" />
		</div>
		<div class="book-info">
			<h2 class="book-title">{{ title }}</h2>
			<p class="book-author">{{ author }}</p>
		</div>
		<button class="btn"><router-link class="router" :to="`library/${$props.bookId}`">View
				Book</router-link></button>
	</div>
</template>

<script>
export default {
	name: 'BookCard',
	props: {
		title: String,
		author: String,
		cover: String,
		bookId: String,
	},
	data() {
		return {
			// Add local component data here if needed
		};
	},
	methods: {
		// Define component methods here if needed
	},
	computed: {
		// Define computed properties here if needed
	},
};
</script>

<style scoped>
.book-card {
	display: flex;
	flex-direction: column;
	width: 200px;
	box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
	overflow: hidden;
	margin: 10px;
	border-radius: 8px;
}

.book-cover img {
	width: 100%;
	height: 300px;
	object-fit: cover;
}

.book-info {
	padding: 8px;
}

.book-title {
	font-size: 16px;
	margin: 10px 0 5px 0;
}

.book-author {
	font-size: 14px;
	color: #666;
	margin: 0;
}

.book-description {
	font-size: 12px;
	color: #888;
	margin-top: 5px;
	overflow: hidden;
	text-overflow: ellipsis;
	display: -webkit-box;
	-webkit-line-clamp: 3;
	/* Limit to 3 lines */
	-webkit-box-orient: vertical;
}

.router {
	color: var(--white-color);
}

.btn {
	background: var(--primary-color);
	width: fit-content;
	margin-left: auto;
	border-radius: 0px;
}
</style>
