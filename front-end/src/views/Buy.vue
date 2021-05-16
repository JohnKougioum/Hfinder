<template>
  <div class="acontainer">
    <div class="acontainer-filters">
      <Filters :filt="getAdds[0]" />
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
import Adds from "../components/Adds";
import Pagination from "../components/Pagination";
import Filters from "../components/Filters";
import axios from "axios";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "Buy",
  components: {
    Adds,
    Pagination,
    Filters,
  },
  props: {
    loc: {
      type: String,
    },
  },
  mounted() {},
  computed: {
    PageNumber() {
      return this.$store.getters.getPageNumber;
    },
    ...mapGetters(["getAdds"]),
  },
  created() {
    const addLocation = this.loc;
    const newValue = this.PageNumber;
    const path = this.$route.name;
    const bedrooms = this.$route.query.beds;
    const bathrooms = this.$route.query.baths;
    let startPrice = this.$route.query.startPrice;
    let endPrice = this.$route.query.endPrice;

    this.fetchAdds({
      newValue,
      addLocation,
      path,
      bedrooms,
      bathrooms,
      startPrice,
      endPrice,
    });
  },
  methods: {
    ...mapActions(["fetchAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      const addLocation = this.loc;
      const path = this.$route.name;

      let bedrooms = parseInt(this.$route.query.beds);
      let bathrooms = parseInt(this.$route.query.baths);
      let startPrice = parseInt(this.$route.query.startPrice);
      let endPrice = parseInt(this.$route.query.endPrice);
      if (isNaN(bedrooms)) bedrooms = 0;
      if (isNaN(bathrooms)) bathrooms = 0;
      if (isNaN(startPrice)) bathrooms = 0;
      if (isNaN(endPrice)) bathrooms = 0;

      this.fetchAdds({
        newValue,
        addLocation,
        path,
        bedrooms,
        bathrooms,
        startPrice,
        endPrice,
      });

      if (newValue == 1) {
        this.$router.push({
          name: "Buy",
          params: { loc: this.loc },
          query: {
            beds: this.getFilters2.beds,
            baths: this.getFilters2.baths,
            startPrice: this.getFilters2.startPrice,
            endPrice: this.getFilters2.endPrice,
          },
        });
        return;
      }
      this.$router.push({
        name: "Buy",
        params: { loc: this.loc },
        query: {
          page: newValue,
          beds: this.getFilters2.beds,
          baths: this.getFilters2.baths,
          startPrice: this.getFilters2.startPrice,
          endPrice: this.getFilters2.endPrice,
        },
      });
    },
    "$route.query.page": {
      immediate: true,
      handler(newVal) {
        if (this.$route.name != "Buy") return;
        if (newVal == null) newVal = 1;
        this.$store.commit("enterPageNumber", newVal);
      },
    },
    "$route.query": {
      immediate: true,
      handler(newVal) {
        const path = this.$route.name;
        if (path == "Buy") {
          const addLocation = this.$route.params.loc;
          const newValue = this.PageNumber;
          let bedrooms = parseInt(this.$route.query.beds);
          let bathrooms = parseInt(this.$route.query.baths);
          let startPrice = parseInt(this.$route.query.startPrice);
          let endPrice = parseInt(this.$route.query.endPrice);

          if (isNaN(bedrooms)) bedrooms = 0;
          if (isNaN(bathrooms)) bathrooms = 0;
          if (isNaN(startPrice)) startPrice = 0;
          if (isNaN(endPrice)) endPrice = 0;

          this.fetchAdds({
            newValue,
            addLocation,
            path,
            bedrooms,
            bathrooms,
            startPrice,
            endPrice,
          });
        }
      },
    },
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
