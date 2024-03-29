<template>
	<div class="chat-app">
		<div class="chat-messages">
			<div class="message w-100" v-for="message in messages" :key="message.id"
				:class="{ 'my-message': message.sender === 'You', 'other-message': message.sender !== 'You' }">
				<div class="sender">{{ message.sender }}</div>
				<div class="msg">
					<div class="text">{{ message.text }}</div>
					<div class="time w-100">{{ message.time }}</div>
				</div>
			</div>
		</div>
		<div class="controllers">
			<input type="text" v-model="newMessage" @keyup.enter="sendMessage" placeholder="Type a message...">
			<button @click="sendMessage"><i class="fa-solid fa-paper-plane"></i></button>
		</div>
	</div>
</template>


<script>
export default {
	name: 'ChatApp',
	data() {
		return {
			messages: [
				{ id: 1, sender: 'Alice', text: 'Hi there!', time: '10:00 AM' },
				{ id: 2, sender: 'Alice', text: 'Hello!', time: '10:01 AM' }
			],
			newMessage: ''
		};
	},
	methods: {
		sendMessage() {
			if (!this.newMessage.trim()) return;

			const newMsg = {
				id: this.messages.length + 1,
				sender: 'You',
				text: this.newMessage,
				time: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
			};

			this.messages.push(newMsg);
			this.newMessage = '';
		}
	}
};
</script>

<style scoped>
.chat-app {
	display: flex;
	flex-direction: column;
	height: 89vh;
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
</style>
