<template>
	<div class="container">
		<button class="btn btn-fixed" type="button" data-toggle="tooltip" rel="tooltip" title="Menu"
			data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample">
			<i class="fas fa-bars"></i>
		</button>

		<div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasExample"
			aria-labelledby="offcanvasExampleLabel">
			<!-- <div class="offcanvas-header">
				<button type="button" class="btn-close close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
		</div> -->
			<button ref="close" type="button" data-bs-dismiss="offcanvas" aria-label="Close"></button>
			<div class="offcanvas-body w-90 pt-3">
				<router-link v-for="router in routers_" :key="router.route" :to="router.route" class="router"
					:class="{ 'active': $route.path === router.route }" @click="handleRouterClick">
					{{ router.title }}

				</router-link>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: "OffCanvas",
	props: {
		routers: {
			type: Array,
			required: true
		}
	},
	data() {
		return {
			routers_: this.routers
		};
	},
	methods: {
		handleRouterClick() {
			this.$refs.close.click();
		}
	}
}
</script>

<style scoped>
.offcanvas-body {
	display: flex;
	flex-direction: column;
	gap: 24px;
	padding: 0;
	background: var(--primary-color);
	text-align: right;
	/* width: 90vw !important; */
}

.offcanvas-body .router {
	color: #fff;
	font-size: 16px;
	padding: 8px 16px;
	width: 100%;
	transition: var(--transition);
}

.modal-content {
	width: fit-content !important;
}

.offcanvas {
	--bs-offcanvas-width: 300px;
}

.offcanvas-body .router:hover:not(.active) {
	background: linear-gradient(to left, #ffffff1a, #00000004);
}

.offcanvas-body .router.active {
	border-bottom: 2px solid var(--secondary-color);
	background: linear-gradient(to left, var(--secondary-color), #00000004);
}
</style>
