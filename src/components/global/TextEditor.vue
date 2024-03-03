<template>
	<div class="hello">
		<QuillEditor ref="editor" v-model="delta" :content="content" :toolbar="toolbarSettings" theme="snow"
			@textChange="onTextChange" @update:content="onContentUpdate" :options="editorOptions">
		</QuillEditor>

		<!-- Display the content in the test div -->
		<div ref="test">{{ delta }}</div>
	</div>
</template>

<script>
import { QuillEditor } from "@vueup/vue-quill";
import "@vueup/vue-quill/dist/vue-quill.snow.css";

const toolbarSettings = {
	container: [
		["bold", "italic", "underline", "strike"], // toggled buttons
		["blockquote", "code-block"],
		[{ header: 1 }, { header: 2 }], // custom button values
		[{ list: "ordered" }, { list: "bullet" }],
		[{ script: "sub" }, { script: "super" }], // superscript/subscript
		[{ indent: "-1" }, { indent: "+1" }], // outdent/indent
		[{ direction: "rtl" }], // text direction
		[{ size: ["small", false, "large", "huge"] }], // custom dropdown
		[{ header: [1, 2, 3, 4, 5, 6, false] }],
		[{ color: [] }, { background: [] }], // dropdown with defaults from theme
		[{ font: [] }],
		[{ align: [] }],
		["clean"], // remove formatting button
		["link", "image", "video"], // add image, video, audio buttons,
	],
};

export default {
	name: "TextEditor",
	components: { QuillEditor },
	data() {
		return {
			toolbarSettings,
			content: "",
			editorOptions: {
				// debug: "info",
				placeholder: "type your text....",
				readonly: true,
				theme: "snow",
			},
			delta: "<h1>Test</h1>", // Initialize delta as an empty string
		};
	},
	watch: {
		content() {
			// Get the HTML content of the Quill editor
			this.delta = this.$refs.editor.root.innerHTML;
			this.$refs.test.root.innerHTML = this.delta;
			// console.log(this.delta);
		},
	},
};
</script>

<style>
/* .ql-snow.ql-toolbar button {
	font-size: 24px;
	width: 36px;
	height: 36px;
  }

  .ql-snow.ql-toolbar button {
	font-size: 64px;
	padding: 4px;
  }

  .ql-snow.ql-toolbar button svg {
	width: 32px;
	height: 32px;
  }

  .ql-toolbar.ql-snow .ql-picker-label {
	font-size: 32px;
	margin-right: 8px;
  } */

/* -------------------------------------------------------- */

.ql-editor {
	height: 25vw !important;
	overflow-y: auto;
}

.ql-toolbar.ql-snow {
	min-height: 48px;
	/* Increase the height of the toolbar */
}

.ql-toolbar.ql-snow .ql-picker,
.ql-toolbar.ql-snow .ql-size {
	/* width: 72px; */
	/* Increase the width of the dropdowns */
}

.ql-editor.ql-blank {
	/* min-height: 200px; */
	/* Increase the minimum height of the editor */
}

.ql-snow.ql-toolbar button {
	font-size: 64px;
	/* background: red; */
}

.ql-snow.ql-toolbar button svg {
	/* transform: scale(2); */
}

.ql-toolbar.ql-snow .ql-picker-label {
	/* transform: scale(2); */
}

.ql-container {
	font-size: 20px;
}

.ql-container {
	font-size: 20px !important;
}
</style>
