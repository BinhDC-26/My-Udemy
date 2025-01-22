import { createRouter, createWebHistory } from 'vue-router';

import HomeView from '@/views/HomeView.vue';
import JobResultsView from '@/views/JobResultsView.vue';
import JobView from '@/views/JobView.vue';
import SlotDemo from '@/views/SlotParent.vue';
// Demo pinia: actions, states
// import { useAppStore } from '@/stores/app-store';
// const appStore = useAppStore();

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView,
  },
  {
    path: '/slot',
    name: 'Slot',
    component: SlotDemo,
  },
  {
    path: '/jobs/results',
    name: 'JobResults',
    component: JobResultsView,
  },
  {
    path: '/jobs/results/:id',
    name: 'JobListing',
    component: JobView,
    //Demo Route-Specific Navigation Guards (Hook dành riêng cho route)
    beforeEnter: (to, from, next) => {
      if (to.params.id === '1' || to.params.id === '2') {
        next(); // Tiếp tục điều hướng đến trang job listing
      } else {
        next({ name: 'Home' }); // Chuyển hướng đến trang home
      }
    },
  },
];

const router = createRouter({
  // history: createWebHashHistory(),
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  console.log(`Global beforeEach hook: ${to.name} -> ${from.name}`)
  next()
});

router.beforeResolve((to, from, next) => {
  console.log(`Global beforeResolve hook: ${to.name} -> ${from.name}`)
  next()
});

router.afterEach((to, from) => {
  console.log(`Global afterEach hook: ${to.name} -> ${from.name}`)
});

export default router;
