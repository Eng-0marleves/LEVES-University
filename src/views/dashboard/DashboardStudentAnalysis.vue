<template>
	<div>
		<canvas ref="chart"></canvas>
	</div>
</template>

<script>
// import { Chart, registerables } from 'chart.js';
// import { ref, onMounted } from 'vue';

export default {
	name: 'GradeDistributionChart',
	// setup() {
	// 	const chartRef = ref(null);

	// 	onMounted(() => {
	// 		// Register the components globally before using them
	// 		Chart.register(...registerables);

	// 		const context = chartRef.value.getContext('2d');
	// 		new Chart(context, {
	// 			type: 'bar', // Or any other type
	// 			data: {
	// 				labels: ['A', 'B', 'C', 'D', 'F'],
	// 				datasets: [{
	// 					label: 'Grade Distribution',
	// 					backgroundColor: ['#f87979', '#45aaf2', '#fd9644', '#a55eea', '#d1d8e0'],
	// 					data: [10, 20, 30, 10, 5]
	// 				}]
	// 			},
	// 			options: {
	// 				responsive: true,
	// 				maintainAspectRatio: false
	// 			}
	// 		});
	// 	});

	// 	return {
	// 		chartRef
	// 	};
	// }
};
</script>

<style scoped>
.dashboard-student-analysis {
	text-align: center;
}
</style>
