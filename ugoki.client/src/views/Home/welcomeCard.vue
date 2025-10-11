
<style scoped>
</style>

<template>
    <div class="flex gap-2">
        <div class="w-[50vw] bg-[var(--color-primary)] rounded-lg rounded-tr-[3rem] rounded-bl-none rounded-br-none p-4">
            <h1 class="text-[var(--color-username-home)] font-bold!">Good Morning, Joel Pinto!</h1>
        </div>
        <ActivityMonth />
    </div>
</template>

<script setup lang="ts">
    import ActivityMonth from '../Home/activityOfTheMonth.vue';
</script>