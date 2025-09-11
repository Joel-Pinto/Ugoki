// This is an example of a simple composable function that can be reused across components.

import { ref } from 'vue';

export default function useCounter(intialValue: number = 0) {
    const count = ref(intialValue);

    // functions to modify the count
    const increment = () => count.value++;
    const decrement = () => count.value--;
    const reset = () => count.value = intialValue;

    return { 
        count, 
        increment, 
        decrement, 
        reset 
    };
}