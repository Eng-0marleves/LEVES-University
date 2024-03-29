<template>
	<div class="dashboard-time-table">
		<table>
			<thead>
				<tr>
					<th>Time/Day</th>
					<th>Monday</th>
					<th>Tuesday</th>
					<th>Wednesday</th>
					<th>Thursday</th>
					<th>Friday</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="timeSlot in timeSlots" :key="timeSlot.id">
					<td>{{ timeSlot.time }}</td>
					<td v-for="day in days" :key="day">
						<div v-if="getClass(day, timeSlot.time)">
							{{ getClass(day, timeSlot.time).subject }}
							<br>
							<small>{{ getClass(day, timeSlot.time).room }}</small>
						</div>
					</td>
				</tr>
			</tbody>
		</table>
	</div>
</template>

<script>
export default {
	name: 'DashboardTimeTable',
	data() {
		return {
			days: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
			timeSlots: [
				{ id: 1, time: '8:00 - 9:00' },
				{ id: 2, time: '9:00 - 10:00' },
				// Add more time slots as needed
			],
			classes: [
				{ day: 'Monday', time: '8:00 - 9:00', subject: 'Mathematics', room: 'Room 101' },
				{ day: 'Wednesday', time: '9:00 - 10:00', subject: 'Computer Science', room: 'Room 202' },
				// Add more classes as needed
			],
		};
	},
	methods: {
		getClass(day, time) {
			return this.classes.find(c => c.day === day && c.time === time);
		}
	}
};
</script>

<style scoped>
.dashboard-time-table {
	overflow-x: auto;
	padding: 16px;
}

table {
	width: 100%;
	border-collapse: collapse;
	text-align: left;
}

thead {
	color: var(--white-color);
	background-color: var(--primary-color);
	text-align: center;
}

th,
td {
	padding: 8px;
	border: 1px solid #ddd;
}

td {
	height: 100px;
	background: var(--white-color);
}
</style>
