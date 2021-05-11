<template>
  <div class="acontainer-adds-results">
    <div :key="add.id" v-for="add in adds" class="acontainer-adds-results-card">
      <Add :add="add" />
      <div class="acontainer-adds-results-card-controls">
        <button
          @click="deleteAdd(add.id)"
          class="acontainer-adds-results-card-controls-delete"
        >
          Διαγραφή
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import Add from "./Add";
import axios from "axios";
import { mapActions } from "vuex";

export default {
  name: "Adds",
  props: {
    adds: Array,
  },
  components: {
    Add,
  },
  methods: {
    // deleteAdd(id) {
    //   console.log(id);
    // },
    ...mapActions(["deleteAdd"]),
  },
};
</script>
