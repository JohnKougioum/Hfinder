import axios from "axios";
import { createStore } from "vuex";

export const store = createStore({
  state: {
    pageNumber: 1,
    adds: [],
    filters: [],
    filters2: [],
    editAdd: [],
    reportedAdds: [],
    location: "",
    rent: 0,
    buy: 1,
    img: "",
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
    setFilters: (state, filters) => (state.filters = filters),
    setFilters2: (state, filters2) => (state.filters2 = filters2),
    removeAdd: (state, id) =>
      (state.adds = state.adds.filter((add) => add.id !== id)),
    setEditAdd: (state, editAdd) => (state.editAdd = editAdd),
    setNewLocation: (state, location) => (state.location = location),
    setReportedAdd: (state, reportedAdd) => (state.reportedAdds = reportedAdd),
    setImg: (state, img) => (state.img = img),
  },
  actions: {
    async fetchOwnAdds(
      { commit },
      {
        page,
        user,
        location,
        sellrent,
        bedrooms,
        bathrooms,
        startPrice,
        endPrice,
        startSm,
        endSm,
      }
    ) {
      if (isNaN(sellrent)) sellrent = 3;
      try {
        const response = await axios.get(
          `https://localhost:5001/UserHouses/${user}`,
          {
            params: {
              page: page,
              location: location,
              sellrent: sellrent,
              beds: bedrooms,
              baths: bathrooms,
              startPrice: startPrice,
              endPrice: endPrice,
              startSm: startSm,
              endSm: endSm,
            },
          }
        );
        commit("setAdds", response.data);
      } catch (error) {
        console.log(error);
      }
    },
    async fetchAdds(
      { commit },
      {
        newValue,
        addLocation,
        path,
        bedrooms,
        bathrooms,
        startPrice,
        endPrice,
        startSm,
        endSm,
      }
    ) {
      // console.log(newValue, addLocation, path, bedrooms, bathrooms);
      let choice;

      if (path == "Buy") choice = 1;
      if (path == "Rent") choice = 0;

      const response = await axios.get(
        `https://localhost:5001/${choice}/${addLocation}`,
        {
          params: {
            page: newValue,
            beds: bedrooms,
            baths: bathrooms,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        }
      );
      commit("setAdds", response.data);
      if (response.data[0] == null) {
        const filt = { location: addLocation, sellRent: choice };
        commit("setFilters", filt);
        return;
      }
      commit("setFilters", response.data[0]);
    },
    async deleteAdd({ commit }, id) {
      var warn = confirm(
        "Είστε σίγουροι ότι θέλεται να διαγράψεται αυτήν την αγγελία"
      );
      if (warn != true) return;

      await axios.delete(`https://localhost:5001/Houses/${id}`);

      commit("removeAdd", id);
    },
    async fetchOneAdd({ commit }, id) {
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
        address: changes.address,
        floor: changes.floor,
        sm: changes.sm,
        type: changes.type,
        beds: changes.beds,
        baths: changes.baths,
        heatingType: changes.heatingType,
        description: changes.description,
      });

      commit("setEditAdd", changes);
    },
    async reportAdd({}, id) {
      console.log(id);
      try {
        const response = await axios.put(
          `https://localhost:5001/Houses/report/${id}`,
          {
            report: 1,
          }
        );
        if (response.status == 204) window.alert("Add Reported");
      } catch (error) {
        console.log(error);
      }
    },
    async setReportedAdds({ commit }) {
      const response = await axios.get("https://localhost:5001/reported", {
        params: {
          report: 1,
        },
      });
      commit("setReportedAdd", response.data);
    },
  },
  modules: {},
  getters: {
    getPageNumber: (state) => state.pageNumber,
    getAdds: (state) => state.adds,
    getEditAdd: (state) => state.editAdd,
    getFilters: (state) => state.filters,
    getFilters2: (state) => state.filters2,
    getLocation: (state) => state.location,
    getReportedAdds: (state) => state.reportedAdds,
    getImg: (state) => state.img,
  },
});
