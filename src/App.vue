<template>
  <div class="app">
    <div v-if="isLoading" class="loading">
      <div class="content">
        <img src="@/assets/images/white_logo_full.png" alt="">
        <div class="loader"></div>
      </div>
    </div>
    <div>
      <NavBar />
      <NavHeader :userData="userData" />
      <div class="d-flex justify-content-between flex-column">
        <router-view class="main" />
        <FooterSection />
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from './components/global/NavBar.vue'
import NavHeader from './components/global/NavHeader.vue'
import FooterSection from './components/global/FooterSection.vue'

export default {
  components: {
    NavBar,
    NavHeader,
    FooterSection
  },
  data() {
    return {
      isLoggedIn: false,
      isLoading: true,
    }
  },
  methods: {
    handleWindowLoad() {
      this.isLoading = false;
    }
  },
  mounted() {
    window.addEventListener('load', this.handleWindowLoad);
  },
  /* eslint-disable */
  beforeDestroy() {
    window.removeEventListener('load', this.handleWindowLoad);
  }
}
</script>

<style scoped>
.main {
  min-height: 100vh;
}

.loading {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background: rgba(0, 0, 0, 0.6);
  z-index: 1000000000000000000000000000000000000000000000000000000000000000000000000000;
}

.loading .content {
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.loading .content img {
  width: 50%;
  margin: 0 auto;
}

.loader {
  width: 3rem;
  height: 3rem;
  margin: 0 auto;
  margin-top: 16px;
  border: .4rem solid var(--secondary-color);
  border-left-color: transparent;
  border-right-color: transparent;
  border-radius: 50%;
  animation: .8s spin ease-in-out alternate infinite;
}

@keyframes spin {
  to {
    transform: rotate(1turn) scale(1.2);
  }
}
</style>
