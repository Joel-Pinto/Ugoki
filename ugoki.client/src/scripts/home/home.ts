export class Home {
    constructor() {}

    // Placeholder data for stats
    getStats() {
        return {
            hoursTrained: { value: 12, increasePct: 15 },
            weightLifted: { value: 4500, increasePct: 10 }, // in kg or lbs, assuming kg
            workoutsDone: { value: 4, increasePct: 25 }
        };
    }

    // Placeholder for user name
    getUserName() {
        return "John Doe";
    }

    getTimeOfDayGreeting() {
        const hour = new Date().getHours();
        if (hour < 12) return "Good Morning";
        if (hour < 18) return "Good Afternoon";
        return "Good Evening";
    }

    // Placeholder for next workout
    getNextWorkout() {
        return { name: "Full Body Blast", date: "Tomorrow", duration: "45 min" };
    }

    // Placeholder for popular workouts
    getPopularWorkouts() {
        return [
            { name: "HIIT Cardio", popularity: "Top Rated" },
            { name: "Strength Training", popularity: "Popular" }
        ];
    }

    // Extra card: suggested workouts
    getSuggestedWorkouts() {
        return [
            { name: "Yoga Relaxation", reason: "Based on your pace" },
            { name: "Running Interval", reason: "High intensity" }
        ];
    }
}
