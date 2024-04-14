<template>
	<div class="enrollment-management">
		<h2>Enrollment Management Dashboard</h2>

		<!-- Enrollment Operations -->
		<div class="enrollment-operations">
			<button @click="processBatchEnrollment" class="btn">Process Batch Enrollment</button>
			<button @click="updateTuitionFees" class="btn">Update Tuition Fees</button>
		</div>

		<!-- Course List and Waitlist Management -->
		<div class="course-management">
			<h3>Course List</h3>
			<input type="text" v-model="searchQuery" placeholder="Search courses..." class="form-control">
			<ul>
				<li v-for="course in filteredCourses" :key="course.id">
					{{ course.name }} - {{ course.availableSlots }} available slots
					<button @click="addToWaitlist(course.id)" class="btn">Add to Waitlist</button>
				</li>
			</ul>
		</div>

		<!-- Drop/Add Period Management -->
		<div class="drop-add-period">
			<button @click="adjustDropAddPeriods" class="btn">Adjust Drop/Add Periods</button>
		</div>
	</div>
</template>

<script>
export default {
	name: 'EnrollmentManagement',
	data() {
		return {
			courses: [],
			waitlist: [],
			searchQuery: ''
		};
	},
	computed: {
		filteredCourses() {
			return this.courses.filter(course => course.name.toLowerCase().includes(this.searchQuery.toLowerCase()));
		}
	},
	methods: {
		fetchCourses() {
			// Simulated API call to fetch courses
			this.courses = [
				{ id: 1, name: "Advanced Mathematics", availableSlots: 5 },
				{ id: 2, name: "Introduction to Computer Science", availableSlots: 0 }
			];
		},
		addToWaitlist(courseId) {
			const course = this.courses.find(c => c.id === courseId);
			if (course && course.availableSlots === 0) {
				this.waitlist.push(courseId);
				alert('Added to waitlist!');
			} else {
				alert('Slots available. No need to add to waitlist.');
			}
		},
		processBatchEnrollment() {
			console.log('Processing batch enrollments...');
		},
		updateTuitionFees() {
			console.log('Updating tuition fees...');
		},
		adjustDropAddPeriods() {
			console.log('Adjusting Drop/Add Periods...');
		}
	},
	mounted() {
		this.fetchCourses();
	}
};
</script>

<style scoped>
.enrollment-management {
	padding: 20px;
}

.btn {
	margin: 10px;
	padding: 10px 20px;
	background-color: #007bff;
	color: white;
	border: none;
	cursor: pointer;
}

.btn:hover {
	background-color: #0056b3;
}

.course-management ul {
	list-style-type: none;
	padding: 0;
}

.course-management li {
	margin-bottom: 10px;
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.form-control {
	margin-bottom: 10px;
	padding: 10px;
	width: 100%;
	box-sizing: border-box;
}
</style>
