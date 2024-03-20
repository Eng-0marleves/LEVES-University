<template>
	<div class="GeneratorQuestion">
		<div class="field">
			<div class="left">
				<p>Question Type</p>
			</div>
			<div class="right d-flex justify-content-between align-items-center">

				<select>
					<option class="d-flex gap-2 align-items-center" value="single-choice">
						<i class="fa-regular fa-circle-dot"></i>
						<p>Single Choice</p>
					</option>
					<option class="d-flex gap-2 align-items-center" value="multiple-choice">
						<i class="fa-regular fa-square-check"></i>
						<p>Multiple Choice</p>
					</option>
					<option class="d-flex gap-2 align-items-center" value="picture-choice">
						<i class="fa-regular fa-image"></i>
						<p>Picture Choice</p>
					</option>
				</select>

				<div class="points">
					<label for="">Points</label>
					<input type="number" name="points" id="points">
				</div>

			</div>
		</div>


		<div class="field">
			<div class="left">
				Questions
			</div>
			<div class="right">
				wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
			</div>
		</div>


		<div class="field">
			<div class="left">
				Options
			</div>
			<div class="right">

			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'GeneratorQuestion',
	data() {
		return {
			// Your data properties go here
		};
	},
	methods: {
		// Your methods go here
	},
	computed: {
		// Your computed properties go here
	},
	mounted() {
		// Code to run when the component is mounted
	},
};
</script>

<style scoped>
.GeneratorQuestion {
	display: flex;
	flex-direction: column;
	align-items: center;
	gap: 16px;
}

.field {
	width: 100%;
	display: flex;
	align-items: flex-start;
	gap: 16px;
}

.field .left {
	width: 120px;
	text-align: right;
}

.field .right {
	width: 100%;
}

.field .right select {
	color: var(--white-color);
	background: var(--primary-color);
	padding: 4px;
	border-radius: 4px;
}
</style>