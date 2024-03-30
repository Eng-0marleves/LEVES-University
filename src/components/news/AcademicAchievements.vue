<template>
	<div class="academic-achievements">
		<h2 class="section-title">Our Academic Achievements</h2>
		<ul class="achievements-list">
			<li v-for="achievement in achievements" :key="achievement.id" class="achievement-item">
				<h3>{{ achievement.title }}</h3>
				<p>{{ achievement.description }}</p>
				<span class="achievement-date">Date: {{ achievement.date }}</span>
			</li>
		</ul>
	</div>
</template>

<script>
export default {
	name: 'AcademicAchievements',
	data() {
		return {
			achievements: [
				{ id: 1, title: 'Nobel Prize in Physics', description: 'Awarded to Prof. Jane Doe for her groundbreaking work in quantum computing.', date: '2022-10-07' },
				{ id: 2, title: 'Rhodes Scholars', description: 'Three students from the university were awarded the prestigious Rhodes Scholarship.', date: '2023-02-15' },
				{ id: 3, title: 'National Science Foundation Grant', description: 'The biology department received a substantial grant for research in marine biology.', date: '2023-05-21' },
				// Add more achievements here
			],
		};
	},
	methods: {
		// You can add methods to handle data or interactions
	},
	computed: {
		// Any computed properties to manipulate data can be added here
	},
	mounted() {
		// This could be used to fetch achievements data from an API if needed
	},
};
</script>

<style scoped>
.academic-achievements {
	padding: 20px;
}

.section-title {
	text-align: center;
	margin-bottom: 30px;
}

.achievements-list {
	list-style-type: none;
	padding: 0;
}

.achievement-item {
	margin-bottom: 20px;
	padding: 15px;
	border: 1px solid #ddd;
	border-radius: 8px;
	background-color: var(--white-color);
}

.achievement-date {
	display: block;
	margin-top: 10px;
	font-style: italic;
	color: #666;
}
</style>
