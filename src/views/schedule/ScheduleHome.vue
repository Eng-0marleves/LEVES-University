import { Month } from '@syncfusion/ej2-vue-schedule';
<template>
	<div class="schedule-home">
		<div class="container">
			<div class="left">
				<div ref="calender" class="calender">
					<div class="month">
						<i ref="prev" class="fas fa-angle-left prev" @click="prevMonth"></i>
						<div ref="date" class="date">{{ months[month] + " " + year }}</div>
						<i ref="next" class="fas fa-angle-right next" @click="nextMonth"></i>
					</div>

					<div class="weekdays">
						<div>Sun</div>
						<div>Mon</div>
						<div>Tu</div>
						<div>Wed</div>
						<div>Thu</div>
						<div>Fri</div>
						<div>Sat</div>
					</div>

					<div ref="days" class="days">
						<div v-for="i in day" :key="i" class="day prev-date">{{ prevDays - day + i
							}}</div>
						<div v-for="i in lastDate" :key="i" class="day"
							:class="{ 'today': i == new Date().getDate() && month == new Date().getMonth() && year == new Date().getFullYear(), 'event': checkDate(i), 'active': activeDay === i }"
							@click="selectDeta(i); getEventsList(i)">
							{{ i }}
						</div>
						<div v-for="i in nextDays" :key="i" class="day next-date">{{ i }}</div>
					</div>

					<div class="goto-day">
						<div claa="goto bg-success">
							<input type="text" placeholder="mm/yyyy" class="date-input" v-model="gotoDate">
							<button class="goto-btn" @click="goToDate">go</button>
						</div>
						<button class="today-btn" @click="today">today</button>
					</div>

				</div>
			</div>
			<div class="right">
				<div class="today-date">
					<div class="event-day">{{ selectedDay }}</div>
					<div class="event-date">{{ selectedDate }}</div>
				</div>
				<div class="events">
					<div v-for="(e, i) in eventsList" :key="i" class="event">
						<div class="title">
							<i class="fas fa-circle"></i>
							<h3 class="event-title">{{ e.eventName }}</h3>
						</div>
						<div class="event-time">
							{{ e.eventTimeFrom }} - {{ e.eventTimeTo }}
						</div>
						<div class="event-time">
							<i class="fa-solid fa-location-dot"></i>
							{{ e.eventLocation }}
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import axios from 'axios';
export default {
	name: 'ScheduleHome',
	data() {
		return {
			month: null,
			year: null,
			months: [
				"January", "February", "March", "April", "May", "June",
				"July", "August", "September", "October", "November", "December"
			],
			firstDay: null,
			lastDay: null,
			prevLastDay: null,
			prevDays: null,
			lastDate: null,
			day: null,
			nextDays: null,
			monthYearText: null,
			gotoDate: '',
			activeDay: null,

			daysOfWeek: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
			selectedDate: this,
			selectedDay: null,

			events: [],
			eventsDates: [],

			eventsList: [],
		};
	},
	methods: {
		initData(month, year) {
			const today = new Date();
			this.month = month || today.getMonth();
			this.year = year || today.getFullYear();
			this.firstDay = new Date(this.year, this.month, 1);
			this.lastDay = new Date(this.year, this.month + 1, 0);
			this.prevLastDay = new Date(this.year, this.month, 0);
			this.prevDays = this.prevLastDay.getDate();
			this.lastDate = this.lastDay.getDate();
			this.day = this.firstDay.getDay();
			this.nextDays = 7 - this.lastDay.getDay() - 1;
			this.monthYearText = this.months[this.month] + " " + this.year;
		},

		selectDeta(day) {
			this.activeDay = day;
			this.selectedDate = day + " " + this.months[this.month] + " " + this.year;
			this.selectedDay = this.daysOfWeek[new Date(this.selectedDate).getDay()];
		},

		nextMonth() {
			this.month++;
			if (this.month > 11) {
				this.month = 0;
				this.year++;
			}
			this.initData(this.month, this.year);
			const activeDayElement = document.querySelector(".day.active");
			if (activeDayElement) {
				activeDayElement.classList.remove("active");
			}
			this.activeDay = null; // Also reset the activeDay state
		},

		prevMonth() {
			this.month--;
			if (this.month < 0) {
				this.month = 11;
				this.year--;
			}
			this.initData(this.month, this.year);
			const activeDayElement = document.querySelector(".day.active");
			if (activeDayElement) {
				activeDayElement.classList.remove("active");
			}
			this.activeDay = null; // Also reset the activeDay state
		},

		today() {
			this.initData();
			this.selectDeta(new Date().toDateString().split(' ')[2]);
		},

		goToDate() {
			const [enteredMonth, enteredYear] = this.gotoDate.split('/');
			if (enteredMonth && enteredYear) {
				const parsedMonth = parseInt(enteredMonth) - 1; // Subtract 1 because JavaScript months are zero-based
				const parsedYear = parseInt(enteredYear);
				if (!isNaN(parsedMonth) && !isNaN(parsedYear)) {
					this.initData(parsedMonth, parsedYear);
					this.gotoDate = ''; // Clear input after successfully setting the date
				} else {
					alert('Please enter a valid month and year (mm/yyyy)');
				}
			} else {
				alert('Please enter both month and year (mm/yyyy)');
			}
		},

		async getEvents() {
			try {
				const response = await axios.get('http://localhost:3000/events');
				if (response.status) {
					this.events = response.data;
					this.getEventsDates();

					const today = new Date();
					const dayOfMonth = today.getDate();
					this.getEventsList(dayOfMonth);
				}
			} catch (e) {
				console.error(e)
			}
		},

		getEventsDates() {
			if (this.events) {
				this.events.forEach(e => {
					let event = e.eventDate;
					let year = event.split('-')[0];
					let month = event.split('-')[1];
					let day = event.split('-')[2];
					this.eventsDates.push({
						year: Number(year),
						month: Number(month),
						day: Number(day),
						eventName: e.eventName,
						eventTimeFrom: e.eventTimeFrom,
						eventTimeTo: e.eventTimeTo,
						eventLocation: e.eventLocation
					})
				});
			}
		},

		checkDate(day) {
			let found = false;

			this.eventsDates.forEach(e => {
				if (e.year === this.year && e.month === (this.month + 1) && e.day === day) {
					found = true;
				}
			});

			return found;
		},

		getEventsList(day) {
			this.eventsList = [];
			this.eventsDates.forEach(e => {
				if (e.year === this.year && e.month === (this.month + 1) && e.day === day) {
					this.eventsList.push({
						eventName: e.eventName,
						eventTimeFrom: e.eventTimeFrom,
						eventTimeTo: e.eventTimeTo,
						eventLocation: e.eventLocation
					})
				}
			});

			console.log(this.eventsDates);
		}
	},
	created() {
		this.initData();
		this.selectDeta(new Date().toDateString().split(' ')[2]);
		this.getEvents();
	},
	mounted() {
	}
};
</script>

<style scoped>
.schedule-home {
	display: flex;
	justify-content: center;
	align-items: center;
	padding: 16px;
}

.container {
	position: relative;
	width: 1200px;
	height: fit-content;
	/* min-height: 850px; */
	margin: 0 auto;
	padding: 8px;
	color: var(--white-color);
	display: flex;
	flex-wrap: wrap;
	/* gap: 16px; */
	border-radius: 12px;
	background: var(--primary-color);
}

.left {
	width: 60%;
	padding: 20px;
}

.calender {
	position: relative;
	width: 100%;
	height: 100%;
	display: flex;
	flex-direction: column;
	flex-wrap: wrap;
	justify-content: space-between;
	align-items: center;
	color: #333;
	border-radius: 8px;
	background: var(--white-color);
	padding: 8px;
}

.calender::before,
.calender::after {
	content: "";
	position: absolute;
	top: 50%;
	left: 100%;
	width: 12px;
	height: 96%;
	border-radius: 0 5px 5px 0;
	background: var(--secondary-color);
	opacity: 0.6;
	transform: translateY(-50%);
}

.calender::before {
	height: 92%;
	left: calc(100% + 12px);
	opacity: 0.3;
}

.month {
	width: 100%;
	height: 15px;
	margin-top: 18px;
	display: flex;
	align-items: center;
	justify-content: space-between;
	padding: 0 56px;
	font-size: 1.2rem;
	font-weight: 500;
	text-transform: capitalize;
}

.month i {
	cursor: pointer;
}

.weekdays {
	width: 100%;
	height: 80px;
	display: flex;
	justify-content: space-between;
	align-items: center;
	padding: 0 18px;
	font-size: 1rem;
	font-weight: 500;
	text-transform: capitalize;
}

.weekdays div {
	width: 14.28%;
	height: 100%;
	display: flex;
	justify-content: center;
	align-items: center;
}

.days {
	width: 100%;
	display: flex;
	justify-content: space-between;
	flex-wrap: wrap;
	padding: 0 18px;
	font-size: 1rem;
	font-weight: 500;
	margin-bottom: 18px;
}

.days .day {
	position: relative;
	width: 14.28%;
	height: 44px;
	display: flex;
	justify-content: center;
	align-items: center;
	cursor: pointer;
	color: var(--primary-color);
	border: 1px solid #f5f5f5;
}

.days .day:not(.prev-date, .next-date):hover {
	color: var(--white-color);
	background: var(--secondary-color);
}

.days .day.prev-date,
.days .day.next-date {
	color: #b3b3b3;
}

.days .day.today {
	font-size: 1.4rem;
	color: var(--secondary-color);
}

.days .day.active {
	position: relative;
	font-size: 1.5rem;
	color: var(--white-color);
	background: var(--secondary-color);
}

.days .day.active::before {
	content: "";
	position: absolute;
	top: 0;
	left: 0;
	width: 100%;
	height: 100%;
	box-shadow: 0 0 10px 2px rgba(0, 0, 0, 0.3);
}

.days .day.event::after {
	content: "";
	position: absolute;
	bottom: 8%;
	left: 12%;
	width: 76%;
	height: 4px;
	border-radius: 32px;
	/* transform: translateX(35%); */
	background: var(--secondary-color);
}

.days .day.event:hover::after {
	background: var(--white-color);
}

.days .day.active.event::after {
	background: var(--white-color);
}

.goto-day {
	height: 50px;
	width: 100%;
	display: flex;
	justify-content: space-between;
	align-items: center;
	gap: 4px;
	padding: 0 20px;
	margin-bottom: 20px;
	color: var(--primary-color);
}

div.goto-day>div {
	display: flex;
	align-items: center;
	border-radius: 4px;
	overflow: hidden;
	border: 1px solid var(--primary-color);
}

div.goto-day>div>input {
	width: 100%;
	height: 30x;
	border-radius: 4px;
	padding: 0 20px;
	color: var(--primary-color);
}

.goto-day button {
	padding: 5px 10px;
	border: 1px solid var(--primary-color);
	border-radius: 5px;
	background: transparent;
	color: var(--primary-color);
}

.goto-day button:hover {
	color: var(--white-color);
	background: var(--secondary-color);
}

.goto-day .goto button:hover {
	color: var(--white-color);
	background: var(--secondary-color);
}

/* right */

.right {
	position: relative;
	width: 40%;
	min-height: 100%;
	padding: 20px;
}

.right .today-date {
	width: 100%;
	height: 50px;
	display: flex;
	justify-content: space-between;
	align-items: center;
	flex-wrap: wrap;
	gap: 8px;
	/* padding: 0 40px; */
	/* padding-left: 70px; */
	/* margin-top: 50px; */
	margin-bottom: 20px;
	text-transform: capitalize;
}

.right .today-date .event-day {
	font-size: 2rem;
	font-weight: 500;
}

.right .today-date .event-date {
	font-size: 1rem;
	font-weight: 400;
	color: #d1d3e0;
}

.events {
	width: 100%;
	height: 100%;
	max-height: 400px;
	overflow-x: hidden;
	overflow-y: auto;
	display: flex;
	flex-direction: column;
}

.events .event {
	position: relative;
	width: 95%;
	min-height: 70px;
	display: flex;
	justify-content: center;
	flex-direction: column;
	gap: 8px;
	/* padding: 0 20px; */
	padding-left: 8px;
	color: var(--white-color);
	cursor: pointer;
	background: linear-gradient(90deg, rgba(255, 255, 255, 0.05), var(--primary-color));
}

.events .event:nth-child(even) {
	background: transparent;
}

.events .event .title {
	display: flex;
	align-items: center;
	pointer-events: none;
}

.events .event .title .event-title {
	font-size: 1rem;
	font-weight: 400;
	margin-left: 8px;
}

.events .event .title i {
	font-size: 12px;
	color: var(--secondary-color);
}

.events .event:hover {
	background: linear-gradient(90deg, var(--secondary-color), var(--primary-color));
}

.events .event:hover .title i,
.events .event:hover .event-time {
	color: var(--white-color);
}

.events .event .event-time {
	font-size: 0.8rem;
	font-weight: 400;
	color: #d1d3e0;
	margin-left: 12px;
	pointer-events: none;
}

.events .event::after {
	content: "✓";
	position: absolute;
	top: 50%;
	right: 0;
	font-size: 2.4rem;
	display: none;
	justify-content: center;
	align-items: center;
	opacity: 0.8;
	color: var(--secondary-color);
	transform: translateY(-50%);
}

.events .event:hover::after {
	display: flex;
}

@media (max-width: 768px) {
	.container {
		width: 100%;
		margin: 0 auto;
	}

	.left {
		width: 100%;
	}

	.right {
		width: 100%;
	}
}
</style>