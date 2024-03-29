<template>
	<div class="courses-registration">
		<h3>Courses Registration</h3>
		<ag-grid-vue style="width: 100%; height: fit-content;" class="ag-theme-quartz" :columnDefs="columnDefs"
			:rowData="rowData" :domLayout="'autoHeight'" :frameworkComponents="frameworkComponents"></ag-grid-vue>
	</div>
</template>

<script>
import { AgGridVue } from 'ag-grid-vue3';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import ActionRenderer from './ActionRenderer.vue'; // Ensure this path is correct

export default {
	name: 'CoursesRegistration',
	components: {
		AgGridVue,
	},
	data() {
		return {
			columnDefs: [
				{ headerName: 'Course Code', field: 'code', flex: 1 },
				{ headerName: 'Credit Hours', field: 'creditHours', flex: 1 },
				{ headerName: 'Weekly Lecture Times', field: 'lectureTimes', flex: 2 },
				{
					headerName: 'Action',
					field: 'isRegistered',
					cellRenderer: ActionRenderer,
					flex: 1,
					cellRendererParams: {
						clicked: function (field) {
							alert(`${field} was clicked`);
						}
					},
				},
			],
			rowData: [
				// Sample data - replace with your dynamic data
				{ code: 'CS101', creditHours: 4, lectureTimes: 'Mon 10:00-12:00, Wed 10:00-12:00', isRegistered: false },
				{ code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				{ code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				{ code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
				{ code: 'CS102', creditHours: 3, lectureTimes: 'Tue 14:00-16:00, Thu 14:00-16:00', isRegistered: true },
			],
			frameworkComponents: {
				actionRenderer: ActionRenderer,
			},
		};
	},
};
</script>

<style scoped></style>
