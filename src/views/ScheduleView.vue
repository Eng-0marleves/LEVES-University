<template>
	<div class="schedule-view">
		<ejs-schedule id='Schedule' :selectedDate='selectedDate' :eventSettings='eventSettings'></ejs-schedule>
	</div>
</template>

<script>
import { SchedulePlugin, Day, Week, WorkWeek, Month, Agenda } from "@syncfusion/ej2-vue-schedule";

export default {
	name: 'ScheduleView',
	components: {
		'ejs-schedule': SchedulePlugin,
		// 'v-date-picker': DatePicker,1
	},
	data() {
		return {
			selectedDate: new Date(2022, 1, 20),
			eventSettings: {
				dataSource: [
					{
						Id: 1,
						Subject: 'Scrum Meeting',
						Location: 'Office',
						StartTime: new Date(2022, 1, 12, 9, 30),
						EndTime: new Date(2023, 1, 12, 10, 30),
						RecurrenceRule: 'FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1'
					}]
			},
		}
	},
	provide: {
		schedule: [Day, Week, WorkWeek, Month, Agenda]
	}
}
</script>

<style scoped>
/* Your styles go here */
</style>
