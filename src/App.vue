<template>
  <div class="app">
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <NavBar />
    <router-view />
  </div>
</template>

<script>
import NavBar from '@/components/global/NavBar.vue';

export default {
  components: {
    NavBar,
  },
};
</script>

<style>
.tesst {
  height: 800rem;
}
</style>
