<template>
	<div class="grades-table">
		<ag-grid-vue :rowData="rowData" :columnDefs="colDefs" style="height: 800px" class="ag-theme-quartz">
		</ag-grid-vue>
	</div>
</template>

<script>
import { ref } from 'vue';
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { AgGridVue } from "ag-grid-vue3"; // AG Grid Component

export default {
	name: 'GradesTable',
	components: {
		AgGridVue
	},
	setup() {

		// Row Data: The data to be displayed.
		const rowData = ref([]);
		for (let i = 1; i <= 20; i++) {
			let row = {
				Id: i,
				Name: `Student ${i}`,
			};
			let total = 0;
			for (let j = 1; j <= 12; j++) {
				let attendance = Math.round(Math.random()); // 0 or 1
				row[`Lec ${j}`] = attendance;
				total += attendance;
			}
			row['Total'] = total;
			rowData.value.push(row);
		}

		// Column Definitions: Defines the columns to be displayed.
		const colDefs = ref([
			{ field: "Id", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' }, filter: 'agTextColumnFilter', filterParams: { filterOptions: ['contains'] } },
			{ field: "Name", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' }, filter: 'agTextColumnFilter', filterParams: { filterOptions: ['contains'] } },
			{ field: "Total", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' } },
			...Array.from({ length: 12 }, (_, i) => ({ field: `Lec ${i + 1}`, flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' } })),
		]);

		return {
			rowData,
			colDefs,
		};
	}
};
</script>


<style>
.attendance-table {
	/* Your styles go here */
}

.ag-header-cell {
	/* border-bottom: 2px solid #DCDCDC; */
}

.ag-header-cell-label {
	display: flex;
	justify-content: center;
	align-items: center;
}

.ag-theme-quartz {
	width: 100%;
	height: 100%;
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