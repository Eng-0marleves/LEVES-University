<template>
	<div class="GeneratorQuestion">
		<div class="field">
			<p style="text-wrap: nowrap;">Question Type</p>
			<div class="field-container">
				<select v-model="questionType">
					<option class="d-flex gap-2 align-items-center" value="single-choice">

						<p><i class="fas fa-circle-dot"></i> Single Choice</p>
					</option>
					<option class="d-flex gap-2 align-items-center" value="multiple-choice">
						<i class="fas fa-square-check"></i>
						<p>Multiple Choice</p>
					</option>
					<option class="d-flex gap-2 align-items-center" value="picture-choice">
						<i class="fa-regular fa-image"></i>
						<p>Picture Choice</p>
					</option>
				</select>

				<div class="points">
					<label for="">Points</label>
					<input type="number" name="points" id="points" min="1" value="1" v-model="points">
				</div>

			</div>
		</div>

		<div class="line"></div>

		<div class="field">
			<p>Question</p>
			<div class="editor">
				<TextEditor />

				<div ref="question" class="output p-3" contenteditable="true">
				</div>
			</div>

			<div class="float-end d-flex align-items-centr gap-2 ms-auto">
				<input v-model="isShowFeedback" type="checkbox" id="isShowFeedback">
				<label for="isShowFeedback">Show question feedback</label>
			</div>

		</div>

		<div v-if="isShowFeedback && !isShowSeparateFeedback" class="line"></div>

		<div v-if="isShowFeedback && !isShowSeparateFeedback" class="field w-100">
			<p>Feedback</p>

			<div class="editor w-100">
				<TextEditor />

				<div ref="feedback" class="output p-3" contenteditable="true"></div>
			</div>
			<div class="float-end d-flex align-items-centr gap-2 ms-auto">
				<input v-model="isShowSeparateFeedback" type="checkbox" id="isShowSeparateFeedback">
				<label for="isShowSeparateFeedback">Separate correct / incorrect feedback</label>
			</div>
		</div>


		<div v-if="isShowFeedback && isShowSeparateFeedback" class="field">
			<p>Correct answer feedback</p>
			<div class="editor w-100">
				<TextEditor />

				<div class="output p-3" ref="correctFeedBack" contenteditable="true"></div>
			</div>
		</div>

		<div v-if="isShowFeedback && isShowSeparateFeedback" class="field">
			<p>Incorrect answer feedback</p>
			<div class="editor w-100">
				<TextEditor />

				<div class="output p-3" ref="inCorrectFeedBack" contenteditable="true">
				</div>
			</div>
		</div>

		<div class="line"></div>

		<div class="field">
			<p>Options</p>
			<div class="options">
				<OptionGenerator v-for="(option, index) in options" :key="option.id" :option="option"
					@deleteOption="deleteOption(index)" @updateOption="updateOption($event, index)" />
			</div>
			<button class="btn normal" @click="addOption">Add Option</button>
		</div>


		<button @click="saveQuestion">test</button>
	</div>
</template>

<script>
import TextEditor from "@/components/global/TextEditor.vue";
import OptionGenerator from "./OptionGenerator.vue";

export default {
	name: 'GeneratorQuestion',
	components: {
		TextEditor,
		OptionGenerator
	},
	data() {
		return {
			questionType: 'single-choice',
			points: 1,
			isShowFeedback: false,
			isShowSeparateFeedback: false,
			questionContent: '',
			feedbackContent: '',
			correctFeedbackContent: '',
			incorrectFeedbackContent: '',
			options: [],
		};
	},
	methods: {
		addOption() {
			this.options.push({
				id: this.generateUniqueId(5),
				text: '',
				correct: false
			});
		},
		deleteOption(index) {
			this.options.splice(index, 1);
		},
		updateOption(updatedOption, index) {
			this.options.splice(index, 1, updatedOption);
		},
		generateUniqueId(length) {
			return Math.random().toString(36).substr(2, length);
		},
		saveQuestion() {
			this.questionContent = this.$refs.question.innerHTML;
			// this.feedbackContent = this.isShowSeparateFeedback ? this.$refs.feedback.innerHTML || '' : '';
			// this.correctFeedbackContent = this.isShowSeparateFeedback ? this.$refs.correctFeedback.innerHTML || '' : '';
			// this.incorrectFeedbackContent = this.isShowSeparateFeedback ? this.$refs.incorrectFeedback.innerHTML || '' : '';

			const questionData = {
				type: this.questionType,
				points: this.points,
				questionContent: this.questionContent,
				// feedbackContent: this.feedbackContent,
				// correctFeedbackContent: this.correctFeedbackContent,
				// incorrectFeedbackContent: this.incorrectFeedbackContent,
				options: this.options,
			};

			this.$emit('save-question', questionData);
		}
	},
	mounted() {
		this.addOption();
		this.addOption();
	},
};
</script>

<style scoped>
.GeneratorQuestion {
	display: flex;
	flex-direction: column;
	align-items: center;
	gap: 16px;
}

.line {
	width: 100%;
	height: 1px;
	background: var(--primary-color);
}

.field {
	width: 100%;
	display: flex;
	flex-direction: column;
	align-items: flex-start;
	gap: 4px;
}

.field p {
	font-size: 1.2rem;
	font-weight: 500;
	color: var(--primary-color);
}

.field .field-container {
	width: 100%;
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.field select {
	color: var(--white-color);
	background: var(--primary-color);
	padding: 4px;
	border-radius: 4px;
}

.editor {
	border: 1px solid var(--primary-color);
}

#questionGeneratorModal>div>div>div.modal-body>div>div:nth-child(3)>div.editor {
	width: 100%;
}

.editor>div {
	padding: 4px !important;
	border-bottom: 1px solid var(--primary-color);
}

.options {
	width: 100%;
	display: flex;
	flex-direction: column;
	align-items: flex-start;
	gap: 16px;
	background: none;
}

.output {
	background: var(--white-color);
	width: 100%;
	height: 200px;
	overflow-wrap: break-word;
	overflow: auto;
	border-bottom: none !important;
}

#points {
	border: 1px solid var(--primary-color);
	margin-left: 8px;
	padding: 4px;
	width: 64px;
	border-radius: 4px;
}
</style>