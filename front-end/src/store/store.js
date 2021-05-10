import axios from "axios";
import { createStore } from "vuex";

export const store = createStore({
  state: {
    pageNumber: 1,
    adds: [],
  },
  mutations: {
    prevPage(state) {
      state.pageNumber--;
    },
    nextPage(state) {
      state.pageNumber++;
    },
    clickPage(state, payload) {
      state.pageNumber = payload + 1;
    },
    resetPageNumber(state) {
      state.pageNumber = 1;
    },
    enterPageNumber(state, payload) {
      state.pageNumber = payload;
    },
    setAdds: (state, adds) => (state.adds = adds),
    removeAdd: (state, id) =>
      (state.adds = state.adds.filter((add) => add.id !== id)),
  },
  actions: {
    async fetchOwnAdds({ commit }) {
      const response = await axios.get("https://localhost:5001/Houses/");

      commit("setAdds", response.data);
    },
    async fetchAdds({ commit }) {
      const response = await axios.get("https://localhost:5001/Houses/");

      commit("setAdds", response.data);
    },
    async deleteAdd({ commit }, id) {
      var warn = confirm(
        "Είστε σίγουροι ότι θέλεται να διαγράψεται αυτήν την αγγελία"
      );
      if (warn != true) return;

      await axios.delete(`https://localhost:5001/Houses/${id}`);

      commit("removeAdd", id);
    },
  },
  modules: {},
  getters: {
    getPageNumber: (state) => state.pageNumber,
    getAdds: (state) => state.adds,
  },
});
