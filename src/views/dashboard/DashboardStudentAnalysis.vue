<template>
	<div class="dashboard-student-analysis">
		<LineChart :chart-data="gpaData" :options="chartOptions" />
		<BarChart :chart-data="hoursData" :options="chartOptions" />
		<!-- Removed DoughnutChart for financial data -->

		<!-- <div class="financial-table">
			<h3>Financial Summary</h3>
			<table>
				<thead>
					<tr>
						<th>Category</th>
						<th>Amount ($)</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="(amount, category) in financialData" :key="category">
						<td>{{ category }}</td>
						<td>{{ amount }}</td>
					</tr>
				</tbody>
			</table>
		</div> -->
	</div>
</template>

<script>
import { ref } from 'vue';
import { LineChart, BarChart } from 'vue-chart-3';
import { Chart, registerables } from 'chart.js';
Chart.register(...registerables);

export default {
	name: 'GradeDistributionChart',
	components: {
		LineChart,
		BarChart,
	},
	setup() {
		const chartOptions = ref({
			responsive: true,
			maintainAspectRatio: false,
		});

		// GPA over time
		const gpaData = ref({
			labels: ['Semester 1', 'Semester 2', 'Semester 3', 'Semester 4'],
			datasets: [{
				label: 'GPA',
				data: [3.2, 3.5, 3.8, 3.9],
				fill: false,
				borderColor: 'rgb(75, 192, 192)',
				tension: 0.1
			}]
		});

		// Hours completed vs. required
		const hoursData = ref({
			labels: ['Completed', 'Required'],
			datasets: [{
				label: 'Study Hours',
				data: [190, 250], // Example data
				backgroundColor: ['rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)'],
			}]
		});

		// Adjusted financial data to be suitable for a table
		// const financialData = ref({
		// 	Tuition: 5000,
		// 	Books: 1000,
		// 	Accommodation: 3000,
		// 	Miscellaneous: 700,
		// });

		return {
			gpaData,
			hoursData,
			// financialData,
			chartOptions,
		};
	},
};
</script>

<style scoped>
.dashboard-student-analysis {
	display: flex;
	flex-direction: column;
	align-items: center;
	gap: 20px;
	padding: 20px 0;
}

.dashboard-student-analysis>div {
	width: 90%;
	max-width: 600px;
	height: auto;
	/* Adjusted for table */
}

/* .financial-table table {
	width: 100%;
	border-collapse: collapse;
}

.financial-table th,
.financial-table td {
	border: 1px solid #ddd;
	padding: 8px;
	text-align: left;
}

.financial-table th {
	background-color: #f2f2f2;
} */
</style>
