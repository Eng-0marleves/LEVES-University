<template>
	<div class="study-plan">
		<h2 class="mb-4 text-center">Study plan</h2>

		<ag-grid-vue style="width: 100%;" :style="{ height: height + 'px' }" class="ag-theme-quartz"
			:columnDefs="columnDefs" :rowData="rowData" :gridOptions="gridOptions" v-if="rowData.length"></ag-grid-vue>
	</div>
</template>

<script>
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import { AgGridVue } from "ag-grid-vue3";
import axios from "axios";
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: 'StudyPlan',
	data() {
		return {
			height: null,
			columnDefs: [
				{ headerName: "Course Code", field: "courseCode", flex: 1 },
				{ headerName: "Name", field: "courseName", flex: 2 },
				{ headerName: "Level", field: "courseLevel", flex: 1 },
				{ headerName: "Credit Hours", field: "courseCreditHours", flex: 1 },
				{
					headerName: "Status",
					field: "courseStatus",
					flex: 1,
					cellStyle: params => {
						switch (params.value) {
							case 'Available': return { backgroundColor: 'lightgreen', borderRightColor: '#e2e2e2' };
							case 'Enrolled': return { backgroundColor: 'lightblue', borderRightColor: '#e2e2e2' };
							case 'Completed': return { backgroundColor: 'yellow', borderRightColor: '#e2e2e2' };
							case 'Not Available': return { backgroundColor: 'salmon', borderRightColor: '#e2e2e2' };
							default: return null;
						}
					}
				},
				{ headerName: "Prerequisites", field: "prerequisites", flex: 2 }
			],

			gridOptions: {
				headerHeight: 56
			},
			userData: {},
			rowData: []
		};
	},
	components: {
		AgGridVue,
	},
	methods: {
		async getRows() {
			var res = await axios.get(`https://localhost:44303/api/Registration/student/studyplan?studentId=${this.userData.id}`);

			this.rowData = res.data;
		},
		gridHeight() {
			const rowHeight = 48;
			const headerHeight = 56;
			const numberOfRows = 6;
			this.height = headerHeight + (numberOfRows * rowHeight);
		}
	},
	computed: {
	},
	mounted() {
		this.gridHeight();
		window.addEventListener('resize', this.gridHeight);

		const authToken = Cookies.get('user-auth-token');
		const decodedToken = jwtDecode(authToken);
		this.userData = decodedToken;
		this.getRows();
	}
};
</script>

<style scoped></style>