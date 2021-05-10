<template>
  <div class="acontainer">
    <div class="acontainer-filters"></div>
    <div class="acontainer-adds">
      <div class="pagination">
        <Adds :adds="getAdds" />

        <Pagination :totalItems="5" />
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
  mounted() {
    if (this.$store.getters.getPageNumber != this.$route.query.page)
      this.$store.commit("enterPageNumber", this.$route.query.page || 1);
  },
  computed: {
    PageNumber() {
      return this.$store.getters.getPageNumber;
    },
    ...mapGetters(["getAdds"]),
  },
  created() {
    this.fetchAdds();
  },
  methods: {
    ...mapActions(["fetchAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      if (newValue == 1) {
        this.$router.push({ name: "Buy" });
        return;
      }
      this.$router.push({
        name: "Buy",
        query: { page: newValue },
      });
    },
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
