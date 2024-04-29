<template>
	<div class="add-book-form">
		<h2>Add New Book</h2>
		<form @submit.prevent="submitBook">
			<div class="form-group">
				<label for="title">Book Title:</label>
				<input id="title" v-model="book.Title" required>
			</div>
			<div class="form-group">
				<label for="author">Book Author:</label>
				<input id="author" v-model="book.Author" required>
			</div>
			<div class="form-group">
				<label for="description">Book Description:</label>
				<input id="description" v-model="book.Description" required>
			</div>
			<div class="form-group">
				<label for="cover">Book CoverImage:</label>
				<input id="cover" type="file" accept="image/png, image/gif, image/jpeg"
					v-on:change="handleCoverImageChange" required>
			</div>
			<div class="form-group">
				<label for="firstName">Book File:</label>
				<input type="file" accept="application/pdf" id="firstName" v-on:change="handleFileChange" required>
			</div>
			<button class="btn normal" type="submit">Add Book</button>
		</form>
	</div>
</template>


<script>
import axios from 'axios';

export default {
	name: 'LibrearyAddBook',
	data() {
		return {
			book: {
				Title: '',
				Author: '',
				Description: '',
				CoverImage: null,
				BookFile: null
			},
		};
	},
	methods: {
		async submitBook() {
			try {
				var formData = new FormData();

				formData.append('Title', this.book.Title);
				formData.append('Author', this.book.Author);
				formData.append('Description', this.book.Description);
				formData.append('CoverImage', this.book.CoverImage);
				formData.append('BookFile', this.book.BookFile);

				const response = await axios.post('https://localhost:44303/AddBook', formData);
				if (response.status === 200) {
					console.log('book added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding book:', response);
				}
			} catch (ex) {
				console.error(ex);
				this.resetForm();
			}
		},
		resetForm() {
			this.book = {
				Title: '',
				Author: '',
				Description: '',
				CoverImage: null,
				BookFile: null
			};
		},
		handleFileChange(event) {
			this.book.BookFile = event.target.files[0];
		},
		handleCoverImageChange(event) {
			this.book.CoverImage = event.target.files[0];
		},
	},
	mounted() {
	},
};
</script>

<style scoped>
.add-book-form {
	max-width: 500px;
	margin: auto;
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
}

.form-group input {
	width: 100%;
	padding: 0.375rem 0.75rem;
	border: 1px solid #ced4da;
	border-radius: 0.25rem;
}
</style>