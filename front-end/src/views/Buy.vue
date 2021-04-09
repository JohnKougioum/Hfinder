<template>
  <div class="acontainer">
    <div class="acontainer-filters"></div>
    <div class="acontainer-adds">
      <Adds :adds="adds" />
    </div>
  </div>
</template>

<script>
import Adds from "../components/Adds";

export default {
  name: "Buy",
  components: {
    Adds,
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
    ];
  },
};
</script>

<style lang="scss" scoped>
@import "../assets/css/adds/adds.css";
</style>
