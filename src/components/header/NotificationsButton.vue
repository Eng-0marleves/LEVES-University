<template>
	<div class="notifications" ref="notificationsRef">
		<button class="notifications-btn" type="button" @click="toggleNotifications">
			<i class="fa-regular fa-bell"></i>
			<span v-if="notifications.length > 0" class="badge bg-success">{{ notifications.length }}</span>
		</button>

		<ul v-if="showNotifications" class="notifications-list">
			<li class="notification" v-for="(notification, index) in notifications" :key="index">
				<router-link :to="notification.route">
					<h5 class="title">{{ notification.title }}</h5>
					<p class="date">{{ notification.date }}</p>
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
	props: {
		userId: {
			type: String,
			required: true
		}
	},
	mounted() {
		this.fetchNotifications();
		// document.addEventListener('click', this.handleClickOutside);
		// console.log("NotificationsButton mounted", this.$props.userId);
	},
	/* eslint-disable */
	beforeDestroy() {
		// document.removeEventListener('click', this.handleClickOutside);
	},
	methods: {
		async fetchNotifications() {
			try {
				const response = await axios.get(`https://localhost:44303/api/Post/user-notifications?userId=${this.$props.userId}`);
				this.notifications = response.data;
				console.log(this.notifications)
			} catch (error) {
				console.error("Error fetching notifications:", error);
			}
		},
		toggleNotifications() {
			this.showNotifications = !this.showNotifications;
		},
		// handleClickOutside(event) {
		// 	if (this.$refs.notificationsRef && !this.$refs.notificationsRef.contains(event.target)) {
		// 		this.showNotifications = false;
		// 	}
		// },
	}
};
</script>

<style scoped>
.notifications {
	position: relative;
}

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

.notifications-list {
	position: absolute;
	top: 100%;
	left: calc(50% + calc(12 * -32px));
	width: calc(12 * 32px);
	background: #fff;
	box-shadow: 0px 0px 8px 0px #ccc;
	display: flex;
	flex-direction: column;
	gap: 8px;
	height: fit-content;
	padding: 8px;
	border-radius: 4px;
}

.notification {
	width: 100%;
	background: #fff !important;
	padding: 8px 16px;
	text-align: left;
	color: var(--primary-color);
	transition: var(--transition);
}

.notification:hover {
	background: #eee !important;
}

.title {
	color: var(--primary-color);
}

.date {
	color: #666;
	font-style: italic;
}
</style>
