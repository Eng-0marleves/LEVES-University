<template>
	<div class="student-semester-report">
		<h2>Student Semester Report</h2>
		<div v-if="semesters.length > 0" class="semester-report">
			<h3>{{ currentSemester.semesterName }}</h3>
			<table>
				<thead>
					<tr>
						<th>Course Code</th>
						<th>Course Name</th>
						<th>Credit Hours</th>
						<th>GPA</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="course in currentSemester.courses" :key="course.code">
						<td>{{ course.code }}</td>
						<td>{{ course.name }}</td>
						<td>{{ course.creditHours }}</td>
						<td>{{ course.gpa }}</td>
					</tr>
				</tbody>
			</table>
			<p class="semester-gpa">Semester GPA: {{ currentSemester.semesterGpa }}</p>
		</div>
		<div v-else>
			<p>No semester reports available.</p>
		</div>

		<div class="navigation">
			<button @click="previousSemester" :disabled="currentSemesterIndex <= 0">Previous</button>
			<button @click="nextSemester" :disabled="currentSemesterIndex >= semesters.length - 1">Next</button>
		</div>

		<p class="total-gpa">Total GPA: {{ totalGpa }}</p>
		<button class="btn normal" @click="downloadReport">Download Report</button>
	</div>
</template>

<script>
import { jsPDF } from 'jspdf';
import 'jspdf-autotable';

export default {
	name: 'StudentSemesterReport',
	data() {
		return {
			semesters: [
				{
					semesterName: 'Fall 2023',
					courses: [
						{ code: 'CS101', name: 'Introduction to Computer Science', creditHours: 3, gpa: 3.5 },
						{ code: 'MATH101', name: 'Calculus I', creditHours: 4, gpa: 3.8 },
					],
					semesterGpa: 3.7,
				},
				{
					semesterName: 'Spring 2024',
					courses: [
						{ code: 'CS102', name: 'Data Structures', creditHours: 3, gpa: 3.9 },
						{ code: 'MATH102', name: 'Calculus II', creditHours: 4, gpa: 3.6 },
					],
					semesterGpa: 3.8,
				},
				// Add more semester data as needed
			],
			currentSemesterIndex: 0, // Initialize to show the first semester
			totalGpa: 3.75,
		};
	},
	computed: {
		currentSemester() {
			return this.semesters[this.currentSemesterIndex];
		},
	},
	methods: {
		previousSemester() {
			if (this.currentSemesterIndex > 0) {
				this.currentSemesterIndex--;
			}
		},
		nextSemester() {
			if (this.currentSemesterIndex < this.semesters.length - 1) {
				this.currentSemesterIndex++;
			}
		},
		downloadReport() {
			const doc = new jsPDF();

			// Set a title for the report
			doc.setFontSize(22);
			doc.text('Student Semester Report', 105, 20, null, null, 'center');

			this.semesters.forEach((semester, index) => {
				// Add a page for each semester except the first one
				if (index !== 0) {
					doc.addPage();
				}

				// Semester title
				doc.setFontSize(18);
				doc.text(semester.semesterName, 105, 40, null, null, 'center');

				// Define the columns and their titles for the semester's courses table
				const columns = [
					{ header: 'Course Code', dataKey: 'code' },
					{ header: 'Course Name', dataKey: 'name' },
					{ header: 'Credit Hours', dataKey: 'creditHours' },
					{ header: 'GPA', dataKey: 'gpa' },
				];

				// Add the courses table
				doc.autoTable({
					startY: 50,
					columns: columns,
					body: semester.courses,
					styles: { fontSize: 10 },
					theme: 'grid',
				});

				// Semester GPA
				let finalY = doc.lastAutoTable.finalY; // Get the Y position after the last table
				doc.text(`Semester GPA: ${semester.semesterGpa}`, 14, finalY + 10);
			});

			// Total GPA
			doc.setFontSize(16);
			doc.text(`Total GPA: ${this.totalGpa}`, 105, doc.internal.pageSize.height - 30, null, null, 'center');

			// Save the PDF
			doc.save('StudentSemesterReport.pdf');
		},

	},
	mounted() {
		this.currentSemesterIndex = this.semesters.length - 1; // Start with the last semester
	},
};
</script>


<style scoped>
.student-semester-report {
	max-width: 800px;
	margin: 20px auto;
	font-family: 'Helvetica', 'Arial', sans-serif;
}

.student-semester-report h2,
.student-semester-report h3 {
	text-align: center;
	color: #333;
}

.student-semester-report table {
	width: 100%;
	margin-top: 10px;
	border-collapse: collapse;
	box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
}

.student-semester-report th,
.student-semester-report td {
	border: 1px solid #ddd;
	padding: 8px;
	text-align: left;
}

.student-semester-report th {
	background: var(--primary-color);
	color: #ffffff;
}

tr {
	background: var(--bg-white);
}

.semester-gpa,
.total-gpa {
	margin-top: 10px;
	font-weight: bold;
}

button {
	margin: 20px auto;
}
</style>
