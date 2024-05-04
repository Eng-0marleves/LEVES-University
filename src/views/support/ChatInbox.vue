<template>
	<div class="chat-inbox">

		<div class="chats-container">
			<h4 class="title text-center mb-2">In Pending</h4>



			<ag-grid-vue class="ag-theme-quartz" :columnDefs="columnDefs" :rowData="paginatedData"
				:frameworkComponents="frameworkComponents" @grid-ready="onGridReady" rowSelection="multiple"
				:domLayout="'autoHeight'" :context="gridOptions.context">
			</ag-grid-vue>
			<div class="pagination-controls">
				<button @click="prevPage">Previous</button>
				<span>Page {{ currentPage }} of {{ totalPages }}</span>
				<button @click="nextPage">Next</button>
			</div>


		</div>

		<!-- <router-link to="" class="chat">
			<div class="user">
				<img src="https://img.freepik.com/free-photo/young-bearded-man-with-striped-shirt_273609-5677.jpg"
					alt="">
				<p>std.Ahmed</p>
			</div>
			<div class="content">
				Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ipsam eaque tempore, facilis corrupti
				dignissimos dicta doloribus reprehenderit impedit, laboriosam sequi blanditiis totam possimus adipisci
				sint minus a quibusdam, magnam cumque?
			</div>
			<div class="time">
				12:30 PM
			</div>
		</router-link> -->

		<button class="btn normal" v-if="userData.role === 'student'" @click="ticket">
			<i class="fa-solid fa-circle-info"></i>
			Support
		</button>
	</div>
</template>

<script>
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";
import { AgGridVue } from "ag-grid-vue3";
import axios from 'axios';

export default {
	name: 'ChatInbox',
	components: {
		AgGridVue
	},
	data() {
		return {
			userData: this.getUserData(),
			currentPage: 1,
			pageSize: 25,
			tickets: [],
			columnDefs: [
				{
					headerName: 'User',
					field: 'user',
					cellRenderer: params => {
						const data = params.data;
						const userImage = this.getUserImage(data.profilePicturePath);
						return `<div class="user d-flex align-items-center gap-2">
									<img src="${userImage}" alt="${data.userName}" style="width: 20px; height: 20px;">
									<p>${data.userName}</p>
								</div>`;
					},
					flex: 3
				},
				{
					headerName: 'Join',
					field: 'joinButton',
					cellRenderer: this.joinButtonRender, cellRendererParams: { component: this },
					flex: 1
				}
			],
			gridOptions: {
				context: {
					onEdit: this.onEditStudent,
					onDelete: this.onDeleteStudent,
				},
			},
		}
	},
	methods: {
		getUserData() {
			const token = Cookies.get('user-auth-token')
			const decodedToken = jwtDecode(token)
			return decodedToken;
		},
		getUserImage(userImage) {
			// this.getUserImageAsync();
			if (userImage) {
				return require(`@/assets/ProfilePictures/${userImage}`);
			} else {
				return require('@/assets/images/profileImage.webp');
			}
		},
		onGridReady(params) {
			this.gridApi = params.api;
			this.gridColumnApi = params.columnApi;
		},
		nextPage() {
			if (this.currentPage < this.totalPages) {
				this.currentPage++;
			}
		},
		prevPage() {
			if (this.currentPage > 1) {
				this.currentPage--;
			}
		},
		async loadTickets() {
			try {
				const res = await axios.get('https://localhost:44303/alltickets');
				if (res.status === 200) {
					this.tickets = res.data;
				}
			} catch (err) {
				console.error(err);
			}
		},
		joinChat(ticketId) {
			this.$emit('joinChat', ticketId, this.userData.id);
		},
		joinButtonRender(params) {
			const button = document.createElement('button');
			button.innerText = 'Join';
			button.classList.add('btn', 'btn-success');
			button.onclick = () => this.joinChat(params.data.id);
			return button;
		},
		ticket() {
			this.$emit("ticket")
		}
	},
	computed: {
		paginatedData() {
			const start = (this.currentPage - 1) * this.pageSize;
			const end = start + this.pageSize;
			return this.tickets.slice(start, end);
		},
		totalPages() {
			return Math.ceil(this.tickets.length / this.pageSize);
		}
	},
	mounted() {
		this.loadTickets();
		console.log(document.querySelectorAll("ag-row"))
		document.querySelectorAll(".ag-row").forEach(el => {
			el.addEventListener("click", () => {
				const selectedRows = this.gridApi.getSelectedRows();
				console.log("Selected rows: ", selectedRows);
			}
			)
		})
	}
}
</script>

<style scoped>
.chat-inbox {
	padding: 8px;
}

.chat-inbox .chat {
	width: 100%;
	color: var(--primary-color);
	display: flex;
	justify-content: space-between;
	align-items: center;
	padding: 8px;
	gap: 24px;
	border-bottom: 1px solid var(--primary-color);
	overflow: hidden;
}

.chat-inbox .chat:hover {
	background: #ddd;
}

.chat-inbox .chat:first-child {
	border-top: 1px solid var(--primary-color);
}

.chat-inbox .chat .user {
	display: flex;
	align-items: center;
	gap: 4px;
}

.chat-inbox .chat .user img {
	width: 32px;
	height: 32px;
	border-radius: 50%;
	object-fit: cover;
	border: 1px solid var(--primary-color);
}

.chat-inbox .chat .user p {
	font-weight: 500;
}

.chat-inbox .content {
	text-wrap: nowrap;
	white-space: nowrap;
	text-overflow: ellipsis;
	overflow: hidden;
}

.chat-inbox .time {
	font-weight: 500;
	text-align: right;
	width: fit-content;
	text-wrap: nowrap;
}

.btn {
	position: fixed;
	bottom: 16px;
	right: 16px;
}

.ag-theme-quartz {
	width: 100%;
	height: auto;

	--ag-borders: none;
	--ag-header-background-color: var(--primary-color);
	--ag-header-foreground-color: white;
	--ag-borders: none;

	--ag-header-cell-hover-background-color: var(--secondary-color);
	--ag-header-cell-moving-background-color: white;
}

.pagination-controls {
	display: flex;
	justify-content: center;
	align-items: center;
	margin-top: 20px;
}

.pagination-controls button {
	margin: 0 10px;
}

img {
	width: 20px;
	height: 20px;
}
</style>