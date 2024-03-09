<template>
  <section class="home">

    <!-- <HeroPart /> -->

    <HomeCarousel />
    <OurFutures />

    <div class="home-container">
      <TestimonialsPart />

      <QA />
    </div>


    <!-- <AboutUniversity /> -->


  </section>
</template>

<script>
import HomeCarousel from '@/components/home/HomeCarousel.vue';
// import AboutUniversity from '@/components/home/AboutUniversity.vue';
// import HeroPart from '@/components/home/HeroPart.vue';
import OurFutures from '@/components/home/OurFutures.vue';
import QA from '@/components/home/QA.vue';
import TestimonialsPart from '@/components/home/TestimonialsPart.vue';


export default {
  name: 'HomeView',

  components: {
    HomeCarousel,
    // AboutUniversity,
    // HeroPart,
    OurFutures,
    QA,
    TestimonialsPart,
  }
}
</script>

<style scoped>
.home {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  gap: 64px;
}

.home-container {
  display: flex;
  justify-content: space-around;
  align-items: flex-start;
  flex-wrap: wrap;
  gap: 48px;
}
</style>