<style src="@/assets/css/home/home.css"></style>

<template>
   <aside v-if="!layoutComponent">
        <h3 class="menu-title">Ugoki</h3>
        <nav>
            <ul >
                
                <li class="active" >
                    <a href="#" >
                        <CircleDashed />
                        <span>Dashboard</span>
                    </a>
                    <a href="#">
                        <i class='bx bx-dumbbell'></i> 
                        <span>Training</span>
                    </a>
                    <a href="#">
                        <i class='bx bx-trending-up' ></i> 
                        <span>Progress</span>
                    </a>
                    <a href="#">
                        <i class='bx bxs-hourglass'  ></i> 
                        <span>Comming Soon</span>
                    </a>
                </li>
    
                <li >
                    <a href="#">
                        <i class='bx  bx-cog'></i>
                        <span >Settings</span>
                    </a>
                    <a href="#">
                        <i class='bx  bx-door-open' ></i> 
                        <span >Logout</span>
                    </a>
                </li>
            </ul>
        </nav>
   </aside> 
</template>

<script lang="ts">

import CircleDashed from '../icons/CircleDashed.vue';
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const showSidebar = computed(() => !route.meta.hideSideBar)

export default {
    name: 'sideBar',
    components: {
        CircleDashed
    },
    computed: {
        layoutComponent() {
            const hideSideBar = this.$route.meta.hideSideBar;
            return hideSideBar;
        }
    }
}
</script>