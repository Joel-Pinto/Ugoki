<style src="../assets/css/home/home.css"></style>

<template>
    <div class="home-container">
        <div class="header-section">
            <div class="user-name-card">
                <h2>{{ homeInstance.getTimeOfDayGreeting() }}, {{ homeInstance.getUserName() }}!</h2>
                <p>Ready for your next workout?</p>
            </div>
        </div>

        <div class="stats-section">
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Hours Trained This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ homeInstance.getStats().hoursTrained.value }}h</div>
                <div class="stat-increase">+{{ homeInstance.getStats().hoursTrained.increasePct }}% vs last week</div>
            </div>
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Total Weight Lifted This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ homeInstance.getStats().weightLifted.value }}kg</div>
                <div class="stat-increase">+{{ homeInstance.getStats().weightLifted.increasePct }}% vs last week</div>
            </div>
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Workouts Done This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ homeInstance.getStats().workoutsDone.value }}</div>
                <div class="stat-increase">+{{ homeInstance.getStats().workoutsDone.increasePct }}% vs last week</div>
            </div>
        </div>

        <div class="cards-section">
            <div class="workout-card">
                <h3>Next Workout</h3>
                <div class="card-content">
                    <p><strong>{{ homeInstance.getNextWorkout().name }}</strong></p>
                    <p>{{ homeInstance.getNextWorkout().date }} • {{ homeInstance.getNextWorkout().duration }}</p>
                </div>
                <button class="card-button">Start Workout</button>
            </div>
            <div class="workout-card">
                <h3>Popular Workouts</h3>
                <div class="card-content">
                    <ul>
                        <li v-for="workout in homeInstance.getPopularWorkouts()" :key="workout.name">
                            {{ workout.name }} - {{ workout.popularity }}
                        </li>
                    </ul>
                </div>
                <button class="card-button">View All</button>
            </div>
            <div class="workout-card">
                <h3>Suggested Workouts</h3>
                <div class="card-content">
                    <ul>
                        <li v-for="workout in homeInstance.getSuggestedWorkouts()" :key="workout.name">
                            {{ workout.name }} - {{ workout.reason }}
                        </li>
                    </ul>
                </div>
                <button class="card-button">Explore More</button>
            </div>
                <div class="workout-card">
                <h1> Users </h1>
                <ul v-if="homeInstance.isLoading.value">
                    Loading users...
                </ul>
                <ul v-else> 
                    <li v-for="user in homeInstance.users.value" :key="user.id">
                        <p>{{ user.username }}</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
    import { home } from '../scripts/views/home.ts';
    const homeInstance = home();
</script>
