<template>
	<div class="course-card padd-15">
		<router-link :to="`courses/${course_code}`">
			<div class="inner">
				<div class="icon">
					<i class="fab fa-leanpub"></i>
				</div>
				<h6>{{ course_code }}</h6>
				<p class="course-name">{{ course_name }}</p>
			</div>
		</router-link>
	</div>
</template>

<script>
export default {
	name: "CourseCard",
	props: {
		course: Object
	},
	data() {
		return {
			course_code: this.course.courseCode,
			course_name: this.course.courseTitle,
		}
	}
}
</script>

<style scoped>
.course-card {
	padding: 8px;
	margin-bottom: 30px;
	width: 350px;
}

.course-card .inner {
	background: var(--primary-color);
	color: var(--white-color);
	border: 2px solid var(--secondary-color);
	border-radius: 10px;
	padding: 16px 8px;
	text-align: center;
	transition: all 0.3s ease;
}

.course-card .inner:hover {
	box-shadow: 0 0 20px rgba(48, 46, 77, .15);
}

.course-card .inner .icon {
	height: 48px;
	width: 48px;
	border-radius: 100%;
	margin: 0 auto 16px;
	text-align: center;
	transition: all 0.3s ease;
}

.course-card .inner .icon i {
	font-size: 24px;
	line-height: 48px;
	transition: all 0.3s ease;
}

.course-card .inner:hover .icon {
	background: var(--secondary-color);
}

.course-card .inner:hover .icon i {
	font-size: 16px;
	color: #fff;
}

.course-card .inner h6 {
	/* font-size: 18px; */
	margin-bottom: 15px;
	font-weight: 700;
}

.course-card .inner p.course-name {
	font-size: 16px;
	line-height: 25px;
	color: #ccc;
	overflow: hidden;
	text-overflow: ellipsis;
	white-space: nowrap;
}

@media (max-width: 768px) {
	.course-card {
		flex: 0 0 90%;
		max-width: 100%;
	}
}
</style>
