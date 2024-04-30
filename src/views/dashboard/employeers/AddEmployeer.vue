<template>
	<div class="add-emp-form">
		<form @submit.prevent="submitEmployee">
			<div class="form-group">
				<label for="firstName">First Name:</label>
				<input id="firstName" v-model="emp.firstName" required>
			</div>
			<div class="form-group">
				<label for="lastName">Last Name:</label>
				<input id="lastName" v-model="emp.lastName" required>
			</div>
			<div class="form-group">
				<label for="email">Email:</label>
				<input id="email" v-model="emp.email" type="email" required>
			</div>
			<div class="form-group">
				<label for="dateOfBirth">Date of Birth:</label>
				<input id="dateOfBirth" v-model="emp.dateOfBirth" type="date" required>
			</div>
			<div class="form-group">
				<label for="phoneNumber">Phone Number:</label>
				<input id="phoneNumber" v-model="emp.phoneNumber" type="tel" required>
			</div>
			<div class="form-group">
				<label for="ntid">NTID:</label>
				<input id="ntid" v-model.number="emp.ntid" type="number" required>
			</div>
			<div class="form-group">
				<label for="city">City:</label>
				<input id="city" v-model="emp.city" required>
			</div>
			<div class="form-group">
				<label for="street1">Street 1:</label>
				<input id="street1" v-model="emp.street1" required>
			</div>
			<div class="form-group">
				<label for="street2">Street 2:</label>
				<input id="street2" v-model="emp.street2">
			</div>
			<div class="form-group">
				<label for="zip">Zip Code:</label>
				<input id="zip" v-model="emp.zip" type="text" required>
			</div>
			<div class="form-group">
				<label for="yearlyPay">Yearly Pay:</label>
				<input id="yearlyPay" v-model.number="emp.yearlyPay" type="number" required>
			</div>
			<div class="form-group d-flex gap-2">
				<select id="empRole" v-model="emp.roleId" required>
					<option v-for="(role, i) in Roles" :key="i" :value="role.id">{{ role.name }}
					</option>
				</select>
			</div>
			<div class="form-group d-flex gap-2">
				<select id="empJopTitle" v-model="emp.jopInformationId" required>
					<option v-for="(jt, i) in JobTitles" :key="i" :value="jt.id">{{ jt.description }}
					</option>
				</select>
			</div>
			<button class="btn normal" type="submit">Add Employee</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'AddEmployeer',
	data() {
		return {
			emp: {
				ntid: 0,
				firstName: '',
				lastName: '',
				email: '',
				phoneNumber: '',
				city: '',
				street1: '',
				street2: '',
				zip: '',
				dateOfBirth: new Date().toISOString(),
				roleId: 0,
				yearlyPay: 0,
				jopInformationId: 0,
			},
			JobTitles: [],
			Roles: []
		};
	},
	methods: {
		async submitEmployee() {
			console.log("Employee: ", this.emp);
			try {
				const response = await axios.post('https://localhost:44303/api/Employees/AddEmployee', this.emp);
				if (response.status === 200) {
					console.log('Employee added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding employee:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
		resetForm() {
			this.emp = {
				ntid: 0,
				firstName: '',
				lastName: '',
				email: '',
				phoneNumber: '',
				city: '',
				street1: '',
				street2: '',
				zip: '',
				dateOfBirth: new Date().toISOString(), // Reset date to current date after submission
				roleId: 0,
				yearlyPay: 0,
				jopInformationId: 0
			};
		},
		async loadJobTitles() {
			try {
				const response = await axios.get('https://localhost:44303/api/Employees/GetJobTitles');
				if (response.status == 200) {
					this.JobTitles = response.data;
				} else {
					console.error('Error loading job titles:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
		async loadRoles() {
			try {
				const response = await axios.get('https://localhost:44303/api/Employees/GetEmployeesRoles');
				if (response.status == 200) {
					this.Roles = response.data;
				} else {
					console.error('Error loading roles:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
	},
	mounted() {
		this.loadJobTitles();
		this.loadRoles();
	},
};
</script>

<style scoped>
.add-emp-form {
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

select {
	background: var(--primary-color);
	color: #fff;
}
</style>
