<template>
	<button class="notifications-btn" :class="{ 'new': notifications.length > 0 }" @click="toggleNotifications">
		<i class="fa-regular fa-bell"></i>
		<div v-if="showNotifications" class="notifications">
			<button v-for="(notification, index) in notifications" :key="index" class="notification"
				@click="splitNotification(index)">
				<router-link :to="notification.path" class="router">
					<h3>{{ notification.title }}</h3>
					<p>{{ notification.route }}</p>
				</router-link>
			</button>
		</div>
	</button>
</template>

<script>
import axios from 'axios';

export default {
	name: 'NotificationsButton',
	data() {
		return {
			notifications: []
		}
	},
	mounted() {
		this.fetchNotifications();
	},
	methods: {
		async fetchNotifications() {
			try {
				const response = await axios.get("http://localhost:3000/notifications");
				this.notifications = response.data;
			} catch (error) {
				console.error("Error fetching notifications:", error);
			}
		},
		toggleNotifications() {
			this.$emit('toggleNotifications');
		},
		splitNotification(index) {
			this.$emit('splitNotification', index);
		}
	}
};
</script>

<style scoped>
.notifications-btn .notifications .notification h3 {
	color: var(--primary-color) !important;
}
</style>
