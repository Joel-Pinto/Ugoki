<style src="../assets/css/home/home.css"></style>

<template>
    <div class="">
        <ActivityCard />
    </div>
</template>

<script lang="ts" setup>
    import { home } from '../scripts/views/home.ts';
    import ActivityCard from './Home/activityCard.vue';

    const homeInstance = home();


</script>
