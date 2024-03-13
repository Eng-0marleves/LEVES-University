<template>
	<div class="material-file">
		<!-- Button trigger modal -->
		<button type="button" class="btn" data-bs-toggle="modal" data-bs-target="#FileModal">
			<div class="card" style="width: 14rem;">
				<img :src="$props.cover" class="card-img-top" alt="...">
				<div class="card-body">
					<p>{{ $props.name }}</p>
				</div>
			</div>
		</button>

		<!-- Modal -->
		<div class="modal fade" id="FileModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-lg">
				<div class="modal-content p-0">
					<div class="modal-body p-0">
						<!-- Embed the PDF file using an iframe -->
						<iframe width='100%' height='800px' :src='$props.src' frameborder='0'></iframe>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'MaterialFile',
	props: {
		name: {
			type: String,
			required: true
		},
		src: {
			type: String,
			required: true
		},
		cover: {
			type: String,
			required: true
		}
	}
};
</script>

<style scoped>
/* .material-file {
	width: 200px;
} */

.card-body {
	text-align: left;
	color: var(--white-color);
	background: var(--primary-color);
}
</style>
