<template>
    <icons />
    <sideBar />
    <router-view></router-view>
</template>

<script lang="ts" setup>
    import icons from './components/dependencies/icons.vue';
    import sideBar from './components/sidemenu/sidebar.vue';
</script>
