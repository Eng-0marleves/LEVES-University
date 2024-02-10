import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// Import Bootstrap styles
import 'bootstrap/dist/css/bootstrap.css';

// Import Bootstrap JavaScript (optional, for components that require it)
import 'bootstrap/dist/js/bootstrap.bundle';

import "@/assets/css/style.css"


createApp(App).use(router).mount('#app')
