<template>
	<div class="dashboard-financials">
		<h2>Financial Overview</h2>
		<div class="financial-section">
			<h3>Tuition Fees</h3>
			<p>Status: {{ financialData.tuitionStatus }}</p>
			<p>Amount Due: {{ financialData.tuitionDue }}</p>
		</div>
		<div class="financial-section">
			<h3>Scholarships</h3>
			<p>{{ financialData.scholarshipDetails }}</p>
		</div>
		<div class="financial-section">
			<h3>Recent Transactions</h3>
			<ul>
				<li v-for="transaction in financialData.recentTransactions" :key="transaction.id">
					{{ transaction.date }} - {{ transaction.description }}: {{ transaction.amount }}
				</li>
			</ul>
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
					{ id: 2, date: '2023-01-10', description: 'Scholarship Credit', amount: '+$2000' }
				],
			},
		};
	}
};
</script>

<style scoped>
.dashboard-financials {
	padding: 20px;
}

.financial-section {
	margin-bottom: 20px;
}

.financial-section h3 {
	margin-bottom: 10px;
}

ul {
	padding-left: 20px;
}

li {
	margin-bottom: 5px;
}
</style>
