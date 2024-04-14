<template>
	<div class="faculty-form">
		<form @submit.prevent="submitForm">
			<div class="form-group">
				<label for="facultyName">Name:</label>
				<input id="facultyName" v-model="faculty.name" required>
			</div>
			<div class="form-group">
				<label for="facultyDepartment">Department:</label>
				<input id="facultyDepartment" v-model="faculty.department" required>
			</div>
			<!-- Optionally, handle courses they can teach -->
			<div class="form-actions">
				<button type="submit" class="btn">Save</button>
			</div>
		</form>
	</div>
</template>

<script>
export default {
	name: 'FacultyForm',
	props: {
		initialFaculty: {
			type: Object,
			default: () => ({ name: '', department: '' })
		}
	},
	data() {
		return {
			faculty: { ...this.initialFaculty }
		};
	},
	methods: {
		submitForm() {
			this.$emit('save', this.faculty);
			this.faculty = { name: '', department: '' }; // Reset form
		}
	}
};
</script>

<style scoped>
.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
}

.form-group input {
	width: 100%;
	padding: 0.375rem 0.75rem;
	margin-top: 0.5rem;
}

.form-actions {
	margin-top: 1rem;
}

.btn {
	background-color: #007bff;
	color: white;
	border: none;
	padding: 8px 12px;
	cursor: pointer;
}

.btn:hover {
	opacity: 0.9;
}
</style>
