<template>
	<div class="about-futures">
		<div class="futures">

			<div class="future">
				<div class="icon">
					<i class="fas fa-graduation-cap"></i>
				</div>
				<div class="content">
					<h5>Quality Education</h5>
					<p>Providing high-quality education to empower students for success.</p>
				</div>
			</div>

			<div class="future">
				<div class="icon">
					<i class="fas fa-chalkboard-teacher"></i>
				</div>
				<div class="content">
					<h5>Expert Faculty</h5>
					<p>Experienced and dedicated faculty members committed to student growth.</p>
				</div>
			</div>

			<div class="future">
				<div class="icon">
					<i class="fas fa-globe"></i>
				</div>
				<div class="content">
					<h5>Global Opportunities</h5>
					<p>Offering diverse opportunities for students to explore and engage globally.</p>
				</div>
			</div>

			<div class="future">
				<div class="icon">
					<i class="fas fa-book"></i>
				</div>
				<div class="content">
					<h5>Advanced Curriculum</h5>
					<p>Delivering cutting-edge curriculum to stay ahead in today's dynamic world.</p>
				</div>
			</div>

			<div class="future">
				<div class="icon">
					<i class="fas fa-user-friends"></i>
				</div>
				<div class="content">
					<h5>Community Engagement</h5>
					<p>Encouraging active involvement in community service and outreach programs.</p>
				</div>
			</div>

		</div>

		<div class="images">
			<img src="https://www.osu.edu/assets/components/gallery/connector.php?action=web/phpthumb&ctx=web&w=950&h=700&zc=0&far=&q=90&fltr%5B%5D=wmi%7C%2Fassets%2Fsite%2Fimages%2Fosu-32px-stacked-watermark.png%7CBR%7C100&src=%2Fassets%2Fgallery%2F281%2F12797.jpg"
				alt="" />
			<img src="https://content.presspage.com/uploads/2170/1920_tessthompsonpresentsdetailsaboutcrimeawarenessresearchinassociateprofessordeannawilkinsonrsquosclass.jpg?10000"
				alt="" />
		</div>

	</div>
</template>

<script>
export default {
	name: 'AboutFutures',
};
</script>

<style scoped>
.about-futures {
	display: flex;
	flex-wrap: wrap;
	justify-content: space-around;
}

.about-futures .images {
	width: 400px;
	display: flex;
	justify-content: space-between;
	flex-direction: column;
	gap: 16px;
}

.about-futures .images img {
	width: 100%;
	height: 300px;
	object-fit: cover;
}

.future {
	width: 500px;
	display: flex;
	align-items: center;
	gap: 16px;
	margin-bottom: 20px;
	padding: 20px;
	border-radius: 8px;
}

.future .icon {
	width: 112px !important;
	height: 72px;
	display: flex;
	justify-content: center;
	align-items: center;
	background: var(--white-color);
	box-shadow: 0 0 8px rgba(0, 0, 0, 0.2);
	border-radius: 50%;
}

.future .icon i {
	font-size: 24px;
	color: var(--secondary-color);
}

.future h5 {
	font-size: 18px;
	margin-bottom: 8px;
}

.future p {
	font-size: 16px;
	color: #666;
}

@media (max-width: 768px) {
	.about-futures .futures .future {
		width: 100%;
	}
}
</style>
