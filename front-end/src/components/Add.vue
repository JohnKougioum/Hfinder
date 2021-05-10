<template>
  <div class="acontainer-adds-results-card-container">
    <div class="acontainer-adds-results-card-container-img">
      <img :src="require(`../assets/images/BG.jpg`)" alt="" />
    </div>
    <div class="acontainer-adds-results-card-container-content">
      <h1 class="acontainer-adds-results-card-container-content-price">
        {{ add.price }}€
      </h1>
      <span><img src="../assets/images/bed.svg" alt="" />bd</span>
      <span><img src="../assets/images/bathtub.svg" alt="" />ba</span>
      <span><img src="../assets/images/sqf.svg" alt="" />sqft</span>
      <div class="acontainer-adds-results-card-container-content-address">
        <h4>720 Clayton St.</h4>
        <h4>Haight, San Fransisco, CA</h4>
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
