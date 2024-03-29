<template>
	<div class="student-semester-report">
		<h2>Student Semester Report</h2>
		<div v-for="(semester, index) in semesters" :key="index" class="semester-report">
			<h3>{{ semester.semesterName }}</h3>
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
					<tr v-for="course in semester.courses" :key="course.code">
						<td>{{ course.code }}</td>
						<td>{{ course.name }}</td>
						<td>{{ course.creditHours }}</td>
						<td>{{ course.gpa }}</td>
					</tr>
				</tbody>
			</table>
			<p class="semester-gpa">Semester GPA: {{ semester.semesterGpa }}</p>
		</div>
		<p class="total-gpa">Total GPA: {{ totalGpa }}</p>
		<button class="btn normal" @click="downloadReport">Download Report</button>
	</div>
</template>

<script>
import jsPDF from 'jspdf';
import 'jspdf-autotable';

export default {
	name: 'DashboardReport',
	data() {
		return {
			semesters: [
				{
					semesterName: 'Fall 2024',
					courses: [
						{ code: 'CS101', name: 'Introduction to Computer Science', creditHours: 3, gpa: 3.5 },
						// More courses...
					],
					semesterGpa: 3.7,
				},
				// More semesters...
			],
			totalGpa: 3.7,
		};
	},
	methods: {
		downloadReport() {
			const doc = new jsPDF();
			this.semesters.forEach((semester, index) => {
				if (index > 0) doc.addPage();
				doc.text(semester.semesterName, 10, 10);
				doc.autoTable({
					head: [['Course Code', 'Course Name', 'Credit Hours', 'GPA']],
					body: semester.courses.map(course => [course.code, course.name, course.creditHours.toString(), course.gpa.toString()]),
					startY: 20,
				});
				doc.text(`Semester GPA: ${semester.semesterGpa}`, 10, doc.lastAutoTable.finalY + 10);
			});
			doc.text(`Total GPA: ${this.totalGpa}`, 10, doc.internal.pageSize.height - 10);
			doc.save('StudentSemesterReport.pdf');
		},
	},
};
</script>

<style scoped>
.student-semester-report {
	padding: 16px;
}

.student-semester-report table {
	width: 100%;
	border-collapse: collapse;
}

.student-semester-report th,
.student-semester-report td {
	border: 1px solid #ddd;
	padding: 8px;
}

.semester-report,
.total-gpa {
	margin-bottom: 20px;
}
</style>
