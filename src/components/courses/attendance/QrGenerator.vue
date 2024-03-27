<template>
	<div class="qr-generator">
		<button type="button" class="btn normal" data-bs-toggle="modal" data-bs-target="#QrGeneratorBtn">
			Generate Qr Code
		</button>

		<div class="modal fade" id="QrGeneratorBtn" tabindex="-1" aria-labelledby="exampleModalLabel"
			aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl">
				<div class="modal-content p-0" style="width: fit-content; margin: 0 auto;">
					<div class="modal-body">
						<qrcode-vue value="lec 10" size="400" level="H" />
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import QrcodeVue from 'qrcode.vue'

export default {
	name: 'QrGenerator',
	components: {
		QrcodeVue
	},
	data() {
		return {
		};
	},
};
</script>

<style scoped></style>
