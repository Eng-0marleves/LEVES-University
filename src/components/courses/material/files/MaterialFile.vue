<template>
	<div class="material-file">
		<!-- Button trigger modal -->
		<button type="button" class="btn" data-bs-toggle="modal" data-bs-target="#FileModal">
			<div class="card" style="width: 18rem;">
				<img src="https://www.keytechinc.com/wp-content/uploads/2022/01/video-thumbnail.jpg" class="card-img-top"
					alt="...">
				<div class="card-body">
					<p>Some quick example text to build on the card title and make up the bulk of the card's content.</p>
				</div>
			</div>
		</button>

		<!-- Modal -->
		<div class="modal fade" id="FileModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered modal-xl">
				<div class="modal-content p-0">
					<div class="modal-body p-0">
						<!-- Embed the PDF file using an iframe -->
						<iframe width='100%' height='800px' src='https://research.google.com/pubs/archive/44678.pdf'
							frameborder='0'></iframe>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'MaterialFile',
};
</script>

<style scoped>
/* Your CSS goes here */
</style>
