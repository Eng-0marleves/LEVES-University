<template>
  <div class="app">
    <NavBar />
    <NavHeader />
    <router-view class="main" />
  </div>
</template>

<script>
import NavBar from './components/global/NavBar.vue'
import NavHeader from './components/global/NavHeader.vue'

export default {
  components: {
    NavBar,
    NavHeader,
  },
  data() {
    return {
      isLoggedIn: false,
    }
  },
  created() {
    this.checkLoginStatus();
  },
  methods: {
    checkLoginStatus() {
      const userInfo = localStorage.getItem('user-info');
      if (userInfo) {
        this.isLoggedIn = true;
      }
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
</style>
