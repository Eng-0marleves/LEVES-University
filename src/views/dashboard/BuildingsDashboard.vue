<template>
	<div class="buildings-dashboard">
		<div class="tabs">
			<button @click="switchTaps('showBuildings')" :class="{ active: currentTab === 'showBuildings' }">Show
				Buildings</button>
			<button @click="switchTaps('editBuilding')" :class="{ active: currentTab === 'editBuilding' }">Edit
				Building</button>
			<button @click="switchTaps('timeTable')" :class="{ active: currentTab === 'timeTable' }">Time Table</button>
		</div>
		<div class="tab-content">
			<ShowBuildings v-if="currentTab === 'showBuildings'" />
			<EditBuildings v-if="currentTab === 'editBuilding'" />
			<TimeTable v-if="currentTab === 'timeTable'" />
		</div>
	</div>
</template>

<script>
import ShowBuildings from '@/components/dashboard/buildings/ShowBuildings.vue';
import EditBuildings from '@/components/dashboard/buildings/EditBuildings.vue';
import TimeTable from '@/components/dashboard/buildings/TimeTable.vue';

export default {
	name: 'BuildingsDashboard',
	components: {
		ShowBuildings,
		EditBuildings,
		TimeTable,
	},
	data() {
		return {
			currentTab: 'showBuildings', // Default tab
		};
	},
	methods: {
		switchTaps(tab) {
			this.currentTab = tab;
		},
	},
};
</script>

<style scoped>
.tabs {
	background: var(--primary-color);
	padding: 8px;
	padding-bottom: 0px;
}

.tabs button {
	color: var(--white-color);
	padding: 10px;
	margin-right: 5px;
	cursor: pointer;
	background-color: transparent;
	border: 1px solid #ddd;
}

.tabs button.active {
	background-color: var(--secondary-color);
}

.tabs button:hover {
	background-color: var(--secondary-color);
}

.tab-content {
	margin-top: 20px;
}
</style>
