<template>
	<div class="p-4" style="height: 600px; width: 100%;">
		<button @click="downloadTimetableAsPDF" class="btn btn-primary mb-2">Download Timetable as PDF</button>
		<button @click="showAddMeetingModal = true" class="btn btn-primary" data-bs-toggle="modal"
			data-bs-target="#addMeetingModal">Add Meeting</button>
		<ag-grid-vue :columnDefs="columnDefs" :rowData="rowData" class="ag-theme-quartz" :defaultColDef="defaultColDef"
			:domLayout="'autoHeight'" rowSelection="multiple"></ag-grid-vue>

		<!-- Add Meeting Modal -->
		<!-- <div v-if="showAddMeetingModal" class="modal fade modal-xl" id="addMeetingModal" data-bs-backdrop="static"
			data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
			<div class="modal-content">
				<div class="modal-header">
					<h1 class="modal-title fs-5" id="staticBackdropLabel">Add New Meeting</h1>
					<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
				</div>
				<div class="modal-body">
					<ag-grid-vue :columnDefs="courseColumnDefs" :rowData="availableCourses" class="ag-theme-quartz"
						:defaultColDef="{ resizable: true, sortable: true }" :domLayout="'autoHeight'"
						@grid-ready="onGridReady"></ag-grid-vue>
					<div class="room-selection">
						<label for="roomSelect">Select Room:</label>
						<select id="roomSelect" v-model="selectedRoom" @change="fetchRoomDetails" class="form-control">
							<option v-for="room in rooms" :key="room.id" :value="room.id">{{ room.name }}</option>
						</select>
					</div>
					<div class="doctor-selection">
						<label for="doctorSelect">Select Doctor:</label>
						<select id="doctorSelect" v-model="selectedDoctorId" class="form-control">
							<option v-for="doctor in doctors" :key="doctor.id" :value="doctor.id">{{ doctor.name }}
							</option>
						</select>
					</div>
				</div>
				<div class="modal-footer">
					<button @click="addCourseToSchedule" class="btn btn-success">Add Course</button>
					<button @click="showAddMeetingModal = false" class="btn btn-secondary">Close</button>
				</div>
			</div>
		</div> -->






		<div class="modal fade" id="addMeetingModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
			aria-labelledby="staticBackdropLabel" aria-hidden="true">
			<div class="modal-dialog modal-xl">
				<div class="modal-content">
					<div class="modal-header">
						<h1 class="modal-title fs-5" id="staticBackdropLabel">Add New Meeting</h1>
						<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
					</div>
					<div class="modal-body">
						<ag-grid-vue :columnDefs="courseColumnDefs" :rowData="availableCourses" class="ag-theme-quartz"
							:defaultColDef="{ resizable: true, sortable: true }" :domLayout="'autoHeight'"
							@grid-ready="onGridReady"></ag-grid-vue>
						<div class="room-selection">
							<label for="roomSelect">Select Room:</label>
							<select id="roomSelect" v-model="selectedRoom" @change="fetchRoomDetails"
								class="form-control">
								<option v-for="room in rooms" :key="room.id" :value="room.id">{{ room.name }}</option>
							</select>
						</div>
						<div class="doctor-selection">
							<label for="doctorSelect">Select Doctor:</label>
							<select id="doctorSelect" v-model="selectedDoctorId" class="form-control">
								<option v-for="doctor in doctors" :key="doctor.id" :value="doctor.id">{{ doctor.name }}
								</option>
							</select>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-success">Add Course</button>
						<button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
import { AgGridVue } from "ag-grid-vue3";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import axios from 'axios';
import jsPDF from "jspdf";
import "jspdf-autotable";

export default {
	name: 'TimeTable',
	components: {
		AgGridVue
	},
	data() {
		return {
			columnDefs: [
				{ headerName: "Time", field: "time", flex: 1 },
				{ headerName: "Course Code", field: "courseCode", flex: 1 },
				{ headerName: "Room", field: "roomCode", flex: 1 },
				{ headerName: "Doctor Name", field: "doctorName", flex: 1 },
			],
			courseColumnDefs: [
				{ headerName: "Course Code", field: "code", flex: 1 },
				{ headerName: "Name", field: "name", flex: 2 },
				{ headerName: "Credits", field: "credits", flex: 1 },
				{
					headerName: "Add", field: "", cellRenderer: function (params) {
						return `<div><button clas="btn btn-success" (click)="${console.log(params.data)}">Click</button></div>`
					}
				}
			],
			rowData: [],
			availableCourses: [
				{ id: 1, name: 'Advanced Mathematics', credits: 3, code: 'AM101' },
				{ id: 2, name: 'Modern Physics', credits: 8, code: 'MP202' },
			],
			showAddMeetingModal: false,
			selectedRoom: '',
			selectedDoctorId: '',
			buildings: [],
			rooms: [],
			doctors: [],
		};
	},
	methods: {
		downloadTimetableAsPDF() {
			const doc = new jsPDF();
			doc.autoTable({
				head: [['Time', 'Course Code', 'Room', 'Doctor Name']],
				body: this.rowData.map(row => [row.time, row.courseCode, row.roomCode, row.doctorName]),
			});
			doc.save('timetable.pdf');
		},
		addCourseToSchedule() {
			// Validate room and doctor selection
			if (!this.selectedRoom || !this.selectedDoctorId) {
				alert("Please select both a room and a doctor.");
				return;
			}
			// Proceed to add the course to the schedule
			alert(`Adding course with Room: ${this.selectedRoom} and Doctor ID: ${this.selectedDoctorId}`);
			// Clear selections
			this.showAddMeetingModal = false;
			this.selectedRoom = '';
			this.selectedDoctorId = '';
		},
		fetchRoomDetails() {
			// API call to fetch room details
			console.log('Fetching details for room', this.selectedRoom);
		},
		fetchBuildings() {
			axios.get('http://localhost:3000/buildings')
				.then(response => {
					this.buildings = response.data.buildings;
					this.rooms = this.buildings.map(b => b.rooms).flat(); // Flatten rooms array
				})
				.catch(error => {
					console.error('Error fetching buildings:', error);
				});
		},
		fetchDoctors() {
			// Simulate fetching doctors
			this.doctors = [
				{ id: 'doc1', name: 'Dr. Alice' },
				{ id: 'doc2', name: 'Dr. Bob' },
			];
		},
	},
	mounted() {
		this.fetchBuildings();
		this.fetchDoctors();
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
	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
}

.modal-overlay {
	width: 100%;
	position: fixed;
	top: 50%;
	left: 50%;
	transform: translate(-50%, -50%);
	background-color: white;
	padding: 20px;
	border-radius: 5px;
	width: 300px;
}

.modal-content {
	width: 100%;
	display: flex;
	flex-direction: column;
}

.close-btn {
	cursor: pointer;
	position: absolute;
	top: 10px;
	right: 10px;
}

.form-control {
	width: 100%;
	padding: 8px;
	margin-bottom: 10px;
}

.btn {
	padding: 10px 20px;
	margin-right: 10px;
	cursor: pointer;
	background-color: #007bff;
	color: white;
	border: none;
	border-radius: 5px;
}

.btn:hover {
	background-color: #0056b3;
}
</style>
