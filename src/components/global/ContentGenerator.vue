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
						<div class="modal-footer-container">
							<div v-if="isSelecetRoles">
								<!-- <button type="buttpn" class="btn normal">Notificate</button> -->
								<div class="notficateOptions">
									<multiselect v-model="selectedRoles" :options="roles" placeholder="Notificate Users"
										label="text" track-by="value" multiple class="custom-multiselect"></multiselect>
								</div>
							</div>
							<div class="d-flex gap-2" style="margin-left: auto">
								<button type="button" class="btn btn-danger" data-bs-dismiss="modal"
									@click="cancel">Cancel</button>
								<button type="button" class="btn btn-success" data-bs-dismiss="modal"
									@click="save">Save</button>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import TextEditor from './TextEditor.vue';
import Multiselect from 'vue-multiselect';

export default {
	name: "ContentGenerator",
	components: {
		TextEditor,
		Multiselect
	},
	data() {
		return {
			fontColor: '#000000',
			backColor: '#ffffff',
			foreColor: '#000000',
			isSelecetRoles: this.$props.selectRoles || false,
			selectedRoles: [],
			roles: [
				{ value: 1, text: 'student' },
				{ value: 2, text: 'doctor' },
				{ value: 3, text: 'manager' },
				{ value: 4, text: 'admin' },
				{ value: 5, text: 'librarian' },
			]
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
		},
		selectRoles: {
			type: Boolean,
			required: false
		}
	},
	methods: {
		save() {
			this.$emit('save', this.$refs.output.innerHTML, this.$props.id);
			this.$emit('saveNewsPost', this.$refs.output.innerHTML, this.selectedRoles);
		},
		cancel() {
			this.$refs.output.innerHTML = "";
			this.$emit('cancle');
		},
	},
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

.modal-footer-container {
	width: 100%;
	display: flex;
	justify-content: space-between;
	align-items: center;
}

.select-container {
	margin-bottom: 20px;
}

.multiselect {
	background: var(--primary-color);
	color: #fff;
	padding: 8px;
	border-radius: 4px;
	cursor: pointer;
}

.multiselect__element:hover {
	background: var(--secondary-color);
}

.multiselect__input {
	color: #eee;
}

.multiselect__input::placeholder {
	color: #ddd;
}
</style>
