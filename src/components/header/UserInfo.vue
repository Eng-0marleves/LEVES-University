<template>
	<div class="user-info">
		<router-link :to="`/dashboard/${roleAbbreviation}`" class="router">
			<h6 class="title">{{ $props.userData.name }}</h6>
			<img :src="profileImage" alt="user profile img">
		</router-link>
		<NotificationsButton :notifications="notifications" :userId="$props.userData.id" />
	</div>
</template>

<script>
import axios from 'axios';
import NotificationsButton from './NotificationsButton.vue';

export default {
	props: {
		user_img: String,
		userData: {
			type: Object,
			required: true
		},
	},
	components: {
		NotificationsButton
	},
	data() {
		return {
			notifications: [],
			defaultProfileImage: require('@/assets/images/profileImage.webp') // Set default profile image path
		}
	},
	computed: {
		profileImage() {
			return this.$props.userData.image === '' ? this.defaultProfileImage : this.$props.userData.image;
		},
	},
	async mounted() {
		try {
			const response = await axios.get("http://localhost:3000/notifications");
			this.notifications = response.data;
		} catch (error) {
			console.error("Error fetching notifications:", error);
		}
	},
	methods: {
		getRoleAbbreviation(role) {
			console.log(role.toLowerCase());
			switch (role.toLowerCase()) {
				case 'student':
					return 'std';
				case 'doctor':
					return 'dr';
				case 'manager':
					return 'mg';
				default:
					return 'M';
			}
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
