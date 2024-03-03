<template>
	<div class="cards-container">
		<CourseCard v-for="(course, index) in courses" :key="index" :course="course" />
	</div>
</template>

<script>
import CourseCard from './CourseCard.vue';

export default {
	name: "CardsContainer",
	components: {
		CourseCard
	},
	props: {
		courses: {
			type: Array,
			required: true
		}
	}
}
</script>

<style scoped>
.cards-container {
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: wrap;
}
</style>
