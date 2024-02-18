<template>
  <section class="home">

    <HeroPart />

    <QA />

    <AboutUniversity />

    <TestimonialsPart />

  </section>
</template>

<script>
// import HomeCarousel from '@/components/home/HomeCarousel.vue';
import AboutUniversity from '@/components/home/AboutUniversity.vue';
import HeroPart from '@/components/home/HeroPart.vue';
import QA from '@/components/home/QA.vue';
import TestimonialsPart from '@/components/home/TestimonialsPart.vue';


export default {
  name: 'HomeView',

  components: {
    // HomeCarousel,
    AboutUniversity,
    HeroPart,
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
  gap: 200px;
}
</style>