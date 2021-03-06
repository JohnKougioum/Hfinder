import { createRouter, createWebHistory } from "vue-router";
import Index from "../views/Index";
import Buy from "../views/Buy";
import Rent from "../views/Rent";
import Login from "../components/Login";
import Register from "../components/Register";
import Newlisting from "../components/Newlisting";
import Editprofile from "../components/Editprofile";
import Dashboard from "../views/Dashboard";
import Editlisting from "../components/Editlisting";
import About_us from "../views/About_us";
import Covid19 from "../views/Covid19";
import Favourites from "../views/Favourites";
import Selectedlisting from "../components/Selectedlisting";
import PageNotFound from "../components/PageNotFound";
import AuthFunction from "../auth";
import Admindashboard from "../components/Admindashboard";
import Contact from '../components/Contact'
const routes = [
  {
    path: "/buy/:loc",
    name: "Buy",
    component: Buy,
    props: true,
  },
  {
    path: '/Contact',
    name: 'Contact',
    component: Contact
  },
  {
    path: "/Rent/:loc",
    name: "Rent",
    component: Rent,
    props: true,
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
    beforeEnter: (to, from, next) => {
      if (!AuthFunction.isAuthenticated())
        next((window.location.href = "http://localhost:8080/Login"));
      next();
    },
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
  {
    path: "/Editlisting/:id",
    name: "Editlisting",
    component: Editlisting,
    props: true,
  },
  {
    path: "/about_us",
    name: "About_us",
    component: About_us,
  },
  {
    path: "/covid19",
    name: "Covid19",
    component: Covid19,
  },
  {
    path: "/favourites",
    name: "Favourites",
    component: Favourites,
  },
  {
    path: "/Selectedlisting/:id",
    name: "Selectedlisting",
    component: Selectedlisting,
    props: true,
  },
  {
    path: "/:catchAll(.*)",
    name: "PageNotFound",
    component: PageNotFound,
  },
  {
    path: "/Admindashboard",
    name: "Admindashboard",
    component: Admindashboard,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
