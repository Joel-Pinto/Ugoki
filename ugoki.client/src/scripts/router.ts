// router.ts
import { createRouter, createWebHistory } from 'vue-router'
import Login from '@/views/Authentication/Login.vue'
import Register from '@/views/Authentication/Register.vue'
import Home from '@/views/Home.vue'

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
        meta: { hideSideBar: false },
    },
    {
        path: "/Login",
        name: "Login",
        component: Login,
        meta: { hideSideBar: true },
    },
    {
        path: "/Register",
        name: "Register",
        component: Register,
        meta: { hideSideBar: true },
    },
];


export const router = createRouter({
    history: createWebHistory(),
    routes,
});
