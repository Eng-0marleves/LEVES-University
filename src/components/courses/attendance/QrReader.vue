<template>
	<div class="qr-reader">
		<!-- Button trigger modal -->
		<!-- <button type="button" class="btn" data-bs-toggle="modal" data-bs-target="#QrGeneratorBtn">Read Qr Code </button> -->

		<button class="btn">Read QR Code</button>
		<qrcode-stream @detect="onDetect" @init="onInit" @decode="onDecode" :torch="false"></qrcode-stream>
		<p>{{ decodeText }}</p>
		<p>{{ error }}</p>
		<!-- Modal -->
		<!-- <div class="modal fade" id="QrGeneratorBtn" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl">
				<div class="modal-content p-0" style="width: fit-content; margin: 0 auto;">
					<div class="modal-body">
						<qrcode-vue value="lec 10" size="400" level="H" />
					</div>
				</div>
			</div>
		</div> -->
	</div>
</template>

<script>
import { QrcodeStream } from 'vue-qrcode-reader'

export default {
	name: 'QrReader',
	components: {
		QrcodeStream
	},
	data() {
		return {
			error: "",
			decodeText: "",
			torch: false
		};
	},
	methods: {
		async onInit(promise) {
			try {
				/* eslint-disable */
				const { capabilities } = await promise
				console.log("start");
				console.log(capabilities);

				// successfully initialized
			} catch (error) {
				if (error.name === 'NotAllowedError') {
					// user denied camera access permisson
				} else if (error.name === 'NotFoundError') {
					// no suitable camera device installed
				} else if (error.name === 'NotSupportedError') {
					// page is not served over HTTPS (or localhost)
				} else if (error.name === 'NotReadableError') {
					// maybe camera is already in use
				} else if (error.name === 'OverconstrainedError') {
					// did you requested the front camera although there is none?
				} else if (error.name === 'StreamApiNotSupportedError') {
					// browser seems to be lacking features
				}
			} finally {
				// hide loading indicator
			}
		},
		onDecode(decodeString) {
			this.decodeText = decodeString;
			console.log(decodeString);
		},
		async onDetect(promise) {
			try {
				const {
					content,      // decoded String
					location      // QR code coordinates
				} = await promise
				console.log(content);
				console.log(location);
				// ...
			} catch (error) {
				// ...
			}
		}
	}
};
</script>

<style scoped>
.qr-reader {
	/* Your styles go here */
}

.btn {
	background: var(--primary-color);
	border-radius: 5px;
	padding: 8px;
	color: #fff;
}

.btn:hover {
	background: var(--secondary-color);
	color: #fff;
}
</style>
