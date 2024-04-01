<template>
	<div class="library-dashboard">
		<h1>Books Dashboard</h1>

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

export default {
	name: 'LibraryDashboard',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			books: [],
			columnDefs: [
				{ headerName: "", checkboxSelection: true, headerCheckboxSelection: true, width: 30 },
				{ headerName: "Title", field: "title", flex: 2, filter: 'agTextColumnFilter' },
				{ headerName: "Author", field: "author", flex: 2, filter: 'agTextColumnFilter' },
				{ headerName: "ISBN", field: "isbn", flex: 1 },
				{ headerName: "Categories", field: "categories", flex: 2, cellRenderer: params => params.value.join(', ') },
				{ headerName: "Rating", field: "rating", flex: 1 },
				{
					headerName: "File",
					field: "file",
					cellRenderer: params => `<a href="${params.value}" target="_blank"><i class="fa fa-download"></i></a>`,
					width: 90,
				},
				{
					headerName: "Actions",
					cellRenderer: params => `<button class="edit-btn btn btn-primary me-2" @click="onEditBook(${params.data.id})">Edit</button>
									 <button class="btn btn-danger" @click="onDeleteBook(${params.data.id})">Delete</button>`,
					cellRendererParams: {
						onEditBook: this.onEditBook,
						onDeleteBook: this.onDeleteBook
					},
					width: 200,
				},
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
		onGridReady(params) {
			this.gridApi = params.api;
			this.gridColumnApi = params.columnApi;
			this.loadBooks();
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
				const response = await axios.get('http://localhost:3000/books');
				this.books = response.data;
			} catch (error) {
				console.error('Error fetching books:', error);
			}
		},
		onEditBook(bookId) {
			console.log("Edit Book ID:", bookId);
			// Implement edit logic here
		},
		onDeleteBook(bookId) {
			console.log("Delete Book ID:", bookId);
			// Implement delete logic here
		},
		mounted() {
			console.log("wd")
			/* eslint-disable */
			documnet.querySelectorAll('.edit-btn').forEach(btn => {
				btn.addEventListener('click', () => {
					console.log('Edit button clicked');
				});
			});
			console.log(documnet.querySelectorAll('.edit-btn'))
		}
	}
};
</script>

<style scoped>
.library-dashboard {
	padding: 16px;
}

.ag-theme-quartz {
	width: 100%;
	height: auto;

	--ag-borders: none;
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;
	--ag-borders: none;

	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
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
