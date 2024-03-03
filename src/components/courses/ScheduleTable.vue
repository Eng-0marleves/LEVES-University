<template>
	<div class="calendar-component">
		<div class="section-title">
			<h2>{{ name }}</h2>
			<div class="line"></div>
		</div>
		<div class="table" ref="tableContainer">
			<table ref="table">
				<thead>
					<tr>
						<th>Day</th>
						<th>From</th>
						<th>To</th>
						<th>Room</th>
						<th>Dr</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="row in rows" :key="row.id">
						<td>{{ row.day }}</td>
						<td>{{ row.from }}</td>
						<td>{{ row.to }}</td>
						<td>{{ row.room }}</td>
						<td>{{ row.doctor }}</td>
					</tr>
				</tbody>
			</table>
		</div>
		<!-- Add a button with an icon to trigger image download -->
		<button @click="downloadTableAsImage">
			Download as Image
			<i class="fa fa-download"></i>
		</button>
	</div>
</template>

<script>
// Import html2canvas library
import html2canvas from 'html2canvas';

export default {
	name: 'ScheduleTable',
	props: {
		name: String
	},
	components: {},
	data() {
		return {
			rows: []
		};
	},
	mounted() {
		// Add at least 10 rows initially
		for (let i = 0; i < 10; i++) {
			this.addRow();
		}
	},
	methods: {
		addRow() {
			this.rows.push({
				id: this.rows.length + 1,
				day: 'Monday',
				from: '9:00 AM',
				to: '12:00 PM',
				room: 'A101',
				doctor: 'Dr. Smith'
			});
		},
		downloadTableAsImage() {
			// Use html2canvas to capture the table as an image
			html2canvas(this.$refs["tableContainer"], { allowTaint: true }).then(canvas => {
				// Convert the canvas to a data URL
				console.log(this.$refs.tableContainer);
				console.log(canvas);
				const imgData = canvas.toDataURL('image/png');
				console.log(imgData);

				// Create a temporary link element to download the image
				const link = document.createElement('a');
				link.href = imgData;
				link.download = 'table_image.png';
				link.click();

				// Present the image in the browser
				const img = document.createElement('img');
				img.src = imgData;
				document.querySelector(".calendar-component").appendChild(img); // Append the image to the body or any other element
			});
		}

	}
};
</script>

<style scoped>
@import url('https://unpkg.com/bootstrap@next/dist/css/bootstrap.min.css');

.section-title {
	margin-bottom: 20px;
}

.table {
	overflow-x: auto;
	scroll-behavior: smooth;
	margin-bottom: 24px;
}

.table::-webkit-scrollbar {
	width: 8px;
	height: 8px;
}

table {
	border-collapse: collapse;
	width: 100%;
	max-height: 800px;
}

th,
td {
	text-align: left;
	padding: 8px;
}

tr:nth-child(even) {
	background-color: #f2f2f2;
}

tr:hover {
	background-color: var(--secondary-color);
	color: #fff;
}

th {
	background-color: var(--primary-color);
	color: white;
}
</style>
