<template>
	<div class="dashboard-off-canvas">
		<OffCanvas :routers="routers" />
	</div>
</template>

<script>
import OffCanvas from '@/components/global/OffCanvas.vue';
import Cookies from 'js-cookie';
import { jwtDecode } from 'jwt-decode';

export default {
	name: 'DashboardOffCanvas',
	components: {
		OffCanvas
	},
	data() {
		return {
			routers: [
				{
					title: "Profile",
					path: `/dashboard/profile`,
				},
				{
					title: "Register",
					path: `/dashboard/register`,
				},
				{
					title: "Report",
					path: `/dashboard/report`,
				},
				{
					title: "Students",
					path: `/dashboard/students`,
				},
				{
					title: "Employees",
					path: `/dashboard/employees`,
				},
				{
					title: "Library",
					path: `/dashboard/books`,
				},
				{
					title: "Buildings",
					path: `/dashboard/buildings`,
				},
				{
					title: "Semester",
					path: `/dashboard/semester`,
				}
			],
			userData: {}
		};
	},
	methods: {
		// Your methods go here
		filterRouters(role) {
			// Define router titles for each role
			const roleRouters = {
				student: ["Profile", "Register", "Report"],
				doctor: ["Profile"],
				manager: ["Profile", "Students", "Employees", "Buildings", "Semester"],
				admin: ["Profile", "Students", "Employees"],
				librarian: ["Profile", "Library"]
			};

			// Get allowed router titles based on the user's role
			const allowedRouters = roleRouters[role] || [];

			// Filter the routers array based on allowed titles
			return this.routers.filter(router => allowedRouters.includes(router.title));
		}
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		const authToken = Cookies.get('user-auth-token');
		const decodedToken = jwtDecode(authToken);
		this.userData = decodedToken;
		this.routers = this.filterRouters(this.userData.role); // Filter routers based on user's role
	},
};
</script>

<style scoped>
.dashboard-off-canvas {
	/* Your styles go here */
}
</style>