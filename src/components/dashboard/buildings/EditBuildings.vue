<template>
	<div class="edit-buildings">
		<div v-if="loading">Loading buildings...</div>
		<div v-else-if="error" class="error">Failed to load buildings. Please try again later.</div>
		<div v-else>
			<ul class="nav-tabs">
				<li class="tab" v-for="building in buildings" :key="building.id"
					:class="{ 'active': selectedBuilding && selectedBuilding.id === building.id }"
					@click="selectBuilding(building)">
					{{ building.name }}
				</li>
			</ul>

			<div class="building-details" v-if="selectedBuilding">
				<h2>{{ selectedBuilding.name }}</h2>
				<div v-for="floor in selectedBuilding.floors" :key="floor.floorNumber" class="floor-details">
					<h3>Floor {{ floor.floorNumber }}</h3>
					<table>
						<thead>
							<tr>
								<th>Room Code</th>
								<th>Type</th>
								<th>Capacity</th>
								<th><button class="btn normal" @click="addRoom()">add</button></th>
							</tr>
						</thead>
						<tbody>
							<tr v-for="room in floor.rooms" :key="room.roomCode">
								<td>{{ room.roomCode }}</td>
								<td>{{ room.type }}</td>
								<td>{{ room.capacity }}</td>
								<td class="actions">
									<button @click="findRoom(selectedBuilding.id, floor.floorNumber, room.roomCode)"
										class="btn normal" data-bs-toggle="modal"
										data-bs-target="#editModal">Edit</button>
									<button @click="deleteRoom()" class="btn normal">Reomve</button>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>


			<!-- edit modal -->
			<div class="modal fade" id="editModal" tabindex="-1" aria-labelledby="editModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<h5 class="modal-title" id="editModalLabel">Edit Room</h5>
							<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
						</div>
						<div class="modal-body">
							<form>
								<div class="mb-3">
									<label for="roomCode" class="form-label">Room Code</label>
									<input type="text" class="form-control" id="roomCode" v-model="edit_room.roomCode">
								</div>
								<div class="mb-3">
									<label for="type" class="form-label">Type</label>
									<select id="type" class="form-select" v-model="edit_room.type">
										<option>Lecture Hall</option>
										<option>Computer Lab</option>
										<option>Science Lab</option>
									</select>
								</div>
								<div class="mb-3">
									<label for="capacity" class="form-label">Capacity</label>
									<input type="number" class="form-control" id="capacity"
										v-model="edit_room.capacity">
								</div>
							</form>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
							<!-- Call saveRoom when the Save button is clicked -->
							<button type="button" class="btn btn-success"
								@click="saveRoom(edit_room, selectedFloor, selectedBuilding)"
								data-bs-dismiss="modal">Save</button>
						</div>
					</div>
				</div>
			</div>


		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'EditBuildings',
	data() {
		return {
			buildings: [],
			selectedBuilding: null,
			loading: false,
			error: false,

			edit_room: {}
		};
	},
	async mounted() {
		this.fetchBuildings();
	},
	methods: {
		async fetchBuildings() {
			this.loading = true;
			try {
				const response = await axios.get('http://localhost:3000/buildings');
				this.buildings = response.data.buildings || response.data; // Adjusted to handle both possible response structures
				this.selectBuilding(this.buildings[0]); // Select the first building by default
			} catch (error) {
				console.error("Failed to fetch buildings:", error);
				this.error = true;
			} finally {
				this.loading = false;
			}
		},
		selectBuilding(building) {
			this.selectedBuilding = building;
		},



		findRoom(buildingId, floorNumber, roomCode) {
			const building = this.buildings.find(b => b.id === buildingId);
			if (!building) {
				console.error('Building not found');
				return null;
			}

			const floor = building.floors.find(f => f.floorNumber === floorNumber);
			if (!floor) {
				console.error('Floor not found');
				return null;
			}

			const room = floor.rooms.find(r => r.roomCode === roomCode);
			if (!room) {
				console.error('Room not found');
				return null;
			}

			this.edit_room = room;
			console.log('Found room:', this.edit_room);
			return room;
		},

		editRoom(buildingId, floorNumber, roomCode) {
			const room = this.findRoom(buildingId, floorNumber, roomCode);
			if (room) {
				console.log('Edit room:', room);
			}
		},

		async saveRoom(editedRoom, floorNumber, building) {
			this.loading = true;
			try {
				const url = `http://localhost:3000/buildings/${building.id}/floors/${floorNumber}/rooms/${editedRoom.roomCode}`;

				const response = await axios.put(url, editedRoom);

				console.log('Room updated successfully:', response.data);

				this.fetchBuildings();
			} catch (error) {
				console.error('Failed to update room:', error);
				this.error = true;
			} finally {
				this.loading = false;
			}
		},
	}
};
</script>

<style scoped>
.nav-tabs {
	list-style-type: none;
	padding: 0;
	display: flex;
	border-bottom: 1px solid #ccc;
	margin-bottom: 20px;
	overflow-x: auto;
	background: var(--primary-color);
	padding: 8px;
	padding-bottom: 0px;
}

.tab {
	color: var(--white-color);
	padding: 10px;
	margin-right: 5px;
	cursor: pointer;
	background-color: transparent;
	border: 1px solid #ddd;
}

.tab.active {
	background-color: var(--secondary-color);
}

.tab:hover {
	background-color: var(--secondary-color);
}

.building-details {
	border: 1px solid #ccc;
	padding: 20px;
}

.floor-details {
	margin-top: 20px;
}

table {
	width: 100%;
	border-collapse: collapse;
}

th,
td {
	border: 1px solid #ddd;
	text-align: left;
	padding: 8px;
}

th {
	color: var(--white-color);
	background-color: var(--primary-color);
}

tr {
	background: var(--white-color);
}

tr button {
	color: red;
}

.actions {
	display: flex;
	justify-content: space-around;
	gap: 8px;
}

.error {
	color: red;
}
</style>
