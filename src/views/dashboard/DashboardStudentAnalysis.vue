<template>
	<div class="dashboard-student-analysis">
		<h2>Student Performance Analysis</h2>
		<grade-distribution-chart :chartData="chartData" :chartOptions="chartOptions"></grade-distribution-chart>
	</div>
</template>

<script>
import GradeDistributionChart from '@/components/dashboard/analysis/GradeDistributionChart.vue'
import { ref } from 'vue'

export default {
	name: 'DashboardStudentAnalysis',
	components: {
		GradeDistributionChart
	},
	setup() {
		const chartData = ref({
			labels: ['A', 'B', 'C', 'D', 'F'],
			datasets: [{
				label: 'Grade Distribution',
				backgroundColor: ['#f87979', '#45aaf2', '#fd9644', '#a55eea', '#d1d8e0'],
				data: [10, 20, 30, 10, 5]
			}]
		})

		const chartOptions = ref({
			responsive: true,
			maintainAspectRatio: false
		})

		return {
			chartData,
			chartOptions
		}
	}
}
</script>

<style scoped>
.dashboard-student-analysis {
	text-align: center;
}
</style>
