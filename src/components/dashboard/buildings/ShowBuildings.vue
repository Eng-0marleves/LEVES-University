<template>
	<div class="show-buildings" style="height: 500px; width: 100%;">
		<ag-grid-vue :columnDefs="columnDefs" :rowData="rowData" class="ag-theme-quartz" :defaultColDef="defaultColDef"
			:domLayout="'autoHeight'" rowSelection="multiple"></ag-grid-vue>
	</div>
</template>

<script>
import axios from 'axios';
import { AgGridVue } from "ag-grid-vue3";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";

export default {
	components: { AgGridVue },
	data() {
		return {
			rowData: [],
			columnDefs: [
				{ headerName: "Building Name", field: "buildingName", flex: 1 },
				{ headerName: "Floor Number", field: "floorNumber", flex: 1 },
				{ headerName: "Room Code", field: "roomCode", flex: 1 },
				{ headerName: "Type", field: "type", flex: 1 },
				{ headerName: "Capacity", field: "capacity", flex: 1 },
			],
			defaultColDef: {
				flex: 1,
				minWidth: 120,
				filter: true,
				sortable: true,
			},
		};
	},
	mounted() {
		this.fetchBuildings();
	},
	methods: {
		async fetchBuildings() {
			try {
				const response = await axios.get('http://localhost:3000/buildings');
				this.rowData = response.data.reduce((acc, building) => {
					building.floors.forEach(floor => {
						floor.rooms.forEach(room => {
							acc.push({
								buildingName: building.name,
								floorNumber: floor.floorNumber,
								roomCode: room.roomCode,
								type: room.type,
								capacity: room.capacity,
							});
						});
					});
					return acc;
				}, []);
			} catch (error) {
				console.error('Error fetching buildings:', error);
			}
		}
	}
};
</script>

<style scoped>
.show-buildings {
	padding: 16px;
}

.building {
	margin-bottom: 20px;
	padding: 10px;
	border: 1px solid #ddd;
	border-radius: 5px;
}

.building h3 {
	margin-top: 0;
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
</style>
