<template>
	<div class="container d-flex flex-column align-center">
		<!-- Button trigger modal -->
		<button type="button" class="btn normal mb-4" style="margin: 0 auto;" data-bs-toggle="modal"
			data-bs-target="#exampleModal">
			Create Quizz
		</button>

		<!-- Modal -->
		<div class="modal modal-lg fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
			aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<h1 class="modal-title fs-5" id="exampleModalLabel">New Quizz</h1>
						<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
					</div>
					<div class="modal-body">
						<input type="text" v-model="quizzTitle" placeholder="Enter title for your quizz">
					</div>
					<div class="modal-footer">
						<button ref="close" type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
						<button type="button" class="btn btn-success"
							:disabled="quizzTitle.length < 5 || !quizzTitle.trim()">
							<router-link class="text-white"
								:to="`/courses/${$route.params.course_code}/course_quizzes/quizz_generator`"
								@click="handleRouterClick">
								Create Quizz
							</router-link>
						</button>
					</div>
				</div>
			</div>
		</div>

		<div class="course-quizzes">
			<QuizzCard v-for="(quiz, index) in quizzes" :key="index" :quiz="quiz" />
		</div>
	</div>
</template>

<script>
import QuizzCard from './QuizzCard.vue';
export default {
	name: 'CourseQuizzes',
	components: {
		QuizzCard,
	},
	data() {
		return {
			quizzes: [], // Initialize an empty array to store quiz data
			quizzTitle: '', // Store the input text for quizz title
		};
	},
	methods: {
		generateDummyQuizzes() {
			// Generate dummy quiz data
			for (let i = 1; i <= 15; i++) {
				this.quizzes.push({
					title: `Quiz ${i}`,
					chapter: `Chapter ${i}`,
					start: `Start Date ${i}`,
					end: `End Date ${i}`
				});
			}
		},
		handleRouterClick() {
			this.$refs.close.click();
		}
	},
	mounted() {
		this.generateDummyQuizzes();
	},
}
</script>

<style scoped>
.course-quizzes {
	display: flex;
	flex-wrap: wrap;
	justify-content: space-around;
}

.modal {
	z-index: 100000;
}

.modal-body input {
	width: 100%;
	padding: 8px;
	/* font-size: 16px; */
	border: 2px solid #ddd;
	border-radius: 4px;
}

.disabled {
	opacity: 0.6;
	cursor: not-allowed;
}
</style>
