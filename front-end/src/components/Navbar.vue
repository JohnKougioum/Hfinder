<template>
  <header>
    <nav>
      <div class="logo">
        <!-- <h4>Hfind</h4> -->
        <router-link to="/">Hfinder</router-link>
      </div>
      <ul class="nav-links">
        <li>
          <a href="#">Νέα Αγγελία</a>
        </li>
        <li>
          <router-link to="/buy">Αγορά</router-link>
        </li>
        <li>
          <a href="#">Ενοικίαση</a>
        </li>
        <li>
          <router-link to="/" class="login-btn">Σύνδεση</router-link>
        </li>
        <li>
          <router-link to="/" class="register-btn">Εγγραφή</router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script>
export default {
  name: "Navbar",
};
</script>

<style lang="scss" scoped>
$main-dark: #343434;

header {
  position: fixed;
  width: 100%;
  z-index: 1000;
}

nav {
  margin-left: -5%;
  margin-right: -6%;
  display: flex;
  justify-content: space-around;
  align-items: center;
  min-height: 10vh;
  background-color: #fff;
  border-bottom: 1px solid $main-dark;

  .logo {
    letter-spacing: 3px;
    font-size: 22px;
  }

  ul {
    display: flex;
    justify-content: space-around;
    width: 35%;
  }

  li {
    list-style: none;
    align-self: center;
    .login-btn {
      display: block;
      border: 2px solid #0080ff;
      padding: 7px;
      border-radius: 8px;
      transition: 0.15s ease-in-out;
    }

    .login-btn:hover {
      background-color: rgb(243, 242, 242);
    }

    .register-btn {
      display: block;
      padding: 7px;
      border-radius: 10px;
      border: 2px solid #0080ff;
      background-color: #0080ff;
      color: white;
      transition: 0.15s ease-in-out;
    }
    .register-btn:hover {
      background-color: #0369cf;
      border-color: #0369cf;
    }
  }

  a {
    text-decoration: none;
    letter-spacing: 2px;
    font-weight: bold;
    cursor: pointer;
    font-size: 15px;
  }
}
</style>
