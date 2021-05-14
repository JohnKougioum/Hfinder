<template>
  <body>
    <div class="edit-listing-container">
      <div class="left-edit-listing">
        <div class="photo-div">
          <div class="photo-gallery">
            <p>PHOTO GALLERY</p>
          </div>
          <input id="grey-button" type="submit" value="Εισαγωγή φωτογραφιών" />
        </div>
        <input id="blue-button" type="submit" value="Aποθήκευση" />
      </div>
      <div class="right-edit-listing">
        <h1>Eπεξεργασία αγγελίας</h1>
        <div class="sell-rent">
          <p>
            Διάθεση προς:
            <input type="radio" id="rent" name="sell-rent" value="0" />
            <label for="radio">Ενοικίαση</label>
            <input type="radio" id="sell" name="sell-rent" value="1" />
            <label for="radio">Πώληση</label>
          </p>
        </div>
        <div class="left-form">
          <form class="new-listing" @submit.prevent="pushEdit">
            <input
              type="text"
              id="newLocation"
              :value="toEditAdd.location"
              placeholder="Διεύθυνση ακινήτου"
            />

            <div class="same-row">
              <select name="">
                <option value="" disabled selected>Είδος ακινήτου</option>
                <option value="volvo">Μονοκατοικία</option>
                <option value="saab">Πολυκατοικία</option>
              </select>
              <input
                type="text"
                name=""
                id="newPrice"
                :value="toEditAdd.price"
                placeholder="Τιμή"
              />
            </div>
            <div class="same-row">
              <input
                type="text"
                name=""
                id="newBeds"
                placeholder="Υπνοδωμάτια"
              />
              <input type="text" name="" id="newBaths" placeholder="Μπάνιο" />
            </div>
            <div class="same-row">
              <input
                type="text"
                name=""
                id="newFloor"
                :value="toEditAdd.floor"
                placeholder="Όροφος"
              />
              <input
                type="text"
                name=""
                id="newSm"
                :value="toEditAdd.sm"
                placeholder="Τετραγωνικα μέτρα"
              />
            </div>
            <input
              type="text"
              name=""
              id="big-textbox"
              placeholder="Αναλυτική περιγραφή"
            />
            <button>Save</button>
          </form>
        </div>
      </div>
    </div>
  </body>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "Editlisting",
  props: {
    id: {
      type: String,
    },
  },
  computed: {
    toEditAdd() {
      return this.$store.getters.getEditAdd;
    },
  },
  created() {
    this.$store.dispatch("fetchAdd", this.id);
  },
  methods: {
    ...mapActions(["pushEditAdd"]),
    async pushEdit() {
      var status;
      let t = document.getElementsByName("sell-rent");
      var revert;

      for (let i = 0; i < t.length; i++) {
        if (t[i].checked) status = i;
      }

      const changes = {
        sellRent: status,
        price: document.getElementById("newPrice").value,
        location: String(document.getElementById("newLocation").value),
        address: this.toEditAdd.address,
        floor: document.getElementById("newFloor").value,
        sm: document.getElementById("newSm").value,
        type: this.toEditAdd.type,
        beds: this.toEditAdd.beds,
        baths: this.toEditAdd.baths,
        heatingType: this.toEditAdd.heatingType,
        description: this.toEditAdd.description,
      };
      const eid = this.id;
      this.pushEditAdd({ changes, eid });
    },
  },
  watch: {
    toEditAdd() {
      if (this.toEditAdd.sellRent == 0)
        document.getElementById("rent").checked = true;
      if (this.toEditAdd.sellRent == 1)
        document.getElementById("sell").checked = true;
    },
  },
};
</script>

<style scoped>
body {
  margin: 0;
  font-family: "Lato", sans-serif;
  background: white;
  box-sizing: border-box;
}
h1 {
  margin-left: -75px;
  text-align: center;
  margin-top: 60px;
  font-size: 30px;
  font-weight: 600;
  letter-spacing: 0.5px;
}
.edit-listing-container {
  display: flex;
}
.right-edit-listing {
  width: 50%;
  padding: 2rem;
  margin-top: 20px;
  margin-left: 200px;
}
.sell-rent {
  text-align: center;
  margin-left: -75px;
  margin-top: 55px;
}
#sell,
#rent {
  margin-left: 19px;
  margin-right: 5px;
}

.same-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-gap: 30px;
}
form {
  font-style: normal;
  width: 94%;
  padding: 20px 15px 0px 0px;
  margin: 10px 0 25px;
  display: grid;
  grid-template-columns: 1fr;
  grid-gap: 22px;
  box-sizing: border-box;
  font-size: 23px;
  font-weight: 400;
}
input[type="text"],
select {
  padding-left: 30px;
  border: 1.5px solid #000000;
  box-sizing: border-box;
  width: 100%;
  height: 50px;
}
#big-textbox {
  height: 100px;
}

.photo-gallery {
  margin-left: -170px;
  margin-top: 180px;
  background-color: #c4c4c4;
  width: 400px;
  height: 200px;
  text-align: center;
  font-size: 30px;
  font-weight: 500;
  letter-spacing: 0.5px;
}
#grey-button {
  background-color: #dddddd;
  margin-left: -170px;
  width: 274px;
  height: 45px;
  margin-top: 25px;
  font-size: 16px;
  font-weight: 500;
  letter-spacing: 0.5px;
}

#blue-button {
  margin-left: -170px;
  margin-top: 145px;
  width: 290px;
  height: 50px;
  background: #0080ff;
  border-radius: 5px;
  font-style: normal;
  font-size: 21px;
  font-weight: 500;
  letter-spacing: 1px;
  line-height: 43px;
  color: #fffbfb;
}

.left-edit-listing {
  margin-left: 250px;
}
</style>
