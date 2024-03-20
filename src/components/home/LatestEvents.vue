<template>
	<div class="latest-events d-flex flex-column gap-3 align-items-center">
		<h3 class="title">LATEST NEWS</h3>
		<p class="desctiption">Stay updated with the latest developments.</p>
		<div class="events-container">

			<div v-for="(event, i) in events" :key="i" class="event mt-4">

				<div class="left text-center">
					<p>{{ event.date.day }}</p>
					<p>{{ event.date.month }}</p>
				</div>

				<div class="devide"></div>
				<div class="right">
					<div class="about">
						<p class="router">{{ event.title }}</p>
						<p>{{ truncateDescription(event.description) }}</p>
					</div>

					<div class="location">
						<p><i class="fas fa-location-dot"></i> {{ event.location }}</p>
						<p><i class="fas fa-clock"></i> {{ event.time }}</p>
					</div>
				</div>

			</div>

		</div>
		<router-link to="schedule/scheduleHome" class="router">See All</router-link>
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
					date: { day: '12', month: 'SEP' },
					time: '10:00 AM',
					location: 'Location 1'
				},
				{
					title: 'Event 2',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel fringilla libero. Proin ac ligula aliquet, efficitur risus vel, pharetra ligula. Duis sollicitudin magna et ultricies aliquam. Duis dapibus condimentum sapien, nec lobortis purus tempus sit amet. Vivamus a dui nec sapien iaculis tempus. Sed sit amet fermentum velit, vitae laoreet magna. Fusce posuere orci sed erat feugiat suscipit. Vestibulum et ex non leo consectetur pellentesque sit amet eu ex. Vivamus viverra nulla at ultricies venenatis. Ut consequat ante a lorem congue, eu molestie lorem fermentum. Aenean eget lacus tortor. Curabitur lacinia augue sed tellus placerat, a rhoncus turpis aliquam. Nulla facilisi. Aliquam erat volutpat. Donec et orci a magna malesuada tempus.',
					date: { day: '15', month: 'SEP' },
					time: '11:30 AM',
					location: 'Location 2'
				},
				{
					title: 'Event 3',
					description: 'Lorem ipsum dolor sitefficitur risus volutpat. Donec et orci a magna malesuada tempus.',
					date: { day: '20', month: 'SEP' },
					time: '1:00 PM',
					location: 'Location 3'
				}
			]
		};
	},
	methods: {
		truncateDescription(description) {
			const words = description.split(' ');
			if (words.length > 25) {
				return words.slice(0, 25).join(' ') + ' ...';
			} else {
				return description;
			}
		}
	}

};
</script>

<style scoped>
.events-container {
	display: flex;
	justify-content: space-around;
	align-items: stretch;
	flex-wrap: wrap;
	gap: 24px;
}

.event {
	position: relative;
	width: 400px;
	transition: var(--transition);
	background: #e3e3e3;
	border: 2px solid transparent;
	padding: 16px;
	display: flex;
	justify-content: space-between;
	align-items: flex-start;
	gap: 8px;
	height: 240px;
	transition: all .3s ease-in-out;
}

.event:hover {
	border-color: var(--secondary-color);
	box-shadow: 0 0 8px rgba(0, 0, 0, 0.2);
}

.event:hover .right .about .router {
	transition: all .3s ease-in-out;
}

.event:hover .right .about .router {
	color: var(--secondary-color);
}

.event .devide {
	width: 2px;
	height: 64px;
	background: #000;
}

.event .right {
	height: 100%;
	display: flex;
	justify-content: space-between;
	align-items: flex-start;
	flex-direction: column;
}

.router {
	color: var(--primary-color);
	font-size: 20px;
	transition: var(--transition);
}

.router:hover {
	color: var(--secondary-color);
}

.event .right .location {
	font-size: 12px;
	color: #666;
	display: flex;
	align-items: center;
	gap: 16px;
}

@media (max-width: 768px) {
	.event {
		width: 90%;
		margin: 0 auto;
	}
}
</style>
