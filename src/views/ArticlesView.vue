<template>
	<div class="articles-view">
		<OffCanvas :routers="routers" />
		<router-view></router-view>
	</div>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';
export default {
	name: 'ArticlesView',
	components: {
		OffCanvas,
	},
	data() {
		return {
			routers: [
				{ route: `/articles/`, title: "Home" },
				{ route: `/articles/generator`, title: "Generator" },
			]
		};
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
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
/* Your styles go here */
</style>
