<template>
	<div class="latest-events d-flex flex-column gap-3 align-items-center">
		<h3 class="title">LATEST NEWS</h3>
		<p class="desctiption">Stay updated with the latest developments.</p>
		<div class="events-container">

			<div v-for="(event, i) in events" :key="i" class="event mt-4">
				<div class="image">
					<img :src="event.imageSrc" alt="">
				</div>
				<div class="description">
					<h4 class="mb-4">{{ event.title }}</h4>
					<p class="overflow">{{ event.description }}</p>
				</div>
				<div class="date">
					<h5>{{ event.date.day }}</h5>
					<p>{{ event.date.month }}</p>
				</div>
			</div>

		</div>
		<router-link to="" class="router">See All</router-link>
	</div>
</template>

<script>
export default {
	name: 'LatestEvents',
	data() {
		return {
			events: [
				{
					title: 'Event 1',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel fringilla libero. Proin ac ligula aliquet, efficitur risus vel, pharetra ligula. Duis sollicitudin magna et ultricies aliquam. Duis dapibus condimentum sapien, nec lobortis purus tempus sit amet. Vivamus a dui nec sapien iaculis tempus. Sed sit amet fermentum velit, vitae laoreet magna. Fusce posuere orci sed erat feugiat suscipit. Vestibulum et ex non leo consectetur pellentesque sit amet eu ex. Vivamus viverra nulla at ultricies venenatis. Ut consequat ante a lorem congue, eu molestie lorem fermentum. Aenean eget lacus tortor. Curabitur lacinia augue sed tellus placerat, a rhoncus turpis aliquam. Nulla facilisi. Aliquam erat volutpat. Donec et orci a magna malesuada tempus.',
					imageSrc: 'https://le.ac.uk/-/media/uol/images/study/postgraduates/pg-events-banner.jpg?cx=0&cy=0&cw=1400&ch=700&hash=F945E10F4D865E7EC65C3617812AF55C',
					date: { day: '12', month: 'SEP' }
				},
				{
					title: 'Event 2',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel fringilla libero. Proin ac ligula aliquet, efficitur risus vel, pharetra ligula. Duis sollicitudin magna et ultricies aliquam. Duis dapibus condimentum sapien, nec lobortis purus tempus sit amet. Vivamus a dui nec sapien iaculis tempus. Sed sit amet fermentum velit, vitae laoreet magna. Fusce posuere orci sed erat feugiat suscipit. Vestibulum et ex non leo consectetur pellentesque sit amet eu ex. Vivamus viverra nulla at ultricies venenatis. Ut consequat ante a lorem congue, eu molestie lorem fermentum. Aenean eget lacus tortor. Curabitur lacinia augue sed tellus placerat, a rhoncus turpis aliquam. Nulla facilisi. Aliquam erat volutpat. Donec et orci a magna malesuada tempus.',
					imageSrc: 'https://oncampusadvertising.com/wp-content/uploads/2019/03/college-event-pic.jpg',
					date: { day: '15', month: 'SEP' }
				},
				{
					title: 'Event 3',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel fringilla libero. Proin ac ligula aliquet, efficitur risus vel, pharetra ligula. Duis sollicitudin magna et ultricies aliquam. Duis dapibus condimentum sapien, nec lobortis purus tempus sit amet. Vivamus a dui nec sapien iaculis tempus. Sed sit amet fermentum velit, vitae laoreet magna. Fusce posuere orci sed erat feugiat suscipit. Vestibulum et ex non leo consectetur pellentesque sit amet eu ex. Vivamus viverra nulla at ultricies venenatis. Ut consequat ante a lorem congue, eu molestie lorem fermentum. Aenean eget lacus tortor. Curabitur lacinia augue sed tellus placerat, a rhoncus turpis aliquam. Nulla facilisi. Aliquam erat volutpat. Donec et orci a magna malesuada tempus.',
					imageSrc: 'https://artsci.washington.edu/sites/default/files/2021-09/NewsAndEvents-main%206.jpg',
					date: { day: '20', month: 'SEP' }
				}
			]
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
};
</script>

<style scoped>
.events-container {
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: wrap;
	gap: 24px;
}

.event {
	position: relative;
	width: 400px;
	transition: var(--transition);
}

.event .image {
	position: relative;
	width: 100%;
	height: 200px;
}

.event .image img {
	width: 100%;
	height: 100%;
	object-fit: cover;
}

.event .image::after {
	content: "";
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 0%;
	background: var(--secondary-color);
	opacity: 0;
	transition: var(--transition);
}

.event:hover .image::after {
	height: 100%;
	opacity: .4;
}

.event .description {
	width: 80%;
	height: 312px;
	margin: 0 auto;
	padding: 16px;
	background: #eee;
	transition: var(--transition);
	text-overflow: ellipsis;
	overflow: hidden;
	padding-bottom: 16px;
}

.event .description p {
	padding-bottom: 16px;
	/* white-space: nowrap; */
	overflow: hidden;
	text-overflow: ellipsis;
}

.event:hover .description {
	color: var(--white-color);
	background: var(--primary-color);
}

.event .date {
	position: absolute;
	top: -32px;
	left: calc(50% - 21.44px);
	padding: 8px;
	color: var(--white-color);
	text-align: center;
	background: var(--primary-color);
}

.router {
	color: var(--secondary-color);
}
</style>
