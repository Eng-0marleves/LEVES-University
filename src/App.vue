<template>
  <div class="app">
    <!-- v-if="isLoading" -->
    <div v-if="isLoading" class="loading">
      <div class="content">
        <img src="@/assets/images/white_logo_full.png" alt="">
        <div class="loader"></div>
      </div>
    </div>
    <div>
      <NavBar />
      <NavHeader />
      <router-view class="main" />
      <FooterSection />
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
      isLoading: true, // Added isLoading to manage the loading state
    }
  },
  created() {
    this.checkLoginStatus();
  },
  methods: {
    checkLoginStatus() {
      // Simulate an async operation, like fetching data
      setTimeout(() => {
        const userInfo = localStorage.getItem('user-info');
        if (userInfo) {
          this.isLoggedIn = true;
        }
        this.isLoading = false; // Update isLoading once the check is complete
      }, 1000); // Simulating async operation with setTimeout
    }
  },
}
</script>

<style scoped>
/* .app {
  display: flex;
  flex-direction: column;
  align-items: center;
} */
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
