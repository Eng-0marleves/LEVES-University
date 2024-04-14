<template>
	<div class="dashboard-financials">
		<div class="card financial-section">
			<h3>Tuition Fees</h3>
			<p>Status: <strong>{{ financialData.tuitionStatus }}</strong></p>
			<p>Amount Due: <strong>{{ financialData.tuitionDue }}</strong></p>
		</div>
		<div class="card financial-section">
			<h3>Scholarships</h3>
			<p>{{ financialData.scholarshipDetails }}</p>
		</div>
		<div class="card financial-section">
			<h3>Recent Transactions</h3>
			<table>
				<thead>
					<tr>
						<th>Date</th>
						<th>Description</th>
						<th>Amount</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="transaction in financialData.recentTransactions" :key="transaction.id">
						<td>{{ transaction.date }}</td>
						<td>{{ transaction.description }}</td>
						<td>{{ transaction.amount }}</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
</template>

<script>
export default {
	name: 'DashboardFinancials',
	data() {
		return {
			financialData: {
				tuitionStatus: 'Paid',
				tuitionDue: '$0',
				scholarshipDetails: 'You have been awarded the Academic Excellence Scholarship.',
				recentTransactions: [
					{ id: 1, date: '2023-01-15', description: 'Tuition Payment', amount: '-$2000' },
					{ id: 2, date: '2023-01-10', description: 'Scholarship Credit', amount: '+$2000' },
					// Additional transactions as needed
				],
			},
		};
	},
};
</script>

<style scoped>
.dashboard-financials {
	max-width: 800px;
	margin: auto;
	padding: 20px;
	background: #f9f9f9;
	border-radius: 8px;
}

.card {
	background: white;
	padding: 20px;
	margin-bottom: 20px;
	border-radius: 8px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

table {
	width: 100%;
	border-collapse: collapse;
}

th,
td {
	text-align: left;
	padding: 8px;
	border-bottom: 1px solid #ddd;
}

th {
	background-color: #f2f2f2;
}

button {
	display: block;
	width: fit-content;
	padding: 10px 20px;
	background-color: #0056b3;
	color: white;
	border: none;
	border-radius: 5px;
	cursor: pointer;
	margin-top: 20px;
}

button:hover {
	background-color: #003d82;
}
</style>
