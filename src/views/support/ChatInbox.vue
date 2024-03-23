<template>
	<div class="chat-inbox">
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>
		<router-link to="" class="chat">
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
		</router-link>

		<button class="btn normal">
			<router-link to="/Support/chat" class="text-white">
				<i class="fa-solid fa-circle-info"></i>
				Support
			</router-link>
		</button>
	</div>
</template>

<script>
export default {
	name: 'ChatInbox',
	data() {
		return {
			// Your data goes here
		}
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
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
</style>