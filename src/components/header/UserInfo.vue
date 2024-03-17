<template>
	<div class="user-info">
		<router-link to="/dashboard/profile" class="router">
			<h6 class="title">std.Ahmed AbdElnaser</h6>
			<img :src="user_img" alt="user profile img">
		</router-link>
		<NotificationsButton :notifications="notifications" />
	</div>
</template>

<script>
import axios from 'axios';
import NotificationsButton from './NotificationsButton.vue';

export default {
	props: {
		user_img: String,
	},
	components: {
		NotificationsButton
	},
	data() {
		return {
			notifications: [] // Initialize notifications as an empty array
		}
	},
	async mounted() {
		try {
			const response = await axios.get("http://localhost:3000/notifications");
			this.notifications = response.data;
		} catch (error) {
			console.error("Error fetching notifications:", error);
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
	text-align: right;
}
</style>