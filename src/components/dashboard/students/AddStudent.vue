<template>
	<div class="add-student-form">
		<h2>Add New User</h2>
		<form @submit.prevent="submitStudent">
			<div class="form-group">
				<label for="firstName">First Name:</label>
				<input id="firstName" v-model="user.firstName" required>
			</div>
			<div class="form-group">
				<label for="lastName">Last Name:</label>
				<input id="lastName" v-model="user.lastName" required>
			</div>
			<div class="form-group">
				<label for="email">Email:</label>
				<input id="email" v-model="user.email" type="email" required>
			</div>
			<div class="form-group">
				<label for="dateOfBirth">Date of Birth:</label>
				<input id="dateOfBirth" v-model="user.dateOfBirth" type="date" required>
			</div>
			<div class="form-group">
				<label for="phoneNumber">Phone Number:</label>
				<input id="phoneNumber" v-model="user.phoneNumber" type="tel" required>
			</div>
			<div class="form-group">
				<label for="ntid">NTID:</label>
				<input id="ntid" v-model="user.ntid" type="number" required>
			</div>
			<div class="form-group">
				<label for="city">City:</label>
				<input id="city" v-model="user.city" required>
			</div>
			<div class="form-group">
				<label for="street1">Street 1:</label>
				<input id="street1" v-model="user.street1" required>
			</div>
			<div class="form-group">
				<label for="street2">Street 2:</label>
				<input id="street2" v-model="user.street2">
			</div>
			<div class="form-group">
				<label for="zip">Zip Code:</label>
				<input id="zip" v-model="user.zip" type="text" required>
			</div>
			<div class="form-group d-flex gap-2">
				<select id="studyArea" v-model="user.areaOfStudy" required>
					<option value="" disabled selected>Select an area of study</option>
					<option v-for="(area, i) in areasOfStudy" :key="i" :v:alue="area.studyTitle">{{
			area.studyTitle }}
					</option>
				</select>
			</div>
			<button class="btn normal" type="submit">Add User</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';
export default {
	name: 'AddStudent',
	data() {
		return {
			user: {
				firstName: '',
				lastName: '',
				email: '',
				dateOfBirth: '',
				phoneNumber: '',
				ntid: null,
				areaOfStudy: '',
				city: '',
				street1: '',
				street2: '',
				zip: '',
			},
			areasOfStudy: this.loadAreas()
		};
	},
	methods: {
		async submitStudent() {
			try {
				const response = await axios.post('https://localhost:44303/AddStudent', this.user);
				if (response.status === 200) {
					console.log('Student added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding student:', response);
				}
			} catch (ex) {
				console.error(ex);
				this.resetForm();
			}
		},
		resetForm() {
			this.user = {
				firstName: '',
				lastName: '',
				email: '',
				dateOfBirth: '',
				phoneNumber: '',
				userType: 'Student',
			};
		},
		async loadAreas() {
			try {
				const response = await axios.get('https://localhost:44303/GetAreasOfStudy');
				if (response.status == 200) {
					this.areasOfStudy = response.data;
					console.log(this.areasOfStudy)
				} else {
					console.error('Error loading areas of study:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
	},
	moutned() {
		this.loadAreas();
		console.log("moutned")
	},
};
</script>

<style scoped>
.add-student-form {
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
	border: 1px solid #ced4da;
	border-radius: 0.25rem;
}
</style>
