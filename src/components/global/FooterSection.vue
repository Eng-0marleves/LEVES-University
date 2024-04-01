<template>
	<footer class="footer-section">
		<div class="footer-content">
			<div class="footer-column">
				<h3>Contact Us</h3>
				<p>123 University St, City, Country</p>
				<p>+1 (123) 456-7890</p>
				<p>info@university.edu</p>
			</div>
			<div class="footer-column">
				<h3>Quick Links</h3>
				<ul>
					<li><a href="/academics">Academics</a></li>
					<li><a href="/admissions">Admissions</a></li>
					<li><a href="/departments">Departments</a></li>
					<!-- Add more links as needed -->
				</ul>
			</div>
			<div class="footer-column">
				<h3>Follow Us</h3>
				<div class="social-links">
					<!-- Icons or text links to social media profiles -->
					<a href="#" aria-label="Facebook"><i class="fab fa-facebook-f"></i></a>
					<a href="#" aria-label="Twitter"><i class="fab fa-twitter"></i></a>
					<a href="#" aria-label="Instagram"><i class="fab fa-instagram"></i></a>
				</div>
			</div>
			<div class="footer-column">
				<h3>Legal</h3>
				<ul>
					<li><a href="/privacy-policy">Privacy Policy</a></li>
					<li><a href="/terms-of-use">Terms of Use</a></li>
					<li><a href="/accessibility">Accessibility</a></li>
				</ul>
			</div>
		</div>
		<div class="footer-bottom">
			<p>&copy; {{ new Date().getFullYear() }} Leves University. All Rights Reserved.</p>
		</div>
	</footer>
</template>


<script>
export default {
	name: 'FooterSection',
	data() {
		return {
			// Your data goes here
		}
	},
	methods: {
		// Your methods go here
	}
}
</script>

<style scoped>
.footer-section {
	background-color: #2c3e50;
	color: #ffffff;
	padding: 40px 0;
}

.footer-content {
	display: flex;
	flex-wrap: wrap;
	justify-content: space-around;
	gap: 16px;
	margin-bottom: 20px;
}

.footer-column {
	flex: 1;
	min-width: 200px;
	padding-left: 20px;
}

.footer-column h3 {
	margin-bottom: 15px;
}

.footer-column ul,
.footer-column p {
	list-style: none;
	padding: 0;
	margin: 0;
}

.footer-column ul li a {
	color: #ffffff;
	text-decoration: none;
	margin-bottom: 10px;
	display: block;
}

.footer-column ul li a:hover,
.footer-column ul li a:focus {
	text-decoration: underline;
}

.social-links a {
	display: inline-block;
	margin-right: 10px;
	color: #ffffff;
	font-size: 24px;
}

.footer-bottom {
	text-align: center;
	font-size: 14px;
}
</style>
