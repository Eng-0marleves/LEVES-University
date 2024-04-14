<template>
	<div class="student-tracking">
		<h1>Student Tracking</h1>

		<!-- Student Profiles Section -->
		<div class="student-profiles">
			<h2>Student Profiles</h2>
			<ul>
				<li v-for="student in students" :key="student.id">
					<h3>{{ student.name }}</h3>
					<p>Major: {{ student.major }}</p>
					<button @click="viewProfile(student.id)">View Profile</button>
				</li>
			</ul>
		</div>

		<!-- Performance Analytics Section -->
		<div class="performance-analytics">
			<h2>Performance Analytics</h2>
			<!-- Placeholder for charts and graphs -->
			<div id="charts">
				<canvas ref="gradeChart"></canvas>
			</div>
		</div>

		<!-- Communication Tools -->
		<div class="communication-tools">
			<h2>Communication Tools</h2>
			<button @click="sendMessage">Send Message</button>
		</div>
	</div>
</template>

<script>
import Chart from 'chart.js/auto';

export default {
	name: 'StudentTracking',
	data() {
		return {
			students: [
				{ id: 1, name: 'John Doe', major: 'Computer Science' },
				{ id: 2, name: 'Jane Smith', major: 'Biology' }
			],
		};
	},
	methods: {
		viewProfile(id) {
			alert(`Viewing profile for student ID: ${id}`);
		},
		sendMessage() {
			alert('Sending message...');
		},
		setupCharts() {
			const ctx = this.$refs.gradeChart.getContext('2d');
			new Chart(ctx, {
				type: 'line',
				data: {
					labels: ['Freshman', 'Sophomore', 'Junior', 'Senior'],
					datasets: [{
						label: 'GPA',
						data: [3.2, 3.5, 3.8, 3.9],
						fill: false,
						borderColor: 'rgb(75, 192, 192)',
						tension: 0.1
					}]
				},
				options: {
					scales: {
						y: {
							suggestedMin: 0,
							suggestedMax: 4
						}
					}
				}
			});
		}
	},
	mounted() {
		this.setupCharts();
	}
};
</script>

<style scoped>
.student-tracking {
	padding: 20px;
}

ul {
	list-style: none;
	padding: 0;
}

li {
	margin-bottom: 10px;
}

#charts {
	width: 400px;
	height: 200px;
}

button {
	margin: 10px;
	padding: 8px 16px;
	background-color: #007bff;
	color: white;
	border: none;
	cursor: pointer;
}

button:hover {
	background-color: #0056b3;
}
</style>
