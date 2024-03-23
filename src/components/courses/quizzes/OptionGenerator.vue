<template>
	<div class="OptionGenerator">
		<input type="text" class="optionInput" :value="option.text" @input="handleInput($event.target.value, 'text')" />
		<input type="checkbox" :checked="option.correct" @change="handleInput($event.target.checked, 'correct')" />
		<button @click="$emit('deleteOption')"><i class="fas fa-times"></i></button>
	</div>
</template>

<script>
export default {
	name: 'OptionGenerator',
	props: {
		option: {
			type: Object,
			required: true
		}
	},
	methods: {
		handleInput(value, key) {
			this.$emit('updateOption', { ...this.option, [key]: value });
		}
	}
};
</script>

<style scoped>
.OptionGenerator {
	width: 100% !important;
	display: flex;
	align-items: center;
	gap: 16px;
}

.OptionGenerator .optionInput {
	width: 100%;
	padding: 4px;
	border-radius: 4px;
	border: 1px solid var(--primary-color);
}
</style>