<template>
  <div class="acontainer-adds-results-card-container">
    <div class="acontainer-adds-results-card-container-img">
      <img :src="require(`../assets/images/BG.jpg`)" alt="" />
    </div>
    <div class="acontainer-adds-results-card-container-content">
      <h1 class="acontainer-adds-results-card-container-content-price">
        {{ add.price.toLocaleString("el-GR") }} €
      </h1>
      <span
        ><img src="../assets/images/bed.svg" alt="" />{{ add.beds }} bd</span
      >
      <span
        ><img src="../assets/images/bathtub.svg" alt="" />{{
          add.baths
        }}
        ba</span
      >
      <span
        ><img src="../assets/images/sqf.svg" alt="" />{{ add.sm }} sqft</span
      >
      <div class="acontainer-adds-results-card-container-content-address">
        <h4>{{ add.address }}</h4>
        <h4>{{ add.location }}</h4>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Add",
  props: {
    add: Object,
  },
};
</script>
