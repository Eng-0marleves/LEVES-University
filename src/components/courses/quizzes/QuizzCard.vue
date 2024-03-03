<template>
	<div class="quizz-card">
		<div class="quizz-card__header">
			<h2 class="quizz-card__title">{{ quiz.title }}</h2>
			<p class="quizz-card__chapter">{{ quiz.chapter }}</p>
		</div>
		<div class="quizz-card__details">
			<p><strong>Start:</strong> {{ quiz.start }}</p>
			<p><strong>End:</strong> {{ quiz.end }}</p>
		</div>
		<div class="quizz-card__actions d-flex flex-row gap-3">
			<button class="btn normal" @click="joinQuiz">Join</button>
			<button class="btn normal" @click="editQuiz">Edit</button>
			<button class="btn normal" @click="analyseQuiz">Anlysis</button>
		</div>
	</div>
</template>

<script>
export default {
	name: 'QuizzCard',
	props: {
		quiz: {
			type: Object,
			required: true,
		},
	},
	data() {
		return {
			// data properties go here
		};
	},
	methods: {
		joinQuiz() {
			// join quiz logic goes here
		},
		editQuiz() {
			// edit quiz logic goes here
		},
		analyseQuiz() {
			// analyse quiz logic goes here
		}
	},
	computed: {
		// computed properties go here
	},
};
</script>

<style scoped>
.quizz-card {
	border: 1px solid #ccc;
	border-radius: 8px;
	box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
	padding: 1em;
	margin-bottom: 20px;
	width: 300px;
}

.quizz-card__header {
	margin-bottom: 10px;
}

.quizz-card__title {
	font-size: 1.5em;
	margin-bottom: 5px;
}

.quizz-card__chapter {
	font-size: 1.2em;
	color: #666;
}

.quizz-card__details {
	margin-bottom: 10px;
}

.quizz-card__details p {
	margin: 5px 0;
}

/* .quizz-card__actions button {
	padding: 8px 16px;
	border: none;
	border-radius: 4px;
	background-color: #007bff;
	color: #fff;
	cursor: pointer;
	transition: background-color 0.3s ease;
}

.quizz-card__actions button:hover {
	background-color: #0056b3;
} */
</style>
