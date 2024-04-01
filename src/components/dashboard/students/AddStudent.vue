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
			<div class="form-group d-flex gap-2">
				<label for="userType">User Type:</label>
				<select id="userType" v-model="user.userType" required>
					<option value="Student">Student</option>
					<option value="Teacher" disabled>Teacher</option>
					<option value="Admin" disabled>Admin</option>
				</select>
			</div>
			<button class="btn normal" type="submit">Add User</button>
		</form>
	</div>
</template>

<script>
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
				userType: 'Student', // Default to 'Student'
			},
		};
	},
	methods: {
		submitStudent() {
			console.log('Submitting user:', this.user);
			// Here you would typically send the user data to a server
			// For now, we'll just log it to the console
			// After submission, you might want to clear the form or give feedback to the user
			this.resetForm();
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
		}
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
