<template>
	<div class="students-page">
		<h1>All Students</h1>
		<ag-grid-vue class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="paginatedData"
			:frameworkComponents="frameworkComponents" @grid-ready="onGridReady" rowSelection="multiple"
			:domLayout="'autoHeight'">
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
import ActionRenderer from './ActionRenderer.vue'; // Adjust the path as necessary

export default {
	name: 'AllStudents',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			students: [], // This will hold the fetched students data
			columnDefs: [
				{ headerName: "Select", checkboxSelection: true, headerCheckboxSelection: true, flex: 2 },
				{ headerName: "Student ID", field: "studentId", flex: 2, filter: 'agTextColumnFilter' },
				{ headerName: "Name", field: "name", flex: 2 },
				{ headerName: "Department", field: "department", flex: 2 },
				{ headerName: "Mobile", field: "mobile", flex: 2, filter: 'agTextColumnFilter' },
				{ headerName: "Email", field: "email", flex: 2, filter: 'agTextColumnFilter' },
				{
					headerName: "Actions",
					cellRenderer: ActionRenderer,
					editable: false,
					colId: "action",
					width: 150,
					flex: 2
				},
			],
			frameworkComponents: {
				actionRenderer: ActionRenderer,
			},
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
		onGridReady() {
			this.loadStudents();
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
		loadStudents() {
			this.students = new Array(100).fill(null).map((_, index) => ({
				studentId: index + 1,
				name: `Student ${index + 1}`,
				department: 'Engineering',
				mobile: `123-456-789${index}`,
				email: `student${index}@example.com`
			}));
		}
	}
};
</script>

<style scoped>
.ag-theme-quartz {
	width: 100%;
	height: 100%;
	margin-top: 24px;
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
