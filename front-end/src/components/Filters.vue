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
        <input
          type="text"
          id="search-filter-location"
          :value="$route.params.loc"
        />
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
        <div class="filters-option-items-rent">
          <input type="radio" id="rent-option" name="option" value="0" />
          <label for="option">Ενοικίαση</label>
        </div>
        <div class="filters-option-items-buy">
          <input type="radio" id="buy-option" name="option" value="1" />
          <label for="option">Αγορά</label>
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
          <input type="checkbox" name="bedsBox" value="1" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >2 Υπνοδωμάτια
          <input type="checkbox" name="bedsBox" value="2" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >3 Υπνοδωμάτια
          <input type="checkbox" name="bedsBox" value="3" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >4+ Υπνοδωμάτια
          <input type="checkbox" name="bedsBox" value="4" />
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
          <input type="checkbox" name="bathsBox" value="1" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >2 μπάνια
          <input type="checkbox" name="bathsBox" value="2" />
          <span class="checkmark"></span>
        </label>
        <label class="container"
          >3+ μπάνια
          <input type="checkbox" name="bathsBox" value="3" />
          <span class="checkmark"></span>
        </label>
      </div>
    </div>
  </form>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "Filters",
  computed: {
    ...mapGetters(["getFilters"]),
  },
  methods: {
    ...mapActions(["fetchAdds"]),
    async handleFilters() {
      let SellOrRent = this.getSellRent();
      let bedsChecked = this.CheckedBeds();
      let bathsChecked = this.CheckedBaths();

      let bedrooms = bedsChecked[0];
      let bathrooms = bathsChecked[0];

      let destination = document.getElementById("search-filter-location").value;
      let startPrice = document.getElementById("startPrice").value;
      let endPrice = document.getElementById("endPrice").value;
      let startSm = document.getElementById("startSpace").value;
      let endSm = document.getElementById("endSpace").value;

      const filters2 = {
        beds: bedsChecked[0],
        baths: bathsChecked[0],
        startPrice: startPrice,
        endPrice: endPrice,
        startSm: startSm,
        endSm: endSm,
      };

      this.$store.commit("setFilters2", filters2);

      if (this.$route.name == "Dashboard") {
        this.applyFilters(
          destination,
          SellOrRent,
          startPrice,
          endPrice,
          startSm,
          endSm,
          bedsChecked,
          bathsChecked
        );
        return;
      }

      if (SellOrRent == 0) {
        if (
          startPrice == "" &&
          endPrice == "" &&
          startSm == "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice == "" &&
          startSm != "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startSm: startSm,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice == "" &&
          startSm == "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              endSm: endSm,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice == "" &&
          startSm != "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startSm: startSm,
              endSm: endSm,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice != "" &&
          startSm == "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              endPrice: endPrice,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice != "" &&
          startSm != "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              endPrice: endPrice,
              startSm: startSm,
            },
          });
        }
        if (
          startPrice == "" &&
          endPrice != "" &&
          startSm == "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              endPrice: endPrice,
              endSm: endSm,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice == "" &&
          startSm == "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice == "" &&
          startSm != "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              startSm: startSm,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice == "" &&
          startSm == "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endSm: endSm,
            },
          });
        }

        if (
          startPrice != "" &&
          endPrice != "" &&
          startSm == "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endPrice: endPrice,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice != "" &&
          startSm != "" &&
          endSm == ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endPrice: endPrice,
              startSm: startSm,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice != "" &&
          startSm == "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endPrice: endPrice,
              endSm: endSm,
            },
          });
        }
        if (
          startPrice != "" &&
          endPrice != "" &&
          startSm != "" &&
          endSm != ""
        ) {
          this.$router.push({
            name: "Rent",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endPrice: endPrice,
              startSm: startSm,
              endSm: endSm,
            },
          });
        }
      }
      if (SellOrRent == 1) {
        if (startPrice == "" && endPrice == "") {
          this.$router.push({
            name: "Buy",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
            },
          });
        }
        if ((startPrice == "") & (endPrice != "")) {
          this.$router.push({
            name: "Buy",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              endPrice: endPrice,
            },
          });
        }
        if (startPrice != "" && endPrice == "") {
          this.$router.push({
            name: "Buy",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
            },
          });
        }
        if (startPrice != "" && endPrice != "") {
          this.$router.push({
            name: "Buy",
            params: { loc: destination },
            query: {
              beds: bedsChecked,
              baths: bathsChecked,
              startPrice: startPrice,
              endPrice: endPrice,
            },
          });
        }
      }

      this.$store.commit("setAdds", []);

      this.$store.commit("setNewLocation", destination);
    },
    CheckedBeds() {
      const checkboxes = document.querySelectorAll(
        'input[name="bedsBox"]:checked'
      );
      let values = [];
      checkboxes.forEach((checkbox) => {
        values.push(checkbox.value);
      });
      return values;
    },
    CheckedBaths() {
      const checkboxes = document.querySelectorAll(
        'input[name="bathsBox"]:checked'
      );
      let values = [];
      checkboxes.forEach((checkbox) => {
        values.push(checkbox.value);
      });
      return values;
    },
    getSellRent() {
      let SellOrRent;
      let t = document.getElementsByName("option");

      for (let i = 0; i < t.length; i++) {
        if (t[i].checked) SellOrRent = i;
      }
      return SellOrRent;
    },
    applyFilters(
      destination,
      SellOrRent,
      startPrice,
      endPrice,
      startSm,
      endSm,
      bedsChecked,
      bathsChecked
    ) {
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice == "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice == "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endSm: endSm,
          },
        });
      }

      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm == ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm == "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent == "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination == "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
      if (
        destination != "" &&
        SellOrRent != "" &&
        startPrice != "" &&
        endPrice != "" &&
        startSm != "" &&
        endSm != ""
      ) {
        this.$router.push({
          name: "Dashboard",
          query: {
            location: destination,
            sellrent: SellOrRent,
            beds: bedsChecked,
            baths: bathsChecked,
            startPrice: startPrice,
            endPrice: endPrice,
            startSm: startSm,
            endSm: endSm,
          },
        });
      }
    },
  },
  watch: {
    getFilters() {
      if (this.getFilters.sellRent == 0)
        document.getElementById("rent-option").checked = true;
      if (this.getFilters.sellRent == 1)
        document.getElementById("buy-option").checked = true;
    },
  },
};
</script>

<style scoped>
@import "../assets/css/filters/filters.css";
</style>
