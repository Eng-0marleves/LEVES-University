<template>
	<div class="course-catalog">
		<h2 class="mb-4">Semester Course Management</h2>

		<div class="current-courses">
			<!-- <h3>Assigned Courses</h3> -->
			<ag-grid-vue class="ag-theme-quartz" :columnDefs="currentCourseDefs" :rowData="currentCoursesSchedules"
				:gridOptions="currentGridOptions" @grid-ready="onCurrentGridReady" style="width: 100%; height: 500px;">
			</ag-grid-vue>
		</div>


		<button v-if="!isSemesterHasEnded" @click="showAddCourses = !showAddCourses" class="btn normal mt-4 mb-2">
			{{ showAddCourses ? 'Hide Form' : 'Add Course Lecture' }}
		</button>

		<div v-if="showAddCourses && !isSemesterHasEnded" class="schedule-form">
			<form @submit.prevent="submitCourseSchedule">
				<fieldset>
					<legend>{{ editingSemester ? 'Edit Semester' : 'New Semester Details' }}</legend>
					<div class="form-group">
						<label for="courseCode">Course Code:</label>
						<input id="courseCode" v-model="newSchedule.courseCode" required>
					</div>
					<div class="form-group">
						<label for="roomCode">Room Code:</label>
						<input id="roomCode" v-model="newSchedule.roomCode" required>
					</div>
					<div class="form-group">
						<label for="doctorName">Doctor ID:</label>
						<input id="doctorName" v-model="newSchedule.doctorName" required>
					</div>
					<div class="form-group">
						<label for="from">From:</label>
						<input type="time" id="from" v-model="newSchedule.from" required>
					</div>
					<div class="form-group">
						<label for="to">To:</label>
						<input type="time" id="to" v-model="newSchedule.to" required>
					</div>
					<div class="form-group">
						<label for="day">Day:</label>
						<select id="day" v-model="newSchedule.day" required>
							<option v-for="(day, index) in daysOfWeek" :key="index" :value="day.value">{{ day.label }}
							</option>
						</select>
					</div>
					<div class="form-actions">
						<button type="submit" class="btn btn-success me-3">Submit</button>
						<button @click="toggleAddSemester" class="btn btn-danger">Cancel</button>
					</div>
				</fieldset>
			</form>
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
			currentCoursesSchedules: [],
			showAddCourses: false,
			searchQuery: '',
			isSemesterHasEnded: true,
			semester: {},
			currentCourseDefs: [
				{ headerName: 'Course Code', field: 'courseCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Doctor Name', field: 'doctorName', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Room Code', field: 'roomCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'From', field: 'from', flex: 1 },
				{ headerName: 'To', field: 'to', flex: 1 },
				// { headerName: 'Remove', field: 'id', cellRenderer: this.renderRemoveButton, cellRendererParams: { component: this }, hide: !this.isSemesterHasEnded }
			],
			currentGridOptions: null,
			availableGridOptions: null,
			newSchedule: {
				courseCode: "",
				roomCode: "",
				doctorName: "",
				from: "",
				to: "",
				day: ""
			},
			daysOfWeek: [
				{ label: 'Sunday', value: "Sunday" },
				{ label: 'Monday', value: "Monday" },
				{ label: 'Tuesday', value: "Tuesday" },
				{ label: 'Wednesday', value: "Wednesday" },
				{ label: 'Thursday', value: "Thursday" },
				{ label: 'Friday', value: "Friday" },
				{ label: 'Saturday', value: "Saturday" }
			]
		};
	},
	methods: {
		onCurrentGridReady(params) {
			this.currentGridOptions = params.api;
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
		async getSemester() {
			try {
				const response = await axios.get('https://localhost:44303/CurrentSemester');
				if (response.status === 200) {
					this.semester = response.data;
					this.isSemesterHasEnded = new Date(this.semester.enrollmentEndDate) > new Date();
					console.log(new Date(this.semester.enrollmentEndDate) > new Date())
				}
			} catch (error) {
				console.error(error);
			}
		},
		async getSemesterCoursesSchedules() {
			try {
				const response = await axios.get("https://localhost:44303/api/CourseSchedule");
				if (response.status === 200) {
					this.currentCoursesSchedules = response.data;
					console.log(this.currentCoursesSchedules)
				}
			} catch (error) {
				console.error(error);
			}
		},
		async submitCourseSchedule() {
			const newSchedule = {
				courseCode: this.newSchedule.courseCode,
				roomCode: this.newSchedule.roomCode,
				doctorName: this.newSchedule.doctorName,
				from: this.newSchedule.from,
				to: this.newSchedule.to,
				day: this.newSchedule.day
			};

			try {
				console.log(newSchedule)
				const response = await axios.post('https://localhost:44303/api/CourseSchedule', newSchedule);
				if (response.status === 201) {
					Swal.fire({
						icon: 'success',
						title: 'Success!',
						text: 'Course schedule added successfully.'
					});
					// Reset form data after successful submission
					this.newSchedule = {
						courseCode: '',
						roomCode: '',
						doctorName: '',
						from: '',
						to: '',
						day: ''
					};
					// Refresh course schedules after adding a new one
					this.getSemesterCoursesSchedules();
				}
			} catch (error) {
				Swal.fire({
					icon: 'error',
					title: 'Error!',
					text: 'Failed to add course schedule. Please try again later.'
				});
				console.error(error);
			}
		}

	},
	mounted() {
		this.getSemester();
		this.getSemesterCoursesSchedules();
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

.schedule-form {
	background: white;
	padding: 15px;
	margin-bottom: 20px;
	border-radius: 8px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
	margin-bottom: .5rem;
}

.form-group input {
	width: 100%;
	padding: .375rem .75rem;
	border: 1px solid #ced4da;
	border-radius: .25rem;
}

.form-actions {
	text-align: right;
}

.btn {
	padding: 10px 15px;
	border: none;
	border-radius: 5px;
	cursor: pointer;
	font-size: 16px;
	transition: background-color 0.3s ease;
}

.btn-primary {
	background-color: #007bff;
	color: white;
}

.btn-secondary {
	background-color: #6c757d;
	color: white;
}

.btn-success {
	background-color: #28a745;
	color: white;
}

.btn:hover {
	opacity: 0.9;
}
</style>
