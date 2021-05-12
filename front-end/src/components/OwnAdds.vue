<template>
  <div class="acontainer-adds-results">
    <div :key="add.id" v-for="add in adds" class="acontainer-adds-results-card">
      <Add :add="add" />
      <div class="acontainer-adds-results-card-controls">
        <button
          @click="gotoEdit(add.id)"
          class="acontainer-adds-results-card-controls-edit"
        >
          Επεξεργασία
        </button>
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
    ...mapActions(["deleteAdd"]),
    gotoEdit(id) {
      this.$router.push({ name: "Editlisting", params: { id: id } });
    },
  },
};
</script>
