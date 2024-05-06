<template>
	<div class="add-class-room-form">
		<form @submit.prevent="submitClassRoom">
			<div class="form-group">
				<label for="roomCode">Room Code:</label>
				<input id="roomCode" v-model="classRoom.roomCode" required>
			</div>
			<div class="form-group">
				<label for="maxSeating">Max Seating:</label>
				<input id="maxSeating" v-model.number="classRoom.maxSeating" required>
			</div>
			<div class="form-group">
				<select id="buildingId" v-model="classRoom.building" required>
					<option v-for="(building, i) in buildings" :key="i" :value="building">
						{{ building.buildingName }}
					</option>
				</select>
			</div>
			<button class="btn normal" type="submit">Add Building</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'AddClassRoom',
	data() {
		return {
			classRoom: {
				buildingId: null,
				roomCode: '',
				maxSeating: 0,
				building: {
					id: '',
					name: ''
				}
			},
			buildings: []
		};
	},
	methods: {
		/* eslint-disable */
		async submitClassRoom() {
			try {
				this.classRoom.buildingId = this.classRoom.building.buildingId;

				const { classroomCount, ...buildingWithoutClassroomCount } = this.classRoom.building;

				this.classRoom.building.id = buildingWithoutClassroomCount.buildingId;
				this.classRoom.building.name = buildingWithoutClassroomCount.buildingName;

				console.log(this.classRoom)
				const response = await axios.post('https://localhost:44303/api/Buildings/AddClassRoom', this.classRoom);
				if (response.status === 200) {
					console.log('Classroom added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding classroom:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
		resetForm() {
			this.classRoom = {
				buildingId: null,
				roomCode: '',
				maxSeating: 0
			};
		},
		async loadBuildings() {
			try {
				const res = await axios.get('https://localhost:44303/api/Buildings/GetAllBuildings');
				if (res.status === 200) {
					this.buildings = res.data;
				}
			} catch (ex) {
				console.error(ex);
			}
		}
	},
	mounted() {
		this.loadBuildings();
	},
};
</script>


<style scoped>
.add-class-room-form {
	max-width: 500px;
	margin: auto;
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
}

.form-group input {
	width: 100%;
	padding: 0.375rem 0.75rem;
	border: 1px solid hsl(210, 14%, 83%);
	border-radius: 0.25rem;
}
</style>