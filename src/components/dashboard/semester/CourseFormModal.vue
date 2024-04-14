<template>
	<div class="modal">
		<form @submit.prevent="submitForm">
			<div class="form-group">
				<label for="courseName">Course Name:</label>
				<input id="courseName" v-model="course.name" required>
			</div>
			<div class="form-group">
				<label for="courseDescription">Description:</label>
				<textarea id="courseDescription" v-model="course.description" required></textarea>
			</div>
			<div class="form-group">
				<label for="courseCredits">Credits:</label>
				<input type="number" id="courseCredits" v-model.number="course.credits" required>
			</div>
			<button type="submit" class="btn btn-primary">Save</button>
			<button type="button" class="btn btn-secondary" @click="$emit('close')">Cancel</button>
		</form>
	</div>
</template>

<script>
export default {
	name: 'CourseFormModal',
	props: {
		initialCourse: {
			type: Object,
			default: () => ({
				name: '',
				description: '',
				credits: 0
			})
		}
	},
	data() {
		return {
			course: { ...this.initialCourse }
		};
	},
	methods: {
		submitForm() {
			this.$emit('save', this.course);
			this.resetForm();
		},
		resetForm() {
			this.course = { ...this.initialCourse };
		}
	}
};
</script>

<style scoped>
.modal {
	background-color: white;
	padding: 20px;
	border-radius: 5px;
	box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
	margin-bottom: 0.5rem;
}

.form-group input,
.form-group textarea {
	width: 100%;
	padding: 0.375rem 0.75rem;
	border: 1px solid #ccc;
	border-radius: 0.25rem;
}

.btn {
	padding: 0.5rem 1rem;
	margin-right: 0.5rem;
	cursor: pointer;
	border: none;
	border-radius: 0.25rem;
}

.btn-primary {
	background-color: #007bff;
	color: white;
}

.btn-secondary {
	background-color: #6c757d;
	color: white;
}

.btn:hover {
	opacity: 0.85;
}
</style>
