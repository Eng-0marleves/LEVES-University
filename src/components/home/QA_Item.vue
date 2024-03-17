<template>
	<div class="qa">
		<div v-for="(item, index) in items" :key="index">
			<div class="item" :class="{ all: $props.all }">
				<button class="accordion-btn" @click="toggleAccordion(index)" :class="{ active: item.open }">
					<p class="header-text">{{ item.header }}</p>
					<i class="icon fas fa-plus"></i>
				</button>
				<div class="panel" :class="{ open: item.open }">
					<pre>{{ item.content }}</pre>
				</div>
			</div>
		</div>

		<router-link v-if="!$props.all" class="all text-center" style="color: var(--secondary-color)" to="/FAQs">See
			All</router-link>
	</div>
</template>

<script>
export default {
	name: "QA_Item",
	props: {
		items: {
			type: Array,
			required: true
		},
		all: {
			type: Boolean,
			default: false
		}
	},
	methods: {
		/* eslint-disable */
		toggleAccordion(index) {
			this.items.forEach((item, i) => {
				if (i !== index) {
					item.open = false;
				}
			});
			this.items[index].open = !this.items[index].open;
		},
	}
}
</script>

<style scoped>
.qa {
	display: flex;
	flex-direction: column;
	gap: 16px;
}

.item {
	width: 500px;
}

pre {
	word-break: break-all;
	white-space: -moz-pre-wrap;
	white-space: -o-pre-wrap;
	white-space: pre-wrap;
	white-space: pre-line;
	word-wrap: break-word;
	font-size: 16px;
	transition: var(--transition) !important;
}

.accordion-btn {
	background-color: var(--primary-color);
	color: var(--white-color);
	display: flex;
	justify-content: space-between;
	align-items: center;
	cursor: pointer;
	padding: 12px;
	width: 500px;
	border: none;
	text-align: left;
	outline: none;
	font-size: 15px;
	transition: var(--transition) !important;
	position: relative;
	line-height: 20px;
}

.accordion-btn.active i {
	transform: rotate(225deg);
}

.accordion-btn p {
	margin: 0;
}

.header-text {
	overflow: hidden;
	text-overflow: ellipsis;
	width: 95%;
	white-space: nowrap;
}

.active,
.accordion-btn:hover {
	background-color: var(--secondary-color);
}

.accordion-btn.all {
	width: 100%;
}

.panel {
	padding: 0 18px;
	background-color: white;
	max-height: 0;
	overflow: hidden;
	transition: max-height 0.3s ease-out;
}

.panel.open {
	max-height: 500px;
}

.icon {
	transition: var(--transition);
}

.accordion-btn.active .icon:after {
	transition: var(--transition) !important;
}

.all {
	width: 100% !important;
}

.all .accordion-btn {
	width: 100% !important;
}

@media (max-width: 768px) {
	.item {
		width: 100% !important;
	}

	.accordion-btn {
		width: 100% !important;
	}
}
</style>
