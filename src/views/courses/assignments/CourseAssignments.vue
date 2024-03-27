<template>
	<div class="CourseAssignments">
		<router-link :to="`CourseQuizzes/quizz_generator`" class="btn normal generator">Assignments
			Generator</router-link>

		<div class="card-body">
			<h6>Lorem ipsum dolor sit amet consectetur</h6>

			<div class="controllers d-flex flex-row flex-wrap gap-2 align-items-center">
				<div class="status me-3">{{ isPublished ? 'Open' : 'In Design' }}</div>
				<router-link to="" class="action-btn" v-if="isPublished">Open</router-link>
				<router-link to="" class="action-btn" v-if="!isPublished">Preview</router-link>
				<router-link to="" class="action-btn" v-if="isPublished">Result</router-link>
				<router-link to="" class="action-btn" v-if="isPublished">Analysis</router-link>

				<a class="action-btn dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
					aria-expanded="false">
					Action
				</a>

				<ul class="dropdown-menu">
					<li><a class="dropdown-item" href="#">Edit</a></li>
					<li><a class="dropdown-item" href="#">Delete</a></li>
					<li><a class="dropdown-item" href="#">Rename</a></li>
				</ul>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'CourseAssignments',
	data() {
		return {
			isPublished: false
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	created() {
		// Code to run when the component is created
	},
};
</script>

<style scoped>
.CourseAssignments {
	padding: 16px;
}

.card-body {
	padding: 16px;
	border: 1px solid #ccc;
	border-radius: 8px;
	display: flex;
	justify-content: space-between;
	align-items: center;
	background: var(--white-color);
}

.loading {
	text-align: center;
	padding: 20px;
}

.CourseQuizzes .generator {
	margin: 0 auto;
}

.action-btn {
	color: var(--white-color);
	background: var(--primary-color);
	padding: 4px 8px;
	transition: var(--transition);
}

.action-btn:hover {
	opacity: 0.9;
}

.generator {
	margin-bottom: 16px;
}
</style>