<template>
  <section class="home">

    <!-- <HeroPart /> -->

    <HomeCarousel />

    <OurFutures />

    <AboutVideo />

    <div class="home-container">
      <TestimonialsPart />

      <QA />
    </div>


    <AboutCounts />


    <AboutFutures />

    <LatestEvents />





    <!-- <AboutUniversity /> -->


  </section>
</template>

<script>
import HomeCarousel from '@/components/home/HomeCarousel.vue';

// import AboutUniversity from '@/components/home/AboutUniversity.vue';
// import HeroPart from '@/components/home/HeroPart.vue';

import OurFutures from '@/components/home/OurFutures.vue';
import AboutVideo from '@/components/home/AboutVideo.vue';
import QA from '@/components/home/QA.vue';
import TestimonialsPart from '@/components/home/TestimonialsPart.vue';
import AboutCounts from '@/components/home/AboutCounts.vue'
import AboutFutures from '@/components/home/AboutFutures..vue';
import LatestEvents from '@/components/home/LatestEvents.vue';

export default {
  name: 'HomeView',

  components: {
    HomeCarousel,

    // AboutUniversity,
    // HeroPart,

    OurFutures,
    AboutVideo,
    QA,
    TestimonialsPart,
    AboutCounts,
    AboutFutures,
    LatestEvents
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

@media (max-width: 768px) {
  .home-container {
    padding: 8px;
  }
}
</style>