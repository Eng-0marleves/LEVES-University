<template>
  <section class="home">

    <div id="carouselExampleInterval" class="carousel slide" data-bs-ride="carousel">
      <div class="carousel-inner">
        <div class="carousel-item active" data-bs-interval="10000">
          <img src="https://t3.ftcdn.net/jpg/05/14/95/12/360_F_514951224_2dxMLbIw5qNRdPGD003chpbVcxWtcp7K.jpg"
            class="d-block w-100 carousel-image" alt="...">
        </div>
        <div class="carousel-item" data-bs-interval="2000">
          <img
            src="https://png.pngtree.com/thumb_back/fh260/background/20190529/pngtree-the-background-of-sense-of-science-and-technology-in-information-technology-image_117255.jpg"
            class="d-block w-100 carousel-image" alt="...">
        </div>
        <div class="carousel-item">
          <img src="https://i.pinimg.com/originals/78/3c/ba/783cba456524d237f9b35473debdbcd0.jpg"
            class="d-block w-100 carousel-image" alt="...">
        </div>
      </div>
      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>

  </section>
</template>

<script>
export default {
  name: 'HomeView',
  components: {

  }
}
</script>

<style scoped>
.carousel-inner {
  height: 25rem;
  border-radius: 10px;
  border-top: 5px solid var(--title-color);
  border-bottom: 5px solid var(--title-color);
}

.carousel-inner img {
  width: 100%;
  height: 25rem;
  object-fit: cover;
}
</style>
