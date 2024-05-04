<template>
	<div class="support-chat">
		<template v-if="userData && userStatus">
			<ChatApp v-if="showChatApp" :userStatus="userStatus" :userData="userData" @chatEnded="handleChatEnded"
				@employeeJoined="handleEmployeeJoined" />
			<ChatInbox v-else :role="userData.role" @joinChat="joinChat" @ticket="reserveTicket" />
		</template>
	</div>
</template>

<script>
import ChatInbox from './ChatInbox.vue';
import ChatApp from './ChatApp.vue';
import axios from 'axios';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: 'SupportChat',
	components: {
		ChatInbox,
		ChatApp
	},
	data() {
		return {
			userData: null,
			userStatus: null,
			showChatApp: false,
			statusWatcher: null
		};
	},
	methods: {
		async getUserData() {
			const token = Cookies.get('user-auth-token');
			const decodedToken = jwtDecode(token);
			this.userData = decodedToken;
		},
		async getUserStatus() {
			try {
				this.getUserData();
				const res = await axios.get(`https://localhost:44303/api/Chat/usser/status?studentId=${this.userData.id}`);
				if (res.status === 200) {
					this.userStatus = res.data;
					this.showChatApp = (this.userStatus === 'User has an existing ticket.' || this.userStatus === 'User is currently in a chat.');
				}
			} catch (e) {
				console.error(e);
			}
		},
		async joinChat(ticketId, userId) {
			try {
				const res = await axios.post(`https://localhost:44303/api/Chat/create?ticketId=${ticketId}&supportEmployeeId=${userId}`);
				if (res.status === 200) {
					this.getUserStatus();
				}
			} catch (e) {
				console.error(e);
			}
		},
		async reserveTicket() {
			try {
				const res = await axios.post(`https://localhost:44303/api/Chat/ticket?studentId=${this.userData.id}`);
				if (res.status === 200) {
					this.userStatus = "User has an existing ticket.";
					this.showChatApp = true;
				}
			} catch (e) {
				console.error(e);
			}
		},
		setupWebSocket() {
			const socket = new WebSocket('ws://localhost:8080');
			socket.onmessage = (event) => {
				const data = JSON.parse(event.data);
				if (data.type === 'statusUpdate') {
					this.getUserStatus();
				}
			};
		},
		handleChatEnded() {
			this.showChatApp = false;
			this.statusWatcher();
		},
		handleEmployeeJoined() {
			this.showChatApp = true;
			this.getUserStatus();
		}
	},
	mounted() {
		this.getUserData();
		this.getUserStatus();

		this.setupWebSocket();

		this.statusWatcher = this.$watch('userStatus', (newValue, oldValue) => {
			if (newValue !== oldValue && !this.showChatApp) {
				this.getUserStatus();
			}
		});
	},
	/* eslint-disable */
	beforeDestroy() {
		this.statusWatcher();
	}
};
</script>

<style scoped>
/* Your styles go here */
</style>
