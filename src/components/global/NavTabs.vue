<template>
	<div class="slider-tabs">
		<ul class="nav nav-tabs">
			<li class="nav-item">
				<a class="nav-link active" aria-current="page" href="#">Active</a>
			</li>
			<li class="nav-item">
				<a class="nav-link" href="#">Link</a>
			</li>
			<li class="nav-item">
				<a class="nav-link" href="#">Link</a>
			</li>
			<li class="nav-item">
				<a class="nav-link disabled" aria-disabled="true">Disabled</a>
			</li>
		</ul>
	</div>
</template>

<script>
export default {
	name: "NavTabs",

	methods: {
		scrollLeft() {
			const tabsContainer = document.querySelector(".tabs-container");
			tabsContainer.scrollLeft -= 100; // Adjust scroll amount as needed
		},

		scrollRight() {
			const tabsContainer = document.querySelector(".tabs-container");
			tabsContainer.scrollLeft += 100; // Adjust scroll amount as needed
		},
	},
};
</script>

<style scoped>
.slider-tabs {
	position: relative;
	width: fit-content;
	display: flex;
	justify-content: center;
	align-items: center;
	gap: 16px;
	border-radius: 16px;
	margin: 0 auto;
}

.slider-tabs .icon {
	position: absolute;
	top: 0;
	height: 100%;
	width: 120px;
	display: flex;
	align-items: center;
}

.slider-tabs .icon:first-child {
	left: -72px;
	background: linear-gradient(90deg, var(--white-color), 70%, transparent);
}

.slider-tabs .icon:last-child {
	right: 0;
	background: linear-gradient(-90deg, var(--white-color), 70%, transparent);
	justify-content: flex-end;
}

.slider-tabs .icon i {
	width: 40px;
	height: 40px;
	margin: 0;
	cursor: pointer;
	font-size: 16px;
	text-align: center;
	line-height: 40px;
	border-radius: 50%;
}

.slider-tabs .icon i:hover {
	background: #ddd;
}

.slider-tabs .icon:first-child i {
	margin-left: 16px;
}

.slider-tabs .icon:last-child i {
	margin-right: 16px;
}

.slider-tabs .tabs-container {
	max-width: 700px;
	list-style: none;
	display: flex;
	gap: 16px;
	overflow-x: hidden;
	scroll-behavior: smooth;
}

.slider-tabs .tabs-container .tab {
	cursor: pointer;
	font-size: 16px;
	background: #f5f4fd;
	padding: 8px 24px;
	border-radius: 32px;
	border: 1px solid #d8d5d2;
	white-space: nowrap;
}
</style>
