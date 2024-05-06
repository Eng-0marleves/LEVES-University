<template>
	<div class="chat-app">
		<div class="chat-messages">
			<div class="message w-100" v-for="message in messages" :key="message.id"
				:class="{ 'my-message': message.sender === 'You', 'other-message': message.sender !== 'You' }">
				<div class="sender">{{ message.sender }}</div>
				<div class="msg">
					<div class="text">{{ message.content }}</div>
					<div class="time w-100">{{ message.time }}</div>
				</div>
			</div>
		</div>

		<div v-if="userStatus === 'User has an existing ticket.'" class="ex-msg">
			You can't send messages
		</div>

		<div v-else class="controllers">
			<input type="text" v-model="newMessage" @keyup.enter="sendMessage" placeholder="Type a message...">
			<button @click="sendMessage"><i class="fa-solid fa-paper-plane"></i></button>
			<button @click="endChat" class="end-chat"></button>
		</div>
	</div>
</template>

<script>
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';
import axios from 'axios';

export default {
	name: 'ChatApp',
	props: {
		userStatus: String
	},
	data() {
		return {
			messages: [],
			newMessage: '',
			userData: null,
			chatId: null,
			socket: null
		};
	},
	methods: {
		async getMessages(chatId) {
			try {
				const response = await axios.get(`https://localhost:44303/messages?chatId=${chatId}`);
				if (response.status === 200) {
					this.messages = response.data;
				}
			} catch (error) {
				console.error('Failed to fetch messages:', error);
			}
		},
		async sendMessage() {
			if (!this.newMessage.trim()) return;
			console.log('Sending message:', this.newMessage);

			try {
				await axios.post(`https://localhost:44303/api/Chat/message`, {
					chatId: this.chatId,
					content: this.newMessage,
					fromId: this.userData.id
				});
				this.newMessage = '';
			} catch (error) {
				console.error('Failed to send message:', error);
				if (error.response && error.response.status === 400) {
					console.log('Bad request. Reloading page.');
					window.location.reload();
				}
			}
		},
		async getUserData() {
			const token = Cookies.get('user-auth-token');
			const decodedToken = jwtDecode(token);
			this.userData = decodedToken;
		},
		setupWebSocket() {
			// WebSocket setup code
		}
	},
	async mounted() {
		this.getUserData();
		try {
			const token = Cookies.get('user-auth-token');
			const decodedToken = jwtDecode(token);
			const userId = decodedToken.id;
			const response = await axios.get(`https://localhost:44303/api/Chat/api/Chat/InProgressChatId?userId=${userId}`);
			if (response.status === 200) {
				this.chatId = response.data;
				this.getMessages(this.chatId); // Fetch messages when chat ID is retrieved
				this.setupWebSocket();
			}
		} catch (error) {
			console.error('Failed to fetch chat ID:', error);
		}
	},
};
</script>




<style scoped>
.chat-app {
	display: flex;
	flex-direction: column;
	height: 90vh;
	padding: 0 8px;
}

.chat-messages {
	flex-grow: 1;
	overflow-y: auto;
	padding: 8px;
}

.message .msg {
	padding: 8px;
	border-radius: 12px;
	margin-bottom: 8px;
	max-width: 80%;
	min-width: 200px;
	width: fit-content;
	color: white;
}

.other-message .msg {
	background-color: var(--primary-color) !important;
	align-self: flex-end;
	text-align: left;
}

.my-message {
	float: right;
}

.my-message .msg {
	background-color: var(--secondary-color) !important;
	float: right;
}

.my-message .sender {
	text-align: right;
}

.time {
	font-size: xx-small;
	color: #eee;
	text-align: right;
}

.controllers {
	display: flex;
	padding: 8px;
	background: var(--primary-color);
	border-radius: 24px;
	padding: 8px 24px;
	color: #fff;
}

input {
	flex-grow: 1;
	margin-right: 8px;
	color: #fff;
}

input::placeholder {
	color: #ddd;
}

.fa-paper-plane {
	color: #fff;
}

.end-chat {
	height: 24px;
	width: 24px;
	border-radius: 50%;
	background: crimson;
	margin-left: 16px;
}

.ex-msg {
	width: 100%;
	padding: 4px;
	text-align: center;
	background: var(--primary-color);
	color: var(--white-color);
}
</style>
