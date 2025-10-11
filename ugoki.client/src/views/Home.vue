<style src="../assets/css/home/home.css"></style>

<template>
    <div class="">
        <welcomeCard />
        <ActivityCard />
    </div>
</template>

<script lang="ts" setup>
    import { home } from '../scripts/views/home.ts';
    import ActivityCard from './Home/activityCard.vue';
    import welcomeCard from './Home/welcomeCard.vue';

    const homeInstance = home();


</script>
