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
							<TextEditor />

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
import TextEditor from './TextEditor.vue';
export default {
	name: "ContentGenerator",
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
	components: {
		TextEditor
	},
	methods: {
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
