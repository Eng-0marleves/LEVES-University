<template>
	<div class="user-info">
		<router-link to="/dashboard/" class="router">
			<h6 class="title">{{ getTitlePrefix(userData.role) }} {{ userData.name }}</h6>
			<img :src="getUserImage(userImage)" alt="user profile img">
		</router-link>
		<NotificationsButton :notifications="notifications" :userId="userData.id" />
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
			defaultProfileImage: require('@/assets/images/profileImage.webp'),
			userImage: ""
		}
	},
	computed: {
		profileImage() {
			return this.userData.image === '' ? this.defaultProfileImage : this.userData.image;
		},
	},
	methods: {
		getUserImage(userImage) {
			this.getUserImageAsync();
			if (userImage) {
				return require(`@/assets/ProfilePictures/${userImage}`);
			} else {
				return require('@/assets/images/profileImage.webp');
			}
		},
		async getUserImageAsync() {
			try {
				const response = await axios.get(`https://localhost:44303/GetProfilePicture?userId=${this.userData.id}`);
				this.userImage = response.data;
				console.log("User image:", response.data);
			} catch (error) {
				console.error("Error fetching notifications:", error);
				return undefined;
			}
		},
		getRoleAbbreviation(role) {
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
		},
		getTitlePrefix(role) {
			const abbreviation = this.getRoleAbbreviation(role);
			return abbreviation ? `${abbreviation}.` : '';
		}
	},
	mounted() {
		this.getUserImageAsync();
	},
	created() {
		this.getUserImageAsync();
	}
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
