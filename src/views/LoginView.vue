<template>
	<div class="login">
		<div class="overlay"></div>
		<div class="register">
			<form class="d-flex flex-column gap-5">
				<h3>Login</h3>
				<div class="form-group d-flex flex-row gap-1 align-items-center">
					<i class="fa-solid fa-user text-white"></i>
					<input type="number" id="id" placeholder="Enter your ID" v-model="id" required />
				</div>
				<div class="form-group d-flex flex-row gap-1 align-items-center">
					<i class="fa-solid fa-lock text-white"></i>
					<input type="password" id="password" placeholder="Enter your password" v-model="password"
						required />
				</div>
				<button class="btn btn-success" @click.prevent="login">Login</button>
			</form>
		</div>
		<div class="layer"></div>
	</div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: "LoginView",
	data() {
		return {
			id: "",
			password: ""
		};
	},
	methods: {
		async login() {
			let loginData = {
				id: this.id + "",
				password: this.password
			};
			try {
				const response = await axios.post(`https://localhost:44303/api/Auth/login/`, loginData, {
					withCredentials: true
				});
				const { status, data } = response;

				if (status == 200 && data) {
					const authToken = data;
					if (authToken) {
						const decodedToken = jwtDecode(authToken);
						const expirationDate = new Date(decodedToken.exp * 1000);
						Cookies.set('user-role', decodedToken.role, {
							expires: expirationDate
						});
						Cookies.set('user-auth-token', authToken, {
							expires: expirationDate
						});

						document.querySelector("body").classList.remove("full");
						document.querySelector("nav").style.display = "flex";
						// document.querySelector("header").style.display = "flex";
						document.querySelector("footer").style.display = "block";

						this.$router.push({ name: "Home" });
					} else {
						Swal.fire({
							icon: 'error',
							title: 'Oops...',
							text: 'User authentication failed',
						});
					}
				} else {
					Swal.fire({
						icon: 'error',
						title: 'Oops...',
						text: 'Invalid credentials',
					});
				}
			} catch (error) {
				console.error("An error occurred during login:", error);
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Invalid credentials',
				});
			}
		}
	},
	mounted() {
		document.querySelector("body").classList.add("full");
		document.querySelector("nav").style.display = "none";
		document.querySelector("header").style.display = "none";
		document.querySelector("footer").style.display = "none";
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
	background: url("@/assets/images/university_bg.jpg") no-repeat center center/cover;
}

.login .register {
	background: var(--primary-color);
	color: var(--white-color);
	padding: 24px;
	border-radius: 8px;
	box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
	max-width: 350px;
	width: 100%;
	z-index: 1000;
}

.login h3 {
	margin: 0 auto;
	text-align: center;
	/* font-size: 24px; */
}

/* .login p {
	font-size: 14px;
	color: #777;
	margin-bottom: 20px;
} */

/* .login .form-group {
	margin-bottom: 20px;
} */

/* .login label {
	font-size: 16px;
	margin-bottom: 6px;
	display: block;
} */

.login .form-group {
	border-bottom: 2px solid var(--white-color);
}

.login .form-group input {
	width: 100%;
	height: 40px;
	color: var(--white-color);
	padding: 8px;
	border-radius: 4px;
	font-size: 16px;
}

.login .form-group input::placeholder {
	color: #ddd;
}

/* .login button {
	width: 100%;
	height: 40px;
	background-color: var(--secondary-color);
	color: #fff;
	border: none;
	border-radius: 4px;
	font-size: 16px;
	cursor: pointer;
	transition: background-color 0.3s;
} */

/* .login button:hover {
	background-color: var(--primary-color);
} */
</style>
