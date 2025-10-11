<style scoped>
    p.stats {
        font-size: xx-large;
        color: var(--color-button-nav);
        font-weight: bolder;
    }

    p.subStats {
        font-size: medium;
        color: var(--color-button-nav);
        font-weight: 500;
    }

    p.subheading {
        color: #868a94;
    }
    
</style>
<template>
    <div class="flex flex-col gap-4 bg-[var(--color-primary)] rounded-lg rounded-tl-none shadow-lg p-4 ">
        <p class="subheading">Stay active and healthy to start your day</p>

        <div class="h-auto flex justify-between">
            <!-- TODO: This can be a component in the future-->
            <div class="p-8">
                <div class="flex">
                    <p class="stats flex gap-3 items-center">
                        <ClockNoArrow />
                        7.8
                    </p>
                    <p class="subStats ml-1 self-end mb-2">/ Hours</p>
                </div>
                <p class="subheading font-extrabold">Training Report</p>

                <div class="h-64 mt-8"> <!-- or h-48, adjust as you like -->
                    <Line :data="chartData" :options="chartOptions" />
                </div>
            </div>

            <div class="p-8">
                <div class="flex">
                    <p class="stats flex gap-3 items-center">
                        <IconDumbell />
                        8260
                    </p>
                    <p class="subStats ml-1 self-end mb-2">/ Kgs lifted</p>
                </div>
                <p class="subheading font-bold">Weight Counter</p>


                <div class="h-64 mt-8"> <!-- or h-48, adjust as you like -->
                    <Line :data="chartData" :options="chartOptions" />
                </div>
            </div>

            <div class="p-8">
                <div class="flex">
                    <p class="stats flex gap-3 items-center">
                        <IconStrongArm />
                        4
                    </p>
                    <p class="subStats ml-1 self-end mb-2">/ 6 Workouts Done</p>
                </div>
                <p class="subheading font-bold">Weekly workout counter</p>


                <div class="h-64 mt-8"> <!-- or h-48, adjust as you like -->
                    <Line :data="chartData" :options="chartOptions" />
                </div>
            </div>

            <div class="p-8">
                <div class="flex">
                    <p class="stats flex gap-3 items-center">
                        <IconLightning />
                        4
                    </p>
                    <p class="subStats ml-1 self-end mb-2">/ Day Streak</p>
                </div>
                <p class="subheading font-bold">Weekly workouts logged</p>


                <div class="h-64 mt-8"> <!-- or h-48, adjust as you like -->
                    <Line :data="chartData" :options="chartOptions" />
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
    import ClockNoArrow from '@/components/icons/ClockNoArrow.vue';
    import IconDumbell from '@/components/icons/IconDumbell.vue';
    import IconStrongArm from '@/components/icons/IconStrongArm.vue';
    import IconLightning from '@/components/icons/IconLightning.vue';
    import { Line } from 'vue-chartjs'
    import {chartData, chartOptions} from '@/scripts/charts/lineChart.ts';
</script>
