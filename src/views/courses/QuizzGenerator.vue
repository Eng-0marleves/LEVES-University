<template>
	<div class="quizz-generator p-3">
		<h1>Quizz Generator</h1>

		<div class="card">
			<h5 class="card-header">Featured</h5>
			<div class="card-body" ref="page">
				<button @click="addQuestion" class="btn normal">Add Question</button>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'QuizzGenerator',
	data() {
		return {
			questionCounter: 0,
		};
	},
	methods: {
		addQuestion() {
			this.questionCounter++;
			console.log(this.questionCounter);
			this.$refs.page.innerHTML += `<h1>Question ${this.questionCounter}</h1>`;
		}
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
.card-header {
	background: var(--primary-color);
	color: var(--white-color);
}
</style>
