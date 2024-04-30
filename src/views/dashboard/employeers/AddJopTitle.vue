<template>
	<div class="add-job-title-form">
		<form @submit.prevent="submitJobTitle">
			<div class="form-group">
				<label for="description">Description:</label>
				<input id="description" v-model="jobTitle.description" required>
			</div>
			<div class="form-group">
				<label for="requirements">Requirements:</label>
				<input id="requirements" v-model="jobTitle.requirements" required>
			</div>
			<div class="form-group">
				<label for="minPay">Minimum Pay:</label>
				<input id="minPay" v-model.number="jobTitle.minPay" type="number" required>
			</div>
			<div class="form-group">
				<label for="maxPay">Maximum Pay:</label>
				<input id="maxPay" v-model.number="jobTitle.maxPay" type="number" required>
			</div>
			<button class="btn normal" type="submit">Add Job Title</button>
		</form>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'AddJobTitle',
	data() {
		return {
			jobTitle: {
				description: '',
				requirements: '',
				minPay: 0,
				maxPay: 0,
				employees: []
			},
		};
	},
	methods: {
		async submitJobTitle() {
			try {
				console.log('Adding job title:', this.jobTitle)
				const response = await axios.post('https://localhost:44303/api/JopTitles/AddJopTitle', this.jobTitle);
				if (response.status === 200) {
					console.log('Job title added successfully:', response.data);
					this.resetForm();
				} else {
					console.error('Error adding job title:', response);
				}
			} catch (ex) {
				console.error(ex);
			}
		},
		resetForm() {
			this.jobTitle = {
				description: '',
				requirements: '',
				minPay: 0,
				maxPay: 0,
				employees: null
			};
		},
	},
};
</script>

<style scoped>
.add-job-title-form {
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