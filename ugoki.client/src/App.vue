<template>
    <icons />
    <navbar />
    <router-view></router-view>
</template>

<script lang="ts" setup>
    import icons from './components/dependencies/icons.vue';
    import navbar from './views/Common/navbar.vue';
</script>
