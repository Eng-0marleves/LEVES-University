<template>
	<div>
		<h2 class="text-center mb-4">Buildings Schedule</h2>

		<ag-grid-vue class="ag-theme-quartz" :columnDefs="buildingsScheduleDefs" :rowData="buildingsSchedule"
			:gridOptions="currentGridOptions" @grid-ready="onCurrentGridReady" style="width: 100%; height: 500px;">
		</ag-grid-vue>
	</div>
</template>

<script>
import { AgGridVue } from 'ag-grid-vue3';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import axios from 'axios';

export default {
	name: 'BuildingsSchedule',
	components: {
		AgGridVue
	},
	data() {
		return {
			buildingsScheduleDefs: [
				{ headerName: 'Building Name', field: 'buildingName', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Room Code', field: 'roomCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Course Code', field: 'courseCode', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'Doctor Name', field: 'doctorName', filter: "PartialMatchFilter", flex: 1 },
				{ headerName: 'From', field: 'from', flex: 1 },
				{ headerName: 'To', field: 'to', flex: 1 },
				{ headerName: 'Day', field: 'day', flex: 1 },
				// { headerName: 'Remove', field: 'id', cellRenderer: this.renderRemoveButton, cellRendererParams: { component: this }, hide: new Date(this.smester.endDate) < new Date() }
			],
			buildingsSchedule: [],
			currentGridOptions: {
				defaultColDef: {
					filter: true,
					sortable: true,
					resizable: true,
					flex: 1,
					minWidth: 100,
					filterParams: {
						applyButton: true,
						clearButton: true,
						inRangeInclusive: true,
					},
				},
			},

		};
	},
	methods: {
		onCurrentGridReady(params) {
			this.currentGridOptions = params.api;
		},
		async getBuildingsSchedule() {
			try {
				const response = await axios.get("https://localhost:44303/api/CourseSchedule/GetAllCoursesSchedules");
				this.buildingsSchedule = response.data;
			} catch (error) {
				console.error(error);
			}
		},
	},
	mounted() {
		this.getBuildingsSchedule();
	},
};
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

.ag-header-cell-label {
	text-align: center;
	display: flex;
	justify-content: center;
	align-items: center;
}
</style>