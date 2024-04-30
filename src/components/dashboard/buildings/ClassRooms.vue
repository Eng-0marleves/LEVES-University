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

export default {
	name: 'ClassRooms',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			rooms: [],
			columnDefs: [
				{ headerName: "Code", field: "roomCode", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Max Seating", field: "maxSeating", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Building Name", field: "buildingName", flex: 1, filter: 'agTextColumnFilter' },
			],
			gridOptions: {
				context: {
					componentParent: this
				}
			}
		};
	}, computed: {
		paginatedData() {
			const start = (this.currentPage - 1) * this.pageSize;
			const end = start + this.pageSize;
			return this.rooms.slice(start, end);
		},
		totalPages() {
			return Math.ceil(this.rooms.length / this.pageSize);
		}
	},
	methods: {
		onGridReady(params) {
			this.gridApi = params.api;
			this.gridColumnApi = params.columnApi;
			this.loadBuildings();
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
		async loadBuildings() {
			try {
				const response = await axios.get('https://localhost:44303/api/Buildings/GetAllClassRooms');
				this.rooms = response.data;
				console.log(this.rooms)
			} catch (error) {
				console.error('Error fetching rooms:', error);
			}
		},
	},
	mounted() {

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