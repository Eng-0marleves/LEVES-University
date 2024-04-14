<template>
	<div class="analytics-reporting">
		<h2>University Analytics Dashboard</h2>
		<div class="charts">
			<canvas ref="enrollmentChart"></canvas>
			<canvas ref="performanceChart"></canvas>
		</div>
		<div class="controls">
			<button @click="exportToPDF" class="btn normal me-3">Export Report as PDF</button>
			<button @click="refreshData" class="btn normal">Refresh Data</button>
		</div>
	</div>
</template>

<script>
import { Chart, registerables } from 'chart.js';
import { jsPDF } from 'jspdf';
import axios from 'axios';

export default {
	name: 'AnalyticsReporting',
	data() {
		return {
			enrollmentChart: null,
			performanceChart: null
		};
	},
	methods: {
		initCharts() {
			Chart.register(...registerables);
			this.enrollmentChart = new Chart(this.$refs.enrollmentChart, this.getChartConfig('Enrollment Numbers', [450, 475, 525, 580, 600]));
			this.performanceChart = new Chart(this.$refs.performanceChart, this.getChartConfig('Graduation Rate', [88, 92, 85, 90, 95]));
		},
		getChartConfig(label, data) {
			return {
				type: 'line',
				data: {
					labels: ['2019', '2020', '2021', '2022', '2023'],
					datasets: [{
						label,
						data,
						borderColor: 'rgb(75, 192, 192)',
						tension: 0.1
					}]
				},
				options: {
					scales: {
						y: {
							beginAtZero: true
						}
					}
				}
			};
		},
		exportToPDF() {
			const doc = new jsPDF();
			doc.text("University Analytics Report", 10, 10);
			doc.save('report.pdf');
		},
		refreshData() {
			// Simulate fetching data and update charts
			axios.get('/api/data')
				.then(response => {
					// Assume response.data has new data arrays
					this.updateChartData(this.enrollmentChart, response.data.enrollment);
					this.updateChartData(this.performanceChart, response.data.graduation);
				})
				.catch(error => console.error('Error fetching data:', error));
		},
		updateChartData(chart, newData) {
			chart.data.datasets.forEach((dataset) => {
				dataset.data = newData;
			});
			chart.update();
		}
	},
	mounted() {
		this.initCharts();
	}
};
</script>

<style scoped>
.analytics-reporting {
	padding: 20px;
}

.charts {
	display: flex;
	justify-content: space-around;
}

.charts canvas {
	max-width: 400px;
}
</style>
