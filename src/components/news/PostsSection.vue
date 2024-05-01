<template>
	<div class="news-posts">
		<div class="controlers">
			<ContentGenerator ref="editor" class="editor" btnText="New Post" @saveNewsPost="savePost" @cancle="cancel"
				:id="postId" :selectRoles="true" :roles="roles" />
			<SearchBar @search="handleSearch" />
		</div>
		<div class="posts d-flex flex-column gap-4 mt-3">

			<div class="post" v-for="(post, i) in filteredPosts" :key="i">
				<div class="post-header">
					<div class="user d-flex align-items-center gap-1">

						<img :src="!post.authorImg ? require('@/assets/images/profileImage.webp') : post.authorImg"
							alt="">

						<div>
							<p>{{ authorName(post.authorRoleName, post.authorName) }}</p>
							<small style="color: var(--secondary-color);">{{ formatDate(post.postDate) }}</small>
						</div>

					</div>
					<div class="settings">
						<i class="fa-solid fa-ellipsis" @click="toggleMenu(i)"></i>
						<div class="menu" v-if="showMenu === i">
							<!-- Add your dropdown menu items here -->
							<button @click="editPost(post.postContent, post.postId)" class="border-bottom"><i
									class="fas fa-pen"></i> Edit</button>
							<button @click="deletePost(post.postId)" class="text-danger"><i class="fas fa-trash"></i>
								Delete</button>
						</div>
					</div>
				</div>
				<div class="content" v-html="post.postContent">
				</div>
			</div>

		</div>
	</div>
</template>

<script>
import ContentGenerator from '@/components/global/ContentGenerator.vue';
import SearchBar from '../global/SearchBar.vue';
import axios from 'axios';
import Swal from 'sweetalert2';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: 'PostsSection',
	components: {
		ContentGenerator,
		SearchBar
	},
	data() {
		return {
			posts: [],
			searchQuery: '',
			showMenu: false,
			saveType: 'new',
			userData: {},
			roles: [],
			rolesNames: [],
			postId: 0,
		};
	},
	methods: {
		async savePost(postContent, roles) {
			try {
				var rolesIds = roles.map(role => role.value);
				const data = {
					postContent: postContent,
					notificationRoute: "/news",
					postAuthorId: this.userData.id,
					postDate: new Date().toISOString(),
					notificationTitle: "New Post",
					notificationDate: new Date().toISOString(),
					notificationRoleIds: rolesIds
				};

				if (this.saveType === "new") {
					await axios.post("https://localhost:44303/api/Post/AddNewsPost", data);
					this.getPosts();
					Swal.fire({
						title: 'Success!',
						text: 'Post has been added successfully.',
						icon: 'success',
						timer: 3000,
						timerProgressBar: true,
						showConfirmButton: false
					});
				} else if (this.saveType === "edit") {
					await axios.put(`https://localhost:44303/edit?postId=${this.postId}&newContent=${postContent}`);
					this.getPosts();
					Swal.fire({
						title: 'Success!',
						text: 'Post has been updated successfully.',
						icon: 'success',
						timer: 3000,
						timerProgressBar: true,
						showConfirmButton: false
					});
					this.saveType = "new";
					this.postId = 0;
				}
			} catch (error) {
				console.error('Error saving post:', error);
				Swal.fire({
					title: 'Error!',
					text: 'An error occurred while saving the post.',
					icon: 'error',
					confirmButtonText: 'OK'
				});
			}
		},
		async deletePost(id) {
			Swal.fire({
				title: 'Are you sure?',
				text: 'You will not be able to recover this post!',
				icon: 'warning',
				showCancelButton: true,
				confirmButtonColor: '#d33',
				cancelButtonColor: '#3085d6',
				confirmButtonText: 'Yes, delete it!'
			}).then(async (result) => {
				if (result.isConfirmed) {

					await axios.delete(`https://localhost:44303/delete?postId=${id}`);
					Swal.fire(
						'Deleted!',
						'Your post has been deleted.',
						'success'
					);
					this.getPosts();
				}
			});
			this.showMenu = false;
		},
		editPost(content, id) {
			this.postId = id;
			Swal.fire({
				title: 'Are you sure?',
				text: 'You are about to edit this post.',
				icon: 'warning',
				showCancelButton: true,
				confirmButtonColor: '#3085d6',
				cancelButtonColor: '#d33',
				confirmButtonText: 'Yes, edit it!'
			}).then((result) => {
				if (result.isConfirmed) {
					this.saveType = 'edit';
					this.postId = id;
					document.getElementById('editorBtn').click();
					document.getElementById('editorOutput').innerHTML = content;
				}
			});
			this.showMenu = false;
		},
		async getPosts() {
			try {
				const response = await axios.get("https://localhost:44303/api/Post/news-posts");
				this.posts = response.data;
			} catch (error) {
				console.error('Error fetching posts:', error);
			}
		},
		handleSearch(query) {
			this.searchQuery = query;
		},
		toggleMenu(index) {
			this.showMenu = this.showMenu === index ? null : index;
		},
		cancel() {
			this.saveType = 'new'; // Reset saveType to 'new' when canceling
		},
		async getRoles() {
			try {
				var res = await axios.get("https://localhost:44303/api/Auth/roles");
				if (res.status == 200) {
					this.roles = res.data;
					this.rolesNames = this.roles.map(role => role.name);
				}
			} catch (error) {
				console.error('Error fetching roles:', error);
			}
		},
		authorName(roleName, name) {
			const roleShortcuts = {
				student: 'std',
				dr: 'doctor',
				mg: 'manager',
				m: 'admin',
				lib: 'librarian'
			};

			const shortcut = roleName.toLowerCase();

			if (Object.prototype.hasOwnProperty.call(roleShortcuts, shortcut)) {
				return roleShortcuts[shortcut] + '.' + name;
			} else {
				return roleName + '.' + name;
			}
		},
		formatDate(dateTimeStr) {
			const date = new Date(dateTimeStr);

			const year = date.getFullYear();
			const month = String(date.getMonth() + 1).padStart(2, '0');
			const day = String(date.getDate()).padStart(2, '0');

			const hours = String(date.getHours()).padStart(2, '0');
			const minutes = String(date.getMinutes()).padStart(2, '0');

			const formattedDate = `${year}-${month}-${day} ${hours}:${minutes}`;

			return formattedDate;
		}
	},
	computed: {
		filteredPosts() {
			if (!this.searchQuery) {
				return this.posts;
			}
			const regex = new RegExp(this.searchQuery, 'i');
			return this.posts.filter(post => regex.test(post.content));
		}
	},
	mounted() {
		this.getPosts();
		this.getRoles();
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
	watch: {
		posts: {
			handler: 'getPosts',
			deep: true
		}
	}
};
</script>

<style scoped>
.controlers {
	width: 100%;
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.news-posts {
	padding: 16px;
}

.post-header {
	color: var(--white-color);
	padding: 8px;
	display: flex;
	justify-content: space-between;
	align-items: center;
	background: var(--primary-color);
	border-top-left-radius: 8px;
	border-top-right-radius: 8px;
}

.post-header .user img {
	width: 40px;
	height: 40px;
	border-radius: 50%;
	object-fit: cover;
	margin-right: 8px;
}

.content {
	padding: 8px;
	background: var(--white-color);
	border-bottom-left-radius: 8px;
	border-bottom-right-radius: 8px;
}

pre {
	height: fit-content;
}

.settings {
	position: relative;
}

.settings i {
	cursor: pointer;
}

.settings .menu {
	position: absolute;
	top: 16px;
	right: 4px;
	width: 96px;
	background: #fff;
	padding: 8px;
	display: flex;
	flex-direction: column;
	gap: 4px;
	border-radius: 4px;
	box-shadow: 0 0 8px rgba(0, 0, 0, 0.4);
}

.settings .menu button {
	text-align: left;
}
</style>
