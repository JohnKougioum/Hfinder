<template>
  <div class="acontainer">
    <div class="acontainer-filters"></div>
    <div class="acontainer-adds">
      <div class="pagination">
        <Adds :adds="getAdds" />

        <Pagination :totalItems="10" />
      </div>
    </div>
  </div>
</template>

<script>
import Adds from "../components/Adds";
import Pagination from "../components/Pagination";
import axios from "axios";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "Buy",
  components: {
    Adds,
    Pagination,
  },
  data() {
    return {
      adds: [],
    };
  },
  mounted() {},
  computed: {
    PageNumber() {
      return this.$store.getters.getPageNumber;
    },
    ...mapGetters(["getAdds"]),
  },
  created() {
    this.fetchAdds(this.PageNumber);
  },
  methods: {
    ...mapActions(["fetchAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      this.$store.dispatch("fetchAdds", newValue);

      if (newValue == 1) {
        this.$router.push({ name: "Buy" });
        return;
      }
      this.$router.push({
        name: "Buy",
        query: { page: newValue },
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
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
