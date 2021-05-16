<template>
  <div class="acontainer">
    <div class="acontainer-filters">
      <Filters />
    </div>
    <div class="acontainer-adds">
      <div class="pagination">
        <OwnAdds :adds="getAdds" />

        <Pagination :totalItems="10" />
      </div>
    </div>
  </div>
</template>

<script>
import OwnAdds from "../components/OwnAdds";
import Pagination from "../components/Pagination";
import Filters from "../components/Filters";
import axios from "axios";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "Dashboard",
  components: {
    OwnAdds,
    Pagination,
    Filters,
  },
  data() {
    return {
      adds: [],
    };
  },
  computed: {
    ...mapGetters(["getAdds"]),
    PageNumber() {
      return this.$store.getters.getPageNumber;
    },
  },
  created() {
    let token = localStorage.getItem("authToken");

    var base64Url = token.split(".")[1];
    var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
    var jsonPayload = decodeURIComponent(
      atob(base64)
        .split("")
        .map(function(c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );

    const user = JSON.parse(jsonPayload).sub;
    const page = this.PageNumber;

    const location = this.$route.query.location;
    const sellrent = this.$route.query.sellrent;
    const bedrooms = this.$route.query.beds;
    const bathrooms = this.$route.query.baths;
    let startPrice = parseInt(this.$route.query.startPrice);
    let endPrice = parseInt(this.$route.query.endPrice);
    let startSm = parseInt(this.$route.query.startSm);
    let endSm = parseInt(this.$route.query.endSm);

    if (isNaN(startPrice)) startPrice = 0;
    if (isNaN(endPrice)) endPrice = 0;
    if (isNaN(startSm)) startSm = 0;
    if (isNaN(endSm)) endSm = 0;

    this.fetchOwnAdds({
      page,
      user,
      location,
      sellrent,
      bedrooms,
      bathrooms,
      startPrice,
      endPrice,
      startSm,
      endSm,
    });
  },
  methods: {
    ...mapActions(["fetchOwnAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      let token = localStorage.getItem("authToken");

      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map(function(c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      const user = JSON.parse(jsonPayload).sub;
      const page = newValue;
      const location = this.$route.query.location;
      const sellrent = this.$route.query.sellrent;
      let bedrooms = parseInt(this.$route.query.beds);
      let bathrooms = parseInt(this.$route.query.baths);
      let startPrice = parseInt(this.$route.query.startPrice);
      let endPrice = parseInt(this.$route.query.endPrice);
      let startSm = parseInt(this.$route.query.startSm);
      let endSm = parseInt(this.$route.query.endSm);

      if (isNaN(bedrooms)) bedrooms = 0;
      if (isNaN(bathrooms)) bathrooms = 0;
      if (isNaN(startPrice)) startPrice = 0;
      if (isNaN(endPrice)) endPrice = 0;
      if (isNaN(startSm)) startSm = 0;
      if (isNaN(endSm)) endSm = 0;

      this.fetchOwnAdds({
        page,
        user,
        location,
        sellrent,
        bedrooms,
        bathrooms,
        startPrice,
        endPrice,
        startSm,
        endSm,
      });

      if (newValue == 1) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: location,
            sellrent: sellrent,
            beds: bedrooms,
            baths: bathrooms,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        });
        return;
      }
      this.$router.push({
        name: "Dashboard",
        query: {
          page: newValue,
          location: location,
          sellrent: sellrent,
          beds: bedrooms,
          baths: bathrooms,
          startPrice: startPrice,
          endPrice: endPrice,
          startSm: startSm,
          endSm: endSm,
        },
      });
    },
    "$route.query.page": {
      immediate: true,
      handler(newVal) {
        if (this.$route.name != "Dashboard") return;
        if (newVal == null) newVal = 1;
        this.$store.commit("enterPageNumber", newVal);
      },
    },
    "$route.query": {
      immediate: true,
      handler(newVal) {
        let token = localStorage.getItem("authToken");

        var base64Url = token.split(".")[1];
        var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
        var jsonPayload = decodeURIComponent(
          atob(base64)
            .split("")
            .map(function(c) {
              return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
            })
            .join("")
        );

        const user = JSON.parse(jsonPayload).sub;
        const page = this.PageNumber;
        const location = this.$route.query.location;
        const sellrent = this.$route.query.sellrent;
        let bedrooms = parseInt(this.$route.query.beds);
        let bathrooms = parseInt(this.$route.query.baths);
        let startPrice = parseInt(this.$route.query.startPrice);
        let endPrice = parseInt(this.$route.query.endPrice);
        let startSm = parseInt(this.$route.query.startSm);
        let endSm = parseInt(this.$route.query.endSm);

        if (isNaN(bedrooms)) bedrooms = 0;
        if (isNaN(bathrooms)) bathrooms = 0;
        if (isNaN(startPrice)) startPrice = 0;
        if (isNaN(endPrice)) endPrice = 0;
        if (isNaN(startSm)) startSm = 0;
        if (isNaN(endSm)) endSm = 0;

        this.fetchOwnAdds({
          page,
          user,
          location,
          sellrent,
          bedrooms,
          bathrooms,
          startPrice,
          endPrice,
          startSm,
          endSm,
        });
      },
    },
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
