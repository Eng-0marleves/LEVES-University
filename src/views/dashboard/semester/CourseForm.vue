<template>
	<div class="course-form">
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
				<input type="number" id="courseCredits" v-model.number="course.credits" required min="1">
			</div>
			<!-- Additional fields like prerequisites could be added here -->
			<div class="form-actions">
				<button type="submit" class="btn">Save</button>
			</div>
		</form>
	</div>
</template>

<script>
export default {
	name: 'CourseForm',
	props: {
		initialCourse: {
			type: Object,
			default: () => ({ name: '', description: '', credits: 0 })
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
			this.course = { name: '', description: '', credits: 0 }; // Reset form
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

.form-group input,
.form-group textarea {
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
