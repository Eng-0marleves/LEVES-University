<template>
	<div class="courses_home">
		<SearchBar :onSearch="filterCourses" />
		<CardsContainer :courses="filteredCourses" />
	</div>
</template>

<script>
import CardsContainer from '../../components/courses/cards/CardsContainer.vue';
import SearchBar from '@/components/global/SearchBar.vue';
import axios from 'axios';
import { ref } from 'vue';

export default {
	name: "CoursesHome",
	components: {
		CardsContainer,
		SearchBar
	},
	setup() {
		const courses = ref([]);
		const filteredCourses = ref([]);

		const getCourses = async () => {
			try {
				const response = await axios.get("http://localhost:3000/courses");
				courses.value = response.data;
				// Initialize filteredCourses with all courses
				filteredCourses.value = response.data;
			} catch (error) {
				console.error("Error fetching courses:", error);
			}
		};

		const filterCourses = (searchInput) => {
			if (!searchInput.trim()) {
				filteredCourses.value = courses.value;
			} else {
				// Filter courses based on search input
				filteredCourses.value = courses.value.filter(course => {
					const lowerCaseSearchInput = searchInput.toLowerCase().trim();
					return course.course_name.toLowerCase().includes(lowerCaseSearchInput) || course.course_code.toLowerCase().includes(lowerCaseSearchInput);
				});
			}
		};

		getCourses();

		return {
			filterCourses,
			filteredCourses
		};
	}
}
</script>
