<template>
	<div class="article-detail">
		<!-- Your code goes here -->
		<div class="article-content">
			<div class="article-banner" :style="{ backgroundImage: 'url(' + article.coverImage + ')' }">
				<div class="article-overlay"></div>
				<div class="article-info">
					<h3 class="article-title">{{ article.title }}</h3>
					<div class="article-tags">
						<small class="tag" v-for="tag in article.categories" :key="tag">{{ tag }}</small>
					</div>
				</div>
				<div class="article-footer">
					<span class="article-date">{{ formatDate(article.date) }}</span>
					<span class="article-author">{{ article.author }}</span>
				</div>
			</div>
			<p class="articale p-2">
				{{ article.content }}
			</p>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'ArticleDetail',
	props: {
		id: {
			required: true,
			type: Number
		}
	},
	async mounted() {
		await this.getArticle();
	},
	data() {
		return {
			article: {},
		};
	},
	methods: {
		async getArticle() {
			try {
				const res = await axios.get(`http://localhost:3000/articles/${this.id}`);
				this.article = res.data;
			} catch (error) {
				console.error("Error fetching article", error);
			}
		},
		formatDate(date) {
			if (!date) return '';
			return new Date(date).toLocaleDateString();
		}
	},
};
</script>

<style scoped>
.article-banner {
	background-size: cover;
	background-position: center;
	width: 100%;
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
	z-index: 1;
}

.article-info {
	position: relative;
	z-index: 2;
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

.article-footer {
	display: flex;
	justify-content: flex-end;
	align-items: center;
	gap: 10px;
	position: absolute;
	right: 10px;
	bottom: 10px;
	z-index: 2;
}

.article-date,
.article-author {
	background: rgba(0, 0, 0, 0.5);
	padding: 2px 8px;
	border-radius: 10px;
}
</style>
