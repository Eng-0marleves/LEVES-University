<template>
	<div class="quizz-details p-2 d-flex flex-column align-items-center gap-2">
		<div class="content w-100">
			<div v-for="(detail, index) in details" :key="index" class="item d-flex flex-row align-items-stretch">
				<div class="left">
					<div class="left-content d-flex align-items-center gap-3">
						<i class="fa-solid fa-angles-right"></i>
						<p>{{ detail.leftTitle }}: </p>
					</div>
				</div>
				<div class="right">
					{{ quizz && quizz[detail.rightKey] }}
				</div>
			</div>
		</div>
		<router-link
			:to="{ name: 'quizz', params: { course_code: $route.params.course_code, quiz_id: $route.params.quizId } }"
			class="btn normal" target="_blank">
			Start
		</router-link>
	</div>
</template>

<script>
import axios from 'axios';
export default {
	name: 'QuizzDetails',
	data() {
		return {
			quizz: null,
			details: [
				{ leftTitle: 'Title', rightKey: 'title' },
				{ leftTitle: 'From', rightKey: 'From' },
				{ leftTitle: 'To', rightKey: 'To' },
				{ leftTitle: 'Duration', rightKey: 'duration' },
				{ leftTitle: 'Grade', rightKey: 'totalGrade' }
			]
		};
	},
	methods: {
		async fetchQuizz() {
			try {
				const response = await axios.get(`http://localhost:3000/quizzes?quizId=${this.$route.params.quiz_id}`);
				if (response.status === 200) {
					console.log(response.data[0]);
					this.quizz = response.data[0];
				} else {
					console.error("Error fetching quizz");
				}
			} catch (e) {
				console.error(e);
			}
		}
	},
	created() {
		this.fetchQuizz();
	}
};
</script>

<style scoped>
.item {
	padding: 16px;
	color: var(--white-color);
	background: var(--primary-color);
}

.item:nth-child(even) {
	background: #ccc;
	color: #000;
}

i {
	color: var(--secondary-color);
}

.left {
	flex: 1;
}

.right {
	flex: 2;
}

.left-content {
	display: flex;
	align-items: center;
	gap: 3px;
}

.btn.normal {
	margin: 0 auto;
}
</style>
