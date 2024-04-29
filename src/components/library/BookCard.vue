<template>
	<div class="book-card">
		<div class="book-cover">
			<img :src="require('@/assets/Library/Covers/' + cover)" :alt="title" />
		</div>
		<div class="book-info">
			<h2 class="book-title">{{ title }}</h2>
			<p class="book-author">{{ author }}</p>
		</div>
		<button type="button" class="btn" data-bs-toggle="modal"
			:data-bs-target="`#bookBackdrop${bookId}`">Book</button>


		<div class="modal fade" :id="`bookBackdrop${bookId}`" data-bs-backdrop="static" data-bs-keyboard="false"
			tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<h1 class="modal-title fs-5" id="staticBackdropLabel">{{ title }}</h1>
						<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
					</div>
					<div class="modal-body">
						<div class="cover">
							<img :src="require('@/assets/Library/Covers/' + cover)" :alt="title" />
						</div>
						<div class="details">
							<h1>{{ title }}</h1>
							<p>{{ description }}</p>
							<p class="author">{{ author }}</p>
							<button type="button" class="btn normal" @click="downloadBook()">Downoload</button>
						</div>
					</div>
				</div>
			</div>
		</div>

	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'BookCard',
	props: {
		bookId: Number,
		title: String,
		author: String,
		cover: String,
		description: String
	},
	data() {
		return {
		};
	},
	methods: {
		async downloadBook() {
			try {
				const res = await axios.get('https://localhost:44303/GetBookFile?bookId=' + this.$props.bookId, {
					responseType: 'arraybuffer'
				});

				if (res.status === 200) {
					const arrayBuffer = res.data;

					const blob = new Blob([arrayBuffer]);

					const link = document.createElement('a');
					link.href = window.URL.createObjectURL(blob);

					link.setAttribute('download', `${this.$props.title}.pdf`);

					link.click();
				}
			} catch (error) {
				console.error(error);
			}
		}
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

.btn {
	color: var(--white-color);
	background: var(--primary-color);
	width: fit-content;
	margin-left: auto;
	border-radius: 0px;
}

.modal-body {
	width: 100%;
	height: 100%;
	display: flex;
	flex-direction: column;
	align-items: flex-start;
	text-align: left;
	gap: 12px;
}

.modal-body .cover img {
	width: 180px;
	height: 250px;
}

.details {
	display: flex;
	flex-direction: column;
	align-items: flex-start;
	gap: 8px;
}

.author {
	color: #ccc;
	font-size: 24px;
	font-style: italic;
}
</style>
