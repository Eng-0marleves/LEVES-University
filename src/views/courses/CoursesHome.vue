<template>
	<div class="courses_home">
		<input type="text" v-model="searchQuery" placeholder="Search by Course Code or Name">
		<CardsContainer :courses="courses" />
	</div>
</template>

<script>
import CardsContainer from '../../components/courses/cards/CardsContainer.vue';
import axios from 'axios';
import { ref, computed, watch } from 'vue';

export default {
	name: "CoursesHome",
	components: {
		CardsContainer,
	},
	setup() {
		const courses = ref([]);
		const searchQuery = ref('');

		const filteredCourses = computed(() => {
			if (!searchQuery.value) {
				return courses.value;
			}
			const query = searchQuery.value.toLowerCase();

			let c = courses;
			return c.value.filter(course => {
				let x = course;
				return x.course_code.toLowerCase().includes(query) ||
					x.name.toLowerCase().includes(query);
			});
		});

		const getCourses = async () => {
			try {
				const response = await axios.get("http://localhost:3000/courses");
				courses.value = response.data;
			} catch (error) {
				console.error("Error fetching courses:", error);
			}
		};

		getCourses();

		watch(searchQuery, () => {
			console.log(filteredCourses.value);
		});

		return {
			courses,
			searchQuery,
			filteredCourses
		};
	}
}
</script>
