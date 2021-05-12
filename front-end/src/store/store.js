import axios from "axios";
import { createStore } from "vuex";

export const store = createStore({
  state: {
    pageNumber: 1,
    adds: [],
    editAdd: [],
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
    setEditAdd: (state, editAdd) => (state.editAdd = editAdd),
  },
  actions: {
    async fetchOwnAdds({ commit }, pageNumber) {
      const response = await axios.get("https://localhost:5001/Houses/", {
        params: {
          page: pageNumber,
        },
      });

      commit("setAdds", response.data);
    },
    // async fetchAdds({ commit }, pageNumber) {
    //   const response = await axios.get("https://localhost:5001/Houses", {
    //     params: {
    //       page: pageNumber,
    //     },
    //   });

    //   commit("setAdds", response.data);
    // },
    async fetchAdds({ commit }, { newValue, addLocation }) {
      const response = await axios.get(
        `https://localhost:5001/Houses/${addLocation}`,
        {
          params: {
            page: newValue,
          },
        }
      );
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
    async fetchEditAdd({ commit }, id) {
      const response = await axios.get(
        `https://localhost:5001/Houses/id/${id}`
      );

      commit("setEditAdd", response.data);
    },
    async pushEditAdd({ commit }, { changes, eid }) {
      const response = await axios.put(`https://localhost:5001/Houses/${eid}`, {
        sellRent: changes.sellRent,
        price: changes.price,
        location: changes.location,
      });
      commit("setEditAdd", changes);
    },
  },
  modules: {},
  getters: {
    getPageNumber: (state) => state.pageNumber,
    getAdds: (state) => state.adds,
    getEditAdd: (state) => state.editAdd,
  },
});
