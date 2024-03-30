<template>
	<div class="scheduling-page">
		<h1>Create a Timetable</h1>
		<form @submit.prevent="submitTimetable">
			<div class="table-title">
				<label for="name">Timetable Name:</label>
				<input type="text" id="name" placeholder="Table title..." v-model="timetable.name" required>
			</div>

			<div v-for="(dateEntry, dateIndex) in timetable.dates" :key="dateIndex" class="date-section">
				<h2>Date:</h2>
				<input type="date" v-model="dateEntry.date" required>

				<h3>Time Slots:</h3>
				<table>
					<thead>
						<tr>
							<th>Start Time</th>
							<th>End Time</th>
							<th>Subject</th>
							<th>Location</th>
							<th>Action</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="(slot, slotIndex) in dateEntry.slots" :key="`slot-${slotIndex}`">
							<td><input type="time" v-model="slot.startTime" required></td>
							<td><input type="time" v-model="slot.endTime" required></td>
							<td><input type="text" v-model="slot.subject" placeholder="MS102" required></td>
							<td><input type="text" v-model="slot.location" placeholder="Room 101" required></td>
							<td><button type="button" class="btn normal"
									@click="removeSlot(dateIndex, slotIndex)">Remove</button></td>
						</tr>
					</tbody>
				</table>
				<button type="button" class="btn normal" @click="addSlot(dateIndex)">Add Time Slot</button>
			</div>
			<button type="button" class="btn normal me-2" @click="addDate">Add Date</button>
			<button type="submit" class="btn normal">Save Timetable</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'SchedulingPage',
	data() {
		return {
			timetable: {
				name: '',
				dates: [
					{ date: '', slots: [{ startTime: '', endTime: '', subject: '', location: '' }] }
				]
			}
		};
	},
	methods: {
		addDate() {
			this.timetable.dates.push({ date: '', slots: [{ startTime: '', endTime: '', subject: '', location: '' }] });
		},
		addSlot(dateIndex) {
			this.timetable.dates[dateIndex].slots.push({ startTime: '', endTime: '', subject: '', location: '' });
		},
		removeSlot(dateIndex, slotIndex) {
			this.timetable.dates[dateIndex].slots.splice(slotIndex, 1);
		},
		async submitTimetable() {
			try {
				const response = await axios.post('http://localhost:3000/schedules', this.timetable);
				console.log('Saved successfully', response.data);
				this.timetable = { name: '', dates: [{ date: '', slots: [{ startTime: '', endTime: '', subject: '', location: '' }] }] };
				alert('Timetable saved successfully!');
			} catch (error) {
				console.error('There was an error saving the timetable:', error);
				alert('Failed to save the timetable.');
			}
		}
	}
};
</script>

<style scoped>
.scheduling-page {
	padding: 20px;
}

.table-title {
	display: flex;
	align-items: center;
	gap: 8px;
}

input[type="text"],
input[type="date"],
input[type="time"] {
	margin: 5px 0;
	padding: 8px;
	box-sizing: border-box;
	display: block;
}

table {
	width: 100%;
	margin-top: 10px;
	margin-bottom: 20px;
	border-collapse: collapse;
}

th,
td {
	border: 1px solid #ddd;
	padding: 8px;
	text-align: left;
}

thead {
	background-color: #f4f4f4;
}

.date-section {
	border: 2px solid #ccc;
	padding: 20px;
	border-radius: 8px;
	margin-bottom: 20px;
}

/* button {
	margin-top: 10px;
	background-color: #007bff;
	color: white;
	border: none;
	padding: 8px 16px;
	cursor: pointer;
	border-radius: 4px;
}

button:hover {
	background-color: #0056b3;
} */

/* .submit-button {
	display: inline-block;
	margin-top: 20px;
} */
</style>
