// scripts/home/useHome.ts
import { ref, onMounted } from "vue";
import api from "@/services/api";

export function home() {
    const users = ref<any[]>([]);
    const isLoading = ref(true);

    async function getUsers() {
        try {
            const response = await api.get("/users");
            users.value = response.data;
        } finally {
            isLoading.value = false;
        }
    }

    function getStats() {
        return {
            hoursTrained: { value: 12, increasePct: 15 },
            weightLifted: { value: 4500, increasePct: 10 },
            workoutsDone: { value: 4, increasePct: 25 },
        };
    }

    function getUserName() {
        return "John Doe";
    }

    function getTimeOfDayGreeting() {
        const hour = new Date().getHours();
        if (hour < 12) return "Good Morning";
        if (hour < 18) return "Good Afternoon";
        return "Good Evening";
    }

    function getNextWorkout() {
        return { name: "Full Body Blast", date: "Tomorrow", duration: "45 min" };
    }

    function getPopularWorkouts() {
        return [
            { name: "HIIT Cardio", popularity: "Top Rated" },
            { name: "Strength Training", popularity: "Popular" },
        ];
    }

    function getSuggestedWorkouts() {
        return [
            { name: "Yoga Relaxation", reason: "Based on your pace" },
            { name: "Running Interval", reason: "High intensity" },
        ];
    }

    onMounted(() => {
        getUsers();
    });

    return {
        users,
        isLoading,
        getUsers,
        getStats,
        getUserName,
        getTimeOfDayGreeting,
        getNextWorkout,
        getPopularWorkouts,
        getSuggestedWorkouts,
    };
}
