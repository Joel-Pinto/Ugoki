import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import Login from './views/Authentication/Login.vue'
import Register from './views/Authentication/Register.vue'
import Home from './views/Home.vue'

import App from './App.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/', name: 'Home', component: Home},
        {path: '/login', name: 'Login', component: Login},
        {path: '/register', name: 'Register', component: Register},
    ]
})

createApp(App)
.use(router)
.mount('#app')
