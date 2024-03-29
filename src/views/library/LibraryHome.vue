<template>
	<div class="library-home">
		<HomeCarousel />
	</div>
</template>

<script>
import HomeCarousel from '@/components/library/HomeCarousel.vue';

export default {
	name: 'LibraryHome',
	data() {
		return {
			// Your data goes here
		};
	},
	components: {
		HomeCarousel
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	created() {
		// Code to run when the component is created
	},
};
</script>

<style scoped>
/* Your styles go here */
</style>