<template>
	<div class="text-editor">
		<!-- Button trigger modal -->
		<button type="button" class="btn normal" data-bs-toggle="modal" data-bs-target="#staticBackdrop" id="editorBtn">
			{{ $props.btnText }}
		</button>

		<!-- Modal -->
		<div class="modal fade" style="z-index: 10000000000000000000000000000000000" id="staticBackdrop"
			data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel"
			aria-hidden="true">
			<div class="modal-dialog modal-xl">
				<div class="modal-content">
					<div class="modal-body p-0">
						<div class="editor">
							<div class="options p-3 d-flex gap-2 flex-wrap">
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
									<i class="fa-solid fa-font"></i>
									<input type="color" v-model="fontColor" @change="applyFontColor">
								</button>

								<button class="btn d-flex align-items-center gap-2">
									<i class="fa-solid fa-highlighter"></i>
									<input type="color" v-model="backColor" @change="applyBackColor">
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

							<div class="output p-3" contenteditable="true" ref="output" id="editorOutput"></div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-danger" data-bs-dismiss="modal"
							@click="cancel">Cancel</button>
						<button type="button" class="btn btn-success" data-bs-dismiss="modal"
							@click="save">Save</button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: "TextEditor",
	data() {
		return {
			fontColor: '#000000', // Initial font color
			backColor: '#ffffff', // Initial background color
			foreColor: '#000000' // Initial foreground color
		};
	},
	props: {
		btnText: {
			type: String,
			required: true
		},
		id: {
			type: Number,
			required: true
		}
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
		save() {
			this.$emit('save', this.$refs.output.innerHTML, this.$props.id);
		},
		cancel() {
			this.$refs.output.innerHTML = "";
			this.$emit('cancle');
		}
	}
};
</script>

<style>
.options {
	background: var(--bg-color);
}

.options .btn {
	background: var(--primary-color);
	color: var(--white-color);
}

.options .btn:hover {
	background: var(--primary-color);
	color: var(--secondary-color);
}

.options .btn.active {
	color: var(--secondary-color);
}

.output {
	background: var(--white-color);
	height: 400px;
	overflow-wrap: break-word;
	overflow: auto;
}

select:hover option {
	color: #fff !important;
}
</style>
