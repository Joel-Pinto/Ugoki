<style src="../assets/css/home/home.css"></style>

<template>
    <div class="home-container">
        <div class="header-section">
            <div class="user-name-card">
                <h2>{{ home.getTimeOfDayGreeting() }}, {{ home.getUserName() }}!</h2>
                <p>Ready for your next workout?</p>
            </div>
        </div>

        <div class="stats-section">
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Hours Trained This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ home.getStats().hoursTrained.value }}h</div>
                <div class="stat-increase">+{{ home.getStats().hoursTrained.increasePct }}% vs last week</div>
            </div>
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Total Weight Lifted This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ home.getStats().weightLifted.value }}kg</div>
                <div class="stat-increase">+{{ home.getStats().weightLifted.increasePct }}% vs last week</div>
            </div>
            <div class="stat-card">
                <div class="stat-header">
                    <span class="stat-label">Workouts Done This Week</span>
                    <i class='bx bx-trending-up green-arrow'></i>
                </div>
                <div class="stat-value">{{ home.getStats().workoutsDone.value }}</div>
                <div class="stat-increase">+{{ home.getStats().workoutsDone.increasePct }}% vs last week</div>
            </div>
        </div>

        <div class="cards-section">
            <div class="workout-card">
                <h3>Next Workout</h3>
                <div class="card-content">
                    <p><strong>{{ home.getNextWorkout().name }}</strong></p>
                    <p>{{ home.getNextWorkout().date }} • {{ home.getNextWorkout().duration }}</p>
                </div>
                <button class="card-button">Start Workout</button>
            </div>
            <div class="workout-card">
                <h3>Popular Workouts</h3>
                <div class="card-content">
                    <ul>
                        <li v-for="workout in home.getPopularWorkouts()" :key="workout.name">
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
                        <li v-for="workout in home.getSuggestedWorkouts()" :key="workout.name">
                            {{ workout.name }} - {{ workout.reason }}
                        </li>
                    </ul>
                </div>
                <button class="card-button">Explore More</button>
            </div>

            <div class="workout-card">
                <h1> Users </h1>
                <ul>
                    <li v-for="user in home.getUsers()" :key="user.id">
                        <p>{{ user }}</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
    import { Home } from '../scripts/home/home.ts';
    const home = new Home();
</script>
