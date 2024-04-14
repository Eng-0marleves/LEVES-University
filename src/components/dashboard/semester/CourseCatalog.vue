<template>
	<div class="course-catalog">
		<h2>Semester Course Management</h2>

		<!-- Current Semester Courses -->
		<div class="current-courses">
			<h3>Assigned Courses</h3>
			<ag-grid-vue class="ag-theme-quartz" :columnDefs="currentCourseDefs" :rowData="currentCourses"
				:gridOptions="currentGridOptions" @grid-ready="onCurrentGridReady" style="width: 100%; height: 300px;">
			</ag-grid-vue>
		</div>

		<!-- Button to Add Courses -->
		<button @click="showAddCourses = !showAddCourses" class="btn normal mt-4 mb-2">
			{{ showAddCourses ? 'Hide Available Courses' : 'Add Courses' }}
		</button>

		<!-- Available Courses to Add -->
		<div v-if="showAddCourses" class="available-courses">
			<h3>Available Courses</h3>
			<input type="text" v-model="searchQuery" placeholder="Search courses..." class="form-control mb-2">
			<ag-grid-vue class="ag-theme-quartz" :columnDefs="availableCourseDefs" :rowData="filteredAvailableCourses"
				:gridOptions="availableGridOptions" @grid-ready="onAvailableGridReady"
				style="width: 100%; height: 300px;">
			</ag-grid-vue>
		</div>
	</div>
</template>

<script>
import { AgGridVue } from 'ag-grid-vue3';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";

export default {
	components: {
		AgGridVue
	},
	data() {
		return {
			currentCourses: [],
			availableCourses: [],
			showAddCourses: false,
			searchQuery: '',
			currentCourseDefs: [
				{ headerName: 'ID', field: 'id', flex: 1 },
				{ headerName: 'Name', field: 'name', flex: 3 },
				{ headerName: 'Credits', field: 'credits', flex: 1 },
				{ headerName: 'Remove', field: 'id', cellRenderer: this.renderRemoveButton, cellRendererParams: { component: this } }
			],
			availableCourseDefs: [
				{ headerName: 'ID', field: 'id', flex: 1 },
				{ headerName: 'Name', field: 'name', flex: 3 },
				{ headerName: 'Credits', field: 'credits', flex: 1 },
				{ headerName: 'Add', field: 'id', cellRenderer: this.renderAddButton, cellRendererParams: { component: this } }
			],
			currentGridOptions: null,
			availableGridOptions: null
		};
	},
	computed: {
		filteredAvailableCourses() {
			return this.availableCourses.filter(course => {
				return course.name.toLowerCase().includes(this.searchQuery.toLowerCase()) &&
					(this.selectedDepartment ? course.department === this.selectedDepartment : true);
			});
		}
	},
	methods: {
		onCurrentGridReady(params) {
			this.currentGridOptions = params.api;
			this.loadCurrentCourses();
		},
		onAvailableGridReady(params) {
			this.availableGridOptions = params.api;
			this.loadAvailableCourses();
		},
		loadCurrentCourses() {
			this.currentCourses = [
				{ id: 101, name: 'Calculus I', credits: 4 },
				{ id: 102, name: 'Physics I', credits: 4 }
			];
		},
		loadAvailableCourses() {
			// Fetch available courses here
			this.availableCourses = [
				{ id: 201, name: 'Chemistry I', credits: 4 },
				{ id: 202, name: 'Biology I', credits: 4 }
			];
		},
		addCourseToSemester(courseId) {
			const courseToAdd = this.availableCourses.find(course => course.id === courseId);
			this.currentCourses.push(courseToAdd);
			this.availableCourses = this.availableCourses.filter(course => course.id !== courseId);
			this.availableGridOptions.setRowData(this.availableCourses);
			this.currentGridOptions.setRowData(this.currentCourses);
		},
		removeCourseFromSemester(courseId) {
			const courseToRemove = this.currentCourses.find(course => course.id === courseId);
			this.availableCourses.push(courseToRemove);
			this.currentCourses = this.currentCourses.filter(course => course.id !== courseId);
			this.availableGridOptions.setRowData(this.availableCourses);
			this.currentGridOptions.setRowData(this.currentCourses);
		},
		renderAddButton(params) {
			const button = document.createElement('button');
			button.innerText = 'Add';
			button.classList.add('btn', 'btn-success');
			button.onclick = () => params.context.component.addCourseToSemester(params.value);
			return button;
		},
		renderRemoveButton(params) {
			const button = document.createElement('button');
			button.innerText = 'Remove';
			button.classList.add('btn', 'btn-danger');
			button.onclick = () => params.context.component.removeCourseFromSemester(params.value);
			return button;
		}
	}
};
</script>

<style scoped>
.course-catalog {
	padding: 8px;
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

.course-catalog h2 {
	text-align: center;
}

.search-filter {
	display: flex;
	justify-content: space-between;
	margin-bottom: 20px;
}

.search-filter .form-control {
	margin: 0 10px;
	flex: 1;
}

button {
	cursor: pointer;
}

.modal {
	background-color: white;
	padding: 20px;
	border-radius: 5px;
	box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
	margin-bottom: 0.5rem;
}

.form-group input,
.form-group textarea {
	width: 100%;
	padding: 0.375rem 0.75rem;
	border: 1px solid #ccc;
	border-radius: 0.25rem;
}

.btn {
	padding: 0.5rem 1rem;
	margin-right: 0.5rem;
	cursor: pointer;
	border: none;
	border-radius: 0.25rem;
}

.btn-primary {
	background-color: #007bff;
	color: white;
}

.btn-secondary {
	background-color: #6c757d;
	color: white;
}

.btn:hover {
	opacity: 0.85;
}
</style>
