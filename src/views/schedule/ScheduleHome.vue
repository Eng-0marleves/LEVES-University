import { Month } from '@syncfusion/ej2-vue-schedule';
<template>
	<div class="schedule-home">
		<div class="container">
			<div class="left">
				<div ref="calender" class="calender">
					<div class="month">
						<i ref="prev" class="fas fa-angle-left prev"></i>
						<div ref="date" class="date">{{ months[month] + " " + year }}</div>
						<i ref="next" class="fas fa-angle-right next"></i>
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
						<div v-for="i in day" :key="i" class="day prev-date">{{ prevDays - i }}</div>
						<div v-for="i in lastDate" :key="i" class="day" :class="{ 'today': i == new Date().getDate() }">
							{{ i }}</div>
					</div>

					<div class="goto-day">
						<div claa="goto bg-success">
							<input type="text" placeholder="mm/yyyy" class="date-input">
							<button class="goto-btn">go</button>
						</div>
						<button class="today-btn">today</button>
					</div>

				</div>
			</div>
		</div>
	</div>
</template>

<script>
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
			monthYearText: null
		};
	},
	methods: {
		initData() {
			const today = new Date();
			this.month = today.getMonth();
			this.year = today.getFullYear();
			this.firstDay = new Date(this.year, this.month, 1);
			this.lastDay = new Date(this.year, this.month + 1, 0);
			this.prevLastDay = new Date(this.year, this.month, 0);
			this.prevDays = this.prevLastDay.getDate();
			this.lastDate = this.lastDay.getDate();
			this.day = this.firstDay.getDate();
			this.nextDays = 7 - this.lastDay.getDay() - 1;
			this.monthYearText = this.months[this.month] + " " + this.year;
		}
	},
	created() {
		this.initData();
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
	border-radius: 12px;
	background: var(--primary-color);
}

.left {
	width: 60%;
	padding: 24px;
}

.calender {
	position: relative;
	width: 100%;
	height: 100%;
	display: flex;
	flex-direction: column;
	flex-wrap: wrap;
	justify-content: space-between;
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
	height: 88px;
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

.days .day .prev-date,
.days .day .next-date {
	color: #b3b3b3;
}

.days .day.today {
	font-size: 2rem;
	color: var(--secondary-color);
}

.days .day.active {
	position: relative;
	font-size: 2rem;
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
	height: 8px;
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
</style>