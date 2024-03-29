<template>
	<div class="course-grades">
		<button @click="toggleEdit" class="btn normal me-4 mb-2"><i class="fas fa-pen"></i> Edit</button>
		<button @click="handleSubmit" class="btn normal me-4 mb-2"><i class="fas fa-paper-plane"></i> Submit</button>
		<button @click="handleSaveAsImage" class="btn normal me-4 mb-2"><i class="fas fa-download"></i> Save </button>

		<ag-grid-vue ref="grid" :rowData="rowData" :columnDefs="colDefs" :defaultColDef="defaultColDef"
			style="height: 800px" class="ag-theme-quartz grades-grid" :editable="isEditEnabled"></ag-grid-vue>
	</div>
</template>

<script>
import { ref, computed } from 'vue';
import { AgGridVue } from "ag-grid-vue3";
import "ag-grid-community/styles//ag-grid.css";
import "ag-grid-community/styles//ag-theme-quartz.css";

export default {
	name: 'StudentsGrades',
	components: {
		AgGridVue,
	},
	setup() {
		const rowData = ref([]);
		const originalData = ref([]);
		const isEditEnabled = ref(false);

		// Function to toggle edit mode
		const toggleEdit = () => {
			isEditEnabled.value = !isEditEnabled.value;
			console.log(isEditEnabled.value);
		};

		// Function to log edited row data
		const handleSubmit = () => {
			stopEdit();
			const editedRows = getEditedRows();
			console.log("Edited Rows:", editedRows);
		};

		// Function to stop edit mode
		const stopEdit = () => {
			isEditEnabled.value = false;
		};

		// Function to get edited rows
		const getEditedRows = () => {
			const editedRows = [];
			for (const [index, row] of rowData.value.entries()) {
				const originalRow = originalData.value[index];
				for (const key in row) {
					if (row[key] !== originalRow[key]) {
						editedRows.push(row);
						break;
					}
				}
			}
			return editedRows;
		};

		// Populate row data
		for (let i = 1; i <= 20; i++) {
			let row = {
				Id: i,
				Name: `Student ${i}`,
			};
			let total = 0;
			for (let j = 1; j <= 12; j++) {
				let grade = Math.round(Math.random() * 100); // random grade between 0 and 100
				row[`Assignment ${j}`] = grade;
				total += grade;
			}
			row['Total'] = total;
			rowData.value.push(row);
			originalData.value.push({ ...row });
		}

		// Define computed property for column definitions
		const colDefs = computed(() => {
			return [
				{ field: "Id", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' }, filter: 'agTextColumnFilter', filterParams: { filterOptions: ['contains'] } },
				{ field: "Name", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' }, filter: 'agTextColumnFilter', filterParams: { filterOptions: ['contains'] } },
				{ field: "Total", flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' } },
				...Array.from({ length: 12 }, (_, i) => ({ field: `Assignment ${i + 1}`, flex: 1, cellStyle: { 'border-right-color': '#e2e2e2' }, editable: isEditEnabled.value })),
			];
		});

		return {
			rowData,
			colDefs,
			isEditEnabled,
			toggleEdit,
			handleSubmit,
		};
	},
	methods: {
		handleSaveAsImage() {
			console.log("");
		}

	}
};
</script>

<style>
.course-grades {
	padding: 16px;
}

.ag-header-row {
	background: var(--primary-color);
}

.ag-header-cell {
	color: var(--white-color);
}
</style>
