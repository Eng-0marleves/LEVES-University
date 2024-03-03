<template>
	<div class="calendar-component">
		<h2>Course Schedule</h2>
		<div class="table" ref="tableContainer">
			<table ref="table">
				<thead border:2>
					<tr>
						<th>Day</th>
						<th>From</th>
						<th>To</th>
						<th>Room</th>
						<th>Dr</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="row in rows" :key="row.id">
						<td>{{ row.day }}</td>
						<td>{{ row.from }}</td>
						<td>{{ row.to }}</td>
						<td>{{ row.room }}</td>
						<td>{{ row.doctor }}</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
</template>

<script>
export default {
	name: 'ScheduleTable',
	components: {
	},
	data() {
		return {
			rows: []
		};
	},
	mounted() {
		// Add at least 10 rows initially
		for (let i = 0; i < 10; i++) {
			this.addRow();
		}
	},
	methods: {
		addRow() {
			this.rows.push({
				id: this.rows.length + 1,
				day: 'Monday',
				from: '9:00 AM',
				to: '12:00 PM',
				room: 'A101',
				doctor: 'Dr. Smith'
			});
		}
	}
};
</script>

<style scoped>
.table {
	overflow-x: auto;
	height: 400px;
	scroll-behavior: smooth;
}

.table::-webkit-scrollbar {
	width: 8px;
	height: 8px;
}

table {
	border-collapse: collapse;
	width: 100%;
	max-height: 800px;
}

th,
td {
	text-align: left;
	padding: 8px;
}

tr:nth-child(even) {
	background-color: #f2f2f2;
}

th {
	background-color: #04aa6d;
	color: white;
}
</style>
