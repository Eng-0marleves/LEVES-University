<template>
	<div class="add-building-form">
		<form @submit.prevent="submitBuilding">
			<div class="form-group">
				<label for="name">Name:</label>
				<input id="name" v-model="building.name" required>
			</div>
			<button class="btn normal" type="submit">Add Building</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'AddBuilding',
	data() {
		return {
			building: {
				name: ''
			}
		};
	},
	methods: {
		async submitBuilding() {
			try {
				const response = await axios.post('https://localhost:44303/api/Buildings/AddBuilding', this.building);
				if (response.status === 200) {
					console.log('Building added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding building:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
		resetForm() {
			this.building = {
				name: ''
			};
		},
	},
};
</script>

<style scoped>
.add-building-form {
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