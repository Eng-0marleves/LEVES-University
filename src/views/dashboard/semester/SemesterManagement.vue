<template>
	<div class="semester-management">
		<h2>Semester Management</h2>

		<div class="semester-selector d-flex justify-content-between align-items-center">
			<div class="select-semester">
				<label for="semesterSelect">Select Semester:</label>
				<select id="semesterSelect" v-model="selectedSemesterId" @change="emitSelectedSemester">
					<option v-for="semester in semesters" :key="semester.id" :value="semester.id">
						{{ semester.title }}
					</option>
				</select>
			</div>

			<button class="btn normal" @click="toggleAddSemester" v-if="isSemesterHasEnded">
				{{ editingSemester ? 'Editing Semester' : 'Add New Semester' }}
			</button>
		</div>

		<div class="add-semester-form">
			<form @submit.prevent="submitSemester">
				<fieldset>
					<legend>{{ editingSemester ? 'Edit Semester' : 'New Semester Details' }}</legend>
					<div class="form-group">
						<label for="semesterName">Name:</label>
						<input id="semesterName" v-model="newSemester.title" required>
					</div>
					<div class="form-group">
						<label for="startDate">Start Date:</label>
						<input type="date" id="startDate" v-model="newSemester.startDate" :min="minDate" required>
					</div>
					<div class="form-group">
						<label for="endDate">End Date:</label>
						<input type="date" id="endDate" v-model="newSemester.endDate" :min="newSemester.startDate"
							required>
					</div>
					<div class="form-group">
						<label for="registrationStart">Registration Start:</label>
						<input type="date" id="registrationStart" v-model="newSemester.enrollmentStartDate"
							:max="newSemester.startDate" required>
					</div>
					<div class="form-group">
						<label for="registrationEnd">Registration End:</label>
						<input type="date" id="registrationEnd" v-model="newSemester.enrollmentEndDate"
							:min="newSemester.enrollmentStartDate" :max="newSemester.endDate" required>
					</div>
					<div class="form-actions">
						<button type="submit" class="btn btn-success me-3">Submit</button>
						<button @click="toggleAddSemester" class="btn btn-danger">Cancel</button>
					</div>
				</fieldset>
			</form>
		</div>

		<div v-if="selectedSemester" class="semester-details">
			<h3>{{ selectedSemester.title }}</h3>
			<p>Start Date: {{ selectedSemester.startDate.split("T")[0] }}</p>
			<p>End Date: {{ selectedSemester.endDate.split("T")[0] }}</p>
			<p>Registration Start: {{ selectedSemester.enrollmentStartDate.split("T")[0] }}</p>
			<p>Registration End: {{ selectedSemester.enrollmentEndDate.split("T")[0] }}</p>
			<!-- <button v-if="!semesterHasEnded(selectedSemester)" @click.stop="editSemester(selectedSemester)"
				class="btn normal">Edit This Semester</button> -->
		</div>
	</div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
	name: 'SemesterManagement',
	data() {
		return {
			semesters: [],
			selectedSemesterId: '',
			showAddSemester: false,
			editingSemester: false,
			editingId: null,
			newSemester: { title: '', startDate: '', endDate: '', enrollmentStartDate: '', enrollmentEndDate: '' },
			currentSemester: null,
			isSemesterHasEnded: false
		};
	},
	computed: {
		minDate() {
			const today = new Date();
			return `${today.getFullYear()}-01-01`;
		},
		selectedSemester() {
			return this.semesters.find(semester => semester.id === parseInt(this.selectedSemesterId)) || null;
		},
	},
	methods: {
		toggleAddSemester() {
			this.showAddSemester = !this.showAddSemester;
		},
		async submitSemester() {
			let semester = {
				title: this.newSemester.title,
				startDate: this.newSemester.startDate,
				endDate: this.newSemester.endDate,
				enrollmentStartDate: this.newSemester.enrollmentStartDate,
				enrollmentEndDate: this.newSemester.enrollmentEndDate
			};

			if (this.editingSemester) {
				const index = this.semesters.findIndex(s => s.id === this.editingId);
				this.semesters.splice(index, 1, semester);
			} else {
				try {
					console.log(semester);
					let res = await axios.post('https://localhost:44303/AddSemester', semester);
					if (res.status === 200) {
						this.semesters.push(semester);
						Swal.fire({
							icon: 'success',
							title: 'Success!',
							text: 'Semester added successfully.'
						});
						this.editingSemester = false;
						this.clearForm();
					} else {
						console.log(res);
					}

				} catch (ex) {
					console.log(ex);
					Swal.fire({
						icon: 'error',
						title: 'Error!',
						text: 'Failed to add semester. Please try again later.'
					});
				}
			}
			this.toggleAddSemester();
		},
		editSemester(semester) {
			this.newSemester = { ...semester };
			this.editingSemester = true;
			this.showAddSemester = true;
			this.editingId = semester.id;
			this.selectedSemesterId = semester.id.toString();
		},
		emitSelectedSemester() {
			this.$emit('selectedSemesterChanged', this.selectedSemester);
		},
		semesterHasEnded(semester) {
			if (semester && semester.endDate) {
				const today = new Date();
				console.log(semester.endDate)
				console.log(new Date(semester.endDate) < today)
				this.isSemesterHasEnded = new Date(semester.endDate) > today;
			}
			this.isSemesterHasEnded = false;
		},
		clearForm() {
			this.newSemester = { name: '', startDate: '', endDate: '', registrationStart: '', registrationEnd: '' };
			this.editingId = null;
		},
		async getSemesters() {
			try {
				var res = await axios.get('https://localhost:44303/Semesters');
				this.semesters = res.data;
				this.selectedSemesterId = this.semesters[0].id.toString();
				console.log(this.semesters);
				this.editingSemester = false;
				this.clearForm();
			} catch (error) {
				console.log(error);
				Swal.fire({
					icon: 'error',
					title: 'Error!',
					text: 'Failed to fetch semesters. Please try again later.'
				});
			}
		},
		async getCurrentSemester() {
			try {
				const res = await axios.get('https://localhost:44303/CurrentSemester');
				this.currentSemester = res.data;
				this.isSemesterHasEnded = new Date(this.semester.endDate) > new Date();
				console.log(this.currentSemester)
			} catch (error) {
				console.log(error);
			}
		}
	},
	mounted() {
		this.getSemesters();
		this.getCurrentSemester();
	},
	watch: {
		'selectedSemesterId': {
			immediate: true,
			handler(newVal) {
				if (newVal) {
					this.emitSelectedSemester();
				} else {
					this.selectedSemesterId = this.semesters.length ? this.semesters[0].id.toString() : '';
					console.log("semster", this.selectedSemesterId);
				}
			}
		}
	}
};
</script>

<style scoped>
/* Add your CSS styling here */
.semester-management .btn-info {
	background-color: #17a2b8;
	color: white;
}

.semester-management .btn-info:hover {
	opacity: 0.8;
}

.semester-management {
	max-width: 800px;
	margin: 20px auto;
	padding: 20px;
	background: #f9f9f9;
	border-radius: 8px;
	box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

h2 {
	margin-bottom: 20px;
}

.add-semester-form {
	background: white;
	padding: 15px;
	margin-bottom: 20px;
	border-radius: 8px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.form-group {
	margin-bottom: 1rem;
}

.form-group label {
	display: block;
	margin-bottom: .5rem;
}

.form-group input {
	width: 100%;
	padding: .375rem .75rem;
	border: 1px solid #ced4da;
	border-radius: .25rem;
}

.form-actions {
	text-align: right;
}

.btn {
	padding: 10px 15px;
	border: none;
	border-radius: 5px;
	cursor: pointer;
	font-size: 16px;
	transition: background-color 0.3s ease;
}

.btn-primary {
	background-color: #007bff;
	color: white;
}

.btn-secondary {
	background-color: #6c757d;
	color: white;
}

.btn-success {
	background-color: #28a745;
	color: white;
}

.btn:hover {
	opacity: 0.9;
}

.semester-list {
	list-style-type: none;
	padding: 0;
}

.semester-list li {
	cursor: pointer;
	padding: 10px;
	background-color: #eee;
	margin-bottom: 8px;
	border-radius: 4px;
	transition: background-color 0.3s ease;
}

.semester-list li:hover {
	background-color: #ddd;
}

.semester-details {
	background: white;
	padding: 15px;
	margin-top: 20px;
	border-radius: 8px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.semester-details h3 {
	color: #0056b3;
}

.semester-selector {
	margin-bottom: 20px;
}

.semester-selector label {
	margin-right: 10px;
}

select {
	color: var(--white-color);
	background: var(--primary-color);
	padding: .375rem .75rem;
	border-radius: .25rem;
	border: 1px solid #ced4da;
}

option:hover {
	background: var(--secondary-color);
}
</style>
