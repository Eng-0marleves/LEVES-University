<template>
	<div class="login">
		<div class="register">
			<h1>Welcome Back</h1>
			<p>Please login to continue</p>
			<form>
				<div class="form-group">
					<label for="id">ID:</label>
					<input type="number" id="id" placeholder="Enter your ID" v-model="id" required />
				</div>
				<div class="form-group">
					<label for="password">Password:</label>
					<input type="password" id="password" placeholder="Enter your password" v-model="password" required />
				</div>
				<button @click.prevent="login">Login</button>
			</form>
		</div>
		<div class="layer"></div>
	</div>
</template>

<script>
import axios from 'axios'

export default {
	name: "LoginView",
	data() {
		return {
			id: "",
			password: ""
		}
	},
	methods: {
		async login() {
			try {
				const response = await axios.get(`http://localhost:3000/users?id=${this.id}&password=${this.password}`)
				if (response.status === 200 && response.data.length > 0) {
					alert("Login successful")
					localStorage.setItem("user-info", JSON.stringify(response.data[0]))
					this.$router.push({ name: "Home" })

					document.querySelector("body").classList.remove("full");
					document.querySelector("nav").style.display = "block";
					document.querySelector("header").style.display = "flex";
				} else {
					alert("Invalid credentials")
				}
			} catch (error) {
				console.error("An error occurred during login:", error)
				alert("An error occurred during login")
			}
		}
	},
	mounted() {
		document.querySelector("body").classList.add("full");
		document.querySelector("nav").style.display = "none";
		document.querySelector("header").style.display = "none";
	}
}
</script>

<style>
body.full {
	padding: 0 !important;
}

.login {
	height: 100vh;
	width: 100vw;
	display: flex;
	justify-content: center;
	align-items: center;
}

.login .register {
	background: #fff;
	padding: 24px;
	border-radius: 8px;
	box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
	max-width: 400px;
	width: 100%;
}

.login h1 {
	font-size: 24px;
	margin-bottom: 10px;
}

.login p {
	font-size: 14px;
	color: #777;
	margin-bottom: 20px;
}

.login .form-group {
	margin-bottom: 20px;
}

.login label {
	font-size: 16px;
	margin-bottom: 6px;
	display: block;
}

.login input[type="number"],
.login input[type="password"] {
	width: 100%;
	height: 40px;
	padding: 8px;
	border: 1px solid #ccc;
	border-radius: 4px;
	font-size: 16px;
}

.login button {
	width: 100%;
	height: 40px;
	background-color: var(--secondary-color);
	color: #fff;
	border: none;
	border-radius: 4px;
	font-size: 16px;
	cursor: pointer;
	transition: background-color 0.3s;
}

.login button:hover {
	background-color: var(--primary-color);
}
</style>
