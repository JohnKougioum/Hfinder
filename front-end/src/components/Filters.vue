<template>
  <form @submit.prevent="handleFilters" class="filters-container">
    <div class="filters-title">
      <h2>Φίλτρα</h2>
      <button type="submit">Αναζήτηση</button>
    </div>
    <div class="filters-search">
      <div class="filters-search-title">
        <span>Περιοχή</span>
      </div>
      <div class="filters-search-items">
        <input type="text" :value="reg" />
        <div class="filters-search-btn">
          <div class="filters-seach-btn-icon">
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
    </div>
    <div class="filters-option">
      <div class="filters-option-title">
        <span>Σκοπός:</span>
      </div>
      <div class="filters-option-items">
        <div class="filters-option-items-buy">
          <input type="radio" id="buy-option" name="option" value="buy" />
          <label for="option">Αγορά</label>
        </div>
        <div class="filters-option-items-rent">
          <input type="radio" id="rent-option" name="option" value="rent" />
          <label for="option">Ενοικίαση</label>
        </div>
      </div>
    </div>
    <div class="filters-price">
      <div class="filters-price-title">
        <span>Περιοχή τιμών</span>
      </div>
      <div class="filters-price-items">
        <div class="filters-price-items-start">
          <span>€</span>
          <input type="text" id="startPrice" placeholder="Από" />
        </div>
        <div class="filters-price-items-end">
          <span>€</span>
          <input type="text" id="endPrice" placeholder="Εώς" />
        </div>
      </div>
    </div>
    <div class="filters-space">
      <div class="filters-space-title">
        <span>
          Τ.μ
        </span>
      </div>

      <div class="filters-space-items">
        <div class="filters-space-items-start">
          <input type="text" id="startSpace" placeholder="Από" />
        </div>
        <div class="filters-space-items-end">
          <input type="text" id="endSpace" placeholder="Εώς" />
        </div>
      </div>
    </div>
    <div class="filters-bedrooms">
      <div class="filters-bedrooms-title">
        <span>Υπνοδωμάτια</span>
      </div>
      <div class="filters-bedrooms-items">
        <label class="container">
          1 Υπνοδωμάτιο
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >2 Υπνοδωμάτια
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >3 Υπνοδωμάτια
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >4+ Υπνοδωμάτια
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
      </div>
    </div>
    <div class="filters-bathrooms">
      <div class="filters-bathrooms-title">
        <span>Μπάνια</span>
      </div>
      <div class="filters-bathrooms-items">
        <label class="container">
          1 μπάνιο
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >2 μπάνια
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >3+ μπάνια
          <input type="checkbox" />
          <span class="checkmark"></span>
        </label>
      </div>
    </div>
  </form>
</template>

<script>
export default {
  name: "Filters",
  props: {
    reg: String,
  },
  methods: {
    async handleFilters() {
      console.log("awe");
    },
  },
};
</script>

<style scoped>
@import "../assets/css/filters/filters.css";
</style>
