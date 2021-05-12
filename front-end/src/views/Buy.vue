<template>
  <div class="acontainer">
    <div class="acontainer-filters"></div>
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
import axios from "axios";
import { mapActions, mapGetters } from "vuex";

export default {
  name: "Buy",
  components: {
    Adds,
    Pagination,
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
    this.fetchAdds({ newValue, addLocation });
  },
  methods: {
    ...mapActions(["fetchAdds"]),
  },
  watch: {
    PageNumber(newValue, oldValue) {
      const addLocation = this.loc;
      this.fetchAdds({ newValue, addLocation });

      if (newValue == 1) {
        this.$router.push({ name: "Buy", params: { loc: this.loc } });
        return;
      }
      this.$router.push({
        name: "Buy",
        params: { loc: this.loc },
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
