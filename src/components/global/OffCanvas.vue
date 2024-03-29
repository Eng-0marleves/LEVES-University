<template>
	<div class="container">
		<div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasExample"
			aria-labelledby="offcanvasExampleLabel">
			<button type="button" ref="close" data-bs-dismiss="offcanvas"></button>
			<button ref="close" type="button" data-bs-dismiss="offcanvas" aria-label="Close"></button>
			<div class="offcanvas-body w-90 pt-3" v-if="routers_">
				<router-link v-for="router in routers_" :key="router.path" :to="router.path" class="router"
					:class="{ 'active': $route.path === router.path }" @click="handleRouterClick">
					{{ router.title }}
				</router-link>
			</div>
		</div>
		<button class="btn fixed" type="button" data-toggle="tooltip" rel="tooltip" title="Menu"
			data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample">
			<i class="fas fa-bars"></i>
		</button>
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
			routers_: null
		};
	},
	watch: {
		routers: {
			immediate: true,
			handler(newVal) {
				this.routers_ = newVal;
			}
		}
	},
	methods: {
		handleRouterClick() {
			this.$refs.close.click();
		}
	}
};
</script>

<style scoped>
.offcanvas {
	z-index: 10000000000000;
}

.btn.fixed {
	z-index: 1000000000000000 !important;
}

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
