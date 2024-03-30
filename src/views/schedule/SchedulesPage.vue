<template>
	<div class="schedules-page">
		<h1 class="text-center mb-3">Schedules</h1>
		<div v-for="schedule in schedules" :key="schedule.id" class="schedule mb-5">
			<h2>{{ schedule.name }}</h2>

			<table>
				<thead>
					<tr>
						<th>Date</th>
						<th>Start Time</th>
						<th>End Time</th>
						<th>Subject</th>
						<th>Location</th>
					</tr>
				</thead>

				<tbody>
					<tr v-for="date in schedule.dates" :key="date.date">
						<td class="date">{{ date.date }}</td>
						<td colspan="4">
							<table>
								<tbody>
									<tr v-for="slot in date.slots" :key="slot.startTime">
										<td>{{ slot.startTime }}</td>
										<td>{{ slot.endTime }}</td>
										<td>{{ slot.subject }}</td>
										<td>{{ slot.location }}</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
				</tbody>

			</table>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'SchedulesPage',
	data() {
		return {
			schedules: []
		};
	},
	async mounted() {
		try {
			const response = await axios.get('http://localhost:3000/schedules');
			this.schedules = response.data;
		} catch (error) {
			console.error("Failed to fetch schedules:", error);
		}
	}
};
</script>

<style scoped>
.schedules-page {
	padding: 20px;
}

table {
	width: 100%;
	border-collapse: collapse;
	margin-top: 20px;
}

th,
td {
	border: 1px solid #ccc;
	padding: 8px;
	text-align: left;
}

.rotate-header>div>span {
	border-bottom: 1px solid #ccc;
	padding: 5px;
	display: block;
}

td>table {
	margin-top: -1px;
}

td>table td {
	border-left: 1px solid #ccc;
}

td>table td:first-child {
	border-left: none;
}
</style>
