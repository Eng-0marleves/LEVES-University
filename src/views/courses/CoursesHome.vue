<template>
	<div class="courses_home">
		<SearchBar class="search" :onSearch="filterCourses" />
		<CardsContainer :courses="filteredCourses" />
	</div>
</template>

<script>
import CardsContainer from '../../components/courses/cards/CardsContainer.vue';
import SearchBar from '@/components/global/SearchBar.vue';
import axios from 'axios';
import { ref } from 'vue';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: "CoursesHome",
	components: {
		CardsContainer,
		SearchBar
	},
	setup() {
		const courses = ref([]);
		const filteredCourses = ref([]);

		var token = Cookies.get('user-auth-token');
		var decodedToken = jwtDecode(token);
		var userData = decodedToken;

		const getCourses = async () => {
			try {
				const response = await axios.get(`https://localhost:44303/api/Courses/user/courses?userId=${userData.id}`);
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
					return course.courseTitle.toLowerCase().includes(lowerCaseSearchInput) || course.courseCode.toLowerCase().includes(lowerCaseSearchInput);
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

<style scoped>
.search {
	margin: 8px 0;
	margin-left: auto;
}
</style>