<template>
  <div class="acontainer">
    <div class="acontainer-filters">
      <Filters />
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
  name: "Rent",
  components: {
    Adds,
    Pagination,
    Filters,
  },
  props: {
    loc: {
      type: String,
    },
    asd: {
      type: String,
    },
  },
  mounted() {},
  computed: {
    PageNumber() {
      return this.$store.getters.getPageNumber;
    },
    ...mapGetters(["getAdds"]),
    ...mapGetters(["getFilters2"]),
  },
  created() {
    const addLocation = this.loc;
    const newValue = this.PageNumber;
    const path = this.$route.name;
    const bedrooms = this.$route.query.beds;
    const bathrooms = this.$route.query.baths;

    this.fetchAdds({ newValue, addLocation, path, bedrooms, bathrooms });
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

      if (isNaN(bedrooms)) bedrooms = 0;
      if (isNaN(bathrooms)) bathrooms = 0;

      this.fetchAdds({ newValue, addLocation, path, bedrooms, bathrooms });

      if (newValue == 1) {
        this.$router.push({
          name: "Rent",
          params: { loc: this.loc },
          query: { beds: this.getFilters2.beds, baths: this.getFilters2.baths },
        });
        return;
      }
      this.$router.push({
        name: "Rent",
        params: { loc: this.loc },
        query: {
          page: newValue,
          beds: this.getFilters2.beds,
          baths: this.getFilters2.baths,
        },
      });
    },
    "$route.query.page": {
      immediate: true,
      handler(newVal) {
        if (this.$route.name != "Rent") return;
        if (newVal == null) newVal = 1;
        this.$store.commit("enterPageNumber", newVal);
      },
    },
    "$route.query": {
      immediate: true,
      handler(newVal) {
        const addLocation = this.$route.params.loc;
        const newValue = this.PageNumber;
        const path = this.$route.name;
        let bedrooms = parseInt(this.$route.query.beds);
        let bathrooms = parseInt(this.$route.query.baths);

        if (isNaN(bedrooms)) bedrooms = 0;
        if (isNaN(bathrooms)) bathrooms = 0;

        this.fetchAdds({ newValue, addLocation, path, bedrooms, bathrooms });
      },
    },
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
