<template>
  <footer>
    <div class="footer-content">
      <div class="footer-content-left">
        <h2>Χρήσιμοι σύνδεσμοι</h2>
        <ul>
          <li><a href="/Newlisting">Καταχώρηση ιδιοκτησίας</a></li>
          <li><a href="#">Ιδιοκτησίες προς πώληση</a></li>
          <li><a href="#">Ιδιοκτησίες προς ενοικίαση</a></li>
        </ul>
      </div>
      <div class="footer-content-right">
        <h2>Hfinder</h2>
        <ul>
          <li><router-link to="/About_us">Σχετικά με εμάς</router-link></li>
          <li><router-link to="/Contact">Επικοινωνία</router-link></li>
        </ul>
      </div>
    </div>
  </footer>
</template>

<script>
export default {
  name: "Footer",
};
</script>

<style lang="scss">
.footer-content {
  margin-top: 10%;
  width: 100%;
  padding: 16px;
  display: flex;
  justify-content: space-between;
  font-size: 17px;

  li {
    list-style: none;
  }

  a {
    text-decoration: none;
  }

  .footer-content-left {
    margin-left: 14%;

    h2 {
      padding-bottom: 15px;
    }

    * {
      padding-bottom: 6px;
    }
  }

  .footer-content-right {
    margin-right: 14%;
    text-align: right;

    h2 {
      padding-bottom: 15px;
    }

    * {
      padding-bottom: 6px;
    }
  }
}

@media screen and (max-width: 620px) {
  .footer-content {
    font-size: 15px;
    flex-direction: column;
    justify-content: center;

    .footer-content-left {
      margin-left: 0%;
      text-align: center;
      margin-bottom: 20px;
    }

    .footer-content-right {
      margin-right: 0%;
      text-align: center;
    }
  }
}
</style>
