<template>
	<div class="news-posts">
		<div class="controlers">
			<ContentGenerator ref="editor" class="editor" btnText="New Post" @save="save" @cancle="cancle"
				:id="postId" />
			<SearchBar @search="handleSearch" />
		</div>
		<div class="posts d-flex flex-column gap-4 mt-3">

			<div class="post" v-for="(post, i) in filteredPosts" :key="i">
				<div class="post-header">
					<div class="user d-flex align-items-center gap-1">
						<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/Outdoors-man-portrait_%28cropped%29.jpg/1200px-Outdoors-man-portrait_%28cropped%29.jpg"
							alt="">
						<p>Dr.Ahmed</p>
					</div>
					<div class="settings">
						<i class="fa-solid fa-ellipsis" @click="toggleMenu(i)"></i>
						<div class="menu" v-if="showMenu === i">
							<!-- Add your dropdown menu items here -->
							<button @click="editPost(post.content, post.id)" class="border-bottom"><i
									class="fas fa-pen"></i> Edit</button>
							<button @click="deletePost(post.id)" class="text-danger"><i class="fas fa-trash"></i>
								Delete</button>
						</div>
					</div>
				</div>
				<div class="content" v-html="post.content">
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
			saveType: "new",
			postId: 0
		};
	},
	methods: {
		async save(postContent, id) {
			if (this.saveType === "new") {
				const data = {
					"page": this.$route.params.course_code,
					"user_id": 123,
					"content": postContent
				}
				await axios.post("http://localhost:3000/posts", data);
			} else {
				const data = {
					"page": "CSE101",
					"user_id": 123,
					"content": postContent
				}
				await axios.put(`http://localhost:3000/posts/${id}`, data);
				this.saveType = "new";
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
					await axios.delete(`http://localhost:3000/posts/${id}`);
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
					this.saveType = "edit";
					this.postId = id;
					document.getElementById("editorBtn").click();
					document.getElementById("editorOutput").innerHTML = content;
				}
			});
			this.showMenu = false;
		},
		async getPosts() {
			try {
				const response = await axios.get(`http://localhost:3000/posts?page=${this.$route.params.course_code}`);
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
		cancle() {
			this.saveType = "new";
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
