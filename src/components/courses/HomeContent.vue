<template>
	<div class="content">
		<div class="row">
			<div class="col-md-6 info-container">
				<h2>Course Information</h2>
				<div class="course-info">
					<p><strong>Course Code:</strong> {{ courseCode }}</p>
					<p><strong>Course Name:</strong> {{ courseName }}</p>
				</div>
			</div>
			<div class="col-md-6  info-container" info-container>
				<h2>Course Grades</h2>
				<div class="course-grades">
					<p><strong>Midterm:</strong> {{ midtermGrade }}/25</p>
					<p><strong>Assignment:</strong> {{ assignmentGrade }}/20</p>
					<p><strong>Attendance:</strong> {{ attendanceGrade }}/5</p>
					<p><strong>Final:</strong> {{ finalGrade }}/50</p>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'HomeContent',
	data() {
		return {
			courseCode: 'CSE101',
			courseName: 'Introduction to Computer Science',
			midtermGrade: 20,
			assignmentGrade: 18,
			attendanceGrade: 4,
			finalGrade: 45,
		};
	},
	methods: {
		// Your methods here
	},
	computed: {
		// Your computed properties here
	},
	mounted() {
		// Your mounted hook code here
	},
};
</script>

<style scoped>
.info-container {
	border-left: 2px solid #ccc;
}

h2 {
	margin-bottom: 16px;
	position: relative;
}

h2::before {
	content: "";
	position: absolute;
	top: 0;
	left: -20px;
	width: 16px;
	height: 16px;
	border-radius: 50%;
	background: var(--primary-color);
}

p {
	margin-bottom: 8px;
	position: relative;
}

p::before {
	content: "";
	position: absolute;
	top: 0;
	left: -16px;
	width: 8px;
	height: 8px;
	border-radius: 50%;
	background: var(--secondary-color);
	padding: 0px;
}
</style>
