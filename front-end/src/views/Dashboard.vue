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
    this.fetchOwnAdds(this.PageNumber);
  },
  methods: {
    ...mapActions(["fetchOwnAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      this.fetchOwnAdds(newValue);

      if (newValue == 1) {
        this.$router.push({ name: "Dashboard" });
        return;
      }
      this.$router.push({
        name: "Dashboard",
        query: { page: newValue },
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
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
