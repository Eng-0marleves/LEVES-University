<template>
	<div class="dashboard-register">
		<ag-grid-vue style="width: 100%;" :style="{ height: height + 'px' }" class="ag-theme-quartz"
			:columnDefs="columnDefs" :rowData="rowData" :domLayout="'autoHeight'" v-if="rowData.length"></ag-grid-vue>
	</div>
</template>

<script>
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { AgGridVue } from "ag-grid-vue3"; // AG Grid Component

export default {
	name: 'DashboardRegister',
	components: {
		AgGridVue,
	},
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
		};
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
			const rowHeight = 48; // Height of one row, adjust based on your styling
			const headerHeight = 56; // Height of the header row, adjust based on your styling
			const numberOfRows = 6; // Number of rows to display
			this.height = headerHeight + (numberOfRows * rowHeight);
		}
	},
	mounted() {
		this.gridHeight();
		window.addEventListener('resize', this.gridHeight);
	},
};
</script>

<style>
.dashboard-register {
	padding: 16px;
}

.ag-header-row {
	background: var(--primary-color);
}

.ag-header-cell {
	color: var(--white-color);
}

.ag-header-cell-label {
	display: flex;
	justify-content: center;
	align-items: center;
}

.ag-theme-quartz {
	width: 100%;
	height: 100%;
	overflow-y: auto !important;
	margin-top: 24px;
	--ag-borders: none;
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;
	--ag-borders: none;

	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
}

.ag-center-cols-container {
	overflow: hidden;
}

.ag-root-wrapper {
	border: 2px solid #DCDCDC;
	border-radius: 5px;
}

.ag-ltr .ag-cell {
	text-align: center;
	padding: 0;
}

.ag-ltr .ag-cell span {
	width: 100%;
	height: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
	position: relative;
}

.is_3d {
	width: 25px;
	height: 25px;
}

.ag-ltr .ag-cell {
	border-right: 2px solid #DCDCDC;
}

.ag-header-cell {
	border-bottom-color: #DCDCDC;
}

.ag-header-cell:not(:last-child) {
	border-right: 2px solid #DCDCDC;
}

.ag-body-vertical-scroll-viewport {
	width: 24px;
}

.ag-header-cell-filter input {
	width: 80%;
	/* Adjust the width as needed */
	margin: 5px;
	/* Add margin for spacing */
	padding: 5px;
	/* Add padding for better appearance */
	border-radius: 5px;
	/* Add border-radius for rounded corners */
	border: 1px solid #ccc;
	/* Add border for clarity */
}
</style>