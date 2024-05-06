<template>
	<div>
		<ag-grid-vue class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="paginatedData"
			:frameworkComponents="frameworkComponents" @grid-ready="onGridReady" rowSelection="multiple"
			:domLayout="'autoHeight'" :context="gridOptions.context">
		</ag-grid-vue>

		<div class="pagination-controls">
			<button @click="prevPage">Previous</button>
			<span>Page {{ currentPage }} of {{ totalPages }}</span>
			<button @click="nextPage">Next</button>
		</div>
	</div>
</template>

<script>
import { AgGridVue } from "ag-grid-vue3";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
	name: 'LibraryBooks',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			books: [],
			columnDefs: [
				{ headerName: "Title", field: "title", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Author", field: "author", flex: 1, filter: 'agTextColumnFilter' },
				{
					headerName: "Image",
					field: "coverImage",
					cellRenderer: params => `<img src="${require('@/assets/Library/Covers/' + params.value)}" alt="${params.data.title}" style="width: 25px; height: auto; object-fit: cover;">`,
					flex: 1
				},
				{ headerName: "Description", field: "description", flex: 3, filter: 'agTextColumnFilter' },
				{ headerName: 'Remove', field: 'id', cellRenderer: this.renderRemoveButton, cellRendererParams: { component: this } },
			],
			gridOptions: {
				context: {
					componentParent: this
				}
			}
		};
	},
	computed: {
		paginatedData() {
			const start = (this.currentPage - 1) * this.pageSize;
			const end = start + this.pageSize;
			return this.books.slice(start, end);
		},
		totalPages() {
			return Math.ceil(this.books.length / this.pageSize);
		}
	},
	methods: {
		func(params) {
			console.log(params)
		},
		onGridReady(params) {
			this.gridApi = params.api;
			this.gridColumnApi = params.columnApi;
			this.loadBooks();
			// this.addEventListenersToButtons();
		},
		nextPage() {
			if (this.currentPage < this.totalPages) {
				this.currentPage++;
			}
		},
		prevPage() {
			if (this.currentPage > 1) {
				this.currentPage--;
			}
		},
		async loadBooks() {
			try {
				const response = await axios.get('https://localhost:44303/GetAllBooks');
				this.books = response.data;
			} catch (error) {
				console.error('Error fetching books:', error);
			}
		},
		addEventListenersToButtons() {
			const editButtons = document.querySelectorAll('.edit-btn');
			const deleteButtons = document.querySelectorAll('.btn-danger');

			editButtons.forEach(button => {
				button.addEventListener('click', () => {
					const bookId = button.getAttribute('data-book-id');
					this.onEditBook(bookId);
				});
			});

			deleteButtons.forEach(button => {
				button.addEventListener('click', () => {
					const bookId = button.getAttribute('data-book-id');
					this.onDeleteBook(bookId);
				});
			});
		},


		renderRemoveButton(params) {
			const button = document.createElement('button');
			button.innerText = 'Remove';
			button.classList.add('btn', 'btn-danger');
			button.onclick = () => this.onDeleteBook(params.data.id);
			return button;
		},
		async onDeleteBook(bookId) {
			try {
				var res = await axios.delete("https://localhost:44303/DeleteBook?id=" + bookId);
				if (res.status === 200) {
					Swal.fire({
						title: "Success",
						text: "Book deleted successfully!",
						icon: "success",
						timer: 1500,
						showConfirmButton: false
					});
					this.loadBooks();
				} else {
					Swal.fire({
						title: "Error",
						text: "Failed to delete book.",
						icon: "error",
					});
				}
			} catch (e) {
				console.error('Error deleting book:', e);
			}
		},
	},
	mounted() {
		this.addEventListenersToButtons();
	}
};
</script>

<style scoped>
.ag-theme-quartz {
	width: 100%;
	height: auto;

	--ag-borders: none;
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;
	--ag-borders: none;

	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
	background-color: var(--white-color);
}

.pagination-controls {
	display: flex;
	justify-content: center;
	align-items: center;
	margin-top: 20px;
}

.pagination-controls button {
	margin: 0 10px;
}
</style>
