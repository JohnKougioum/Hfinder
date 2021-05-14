<template>
  <div class="acontainer-adds-results">
    <div
      :key="add.id"
      v-for="add in adds"
      @click="goToAdd(add.id)"
      class="acontainer-adds-results-card"
    >
      <Add :add="add" />
    </div>
  </div>
</template>

<script>
import Add from "./Add";

export default {
  name: "Adds",
  props: {
    adds: Array,
  },
  components: {
    Add,
  },
  methods: {
    goToAdd(id) {
      this.$router.push({ name: "Selectedlisting", params: { id: id } });
    },
  },
};
</script>
