<template>
  <div>
    <div class="pagination-row">
      <button
        v-if="pageNumber >= 2"
        class="pagination-button first"
        :disabled="pageNumber <= 1"
        @click="$store.commit('resetPageNumber')"
      >
        &lt; &lt;
      </button>
      <button
        v-if="pageNumber >= 2"
        class="pagination-button"
        :disabled="pageNumber <= 1"
        @click="$store.commit('prevPage')"
      >
        &lt;
      </button>
      <li class="pagination-btn">
        <span>{{ pageNumber }}</span>
      </li>
      <li class="pagination-mid">
        of
      </li>
      <li class="pagination-btn">
        <span class="asd">{{ numberPages }}</span>
      </li>

      <button
        v-if="pageNumber <= numberPages - 1"
        class="pagination-button"
        :disabled="pageNumber >= numberPages"
        @click="$store.commit('nextPage')"
      >
        &gt;
      </button>
      <button
        v-if="pageNumber <= numberPages - 1"
        class="pagination-button last"
        :disabled="pageNumber >= numberPages"
        @click="$store.commit('clickPage', numberPages - 1)"
      >
        &gt;&gt;
      </button>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      perPage: 4,
    };
  },
  computed: {
    numberPages() {
      return Math.ceil(this.totalItems / this.perPage);
    },
    pageNumber() {
      return this.$store.getters.getPageNumber;
    },
  },
  props: {
    totalItems: {
      type: Number,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
li {
  list-style: none;
}
a {
  text-decoration: none;
}

.first,
.last {
  letter-spacing: -3px;
}

.pagination-button {
  padding: 8px;
  margin: 2px;
  border-radius: 3px;
  font-size: 1.4em;
  cursor: pointer;
  background-color: white;
  border: none;
  user-select: none;
}

.pagination-btn {
  padding: 8px;
  margin: 2px;
  width: 40px;
  height: 40px;
  border-radius: 50%;
  border: none;
  font-size: 1em;
  cursor: auto;
  background-color: #a0a0a0be;
  position: relative;
  span {
    color: white;
    text-align: center;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
  }
}

.pagination-mid {
  padding: 8px 2px 8px 2px;
  margin: 2px;
  font-size: 1.2em;
}

.pagination-row {
  display: flex;
  justify-content: center;
}

.active {
  background-color: #0080ff;
  color: white;
}

:disabled {
  cursor: auto;
}
</style>
