<template>
	<div class="courses-registration">
		<h2 class="mb-4 text-center">Courses Registration</h2>
		<ag-grid-vue style="width: 100%;
            height: fit-content;" class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="rowData"
			:domLayout="'autoHeight'" :frameworkComponents="frameworkComponents">
		</ag-grid-vue>
	</div>
</template>

<script>
import { AgGridVue } from 'ag-grid-vue3';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import ActionRenderer from './ActionRenderer.vue'; // Ensure this path is correct
import axios from 'axios';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';
import Swal from 'sweetalert2';

export default {
	name: 'CoursesRegistration',
	components: {
		AgGridVue,
	},
	data() {
		return {
			columnDefs: [
				{ headerName: 'Course Code', field: 'courseCode', flex: 1 },
				{ headerName: 'Course Name', field: 'courseName', flex: 3 },
				{ headerName: 'Credit Hours', field: 'creditHours', flex: 1 },
				{ headerName: 'Weekly Lecture Times', field: 'date', flex: 3 },
				{
					headerName: 'Action',
					flex: 2,
					cellRenderer: this.renderButton,
					cellRendererParams: { component: this }
				},
			],
			rowData: [
				// Sample data - replace with your dynamic data
				// { code: 'CS101', creditHours: 4, lectureTimes: 'Mon 10:00-12:00, Wed 10:00-12:00', isRegistered: false },
				// { code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				// { code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				// { code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				// { code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
			],
			frameworkComponents: {
				actionRenderer: ActionRenderer,
			},
			userData: {}
		};
	},
	methods: {
		async getData() {
			try {
				const response = await axios.get(`https://localhost:44303/api/Registration/student/availablecourses?studentId=${this.userData.id}`);
				this.rowData = response.data;
				console.log(response.data)
			} catch (error) {
				console.error('Error fetching data:', error);
			}
		},
		renderButton(params) {
			const button = document.createElement('button');

			button.classList.add('btn', 'normal');
			button.style.width = '100%';

			if (params.data.isEnrolled) {
				button.innerText = 'Drop';
				button.onclick = () => this.dropCourse(this.userData.id, params.data.scheduleId);
			} else {
				button.innerText = 'Register';
				button.onclick = () => this.enrollCourse(this.userData.id, params.data.scheduleId);
			}

			return button;
		},
		async enrollCourse(userId, scheduleId) {
			try {
				const response = await axios.post(`https://localhost:44303/api/Registration/student/enroll?studentId=${userId}&courseScheduleId=${scheduleId}`);
				console.log(response.data);
				this.getData();
				this.showAlert('success', 'Course enrolled successfully!');
			} catch (error) {
				console.error('Error enrolling course:', error);
				this.showAlert('error', 'Error enrolling course. Please try again later.');
			}
		},

		async dropCourse(userId, scheduleId) {
			try {
				const response = await axios.post(`https://localhost:44303/api/Registration/student/drop?studentId=${userId}&courseScheduleId=${scheduleId}`);
				console.log(response.data);
				this.getData();
				// Show success alert
				this.showAlert('success', 'Course dropped successfully!');
			} catch (error) {
				console.error('Error dropping course:', error);
				// Show error alert
				this.showAlert('error', 'Error dropping course. Please try again later.');
			}
		},

		showAlert(type, message) {
			Swal.fire({
				icon: type,
				title: message,
				showConfirmButton: false,
				timer: 1500 // Adjust as needed
			});
			this.getData();
		}

	},
	mounted() {
		const authToken = Cookies.get('user-auth-token');
		const decodedToken = jwtDecode(authToken);
		this.userData = decodedToken;
		this.getData();
	}
};
</script>

<style>
/* .register-action {
	width: 100%;
	padding: 6px 12px;
	border: none;
	border-radius: 4px;
	cursor: pointer;
	background-color: #007bff;
	color: white;
}

.register-action:hover {
	background-color: #0056b3;
} */
</style>
