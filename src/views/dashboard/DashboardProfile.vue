<template>
	<div class="dashboard-profile">
		<img src="https://t4.ftcdn.net/jpg/03/64/21/11/360_F_364211147_1qgLVxv1Tcq0Ohz3FawUfrtONzz8nq3e.jpg" alt=""
			class="profile_img">
		<h2>{{ profile.name }}</h2>
		<p class="profile-email">{{ profile.email }}</p>
		<p class="profile-role">{{ profile.role }} - {{ profile.department }}</p>
		<!-- <div class="recent-activities">
			<h3>Recent Activities</h3>
			<ul>
				<li v-for="(activity, index) in profile.recentActivities" :key="index">
					{{ activity }}
				</li>
			</ul>
		</div> -->
		<div class="enrolled-subjects">
			<h3>Enrolled Subjects</h3>
			<ul>
				<li v-for="(course) in profile.enrolledCourses" :key="course.id">
					{{ course.name }} (Code: <router-link class="router" :to="`/courses/${course.code}`">{{ course.code
						}}</router-link>)
				</li>
			</ul>
		</div>
	</div>
</template>


<script>
export default {
	name: 'DashboardProfile',
	data() {
		return {
			profile: {
				name: "Alex Johnson",
				email: "alex.johnson@example.com",
				role: "Student",
				department: "Computer Science",
				// recentActivities: [
				// 	"Submitted assignment: CS101 - Introduction to Programming",
				// 	"Attended webinar: Future of AI",
				// 	"Updated profile picture"
				// ],
				enrolledCourses: [
					{ code: "CSE101", name: "Introduction to Computer Science" },
					{ code: "MATH301", name: "Discrete Mathematics" },
					{ code: "AI701", name: "Technical Writing" }
				]
			}
		};
	}
};
</script>


<style scoped>
.dashboard-profile {
	width: 100%;
	padding: 16px;
	display: flex;
	justify-content: center;
	align-items: center;
	flex-direction: column;
	text-align: center;
}

.router {
	color: var(--primary-color);
}

.router:hover {
	color: var(--secondary-color);
}

.dashboard-profile .profile_img {
	width: 200px;
	height: 200px;
	border-radius: 50%;
	object-fit: cover;
	border: 4px solid var(--secondary-color);
	margin-bottom: 20px;
}

.profile-email,
.profile-role {
	margin: 5px 0;
}

.recent-activities h3 {
	margin-top: 20px;
}

.recent-activities ul {
	list-style: none;
	padding: 0;
}

.recent-activities li {
	text-align: left;
	margin-top: 10px;
}

.enrolled-subjects h3 {
	margin-top: 20px;
}

.enrolled-subjects ul {
	list-style: none;
	padding: 0;
	margin-top: 10px;
}

.enrolled-subjects li {
	text-align: left;
	margin-top: 5px;
}
</style>
