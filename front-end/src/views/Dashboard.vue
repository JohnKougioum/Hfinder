<template>
  <div class="acontainer">
    <div class="acontainer-filters"></div>
    <div class="acontainer-adds">
      <div class="pagination">
        <OwnAdds :adds="getAdds" />

        <Pagination :totalItems="5" />
      </div>
    </div>
  </div>
</template>

<script>
import OwnAdds from "../components/OwnAdds";
import Pagination from "../components/Pagination";
import axios from "axios";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "Dashboard",
  components: {
    OwnAdds,
    Pagination,
  },
  data() {
    return {
      adds: [],
    };
  },
  computed: {
    ...mapGetters(["getAdds"]),
  },
  created() {
    this.fetchOwnAdds();
  },
  methods: {
    ...mapActions(["fetchOwnAdds"]),
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
