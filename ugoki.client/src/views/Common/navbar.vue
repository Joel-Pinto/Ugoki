
<style src="@/assets/css/buttons.css" scoped></style>
<template>
    <!-- navbar wrapper-->
    <nav class="flex align-center h-[3.675rem] p-2 mb-4 rounded-full bg-[var(--color-primary)] gap-4 border border-black shadow-lg">
        <!-- Here will be the name plus logo or just logo-->
        <a href="#" class="flex self-center ml-2 mr-[5rem]">
           <img src="@/assets/images/logo/Ugoki.png" alt="Ugoki Logo" class="h-14 mr-2"/> 
        </a>

        <!-- NavBar options -->
        <ul class="flex gap-4 list-none m-0 p-0">
            <li v-for="item in items"
                :key="item.name" 
                class="selector h-full p-4 rounded-full max-h-initial flex items-center"
                :class="{ 
                    active: item.current, 
                    'hover:bg-[var(--color-button-nav)]': !item.current
                    }">
                <a :href="item.href"
                    class="btn"
                    :class="{active: item.current}">
                    {{ item.name }}
                </a>
            </li>
        </ul>

        <!-- Search Input -->
        <div class="flex w-auto p-2 ml-auto align-center rounded-full bg-[#edeaec]">
            <input name="searchInput" class="size-fit mx-[0.625rem] focus:outline-none focus:ring-0" placeholder="Search..."/>
        </div>

        <!-- Notifications-->
        <div class="flex items-center">
            <NotificationBell/>
        </div>

        <!-- Divider -->
        <div class="flex items-center">
            <div class="w-px h-6 bg-gray-300"></div>
        </div>

        <!-- User profile -->
        <div class="flex items-center">
            <img src="@/assets/images/logo/Ugoki_figure.png" alt="User Profile" class="w-9 h-9 mr-2 rounded-full border-2 border-black "/>
        </div>
    </nav>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue';
import NotificationBell from '@/components/icons/NotificationBell.vue';

type NavigationItems = {
    name: string,
    href: string,
    current: boolean
};

const navigation: NavigationItems = [
    { name: "Overview", href: "/", current: true },
    { name: "Activity", href: "/", current: false },
    { name: "Fitness Goal", href: "/", current: false },
    { name: "Achievments", href: "/", current: false },
    { name: "Training Plans", href: "/", current: false },
];

const items = reactive(navigation);

</script>