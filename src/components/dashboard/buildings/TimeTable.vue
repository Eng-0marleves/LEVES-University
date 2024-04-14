<template>
	<div class="p-4" style="height: 600px; width: 100%;">
		<button @click="downloadTimetableAsPDF" class="download-btn">Download Timetable as PDF</button>
		<ag-grid-vue :columnDefs="columnDefs" :rowData="rowData" class="ag-theme-quartz" :defaultColDef="defaultColDef"
			:domLayout="'autoHeight'" rowSelection="multiple"></ag-grid-vue>
	</div>
</template>

<script>
import { AgGridVue } from "ag-grid-vue3";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";

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
				{ headerName: "Time", field: "time", flex: 1, editable: true },
				{ headerName: "Course Code", field: "courseCode", flex: 1, editable: true },
				{ headerName: "Doctor Name", field: "doctorName", flex: 1, editable: false },
				{ headerName: "Doctor ID", field: "doctorId", flex: 1, editable: false },
			],
			rowData: [],
			gridOptions: {},
			rooms: [
				{
					id: "room1",
					name: "Conference Hall",
					schedule: [
						{ time: "09:00 - 10:00", courseCode: "CS101", doctorName: "Dr. Smith", doctorId: "DR001" },
						{ time: "10:00 - 11:00", courseCode: "MA201", doctorName: "Dr. Johnson", doctorId: "DR002" },
						// Additional slots as needed
					],
				},
				// Additional rooms as needed
			],
		};
	},
	created() {
		this.prepareRowData();
	},
	methods: {
		prepareRowData() {
			this.rowData = this.rooms.reduce((acc, room) => {
				const roomSchedule = room.schedule.map(slot => ({
					...slot,
					roomName: room.name // Include room name if needed in the grid
				}));
				return [...acc, ...roomSchedule];
			}, []);
		},
		downloadTimetableAsPDF() {
			const doc = new jsPDF();

			this.rooms.forEach((room, index) => {
				if (index !== 0) doc.addPage(); // Add a new page for each room except the first

				doc.text(room.name, 10, 10); // Customize position and formatting as needed

				const headers = this.columnDefs.map(col => col.headerName);
				const data = room.schedule.map(slot => [
					slot.time, slot.courseCode, slot.doctorName, slot.doctorId
				]);

				doc.autoTable({
					head: [headers],
					body: data,
					startY: 20, // Customize table position
					theme: 'grid',
				});

				// Optionally, add more room details or custom formatting
			});

			doc.save('timetable.pdf');
		},
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
</style>
