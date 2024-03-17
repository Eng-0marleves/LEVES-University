<template>
	<div class="dropdown">

		<button class="notifications-btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
			<i class="fa-regular fa-bell"></i>
			<span v-if="notifications.length > 0" class="badge bg-success">{{ notifications.length }}</span>
		</button>

		<ul class="dropdown-menu">
			<li v-for="(notification, index) in notifications" :key="index">
				<router-link class="dropdown-item" :to="notification.route">
					<h6 class="dropdown-title">{{ notification.title }}</h6>
					<p class="dropdown-message">{{ notification.message }}</p>
				</router-link>
			</li>
		</ul>

	</div>
</template>

<script>
import axios from 'axios';

export default {
	name: 'NotificationsButton',
	data() {
		return {
			notifications: [],
			showNotifications: false
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
			this.showNotifications = !this.showNotifications;
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

.notifications-btn {
	position: relative;
}

.badge {
	position: absolute;
	top: 0px;
	right: 0px;
	border-radius: 50%;
}

.notifications-btn.new::after {
	content: "";
	position: absolute;
	top: 0px;
	right: 0px;
	width: 12px;
	height: 12px;
	border-radius: 50%;
	background: var(--secondary-color);
}

.notifications-btn i.fa-bell {
	width: 48px;
	height: 48px;
	color: var(--primary-color);
	transition: var(--transition);
	border-radius: 50%;
	cursor: pointer;
	display: flex;
	justify-content: center;
	align-items: center;
	font-size: 32px !important;
}

.notifications-btn .notifications {
	position: absolute;
	top: 100%;
	left: calc(50% + calc(8 * -32px));
	width: calc(8 * 32px);
	background: #ccc;
	box-shadow: 0px 0px 8px 0px #ccc;
	display: flex;
	flex-direction: column;
	gap: 4px;
	height: fit-content;
}

.notifications-btn .notifications .notification {
	width: 100%;
	background: #fff;
	padding: 8px 16px;
	text-align: left;
	color: var(--primary-color);
}

.notifications-btn .notifications .notification h3,
.notifications-btn .notifications .notification p {
	color: var(--primary-color);
}
</style>
