<template>
	<div class="qa">
		<div class="accordion accordion-flush" id="accordionFlushExample">
			<div v-for="(item, index) in items" :key="index" class="accordion-item">
				<h2 class="accordion-header">
					<button class="accordion-button collapsed" type="button" :data-bs-toggle="'collapse'"
						:data-bs-target="'#flush-collapse-' + index" :aria-expanded="false"
						:aria-controls="'flush-collapse-' + index">
						{{ item.header }}
					</button>
				</h2>
				<div :id="'flush-collapse-' + index" class="accordion-collapse collapse"
					:data-bs-parent="'#accordionFlushExample'">
					<pre class="accordion-body">
						{{ item.content }}
					</pre>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: "QA_Item",
	props: {
		items: {
			type: Array,
			required: true
		}
	}
}
</script>

<style scoped>
.accordion {
	display: flex;
	justify-content: space-around;
	align-items: center;
	flex-wrap: nowrap;
	flex-direction: column;
	gap: 24px;
	flex: 1;
}

pre {
	word-break: break-all;
	white-space: -moz-pre-wrap;
	white-space: -o-pre-wrap;
	white-space: pre-wrap;
	white-space: pre-line;
	word-wrap: break-word;
	font-size: 16px;
	/* line-height: 2px; */
}

.accordion .accordion-item {
	width: 600px;
}

@media (max-width: 768px) {
	.qa {
		width: 100%;
	}
}
</style>