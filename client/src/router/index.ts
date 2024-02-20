import { createWebHistory, createRouter } from 'vue-router';
import Home from '@/views/home/index.vue';
import NotFound from '@/views/not-found/index.vue';

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/404",
    name: "NotFound",
    component: NotFound,
  },
  {
    path: "/:catchAll(.*)",
    redirect: "/404",
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;