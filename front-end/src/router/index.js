import { createRouter, createWebHistory } from "vue-router";
import Index from "../views/Index";
import Buy from "../views/Buy";

const routes = [
  {
    path: "/buy",
    name: "Buy",
    component: Buy,
  },
  {
    path: "/",
    name: "Index",
    component: Index,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
