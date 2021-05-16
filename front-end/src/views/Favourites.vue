<template>
  <!--  <div class="acontainer">
    <div class="acontainer-filters"></div> 
    <div class="acontainer-adds">
      <h1>Αγαπημένα </h1>
      <div class="hero-section_area-search">
            <input
              id="search_input"
              placeholder="Αναζήτηση τοποθεσίας"
              type="text"
            />
            <div class="hero-section_area-search_btn">
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
      <Adds :adds="adds" />
      <Pagination :totalItems="5" />
    </div>
  </div> -->

  <div class="acontainer">
    <div class="acontainer-filters">
      <Filters :reg="loc" />
    </div>
    <div class="acontainer-adds">
      <div class="pagination">
        <h2>Showing adds for "{{ loc }}"</h2>
        <Adds :adds="getAdds" />

        <Pagination :totalItems="7" />
      </div>
    </div>
  </div>
</template>

<script>
import Adds from "../components/FavAdds";
import Pagination from "../components/Pagination";
import Filters from "../components/Filters";
import { mapActions, mapGetters } from "vuex";
export default {
  name: "Favourites",
  components: {
    Adds,
    Pagination,
    Filters,
  },
  // data() {
  //   return {
  //     adds: [],
  //   };
  props: {
    loc: {
      type: String,
    },
  },
  created() {
    const addLocation = this.loc;
    const newValue = this.PageNumber;
    const path = this.$route.name;
    this.fetchAdds({ newValue, addLocation, path });
  },
  methods: {
    ...mapActions(["fetchAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      const addLocation = this.loc;
      this.fetchAdds({ newValue, addLocation });
      if (newValue == 1) {
        this.$router.push({ name: "Favourites", params: { loc: this.loc } });
        return;
      }
      this.$router.push({
        name: "Favourites",
        params: { loc: this.loc },
        query: { page: newValue },
      });
    },
    "$route.query.page": {
      immediate: true,
      handler(newVal) {
        if (this.$route.name != "Favourites") return;
        if (newVal == null) newVal = 1;
        this.$store.commit("enterPageNumber", newVal);
      },
    },
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
.hero-section_area-search {
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  margin-top: 0%;
  margin-left: 55%;
}
.hero-section_area-search #search_input {
  width: 50%;
  height: 30px;
  border-radius: 5px;
  border: solid black;
  outline: none;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  padding: 20px;
  font-size: 16px;
  border-top-right-radius: 0px;
  border-bottom-right-radius: 0px;
}
.hero-section_area-search .hero-section_area-search_btn {
  width: 10%;
  background-color: grey;
  border-radius: 5px;
  border-top-left-radius: 0px;
  border-bottom-left-radius: 0px;
  border-left: 3px solid #343434;
  cursor: pointer;
  border: black solid;
}
.hero-section_area-search
  .hero-section_area-search_btn
  .hero-section_area-search_btn-img {
  width: 50%;
  position: relative;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}
.hero-section_area-search
  .hero-section_area-search_btn
  .hero-section_area-search_btn-img
  svg {
  width: 90%;
  fill: white;
  -webkit-transition: 0.2s ease-in-out;
  transition: 0.2s ease-in-out;
}
.hero-section_area-search .hero-section_area-search_btn:hover svg {
  width: 100%;
  fill: black;
}
</style>
