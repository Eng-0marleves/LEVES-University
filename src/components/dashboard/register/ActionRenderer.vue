<template>
	<button class="btn normal" style="width: 100%;" @click="handleClick">{{ buttonText }}</button>
</template>

<script>
export default {
	props: {
		params: Object,
	},
	computed: {
		// Compute the button text based on the isRegistered value
		buttonText() {
			return this.params.data.isRegistered ? 'Drop' : 'Register';
		},
	},
	methods: {
		handleClick() {
			// Here, you could toggle the registration state, for example
			// For now, let's just log to the console
			console.log(`Clicked to ${this.buttonText.toLowerCase()} course ${this.params.data.code}`);

			// Optionally, you could invoke an external method passed as a prop
			// this.params.clicked(this.params.data.code);
		},
	},
};
</script>

<style scoped>
button {
	padding: 6px 12px;
	border: none;
	border-radius: 4px;
	cursor: pointer;
	background-color: #007bff;
	color: white;
}

button:hover {
	background-color: #0056b3;
}
</style>
