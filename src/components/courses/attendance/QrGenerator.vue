<template>
	<div class="qr-generator">
		<form>
			<input type="text" v-model="QrValue">
		</form>
		<!-- Button trigger modal -->
		<button type="button" class="btn" data-bs-toggle="modal" data-bs-target="#QrGeneratorBtn">Generate Qr Code </button>

		<!-- Modal -->
		<div class="modal fade" id="QrGeneratorBtn" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
			QrValue: null
		};
	},
};
</script>

<style scoped>
.qr-generator {
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
