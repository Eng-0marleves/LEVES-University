<template>
	<div class="qr-reader">
		<button class="btn normal" @click="toggleCamera" data-bs-toggle="modal" data-bs-target="#reader">
			Scan Qr Code
		</button>

		<div class="modal fade" id="reader" tabindex="-1" data-bs-backdrop="static" aria-labelledby="exampleModalLabel"
			aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-body">
						<qrcode-stream v-if="isCameraActive" @decode="onDecode" @init="onInit"></qrcode-stream>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-danger" @click="toggleCamera"
							data-bs-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { QrcodeStream } from 'vue-qrcode-reader';

export default {
	name: 'QrReader',
	components: {
		QrcodeStream,
	},
	data() {
		return {
			isCameraActive: false, // Initially, camera is not active
		};
	},
	methods: {
		onDecode(content) {
			alert(`QR code detected: ${content}`);
			// Here, you can handle the decoded content, e.g., validating it or navigating based on its value.
			// Optionally, close the camera after successful decode
			this.isCameraActive = false;
		},
		onInit(promise) {
			promise.then(() => {
				console.log('QR reader initialization complete');
				// QR reader is ready to scan.
			}).catch(error => {
				if (error.name === 'NotAllowedError') {
					// User denied camera access permission
					alert('You need to grant camera access permission');
				} else if (error.name === 'NotFoundError') {
					// No cameras found
					alert('No camera found on this device');
				} else {
					// Some other kind of error or user denied browser permission
					alert('Cannot open camera');
				}
				this.isCameraActive = false; // Ensure the camera is marked as inactive if there's an error
			});
		},
		toggleCamera() {
			// Toggle the camera active state
			this.isCameraActive = !this.isCameraActive;
		},
	},
};
</script>

<style scoped>
.qr-reader {
	/* Styles for your QR reader container */
}
</style>
