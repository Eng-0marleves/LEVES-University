<template>
	<div class="text-editor">
		<div class="options p-1 d-flex gap-2 flex-wrap">
			<button class="btn" @click="applyStyle('undo')">
				<i class="fas fa-undo"></i>
			</button>

			<button class="btn" @click="applyStyle('redo')">
				<i class="fas fa-redo"></i>
			</button>

			<button class="btn" @click="applyStyle('bold')">
				<i class="fas fa-bold"></i>
			</button>

			<button class="btn d-flex align-items-center gap-2">
				<label for="fontColor"><i class="fa-solid fa-font"></i></label>
				<input type="color" v-model="fontColor" id="fontColor" @change="applyFontColor">
			</button>

			<button class="btn d-flex align-items-center gap-2">
				<label for="backColor"><i class="fa-solid fa-highlighter"></i></label>
				<input type="color" v-model="backColor" id="backColor" @change="applyBackColor">
			</button>

			<button class="btn" @click="applyStyle('italic')">
				<i class="fas fa-italic"></i>
			</button>

			<button class="btn" @click="applyStyle('underline')">
				<i class="fas fa-underline"></i>
			</button>

			<button class="btn" @click="applyStyle('strikethrough')">
				<i class="fas fa-strikethrough"></i>
			</button>

			<select class="btn" @change="applyFormat($event.target.value)">
				<option value="H1" class="text-left text-white">H1</option>
				<option value="H2">H2</option>
				<option value="H3">H3</option>
				<option value="H4">H4</option>
				<option value="H5">H5</option>
				<option value="H6">H6</option>
			</select>

			<button class="btn" @click="applyStyle('superscript')">
				<i class="fas fa-superscript"></i>
			</button>

			<button class="btn" @click="applyStyle('subscript')">
				<i class="fas fa-subscript"></i>
			</button>

			<button class="btn" @click="applyStyle('insertOrderedList')">
				<i class="fas fa-list-ol"></i>
			</button>

			<button class="btn" @click="applyStyle('InsertUnorderedList')">
				<i class="fas fa-list-ul"></i>
			</button>

			<button class="btn" @click="applyStyle('justifyLeft')">
				<i class="fas fa-align-left"></i>
			</button>

			<button class="btn" @click="applyStyle('justifyCenter')">
				<i class="fas fa-align-center"></i>
			</button>

			<button class="btn" @click="applyStyle('justifyRight')">
				<i class="fas fa-align-right"></i>
			</button>

			<button class="btn" @click="applyStyle('justifyFull')">
				<i class="fas fa-align-justify"></i>
			</button>

			<button class="btn" @click="applyStyle('insertImage')">
				<i class="fas fa-images"></i>
			</button>

			<button class="btn" @click="applyStyle('createLink')">
				<i class="fas fa-link"></i>
			</button>

			<button class="btn" @click="applyStyle('unlink')">
				<i class="fas fa-link-slash"></i>
			</button>

			<!-- <button class="btn" @click="applyStyle('table')">
									<i class="fas fa-table"></i>
								</button> -->
		</div>
	</div>
</template>

<script>
export default {
	name: 'TextEditor',
	data() {
		return {
			// Your data goes here
		};
	},
	methods: {
		applyStyle(style) {
			if (style === "insertImage" || style === "createLink") {
				let url = prompt("Insert Link here");
				document.execCommand(style, false, url);
			} else {
				document.execCommand(style, false);
			}
		},
		applyFormat(format) {
			document.execCommand("formatBlock", false, format);
		},
		applyFontColor() {
			document.execCommand('foreColor', false, this.fontColor);
		},
		applyBackColor() {
			document.execCommand('backColor', false, this.backColor);
		},
		applyForeColor() {
			document.execCommand('foreColor', false, this.foreColor);
		},
	},
	computed: {
		// Your computed properties go here
	},
};
</script>

<style scoped>
.text-editor .btn {
	padding: 4px 8px;
	background: transparent;
	border: none;
	color: var(--primary-color);
	transition: var(--transition);
}

.text-editor .btn:hover {
	background: #ccccccc3;
}

.text-editor input,
.text-editor label {
	cursor: pointer;
}
</style>