<template>
	<div class="page">
		<div class="header">
			<div class="title">
				<p v-if="!editingTitle">{{ page.title }}</p>
				<input v-else type="text" v-model="editedTitle" @keydown.enter="saveTitle" @blur="saveTitle"
					autofocus />
			</div>

			<div class="controllers d-flex align-items-center gap-3">
				<button class="action-btn" @click="toggleEdit">
					<i class="fa-solid fa-pen-to-square"></i>
				</button>
				<button class="action-btn" @dblclick="movePage">
					<i class="fa-solid fa-arrows-up-down-left-right"></i>
				</button>
				<button class="action-btn" @click="deletePage">
					<i class="fa-solid fa-xmark"></i>
				</button>
			</div>
		</div>

		<div class="content">
			{{ page }}
		</div>

		<div class="body">
			<div class="questions">
				<!-- <GeneratorQuestion v-for="(question, index) in page.questions" :key="index" :question="question"
					:questionNumber="index + 1" /> -->
				<button class="btn normal" data-bs-toggle="modal" data-bs-target="#questionGeneratorModal"
					@click="addQuestion">Add Question</button>


				<div class="modal fade modal-xl" id="questionGeneratorModal" tabindex="-1"
					aria-labelledby="questionGeneratorModal" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<h1 class="modal-title fs-5" id="">New Question</h1>
								<button type="button" class="btn-close" data-bs-dismiss="modal"
									aria-label="Close"></button>
							</div>
							<div class="modal-body">


								<GeneratorQuestion ref="generatorQuestionRef" @save-question="handleSaveQuestion" />

							</div>
							<div class="modal-footer">
								<button type="button" class="btn btn-danger" ref="cancle"
									data-bs-dismiss="modal">Cancle</button>
								<button type="button" class="btn btn-success">Save and Add Another</button>
								<button type="button" class="btn btn-success" @click="handleSaveQuestion">Save</button>
							</div>
						</div>
					</div>
				</div>


			</div>
		</div>
	</div>
</template>

<script>
import GeneratorQuestion from './GeneratorQuestion.vue';

export default {
	name: 'GeneratorPage',
	props: {
		page: Object,
		pageNumber: Number
	},
	components: {
		GeneratorQuestion
	},
	data() {
		return {
			editingTitle: false,
			editedTitle: '',
			Page: this.$props.page
		};
	},
	computed: {
		pageTitle() {
			return this.page.title || `Page ${this.pageNumber}`;
		}
	},
	methods: {
		toggleEdit() {
			this.editedTitle = this.page.title || '';
			this.editingTitle = !this.editingTitle;
		},
		saveTitle() {
			if (this.editedTitle.trim() !== '') {
				this.$emit('edit-page', this.page.pageId, this.editedTitle);
				this.editingTitle = false;
			} else {
				this.editingTitle = false; // Maybe reset to original title if necessary
			}
		},
		deletePage() {
			this.$emit('delete-page', this.page.pageId);
		},
		movePage() {
			this.$emit('move-page');
		},
		handleSaveQuestion() {
			const questionData = this.$refs.generatorQuestionRef.saveQuestion();
			this.Page.questions.push(questionData);
			this.$refs.cancle.click();
			// this.$emit('save-page', this.Page);
			console.log(this.Page);

		},

	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
.page {
	width: 100%;
}

.page .header {
	width: 100%;
	padding: 8px;
	display: flex;
	justify-content: space-between;
	align-items: center;
	color: var(--white-color);
	background: var(--primary-color);
}

.page .header .controllers button i {
	color: var(--white-color);
}

.content {
	padding: 8px;
}

.body {
	width: 100%;
	padding: 8px;
	background: var(--white-color);
	border: 1px solid var(--primary-color);
	border-top: none;
}

.page.dragging {
	opacity: 0.5;
}

.modal {
	z-index: 100000000000;
}
</style>
