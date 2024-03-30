<template>
	<div class="announcements-section">
		<h2 class="section-title">Latest Announcements</h2>
		<div class="announcements-filter">
			<button v-for="category in categories" :key="category" @click="filterCategory(category)"
				:class="['filter-btn', { active: currentCategory === category }]">
				{{ category }}
			</button>
		</div>
		<div class="announcement-list">
			<div v-for="announcement in displayedAnnouncements" :key="announcement.id" class="announcement-item">
				<h3>{{ announcement.title }}</h3>
				<p>{{ announcement.summary }}</p>
				<p class="date">Published on: {{ announcement.date }}</p>
				<router-link :to="`/announcements/${announcement.id}`">Read more</router-link>
			</div>
		</div>
		<button @click="toggleViewAll" class="view-all-btn">{{ viewAll ? 'View Less' : 'View All' }}</button>
	</div>
</template>


<script>
export default {
	name: 'AnnouncementsSection',
	data() {
		return {
			announcements: [
				{
					id: "1",
					title: "Fall Semester Registration Open",
					summary: "Registration for the Fall 2023 semester is now open. Ensure to check the deadlines.",
					date: "2023-07-01",
					category: "Academic",
				},
				{
					id: "2",
					title: "New Campus Library Opens",
					summary: "The new campus library has officially opened its doors to students and faculty.",
					date: "2023-07-05",
					category: "Events",
				},
				{
					id: "3",
					title: "Upcoming Guest Lecture on Climate Change",
					summary: "Join us for a guest lecture on the impacts of climate change this Friday in the main auditorium.",
					date: "2023-07-10",
					category: "Events",
				},
				{
					id: "4",
					title: "Career Fair This Weekend",
					summary: "Don't miss out on this weekend's career fair. It's a great opportunity to connect with potential employers.",
					date: "2023-07-15",
					category: "Events",
				},
				{
					id: "5",
					title: "Annual Sports Meet",
					summary: "Our annual sports meet is scheduled for next month. Time to get your game on!",
					date: "2023-07-20",
					category: "Sports",
				},
				{
					id: "6",
					title: "Scholarship Applications Now Open",
					summary: "Applications for scholarships for the upcoming academic year are now open.",
					date: "2023-07-25",
					category: "Academic",
				},
				{
					id: "7",
					title: "New Research Opportunities",
					summary: "Explore new research opportunities available this semester in our latest announcement.",
					date: "2023-07-30",
					category: "Academic",
				},
				{
					id: "8",
					title: "Alumni Gathering",
					summary: "Join us for the annual alumni gathering and reconnect with your batchmates.",
					date: "2023-08-04",
					category: "Events",
				},
				{
					id: "9",
					title: "Study Abroad Information Session",
					summary: "Interested in studying abroad? Attend our information session to learn more.",
					date: "2023-08-09",
					category: "Academic",
				},
				{
					id: "10",
					title: "Tech Hackathon",
					summary: "Register for our upcoming tech hackathon and showcase your coding skills.",
					date: "2023-08-14",
					category: "Events",
				},
				{
					id: "11",
					title: "Mental Health Workshop",
					summary: "Attend our mental health workshop to learn coping strategies and resources available on campus.",
					date: "2023-08-19",
					category: "Academic",
				},
				{
					id: "12",
					title: "Campus Art Exhibition",
					summary: "Explore the creative works of students and faculty at our campus art exhibition.",
					date: "2023-08-24",
					category: "Events",
				},
				{
					id: "13",
					title: "Science and Innovation Fair",
					summary: "Join us at the science and innovation fair to see groundbreaking projects from our students.",
					date: "2023-08-29",
					category: "Academic",
				},
				{
					id: "14",
					title: "Community Service Day",
					summary: "Participate in our community service day and give back to the local community.",
					date: "2023-09-03",
					category: "Events",
				},
				{
					id: "15",
					title: "Inter-College Sports Championship",
					summary: "Cheer for your teams at the inter-college sports championship happening next week.",
					date: "2023-09-08",
					category: "Sports",
				},
			],
			categories: ["All", "Events", "Academic", "Sports"],
			currentCategory: "All",
			viewAll: false,
		};
	},
	computed: {
		filteredAnnouncements() {
			if (this.currentCategory === "All") {
				return this.announcements;
			}
			return this.announcements.filter(announcement => announcement.category === this.currentCategory);
		},
		displayedAnnouncements() {
			return this.viewAll ? this.filteredAnnouncements : this.filteredAnnouncements.slice(0, 6);
		}
	},
	methods: {
		filterCategory(category) {
			this.currentCategory = category;
			this.viewAll = false; // Reset viewAll when category changes
		},
		toggleViewAll() {
			this.viewAll = !this.viewAll;
		},
	},
};
</script>

<style scoped>
.announcements-section .section-title {
	text-align: center;
	margin-bottom: 20px;
}

.announcements-filter {
	display: flex;
	justify-content: center;
	gap: 10px;
	margin-bottom: 20px;
}

.filter-btn {
	padding: 5px 10px;
	background-color: var(--primary-color);
	color: var(--white-color);
	border-radius: 8px;
	cursor: pointer;
}

.filter-btn:hover,
.filter-btn.active {
	background-color: var(--secondary-color);
}

.announcement-list {
	display: grid;
	grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
	gap: 20px;
	padding: 16px;
}

.announcement-item {
	border: 1px solid #ddd;
	padding: 15px;
	border-radius: 5px;
	background-color: #f9f9f9;
}

.announcement-item h3 {
	margin: 0;
	color: #333;
}

.announcement-item .date {
	font-size: 0.8em;
	color: #666;
}

.view-all-btn {
	display: block;
	margin: 20px auto;
	padding: 10px 20px;
	background-color: var(--primary-color);
	color: var(--white-color);
	border-radius: 8px;
	cursor: pointer;
}

.view-all-btn:hover {
	opacity: 0.8;
}
</style>