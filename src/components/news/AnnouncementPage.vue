<template>
	<div class="announcement-page">
		<div v-if="announcement" class="announcement-content">
			<h1>{{ announcement.title }}</h1>
			<p>{{ announcement.summary }}</p>
			<div class="announcement-body">
				{{ announcement.content }}
			</div>
			<p class="announcement-date">Published on: {{ announcement.date }}</p>
		</div>
		<div v-else>
			<p>Announcement not found.</p>
		</div>
	</div>
</template>

<script>
export default {
	name: 'AnnouncementPage',
	data() {
		return {
			announcement: {
				id: '1',
				title: 'Fall Semester Registration Open',
				summary: 'Registration for the Fall 2024 semester is now open. Ensure to check the deadlines.',
				content: 'Detailed information about the registration process and deadlines.',
				date: '2024-07-01',
				category: 'Academic'
			}
		};
	},
	methods: {
		async fetchAnnouncement() {
			// This should be replaced with an actual API call
			// For this example, we'll use static data
			const exampleAnnouncements = [
				{
					id: '1',
					title: 'Fall Semester Registration Open',
					summary: 'Registration for the Fall 2024 semester is now open. Ensure to check the deadlines.',
					content: 'Detailed information about the registration process and deadlines.',
					date: '2024-07-01',
					category: 'Academic'
				},
				// Add more announcements here
			];

			const announcementId = this.$route.params.id;
			this.announcement = exampleAnnouncements.find(announcement => announcement.id === announcementId);
		}
	},
	mounted() {
		// this.fetchAnnouncement();
	}
};
</script>

<style scoped>
.announcement-page {
	padding: 20px;
	background: #f9f9f9;
	border-radius: 8px;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
	max-width: 800px;
	margin: 40px auto;
}

.announcement-content {
	background: #ffffff;
	padding: 30px;
	border-radius: 8px;
}

.announcement-title {
	font-size: 28px;
	color: #333;
	margin-bottom: 15px;
}

.announcement-summary {
	font-size: 18px;
	color: #666;
	line-height: 1.6;
	margin-bottom: 20px;
}

.announcement-body {
	font-size: 16px;
	color: #444;
	line-height: 1.8;
	margin-top: 20px;
	border-top: 1px solid #eee;
	padding-top: 20px;
}

.announcement-date {
	margin-top: 20px;
	font-style: italic;
	color: #999;
}

@media (max-width: 768px) {
	.announcement-page {
		padding: 15px;
	}

	.announcement-content {
		padding: 20px;
	}

	.announcement-title {
		font-size: 24px;
	}

	.announcement-summary,
	.announcement-body {
		font-size: 14px;
	}
}
</style>
