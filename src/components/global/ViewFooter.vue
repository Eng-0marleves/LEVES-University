<template>
	<div class="footer">
		<!-- Footer -->
		<footer class="text-center text-lg-start bg-dark text-muted">
			<!-- div: Social media -->
			<div class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom flex-row">
				<!-- Left -->
				<div class="me-5 d-none d-lg-block">
					<span class="text-light">Get connected with us on social networks:</span>
				</div>
				<!-- Left -->

				<!-- Right -->
				<div>
					<a href="" class="me-4 text-white">
						<i class="fab fa-facebook-f fa-lg"></i>
					</a>
					<a href="" class="me-4 text-white">
						<i class="fab fa-twitter fa-lg"></i>
					</a>
					<a href="" class="me-4 text-white">
						<i class="fab fa-google fa-lg"></i>
					</a>
					<a href="" class="me-4 text-white">
						<i class="fab fa-instagram fa-lg"></i>
					</a>
					<a href="" class="me-4 text-white">
						<i class="fab fa-linkedin fa-lg"></i>
					</a>
				</div>
				<!-- Right -->
			</div>
			<!-- div: Social media -->

			<!-- div: Links  -->
			<div class="">
				<div class="container text-center text-md-start mt-5">
					<!-- Grid row -->
					<div class="row mt-3 align-items-center justify-content-between flex-wrap">
						<!-- Grid column -->
						<div class="col-md-auto mb-4">
							<img src="@/assets/images/white_logo_mini.png" class="logo" alt="">
						</div>
						<!-- Grid column -->

						<!-- Grid column -->
						<div class="col-md-auto mb-4">
							<!-- Links -->
							<h6 class="text-uppercase fw-bold mb-4">
								<span class="text-light">Quick links</span>
							</h6>
							<p class="text-light">
								<a href="#!" class="text-reset">
									<i class="fas fa-home me-2"></i> Home
								</a>
							</p>
							<p class="text-light">
								<a href="#!" class="text-reset">
									<i class="fas fa-cog me-2"></i> Dashbpard
								</a>
							</p>
							<p class="text-light">
								<a href="#!" class="text-reset">
									<i class="fas fa-box me-2"></i> Courses
								</a>
							</p>
							<p class="text-light">
								<a href="#!" class="text-reset">
									<i class="fas fa-question-circle me-2"></i> About
								</a>
							</p>
						</div>
						<!-- Grid column -->

						<!-- Grid column -->
						<div class="col-md-auto mb-md-0 mb-4">
							<!-- Links -->
							<h6 class="text-uppercase fw-bold mb-4"><span class="text-light">Contact</span></h6>
							<p class="text-light"><i class="fas fa-home me-3"></i> New York, NY 10012, US</p>
							<p class="text-light">
								<i class="fas fa-envelope me-3"></i>
								info@example.com
							</p>
							<p class="text-light"><i class="fas fa-phone me-3"></i> + 01 234 567 88</p>
							<p class="text-light"><i class="fas fa-print me-3"></i> + 01 234 567 89</p>
						</div>
						<!-- Grid column -->
					</div>
					<!-- Grid row -->
				</div>
			</div>
			<!-- div: Links  -->

			<!-- Copyright -->
			<div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
				<span class="text-light">© 2024 LEVES University</span>
			</div>
			<!-- Copyright -->
		</footer>
		<!-- Footer -->
	</div>
</template>

<script>
export default {
	name: 'ViewFooter',
}
</script>

<style scoped>
.logo {
	width: 400px;
	height: 400px;
}

.footer {
	/* margin-top: 100; */
}
</style>