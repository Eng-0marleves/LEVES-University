import { createApp } from 'vue'
import App from './App.vue'
import router from './router'


// Import Bootstrap CSS
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

import bootstrap from 'bootstrap/dist/js/bootstrap.bundle.js'
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

import "@/assets/css/main.css"


createApp(App)
	.use(router)
	.use(bootstrap)
	.mount('#app')