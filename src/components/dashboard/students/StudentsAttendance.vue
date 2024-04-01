<template>
	<div>
		<h1>All Students Attendance</h1>
		<ag-grid-vue class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="paginatedData" @grid-ready="onGridReady"
			rowSelection="multiple" :domLayout="'autoHeight'">
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

export default {
	name: 'StudentsAttendance',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			students: this.loadAttendanceRecords(), // Adjusted to reflect the loading of attendance records
			columnDefs: [
				{ headerName: "Student ID", field: "studentId", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Name", field: "name", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Date", field: "date", flex: 1, filter: 'agTextColumnFilter' },
				{ headerName: "Course", field: "course", flex: 1 },
			],
		};
	},
	computed: {
		paginatedData() {
			const start = (this.currentPage - 1) * this.pageSize;
			const end = start + this.pageSize;
			return this.students.slice(start, end);
		},
		totalPages() {
			return Math.ceil(this.students.length / this.pageSize);
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
		loadAttendanceRecords() {
			return new Array(100).fill(null).map((_, index) => ({
				studentId: `S${1000 + index}`,
				name: `Student ${index + 1}`,
				date: new Date().toISOString().split('T')[0], // Using current date for simplicity
				course: `Course ${Math.ceil(Math.random() * 5)}`,
			}));
		},
	},
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
