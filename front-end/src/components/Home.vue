<template>
  <div>
    <section class="hero">
      <div class="hero-section">
        <img src="../assets/images/homebg-1.jpg" alt="" />

        <div class="hero-section_area">
          <div class="hero-section_area-title">
            <h1>
              Discover a place <br />
              you'll love to live
            </h1>
          </div>

          <div class="hero-section_area-search">
            <input
              id="search_input"
              placeholder="Αναζήτηση τοποθεσίας"
              type="text"
              v-model="location"
            />
            <div class="hero-section_area-search_btn" @click="searchLoc">
              <div class="hero-section_area-search_btn-img">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                >
                  <path
                    d="M23.809 21.646l-6.205-6.205c1.167-1.605 1.857-3.579 1.857-5.711 0-5.365-4.365-9.73-9.731-9.73-5.365 0-9.73 4.365-9.73 9.73 0 5.366 4.365 9.73 9.73 9.73 2.034 0 3.923-.627 5.487-1.698l6.238 6.238 2.354-2.354zm-20.955-11.916c0-3.792 3.085-6.877 6.877-6.877s6.877 3.085 6.877 6.877-3.085 6.877-6.877 6.877c-3.793 0-6.877-3.085-6.877-6.877z"
                  />
                </svg>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section class="main">
      <div class="progressbar">
        <div class="progessbar-wrapper">
          <div class="progressbar-container">
            <div class="progressbar-container-text"><h3>Αναζήτηση</h3></div>
            <div class="progressbar-container-circle" id="first_circle">
              <span class="progressbar-container-circle-line"></span>
            </div>
          </div>
          <div class="progressbar-container">
            <div class="progressbar-container-text">
              <h3>Έλεγχος λεπτομεριών</h3>
            </div>
            <div class="progressbar-container-circle" id="second_circle">
              <span class="progressbar-container-circle-line"></span>
            </div>
          </div>
          <div class="progressbar-container">
            <div class="progressbar-container-text"><h3>Ολοκλήρωση</h3></div>
            <div class="progressbar-container-circle"></div>
          </div>
        </div>
      </div>

      <div class="covid-banner">
        <div class="covid-banner-content">
          <div class="covid-banner-content-wrapper">
            <div class="covid-banner-content-wrapper-logo">
              <h1>Hfinder Logo</h1>
            </div>
            <div class="covid-banner-content-wrapper-details">
              <p>
                Πώς ανταποκρίνεται το Hfinder στον COVID-19
                <router-link to="/Covid19">Λεπτομέρειες</router-link>
              </p>
            </div>
          </div>
        </div>
      </div>

      <div class="wrapper">
        <div class="wrapper-container">
          <div class="wrapper-container-icon">
            <img src="../assets/images/Home-Sale.svg" alt="Sale House" />
          </div>

          <div class="wrapper-container-content">
            <h2>Πώληση ιδιοκτησίας</h2>
            <p>
              Το Hfinder απλοποιεί και καθιστά ασφαλέστερη την πώληση της
              ιδιοκτησίας σας
            </p>
            <a href="#">Πώληση</a>
          </div>
        </div>
        <div class="wrapper-container">
          <div class="wrapper-container-icon">
            <img src="../assets/images/buy.svg" alt="Buy House" />
          </div>

          <div class="wrapper-container-content">
            <h2>Αγορά κατοικίας</h2>
            <p>
              Το Hfinder απλοποιεί και καθιστά ασφαλέστερη την πώληση της
              ιδιοκτησίας σας
            </p>
            <a href="#">Αγορά</a>
          </div>
        </div>

        <div class="wrapper-container">
          <div class="wrapper-container-icon">
            <img src="../assets/images/Home-Rent.svg" alt="House Rent" />
          </div>

          <div class="wrapper-container-content">
            <h2>Ενοικίαση κατοικίας</h2>
            <p>
              Το Hfinder απλοποιεί και καθιστά ασφαλέστερη την πώληση της
              ιδιοκτησίας σας
            </p>
            <a href="#">Ενοικίαση</a>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      location: "",
    };
  },
  methods: {
    searchLoc() {
      this.$router.push({ name: "Buy", params: { loc: this.location } });
    },
  },
};
</script>

<style scoped>
@import "../assets/css//home/home.css";
</style>
