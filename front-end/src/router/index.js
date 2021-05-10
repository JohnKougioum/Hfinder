import { createRouter, createWebHistory } from "vue-router";
import Index from "../views/Index";
import Buy from "../views/Buy";
import Login from "../components/Login";
import Register from "../components/Register";
import Newlisting from "../components/Newlisting";
import Editprofile from "../components/Editprofile";
import Dashboard from "../views/Dashboard";

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
  {
    path: "/Login",
    name: "Login",
    component: Login,
  },
  {
    path: "/Register",
    name: "Register",
    component: Register,
  },
  {
    path: "/Newlisting",
    name: "Newlisting",
    component: Newlisting,
  },
  {
    path: "/Editprofile",
    name: "Editprofile",
    component: Editprofile,
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
