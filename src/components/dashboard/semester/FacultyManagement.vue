<template>
	<div class="faculty-management">
		<h2>University Management Dashboard</h2>

		<!-- Faculty and Manager List -->
		<div class="management-list">
			<h3>Faculties & Managers</h3>
			<ul>
				<li v-for="faculty in faculties" :key="faculty.id">
					<img :src="faculty.manager.photo" alt="manager profile" class="profile-photo">
					<div>
						<h4>{{ faculty.name }} - Managed by: {{ faculty.manager.name }}</h4>
						<button @click="selectFaculty(faculty)" class="btn btn-info">View Details</button>
					</div>
				</li>
			</ul>
		</div>

		<!-- Department Details Modal -->
		<div v-if="selectedFaculty" class="modal">
			<div class="modal-content">
				<div class="modal-header">
					<h5>{{ selectedFaculty.name }} Departments</h5>
					<button @click="selectedFaculty = null" class="close-btn">×</button>
				</div>
				<div class="modal-body">
					<ul>
						<li v-for="department in selectedFaculty.departments" :key="department.id">
							<h5>{{ department.name }} - Managed by: {{ department.manager.name }}</h5>
							<button @click="selectDepartment(department)" class="btn btn-secondary">View
								Courses</button>
						</li>
					</ul>
				</div>
			</div>
		</div>

		<!-- Course Details Modal -->
		<div v-if="selectedDepartment" class="modal">
			<div class="modal-content">
				<div class="modal-header">
					<h5>{{ selectedDepartment.name }} Courses</h5>
					<button @click="selectedDepartment = null" class="close-btn">×</button>
				</div>
				<div class="modal-body">
					<ul>
						<li v-for="course in selectedDepartment.courses" :key="course.id">
							<h5>{{ course.name }} - Credits: {{ course.credits }}</h5>
							<button @click="editCourse(course)" class="btn btn-primary">Edit Course</button>
						</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'FacultyManagement',
	data() {
		return {
			faculties: [],
			selectedFaculty: null,
			selectedDepartment: null,
		};
	},
	methods: {
		fetchFaculties() {
			// Simulated API call
			this.faculties = [
				{
					id: 1,
					name: 'Engineering',
					manager: { name: 'John Doe', photo: 'https://aasarchitecture.com/wp-content/uploads/Nursing-Faculty-Building-by-Leonardo-Alvarez-Yepes-Arquitectos-00.jpg' },
					departments: [
						{
							id: 1,
							name: 'Computer Science',
							manager: { name: 'Jane Smith' },
							courses: [
								{ id: 1, name: 'Introduction to Programming', credits: 4 },
								{ id: 2, name: 'Data Structures', credits: 3 },
							],
						},
						// More departments...
					],
				},
				// More faculties...
			];
		},
		selectFaculty(faculty) {
			this.selectedFaculty = faculty;
			this.selectedDepartment = null; // Reset department selection
		},
		selectDepartment(department) {
			this.selectedDepartment = department;
		},
		editCourse(course) {
			// Open edit modal or form for the selected course
			console.log('Editing course:', course);
		}
	},
	created() {
		this.fetchFaculties();
	}
};
</script>

<style scoped>
.faculty-management {
	padding: 20px;
}

.management-list ul,
.modal-body ul {
	list-style-type: none;
	padding: 0;
}

.management-list li,
.modal-body li {
	display: flex;
	align-items: center;
	margin-bottom: 10px;
}

.profile-photo {
	width: 50px;
	height: 50px;
	border-radius: 50%;
	margin-right: 20px;
}

.modal {
	position: fixed;
	left: 0;
	top: 0;
	width: 100%;
	height: 100%;
	background-color: rgba(0, 0, 0, 0.5);
	display: flex;
	align-items: center;
	justify-content: center;
}

.modal-content {
	background-color: white;
	padding: 20px;
	border-radius: 5px;
	width: 50%;
}

.modal-header h5 {
	margin: 0;
}

.close-btn {
	float: right;
	cursor: pointer;
}

.btn {
	padding: 10px 20px;
	cursor: pointer;
	background-color: #007bff;
	color: white;
	border: none;
	border-radius: 5px;
}

.btn-info {
	background-color: #17a2b8;
}

.btn-primary,
.btn-secondary {
	margin-left: 10px;
}

.btn:hover {
	background-color: #0056b3;
}
</style>
