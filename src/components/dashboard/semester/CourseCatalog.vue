<template>
	<div class="course-catalog">
		<h2>Semester Course Management</h2>

		<div class="current-courses">
			<h3>Assigned Courses</h3>
			<ag-grid-vue class="ag-theme-quartz" :columnDefs="currentCourseDefs" :rowData="currentCourses"
				:gridOptions="currentGridOptions" @grid-ready="onCurrentGridReady" style="width: 100%; height: 500px;">
			</ag-grid-vue>
		</div>

		<button @click="showAddCourses = !showAddCourses" class="btn normal mt-4 mb-2">
			{{ showAddCourses ? 'Hide Available Courses' : 'Add Courses' }}
		</button>

		<div v-if="showAddCourses" class="available-courses">
			<h3>Available Courses</h3>
			<!-- <input type="text" v-model="searchQuery" placeholder="Search courses..." class="form-control mb-2"> -->
			<ag-grid-vue class="ag-theme-quartz" :columnDefs="availableCourseDefs" :rowData="availableCourses"
				:gridOptions="availableGridOptions" @grid-ready="onAvailableGridReady"
				style="width: 100%; height: 500px;">
			</ag-grid-vue>
		</div>
	</div>
</template>

<script>
import { AgGridVue } from 'ag-grid-vue3';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import axios from 'axios';
import Swal from 'sweetalert2';

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
			semester: {},
			currentCourseDefs: [
				{ headerName: 'Course Code', field: 'courseCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Course Name', field: 'courseTitle', filter: "PartialMatchFilter", flex: 2 },
				{ headerName: 'Course Description', field: 'courseDescription', flex: 3 },
				{ headerName: 'Credit Hours', field: 'creditHours', flex: 2 },
				{ headerName: 'Remove', field: 'id', cellRenderer: this.renderRemoveButton, cellRendererParams: { component: this } }
			],
			availableCourseDefs: [
				{ headerName: 'Course Code', field: 'courseCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Course Name', field: 'courseTitle', filter: "PartialMatchFilter", flex: 2 },
				{ headerName: 'Course Description', field: 'courseDescription', flex: 3 },
				{ headerName: 'Credit Hours', field: 'creditHours', flex: 2 },
				{ headerName: 'Add', field: 'id', cellRenderer: this.renderAddButton, cellRendererParams: { component: this } }
			],
			currentGridOptions: null,
			availableGridOptions: null
		};
	},
	methods: {
		onCurrentGridReady(params) {
			this.currentGridOptions = params.api;
		},
		onAvailableGridReady(params) {
			this.availableGridOptions = params.api;
		},
		renderAddButton(params) {
			const button = document.createElement('button');
			button.innerText = 'Add';
			button.classList.add('btn', 'btn-success');
			button.onclick = () => this.addCourseToSemester(params.data.courseNumber);
			button.setAttribute('data-course-id', params.value);
			return button;
		},
		renderRemoveButton(params) {
			const button = document.createElement('button');
			button.innerText = 'Remove';
			button.classList.add('btn', 'btn-danger');
			button.onclick = () => this.removeCourseFromSemester(params.data.courseNumber);
			return button;
		},
		async addCourseToSemester(courseId) {
			try {
				const response = await axios.post(`https://localhost:44303/AddSemesterCourse?CourseId=${courseId}`);
				console.log(courseId);
				console.log(response.data);
				if (response.status === 200) {
					Swal.fire({
						title: "Success",
						text: "Course added to semester successfully!",
						icon: "success",
						timer: 1500,
						showConfirmButton: false
					});

					this.getSemesterCourses();
					this.GetUnAvilableCourses();
				} else {
					Swal.fire({
						title: "Error",
						text: "Failed to add course to semester.",
						icon: "error",
					});
				}
			} catch (error) {
				Swal.fire({
					title: "Error",
					text: "An error occurred while adding the course to semester.",
					icon: "error",
				});
				console.error(error);
			}
		},
		async GetUnAvilableCourses() {
			try {
				const response = await axios.get("https://localhost:44303/GetUnAvilableCoursesInSemester");
				if (response.status === 200) {
					this.availableCourses = response.data;
				}
			} catch (error) {
				console.error(error);
			}
		},
		async removeCourseFromSemester(courseId) {
			try {
				const response = await axios.delete(`https://localhost:44303/DeleteSemesterCourse?id=${courseId}`);

				if (response.status === 200) {
					Swal.fire({
						title: "Success",
						text: "Course removed from semester successfully!",
						icon: "success",
						timer: 1500,
						showConfirmButton: false
					});

					this.getSemesterCourses();
					this.GetUnAvilableCourses();
				} else {
					Swal.fire({
						title: "Error",
						text: "Failed to remove course to semester.",
						icon: "error",
					});
				}
			} catch (error) {
				Swal.fire({
					title: "Error",
					text: "An error occurred while removing the course to semester.",
					icon: "error",
				});
				console.error(error);
			}
		},
		async getSemester() {
			try {
				const response = await axios.get('https://localhost:44303/CurrentSemester');
				if (response.status === 200) {
					this.semester = response.data;
				}
			} catch (error) {
				console.error(error);
			}
		},
		async getSemesterCourses() {
			try {
				const response = await axios.get("https://localhost:44303/GetSemesterCourses");
				if (response.status === 200) {
					this.currentCourses = response.data;
				}
			} catch (error) {
				console.error(error);
			}
		},
	},
	mounted() {
		this.getSemester();
		this.getSemesterCourses();
		this.GetUnAvilableCourses();
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

.ag-header-cell-label {
	text-align: center;
	display: flex;
	justify-content: center;
	align-items: center;
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
