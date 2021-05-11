<template>
  <div class="acontainer">
    <!-- <div class="acontainer-filters"></div> -->
    <div class="acontainer-adds">
      <h1>Αγαπημένα </h1>
      <div class="hero-section_area-search">
            <input
              id="search_input"
              placeholder="Αναζήτηση τοποθεσίας"
              type="text"
            />
            <div class="hero-section_area-search_btn">
              <div class="hero-section_area-search_btn-img">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                >
                  <path
                    d="M23.809 21.646l-6.205-6.205c1.167-1.605 1.857-3.579 1.857-5.711 0-5.365-4.365-9.73-9.731-9.73-5.365 0-9.73 4.365-9.73 9.73 0 5.366 4.365 9.73 9.73 9.73 2.034 0 3.923-.627 5.487-1.698l6.238 6.238 2.354-2.354zm-20.955-11.916c0-3.792 3.085-6.877 6.877-6.877s6.877 3.085 6.877 6.877-3.085 6.877-6.877 6.877c-3.793 0-6.877-3.085-6.877-6.877z"
                  />
                </svg>
              </div>
            </div>
          </div>
      <Adds :adds="adds" />

      <Pagination :totalItems="5" />

    </div>
  </div>
</template>

<script>
import Adds from "../components/FavAdds";
import Pagination from "../components/Pagination";
export default {
  name: "Favourites",
  components: {
    Adds,
    Pagination,
  },
  data() {
    return {
      adds: [],
    };
  },
  created() {
    this.adds = [
      {
        id: "1",
        img: "home_photo.jpg",
        price: "€1.500.000",
        beds: "3",
        bathrooms: "2",
        sqf: "1.409",
      },
      {
        id: "2",
        img: "BG.jpg",
        price: "€2.500.000",
        beds: "6",
        bathrooms: "3",
        sqf: "2.210",
      },
      {
        id: "3",
        img: "home_photo.jpg",
        price: "€500.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "4",
        img: "homebg-1.jpg",
        price: "€1.700.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "5",
        img: "BG.jpg",
        price: "€900.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
            {
        id: "6",
        img: "home_photo.jpg",
        price: "€1.500.000",
        beds: "3",
        bathrooms: "2",
        sqf: "1.409",
      },
      {
        id: "7",
        img: "BG.jpg",
        price: "€2.500.000",
        beds: "6",
        bathrooms: "3",
        sqf: "2.210",
      },
      {
        id: "8",
        img: "home_photo.jpg",
        price: "€500.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "9",
        img: "homebg-1.jpg",
        price: "€1.700.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "10",
        img: "BG.jpg",
        price: "€900.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
            {
        id: "11",
        img: "home_photo.jpg",
        price: "€1.500.000",
        beds: "3",
        bathrooms: "2",
        sqf: "1.409",
      },
      {
        id: "12",
        img: "BG.jpg",
        price: "€2.500.000",
        beds: "6",
        bathrooms: "3",
        sqf: "2.210",
      },
      {
        id: "13",
        img: "home_photo.jpg",
        price: "€500.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "14",
        img: "homebg-1.jpg",
        price: "€1.700.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "15",
        img: "BG.jpg",
        price: "€900.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
            {
        id: "16",
        img: "home_photo.jpg",
        price: "€1.500.000",
        beds: "3",
        bathrooms: "2",
        sqf: "1.409",
      },
      {
        id: "17",
        img: "BG.jpg",
        price: "€2.500.000",
        beds: "6",
        bathrooms: "3",
        sqf: "2.210",
      },
      {
        id: "18",
        img: "home_photo.jpg",
        price: "€500.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "19",
        img: "homebg-1.jpg",
        price: "€1.700.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
      {
        id: "20",
        img: "BG.jpg",
        price: "€900.000",
        beds: "3",
        bathrooms: "1",
        sqf: "850",
      },
    ];
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";


.hero-section_area-search {
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  margin-top: 0%;
  margin-left: 55%;
}

.hero-section_area-search #search_input {
  width: 50%;
  height: 30px;
  border-radius: 5px;
  border: solid black;
  outline: none;
  -webkit-box-sizing: border-box;
          box-sizing: border-box;
  padding: 20px;
  font-size: 16px;
  border-top-right-radius: 0px;
  border-bottom-right-radius: 0px;
}

.hero-section_area-search .hero-section_area-search_btn {
  width: 10%;
  background-color: grey;
  border-radius: 5px;
  border-top-left-radius: 0px;
  border-bottom-left-radius: 0px;
  border-left: 3px solid #343434;
  cursor: pointer;
  border: black solid;
}

.hero-section_area-search .hero-section_area-search_btn .hero-section_area-search_btn-img {
  width: 50%;
  position: relative;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
          transform: translate(-50%, -50%);
}

.hero-section_area-search .hero-section_area-search_btn .hero-section_area-search_btn-img svg {
  width: 90%;
  fill: white;
  -webkit-transition: 0.2s ease-in-out;
  transition: 0.2s ease-in-out;
}

.hero-section_area-search .hero-section_area-search_btn:hover svg {
  width: 100%;
  fill: black;
}
</style>

