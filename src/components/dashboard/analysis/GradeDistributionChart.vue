<template>
	<div>
		<canvas ref="canvas"></canvas>
	</div>
</template>

<script>
import { Bar } from 'vue-chartjs'
import { ref, onMounted } from 'vue'

export default {
	name: 'GradeDistributionChart',
	props: {
		chartData: {
			type: Object,
			default: () => { }
		},
		chartOptions: {
			type: Object,
			default: () => { }
		}
	},
	setup(props) {
		const canvas = ref(null)

		onMounted(() => {
			const context = canvas.value.getContext('2d')
			new Bar(context, {
				data: props.chartData,
				options: props.chartOptions
			})
		})

		return {
			canvas
		}
	}
}
</script>
