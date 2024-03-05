<template>
	<div class="user-info">
		<router-link to="/dashboard/profile" class="router">
			<h6 class="title">std.Ahmed AbdElnaser</h6>
			<img :src="user_img" alt="user profile img">
		</router-link>

		<button class="notifications-btn" :class="{ 'new': notifications.length > 0 }" @click="toggleNotifications">
			<i class="fa-regular fa-bell"></i>
			<div v-if="showNotifications" class="notifications">
				<button v-for="(notification, index) in notifications" :key="index" class="notification"
					@click="splitNotification(index)">
					<router-link :to="notification.path">
						<h3>{{ notification.title }}</h3>
						<p>{{ notification.route }}</p>
					</router-link>
				</button>
			</div>
		</button>
	</div>
</template>

<script>
import axios from 'axios';

export default {
	props: {
		user_img: String,
		showNotifications: Boolean,
		toggleNotifications: Function,
		splitNotification: Function
	},
	data() {
		return {
			notifications: axios.get("http://localhost:3000/notifications")
		}
	},
};
</script>


<style scoped>
.user-info {
	display: flex;
	align-items: center;
	gap: 8px;
}

.user-info .router {
	display: flex;
	align-items: center;
	gap: 8px;
}

.user-info .router img {
	width: 48px;
	height: 48px;
	border-radius: 50%;
	border: 4px solid var(--primary-color);
	align-items: center;
}

.title {
	color: var(--primary-color);
}

.notifications-btn {
	position: relative;
}

.notifications-btn.new::after {
	content: "";
	position: absolute;
	top: 0px;
	right: 0px;
	width: 16px;
	height: 16px;
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