<template>
	<div class="library-dashboard">
		<ul class="nav-tabs">
			<li v-for="tab in tabs" :key="tab" :class="{ active: currentTab === tab }" @click="currentTab = tab">{{ tab
				}}</li>
		</ul>

		<h2 class="mb-4 text-center">Library Dashboard</h2>

		<div class="tab-content">
			<div v-if="currentTab === 'Books'">
				<LibraryBooks />
			</div>
			<div v-if="currentTab === 'Add Book'">
				<LibrearyAddBook />
			</div>
			<!-- <div v-if="currentTab === 'Articals'">
				<LibraryArticals />
			</div>
			<div v-if="currentTab === 'Add Artical'">
				<LibraryAddArtical />
			</div> -->
		</div>
	</div>
</template>

<script>
import LibraryBooks from '@/components/dashboard/Library/LibraryBooks.vue';
import LibrearyAddBook from '@/components/dashboard/Library/LibrearyAddBook.vue';
// import LibraryArticals from '@/components/dashboard/Library/LibraryArticals.vue';
// import LibraryAddArtical from '@/components/dashboard/Library/LibraryAddArtical.vue';

export default {
	name: 'LibraryDashboard',
	components: {
		LibraryBooks,
		LibrearyAddBook,
		// LibraryArticals,
		// LibraryAddArtical
	},
	data() {
		return {
			currentTab: 'Books',
			tabs: ['Books', 'Add Book'],
		};
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
