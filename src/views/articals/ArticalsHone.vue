<template>
	<div class="filter">
		<SearchBar @search="handleSearch" />
	</div>
	<div class="articles-home">
		<div class="article-card" v-for="article in filteredArticles" :key="article.id"
			:style="{ backgroundImage: 'url(' + article.coverImage + ')' }">
			<div class="article-overlay"></div>
			<div class="article-info">
				<h3 class="article-title">{{ article.title }}</h3>
				<div class="article-tags">
					<small class="tag" v-for="tag in article.categories" :key="tag">{{ tag }}</small>
				</div>
			</div>
			<router-link :to="`/articals/${article.id}`" class="see-article-btn d-flex align-items-center gap-2">
				<p>See Article</p>
				<i class="fas fa-right-long"></i>
			</router-link>
		</div>
	</div>
</template>

<script>
import SearchBar from '@/components/global/SearchBar.vue';
import axios from 'axios';

export default {
	name: 'ArticlesHome',
	data() {
		return {
			articles: [],
			searchQuery: '',
		};
	},
	components: {
		SearchBar,
	},
	computed: {
		filteredArticles() {
			if (!this.searchQuery) return this.articles;
			return this.articles.filter(article => {
				return (
					article.title.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
					article.author.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
					article.categories.some(category =>
						category.toLowerCase().includes(this.searchQuery.toLowerCase())
					)
				);
			});
		},
	},
	methods: {
		async gitArticles() {
			const res = await axios.get("http://localhost:3000/articles");
			if (res.status == 200) {
				this.articles = res.data;
			} else {
				console.log("Error fetching articles");
			}
		},
		handleSearch(query) {
			this.searchQuery = query;
		},
	},
	mounted() {
		this.gitArticles();
	},
};
</script>

<style scoped>
.filter {
	margin: 8px;
	display: flex;
	justify-content: flex-end;
	align-items: center;
}

.articles-home {
	display: flex;
	justify-content: space-around;
	flex-wrap: wrap;
	align-items: flex-start;
	gap: 20px;
	padding: 8px;
}

.article-card {
	background-size: cover;
	background-position: center;
	width: 350px;
	height: 250px;
	position: relative;
	color: #fff;
	display: flex;
	flex-direction: column;
	justify-content: space-between;
}

.article-overlay {
	position: absolute;
	top: 0;
	right: 0;
	bottom: 0;
	left: 0;
	background: rgba(0, 0, 0, 0.5);
	/* Dark overlay, adjust opacity as needed */
	z-index: 1;
	/* Ensure it's above the background image but below text */
}

.article-info {
	position: relative;
	z-index: 2;
	/* Ensure text is above the overlay */
	margin: 8px;
}

.article-title {
	margin: 0;
}

.article-tags {
	display: flex;
	gap: 10px;
}

.tag {
	background: rgba(255, 255, 255, 0.5);
	padding: 0 4px;
	border-radius: 16px;
}

.see-article-btn {
	align-self: flex-end;
	z-index: 2;
	/* Ensure the button is above the overlay */
	padding: 10px 20px;
	background-color: var(--primary-color);
	color: white;
	border: none;
	cursor: pointer;
}

/* @media (max-width: 768px) {
	.articles-home {
		justify-content: center !important;
		align-items: center !important;
	}
} */
</style>
