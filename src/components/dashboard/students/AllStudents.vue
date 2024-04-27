<template>
	<div class="students-page">
		<h1>All Students</h1>
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
	name: 'AllStudents',
	components: {
		AgGridVue,
	},
	data() {
		return {
			currentPage: 1,
			pageSize: 25,
			students: [],
			columnDefs: [
				{ field: 'studentId', headerName: 'Student ID', flex: 2 },
				{ field: 'name', headerName: 'Name', flex: 3 },
				{ field: 'grade', headerName: 'Grade', flex: 1 },
				{ field: 'gpa', headerName: 'GPA', flex: 1 },
				{ field: 'areaOfStudy', headerName: 'Area of Study', flex: 3 },
				{ field: 'ntid', headerName: 'NTID', flex: 2 },
				{ field: 'email', headerName: 'Email', flex: 3 },
				{ field: 'phoneNumber', headerName: 'Phone Number', flex: 2 }
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
		async loadStudents() {
			try {
				const res = await axios.get('https://localhost:44303/GetAllStudents');
				if (res.status === 200) {
					this.students = res.data;
					console.log("Students: ", res.data);
					console.log("Students: ", this.students);
				}
			} catch (err) {
				console.error(err);
			}
		},
		onEditStudent(studentData) {
			console.log("Edit student: ", studentData);
			// Implement your edit logic here
		},
		onDeleteStudent(studentData) {
			console.log("Delete student: ", studentData);
			// Implement your delete logic here
		}
	},
	mounted() {
		this.loadStudents();
		console.log(document.querySelectorAll("ag-row"))
		document.querySelectorAll(".ag-row").forEach(el => {
			el.addEventListener("click", () => {
				const selectedRows = this.gridApi.getSelectedRows();
				console.log("Selected rows: ", selectedRows);
			}
			)
		})
	}
}
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
