<template>
	<div class="quizz-generator">
		<div class="header d-flex justify-content-between align-items-center">

			<ul class="nav nav-tabs" id="myTab" role="tablist">
				<li class="nav-item" role="presentation">
					<button class="nav-link active" id="create-tab" data-bs-toggle="tab"
						data-bs-target="#create-tab-pane" type="button" role="tab" aria-controls="create-tab-pane"
						aria-selected="true">
						Create
					</button>
				</li>
				<li class="nav-item" role="presentation">
					<button class="nav-link" id="settings-tab" data-bs-toggle="tab" data-bs-target="#settings-tab-pane"
						type="button" role="tab" aria-controls="settings-tab-pane" aria-selected="false">
						Settings
					</button>
				</li>
			</ul>

			<div class="controllers d-flex flex-row gap-4 align-items-center">
				<button class="print d-flex gap-2 align-items-center" id="print-btn">
					<i class="fa-solid fa-print"></i>
					<p>Print</p>
				</button>
				<button class="preview d-flex gap-2 align-items-center">
					<i class="fa-regular fa-eye"></i>
					<p>Preview</p>
				</button>
			</div>
		</div>

		<div class="title w-100 d-flex gap-1">Title: <p id="quizzTitle">{{ quizz.title }}</p>
		</div>

		<div class="tab-content" id="myTabContent">
			<div class="tab-pane fade show active" id="create-tab-pane" role="tabpanel" aria-labelledby="create-tab"
				tabindex="0">
				<GeneratorCreate />
			</div>
			<div class="tab-pane fade" id="settings-tab-pane" role="tabpanel" aria-labelledby="settings-tab"
				tabindex="0">
				Settings
			</div>
		</div>
	</div>
</template>

<script>
import GeneratorCreate from '@/components/courses/quizzes/GeneratorCreate.vue';

export default {
	name: 'QuizzGenerator',
	data() {
		return {
			quizz: {
				quizId: 1,
				title: "Quizz Title",
				description: "",
				courseCode: "",
				isPublished: false,
				publishDate: "",
				From: "",
				To: "",
				duration: "",
				showResult: true,
				totalGrade: 100,
				enrolls: [],
				page: [
					{
						pageId: "1",
						questions: []
					}
				]
			}
		};
	},
	components: {
		GeneratorCreate
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	}
};
</script>

<style scoped>
.quizz-generator .header {
	padding: 8px;
	padding-bottom: 0px;
	background: var(--primary-color);
	border-bottom: 1px solid var(--white-color);
}

.header .controllers button {
	color: var(--white-color);
}

.title {
	padding: 8px;
	background: var(--white-color);
}

.nav-tabs {
	border-color: transparent !important;
}

.nav-tabs .nav-link {
	color: var(--white-color) !important;
}

.nav-tabs .nav-link.active {
	background: var(--secondary-color);
}

.nav-link.active {
	border-color: transparent !important;
}
</style>
