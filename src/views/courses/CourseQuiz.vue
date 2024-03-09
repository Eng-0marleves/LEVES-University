<template>
	<div>
		<div class="duration" :style="{ color: durationColor }">
			{{ formattedDuration }}
		</div>

		<div class="course-quiz p-3">
			<div class="pages d-flex flex-column gap-5">
				<div class="page" v-for="(page, i) in currentPageQuestions" :key="i">
					<h1 class="page-title">Page {{ currentPageIndex + 1 }}</h1>

					<div class="questions d-flex flex-column gap-5">
						<div class="question" v-for="(question, j) in page.questions" :key="j">
							<h3 class="question-text">{{ question.text }}</h3>

							<div class="answers">
								<template v-if="question.type === 'multiple_choice'">
									<div class="answer" v-for="(answer, k) in question.answers" :key="k">
										<input type="radio" :id="`answer-${currentPageIndex}-${j}-${k}`"
											:name="`question-${currentPageIndex}-${j}`" :value="answer.text" />
										<label :for="`answer-${currentPageIndex}-${j}-${k}`" class="answer-label">{{
			answer.text }}</label>
									</div>
								</template>
								<template v-else-if="question.type === 'text_entry'">
									<textarea :id="`text-${currentPageIndex}-${j}`"
										:name="`question-${currentPageIndex}-${j}`" rows="4" cols="50"
										placeholder="Enter your text" class="text-entry"></textarea>
								</template>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div class="pagination">
				<button @click="prevPage" :disabled="currentPageIndex === 0">Previous</button>
				<button @click="nextPage" :disabled="currentPageIndex === totalPages - 1">Next</button>
			</div>
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'CourseQuiz',
	data() {
		return {
			quizz: {},
			formattedDuration: "00:00:00",
			timer: null,
			pages: [],
			currentPageIndex: 0,
			itemsPerPage: 1
		}
	},
	computed: {
		currentPageQuestions() {
			const startIndex = this.currentPageIndex * this.itemsPerPage;
			return this.pages.slice(startIndex, startIndex + this.itemsPerPage);
		},
		totalPages() {
			return Math.ceil(this.pages.length / this.itemsPerPage);
		}
	},
	methods: {
		formatDuration(duration) {
			const [hours, minutes, seconds] = duration.split(':');
			return `${hours} : ${minutes} : ${seconds}`;
		},
		startTimer() {
			this.timer = setInterval(() => {
				const [hours, minutes, seconds] = this.formattedDuration.split(':').map(Number);
				let totalSeconds = hours * 3600 + minutes * 60 + seconds;
				if (totalSeconds > 0) {
					totalSeconds--;
					const newHours = Math.floor(totalSeconds / 3600);
					const newMinutes = Math.floor((totalSeconds % 3600) / 60);
					const newSeconds = totalSeconds % 60;
					this.formattedDuration = `${newHours.toString().padStart(2, '0')} : ${newMinutes.toString().padStart(2, '0')} : ${newSeconds.toString().padStart(2, '0')}`;
					if (this.formattedDuration === "00:00:10") {
						this.$refs.duration.style.color = 'red';
					}
				} else {
					clearInterval(this.timer);
					this.$router.push(`/courses/${this.quizz.courseCode}/CourseQuizzes`);
				}
			}, 1000);
		},
		nextPage() {
			if (this.currentPageIndex < this.totalPages - 1) {
				this.currentPageIndex++;
			}
		},
		prevPage() {
			if (this.currentPageIndex > 0) {
				this.currentPageIndex--;
			}
		}
	},
	async mounted() {
		try {
			const response = await axios.get(`http://localhost:3000/quizzes?quizId=${this.$route.params.quiz_id}`);
			this.quizz = response.data[0];
			this.pages = this.quizz.pages;
			this.formattedDuration = this.formatDuration(this.quizz.duration);
			this.startTimer();
		} catch (error) {
			console.error('Error fetching quiz:', error);
		}
	},
	/* eslint-disable */
	beforeDestroy() {
		clearInterval(this.timer);
	}
}
</script>

<style scoped>
.duration {
	font-size: 24px;
	text-align: center;
	font-weight: bold;
}

.page-title {
	color: #333;
	font-size: 20px;
}

.question-text {
	font-size: 18px;
	color: #555;
}

.answer-label {
	margin-left: 10px;
}

.text-entry {
	border: 1px solid #ccc;
	padding: 5px;
}

.pagination {
	margin-top: 20px;
	display: flex;
	justify-content: center;
}

.pagination button {
	margin: 0 5px;
	padding: 5px 10px;
	cursor: pointer;
	background-color: #007bff;
	color: #fff;
	border: none;
	border-radius: 5px;
}

.pagination button:disabled {
	background-color: #ccc;
	cursor: not-allowed;
}
</style>
