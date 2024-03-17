<template>
	<div class="quizz">
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

							<div class="answers d-flex flex-column gap-3">
								<template v-if="question.type === 'multiple_choice'">
									<div v-for="(answer, k) in question.answers" :key="k" class="answer">
										<input type="radio" :id="answer.answerId" :name="question.questionId"
											:value="answer.text" v-model="selectedAnswers[i][j]" />
										<label :for="answer.answerId" class="radio-label ms-2">{{ answer.text }}</label>
										<span class="radio-custom"></span>
									</div>
								</template>
								<template v-else-if="question.type === 'text_entry'">
									<textarea :id="`text-${i}-${j}`" :name="`question-${i}-${j}`" rows="4" cols="50"
										placeholder="Enter your text" class="text-entry"></textarea>
								</template>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div class="pagination">
				<button class="btn normal" @click="firstPage" :disabled="currentPageIndex === 0">
					<i class="fa-solid fa-angles-left"></i>
				</button>

				<button class="btn normal" @click="prevPage" :disabled="currentPageIndex === 0">
					<i class="fa-solid fa-angle-left"></i>
				</button>


				<p>{{ currentPageIndex + 1 }} / {{ totalPages }}</p>

				<button class="btn normal" @click="nextPage" :disabled="currentPageIndex === totalPages - 1">
					<i class="fa-solid fa-angle-right"></i>
				</button>

				<button class="btn normal" @click="lastPage" :disabled="currentPageIndex === totalPages - 1">
					<i class="fa-solid fa-angles-right"></i>
				</button>
			</div>
		</div>

		<!-- Display the total number of answered questions -->
		<div class="answered-questions">
			Total Answered Questions: {{ totalAnsweredQuestions }}
		</div>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'CourseQuiz',
	data() {
		return {
			selectedAnswers: [], // Initialize selectedAnswers array
			quizz: {},
			duration: "00:00:00",
			formattedDuration: "00:00:00",
			timer: null,
			pages: [],
			currentPageIndex: 0,
			itemsPerPage: 1,
			totalSeconds: 0,
			totalDurationInSeconds: 0,
			elapsedPercentage: 0
		};
	},
	computed: {
		currentPageQuestions() {
			const startIndex = this.currentPageIndex * this.itemsPerPage;
			return this.pages.slice(startIndex, startIndex + this.itemsPerPage);
		},
		totalPages() {
			return Math.ceil(this.pages.length / this.itemsPerPage);
		},
		totalAnsweredQuestions() {
			// Flatten the selectedAnswers array and count non-empty values
			return this.selectedAnswers.flat().filter(answer => answer !== "").length;
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
					this.formattedDuration = `${newHours.toString().padStart(2, '0')} : ${newMinutes
						.toString()
						.padStart(2, '0')} : ${newSeconds.toString().padStart(2, '0')}`;
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
		lastPage() {
			if (this.currentPageIndex < this.totalPages - 1) {
				this.currentPageIndex = this.totalPages - 1;
			}
		},
		prevPage() {
			if (this.currentPageIndex > 0) {
				this.currentPageIndex--;
			}
		},
		firstPage() {
			if (this.currentPageIndex > 0) {
				this.currentPageIndex = 0;
			}
		}
	},
	async mounted() {
		document.querySelector("body").classList.add("full");
		document.querySelector("nav").style.display = "none";
		document.querySelector("header").style.display = "none";

		try {
			const response = await axios.get(`http://localhost:3000/quizzes?quizId=${this.$route.params.quiz_id}`);
			this.quizz = response.data[0];
			this.pages = this.quizz.pages;
			this.duration = this.formatDuration(this.quizz.duration);
			this.formattedDuration = this.formatDuration(this.quizz.duration);
			this.startTimer();

			// Initialize selectedAnswers array and its nested arrays
			this.selectedAnswers = new Array(this.pages.length).fill([]).map(() => new Array(this.itemsPerPage).fill(""));
		} catch (error) {
			console.error('Error fetching quiz:', error);
		}
	},
	/* eslint-disable */
	beforeDestroy() {
		clearInterval(this.timer);
	},
	/* eslint-disable */
	destroyed() {
		document.querySelector("body").classList.remove("full");
		document.querySelector("nav").style.display = "block";
		document.querySelector("header").style.display = "flex";
	}
};
</script>

<style scoped>
.quizz {
	width: 100%;
	min-height: 100vh;
	background: var(--white-color) !important;
}

.duration {
	font-size: 24px;
	text-align: center;
	font-weight: bold;
}

.page-title {
	color: #333;
	font-size: 20px;
}

.question {
	border-radius: 8px;
	box-shadow: 0 0 16px rgba(0, 0, 0, 0.05);
}

.question-text {
	font-size: 18px;
	color: var(--white-color);
	background: var(--primary-color);
	border-top-left-radius: 8px;
	border-top-right-radius: 8px;
	padding: 8px;
}

.answers {
	font-size: 18px;
	font-weight: 500;
	color: #666;
	padding: 8px;
	border: 1px solid var(--primary-color);
	border-bottom-left-radius: 8px;
	border-bottom-right-radius: 8px;
}

.text-entry {
	border: 1px solid #ccc;
	padding: 5px;
}

.pagination {
	margin-top: 20px;
	display: flex;
	justify-content: center;
	align-items: center;
	gap: 8px;
}

/* .pagination button {
	margin: 0 5px;
	padding: 5px 10px;
	cursor: pointer;
	background-color: #007bff;
	color: #fff;
	border: none;
	border-radius: 5px;
} */

.pagination button:disabled {
	opacity: .2;
	cursor: not-allowed;
}
</style>
