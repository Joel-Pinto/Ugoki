import { ref, onMounted } from 'vue'
import { Line } from 'vue-chartjs'
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  LineElement,
  CategoryScale,
  LinearScale,
  PointElement,
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, LineElement, CategoryScale, LinearScale, PointElement)

export const chartData = ref({
  labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
  datasets: [
    {
      data: [65, 59, 80, 81, 56],
      borderColor: '#4CAF50',
      tension: 0.3
    },
    {
      data: [45, 39, 70, 41, 66],
      borderColor: '#fa5060',
      tension: 0.3
    }
  ]
})

export const chartOptions = ref({
  responsive: true,
  maintainAspectRatio: false,
  plugins:{
    legend: {
        display: false
    }
  },
   scales: {
    x: {
      grid: {
        display: false 
      },
      ticks: {
        display: false 
      },
    },
    y: {
      grid: {
        display: false 
      },
      ticks: {
        display: false 
      },
      border: {
        display: false 
      }
    }
  }
})
