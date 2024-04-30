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
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import { AgGridVue } from "ag-grid-vue3";
import axios from 'axios';

export default {
	name: 'JobTitles',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			titles: [],
			columnDefs: [
				{ field: 'description', headerName: 'Description', flex: 2 },
				{ field: 'requirements', headerName: 'Requirements', flex: 4 },
				{ field: 'minPay', headerName: 'Min Pay', flex: 1 },
				{ field: 'maxPay', headerName: 'Max Pay', flex: 1 },
			],
			gridOptions: {
				context: {
					onEdit: this.onEditStudent,
					onDelete: this.onDeleteStudent,
				},
			},
		};
	},
	computed: {
		paginatedData() {
			const start = (this.currentPage - 1) * this.pageSize;
			const end = start + this.pageSize;
			return this.titles.slice(start, end);
		},
		totalPages() {
			return Math.ceil(this.titles.length / this.pageSize);
		}
	},
	methods: {
		onGridReady(params) {
			this.gridApi = params.api;
			this.gridColumnApi = params.columnApi;
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
		async loadTitles() {
			try {
				const res = await axios.get('https://localhost:44303/api/JopTitles');
				if (res.status === 200) {
					this.titles = res.data;
				}
			} catch (err) {
				console.error(err);
			}
		},
	},
	mounted() {
		this.loadTitles();
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