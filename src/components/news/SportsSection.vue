<template>
	<div class="sports-section">
		<section class="featured-teams">
			<h2>Featured Teams</h2>
			<div class="teams-container">
				<div class="team-card" v-for="team in teams" :key="team.name">
					<img :src="team.logo" :alt="`${team.name} Logo`" class="team-logo">
					<div class="team-info">
						<h3>{{ team.name }}</h3>
						<p>{{ team.description }}</p>
					</div>
				</div>
			</div>
		</section>

		<section class="upcoming-matches">
			<h2>Upcoming Matches</h2>
			<table>
				<thead>
					<tr>
						<th>Match</th>
						<th>Date</th>
						<th>Details</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="match in upcomingMatches" :key="match.date">
						<td><strong>{{ match.team1 }}</strong> vs <strong>{{ match.team2 }}</strong></td>
						<td>{{ formatDate(match.date) }}</td>
						<td><button @click="viewMatchDetails(match)">View</button></td>
					</tr>
				</tbody>
			</table>
		</section>

		<section class="recent-results">
			<h2>Recent Results</h2>
			<table>
				<thead>
					<tr>
						<th>Match</th>
						<th>Result</th>
						<th>Date</th>
					</tr>
				</thead>
				<tbody>
					<tr v-for="result in recentResults" :key="result.date"
						:class="{ 'win': result.result.includes('Win'), 'loss': result.result.includes('Lost') }">
						<td>{{ result.team }} vs {{ result.opponent }}</td>
						<td><strong>{{ result.result }}</strong></td>
						<td>{{ formatDate(result.date) }}</td>
					</tr>
				</tbody>
			</table>
		</section>

	</div>
</template>

<script>
export default {
	name: 'SportsSection',
	data() {
		return {
			teams: [
				{ name: "Basketball", logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/2023-24_Brown_Bears_mens_basketball_players.jpg/800px-2023-24_Brown_Bears_mens_basketball_players.jpg", description: "Defending champions of the regional conference." },
				{ name: "Soccer", logo: "https://thomasmoresaints.com/images/2023/12/6/Celebration__7_.jpg?width=936&height=527&mode=crop&scale=both&format=jpg&quality=80", description: "A team known for their quick plays and teamwork." },
				// More teams...
			],
			upcomingMatches: [
				{ team1: "Basketball", team2: "Tech University", date: "2024-04-05" },
				{ team1: "Soccer", team2: "City College", date: "2024-04-12" },
				// More matches...
			],
			recentResults: [
				{ team: "Basketball", opponent: "Historic College", result: "Win 102-97", date: "2024-03-30" },
				{ team: "Soccer", opponent: "Modern University", result: "Lost 2-3", date: "2024-03-25" },
				// More results...
			],
		};
	},
	methods: {
		formatDate(value) {
			const options = { year: 'numeric', month: 'long', day: 'numeric' };
			return new Date(value).toLocaleDateString(undefined, options);
		},
		viewMatchDetails(match) {
			// Implementation depends on your app's structure:
			// Could open a modal, display a tooltip, or navigate to a detailed match page
			console.log('Viewing details for match:', match);
		},
	},
};
</script>

<style scoped>
.sports-section {
	display: flex;
	flex-direction: column;
	gap: 32px;
	padding: 20px;
}

h2 {
	margin-bottom: 16px;
	color: #333;
}

.teams-container,
.profiles-container {
	display: flex;
	flex-wrap: wrap;
	gap: 20px;
}

.team-card,
.profile-card {
	flex: 1;
	min-width: 280px;
	border: 1px solid #ddd;
	border-radius: 8px;
	overflow: hidden;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
	padding: 15px;
}

.team-logo {
	width: 100%;
	height: 300px;
	object-fit: cover;
	margin-bottom: 15px;
}

ul {
	list-style-type: none;
	padding: 0;
}

li {
	margin-bottom: 10px;
}

li strong {
	color: #007bff;
}

li span {
	margin-left: 10px;
	font-size: 0.9em;
	color: #666;
}

table {
	width: 100%;
	border-collapse: collapse;
}

th,
td {
	border: 1px solid #ddd;
	padding: 8px;
	text-align: left;
}

th {
	background-color: #f4f4f4;
}

tr:nth-child(even) {
	background-color: #f9f9f9;
}

tr:hover {
	background-color: #eef;
}

.win {
	color: green;
}

.loss {
	color: red;
}

button {
	cursor: pointer;
}
</style>
