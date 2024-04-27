<template>
	<div class="study-plan">
		<h3>Study plan</h3>

		<ag-grid-vue style="width: 100%;" :style="{ height: height + 'px' }" class="ag-theme-quartz"
			:columnDefs="columnDefs" :rowData="rowData" :gridOptions="gridOptions" v-if="rowData.length"></ag-grid-vue>
	</div>
</template>

<script>
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import { AgGridVue } from "ag-grid-vue3";

export default {
	name: 'StudyPlan',
	data() {
		return {
			height: null,
			columnDefs: [
				{ headerName: "Course Code", field: "code", flex: 1 },
				{ headerName: "Name", field: "name", flex: 2 },
				{ headerName: "Level", field: "level", flex: 1 },
				{ headerName: "Credit Hours", field: "creditHours", flex: 1 },
				{
					headerName: "Status",
					field: "status",
					flex: 1,
					cellStyle: params => {
						switch (params.value) {
							case 'Available': return { backgroundColor: 'lightgreen', borderRightColor: '#e2e2e2' };
							case 'Enrolled': return { backgroundColor: 'lightblue', borderRightColor: '#e2e2e2' };
							case 'Completed': return { backgroundColor: 'yellow', borderRightColor: '#e2e2e2' };
							case 'Unavailable': return { backgroundColor: 'salmon', borderRightColor: '#e2e2e2' };
							default: return null;
						}
					}
				},
				{ headerName: "Managed By", field: "managedBy", flex: 1 },
				{ headerName: "Prerequisites", field: "prerequisites", flex: 2 } // Added column for prerequisites
			],

			rowData: this.generateRows(), // Use a method to generate rows
			gridOptions: {
				headerHeight: 56 // Set fixed header height
			}
		};
	},
	components: {
		AgGridVue,
	},
	methods: {
		generateRows() {
			const courses = [
				// Define your courses here, each with a code, name, level, creditHours, status, managedBy, and prerequisites
			];

			// Ensure you have a total of 20 rows
			while (courses.length < 20) {
				courses.push({
					code: `NewCourse${courses.length + 1}`,
					name: `New Course ${courses.length + 1}`,
					level: `${Math.ceil(Math.random() * 4)}`, // Randomly assign a level between 1 and 4
					creditHours: Math.ceil(Math.random() * 5), // Random credit hours between 1 and 5
					status: ["Available", "Enrolled", "Completed", "Unavailable"][Math.floor(Math.random() * 4)], // Random status
					managedBy: `Prof. ${String.fromCharCode(65 + courses.length % 26)}`, // Random professor name
					prerequisites: "None", // Default prerequisite
				});
			}

			return courses;
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
	},
};
</script>

<style scoped></style>