<template>
	<div class="buildings-dashboard">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<div class="tab-content">
			<div v-if="currentTab === 'Buildings'">
				<AllBuildings />
			</div>
			<div v-if="currentTab === 'Add Building'">
				<AddBuilding />
			</div>
			<div v-if="currentTab === 'Buildings Time Table'">
				Buildings Time Table
			</div>
			<div v-if="currentTab === 'Class Rooms'">
				<ClassRooms />
			</div>
			<div v-if="currentTab === 'Add Class Room'">
				<AddClassRoom />
			</div>
		</div>
	</div>
</template>

<script>
import AllBuildings from '@/components/dashboard/buildings/AllBuildings.vue';
import AddBuilding from '@/components/dashboard/buildings/AddBuilding.vue';
import ClassRooms from '@/components/dashboard/buildings/ClassRooms.vue';
import AddClassRoom from '@/components/dashboard/buildings/AddClassRoom.vue';

export default {
	name: 'BuildingsDashboard',
	components: {
		AllBuildings,
		AddBuilding,
		ClassRooms,
		AddClassRoom
	},
	data() {
		return {
			currentTab: 'Class Rooms',
			tabs: ['Buildings', 'Add Building', 'Buildings Time Table', 'Class Rooms', 'Add Class Room'],
		};
	},
	methods: {
	},
};
</script>

<style scoped>
.nav-tabs {
	color: var(--white-color);
	list-style-type: none;
	padding: 0;
	display: flex;
	margin-bottom: 20px;
	background: var(--primary-color);
}

.nav-tabs li {
	cursor: pointer;
	padding: 10px 20px;
	border: 1px solid #ccc;
	margin: 0 5px;
	transition: background-color 0.3s;
}

.nav-tabs li:hover,
.nav-tabs li.active {
	background-color: var(--secondary-color);
}

.tab-content {
	border: 1px solid #ccc;
	padding: 20px;
}
</style>
