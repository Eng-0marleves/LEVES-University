<template>
  <section class="home">

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

  </section>
</template>

<script>
import HomeCarousel from '@/components/home/HomeCarousel.vue';
import OurFutures from '@/components/home/OurFutures.vue';
import AboutVideo from '@/components/home/AboutVideo.vue';
import QA from '@/components/home/QA.vue';
import TestimonialsPart from '@/components/home/TestimonialsPart.vue';
import AboutCounts from '@/components/home/AboutCounts.vue'
import AboutFutures from '@/components/home/AboutFutures..vue';
import LatestEvents from '@/components/home/LatestEvents.vue';
import Cookies from 'js-cookie';

export default {
  name: 'HomeView',

  data() {
    return {
      userData: null
    };
  },

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
  },
  created() {
    const userDataString = Cookies.get('user_data');
    if (userDataString) {
      this.userData = JSON.parse(userDataString);
    }
  },
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