<template>
	<div class="dashboard-profile">
		<div class="profileImageCpntainer">
			<img :src="getUserImage()" alt="Profile Image" class="profile_img" @click="$refs.viewImage.click()">
			<button class="editProfileImage" @click="$refs.inputImage.click()">
				<i class="fas fa-pen"></i>
				<input ref="inputImage" type="file" class="d-none" @change="handleImageChange">
			</button>
			<button ref="viewImage" type="button" class="d-none" data-bs-toggle="modal"
				data-bs-target="#viewProfileImage"></button>
		</div>
		<div class="modal fade" id="viewProfileImage" tabindex="-1" aria-labelledby="exampleModalLabel"
			aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered">
				<div class="modal-content">
					<img :src="getUserImage()" alt="user profile img">
				</div>
			</div>
		</div>
		<h2>{{ userData.name }}</h2>
		<p class="profile-email">{{ userData.id }}</p>
		<p class="profile-role">{{ userData.email }}</p>
	</div>
</template>

<script>
import { jwtDecode } from 'jwt-decode';
import Cookies from 'js-cookie';
import profile_image from '@/assets/images/profileImage.webp'; ""
import axios from 'axios';

export default {
	name: "LoginView",
	data() {
		return {
			userData: {},
			profileImage: profile_image,
			userImage: undefined,
			selectedImage: null,
		};
	},
	methods: {
		getUserImage() {
			this.getUserImageAsync();
			if (this.userImage) {
				console.log(this.userImage)
				console.log("founded")
				return require(`@/assets/ProfilePictures/${this.userImage}`);
			} else {
				console.log(this.userImage)
				console.log("not founded")
				return require('@/assets/images/profileImage.webp');
			}
		},
		decodeAuthToken() {
			const authToken = Cookies.get('user-auth-token');
			if (authToken) {
				try {
					const decodedToken = jwtDecode(authToken);
					this.userData = decodedToken;
					console.log("Decoded authentication token:", this.userData);
				} catch (error) {
					console.error("Error decoding authentication token:", error);
				}
			}
		},
		async getUserImageAsync() {
			try {
				const response = await axios.get(`https://localhost:44303/GetProfilePicture?userId=${this.userData.id}`);
				this.userImage = response.data;
				console.log("User image:", response.data);
			} catch (error) {
				console.error("Error fetching user image:", error);
			}
		},
		handleImageChange(event) {
			this.selectedImage = event.target.files[0];
			this.updateProfileImage();
		},
		async updateProfileImage() {
			try {
				const formData = new FormData();
				formData.append('userId', this.userData.id);
				formData.append('image', this.selectedImage);

				await axios.put('https://localhost:44303/api/Auth/update-profile-picture', formData, {
					headers: {
						'Content-Type': 'multipart/form-data'
					}
				});

				this.getUserImageAsync(); // Update user image after successful upload
			} catch (error) {
				console.error("Error updating profile image:", error);
			}
		},
	},
	mounted() {
		this.decodeAuthToken();
		this.getUserImageAsync();
	}
}
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

.profileImageCpntainer {
	position: relative;
	background: red;
	width: 200px;
	height: 200px;
	border-radius: 50%;
	background: rgba(0, 0, 0, 0.4);
	border: 4px solid var(--secondary-color);
}

.modal-content {
	width: 100%;
	height: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
	background: transparent;
	border: none;
}

.modal-dialog {
	display: flex;
	justify-content: center;
}

.full-image {
	width: 100%;
	height: 100%;
}

.editProfileImage {
	position: absolute;
	bottom: 0;
	right: 0;
	color: var(--secondary-color);

}

/* .profileImageCpntainer::before {
	content: "";
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	border-radius: 50%;
	background: transparent;
} */

.profileImageCpntainer:hover::before {
	background: rgba(0, 0, 0, 0.4);
}

.dashboard-profile .profile_img {
	width: 100%;
	height: 100%;
	border-radius: 50%;
	object-fit: cover;
	margin-bottom: 20px;
	cursor: pointer;
}

.dashboard-profile .profile_img:hover {
	filter: brightness(50%);
	transition: var(--transition);
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
