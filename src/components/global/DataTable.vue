<template>
	<div class="dataTable">
		<ag-grid-vue :rowData="row_data" :columnDefs="column_defs" style="height: 800px" class="ag-theme-quartz">
		</ag-grid-vue>
	</div>
</template>

<script>
import { ref, watch } from 'vue';
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { AgGridVue } from "ag-grid-vue3"; // AG Grid Component

export default {
	name: 'DataTable',
	components: {
		AgGridVue
	},
	props: {
		rowData: {
			type: Array,
			default: () => []
		},
		columnDefs: {
			type: Array,
			default: () => []
		}
	},
	setup(props) {
		const row_data = ref(props.rowData);
		const column_defs = ref(props.columnDefs);

		// Watch for changes in props
		watch(() => props.rowData, (newValue) => {
			row_data.value = newValue;
		});

		watch(() => props.columnDefs, (newValue) => {
			column_defs.value = newValue;
		});

		return {
			row_data,
			column_defs
		}
	}
}
</script>


<style scoped>
.ag-header-cell {
	border-bottom: 2px solid #DCDCDC;
}

.ag-header-cell-label {
	display: flex;
	justify-content: center;
	align-items: center;
}

.ag-theme-quartz {
	width: 100%;
	height: 100%;
	/* --ag-borders: none; */
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;

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

.ag-ltr .ag-cell:not(:nth-child(6n):last-child) {
	border-right: 2px solid #DCDCDC;
}

.ag-row-animation .ag-row:last-child {
	border-bottom: none;
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
