<template>
  <body>
    <div class="new-listing-container">
      <div class="left-new-listing">
        <h1>Συμπληρώστε τα στοιχεία</h1>
        <div class="sell-rent">
          <p>
            Διάθεση προς:
            <input
              type="radio"
              id="sell"
              name="sell-rent"
              value="sell"
              v-model="sellrent"
            />
            <label for="radio">Πώληση</label>
            <input
              type="radio"
              id="rent"
              name="sell-rent"
              value="rent"
              v-model="sellrent"
            />
            <label for="radio">Ενοικίαση</label>
          </p>
        </div>
        <div class="left-form">
          <form class="new-listing" action="">
            <input
              type="text"
              name=""
              v-model="address"
              placeholder="Διεύθυνση ακινήτου"
            />
            <div class="same-row">
              <input type="text" name="" v-model="name" placeholder="Όνομα" />
              <input
                type="text"
                name=""
                v-model="lastname"
                placeholder="Επίθετο"
              />
            </div>
            <div class="same-row">
              <input
                type="text"
                name=""
                v-model="email"
                placeholder="Email επικοινωνίας"
              />
              <input
                type="text"
                name=""
                v-model="phone"
                placeholder="Τηλέφωνο επικοινωνίας"
              />
            </div>
            <div class="same-row">
              <select v-model="type" nam>
                <option value="" disabled selected>Είδος ακινήτου</option>
                <option value="monokatoikia"> Μονοκατοικία</option>
                <option value="polukatoikia">Πολυκατοικία</option>
              </select>
              <input type="text" name="" v-model="price" placeholder="Τιμή" />
            </div>
            <div class="same-row">
              <input
                type="text"
                name=""
                v-model="bedrooms"
                placeholder="Υπνοδωμάτια"
              />
              <input
                type="text"
                name=""
                v-model="bathrooms"
                placeholder="Μπάνιο"
              />
            </div>
            <div class="same-row">
              <input type="text" name="" v-model="floor" placeholder="Όροφος" />
              <input
                type="text"
                name=""
                v-model="cm2"
                placeholder="Τετραγωνικα μέτρα"
              />
            </div>
            <input
              type="text"
              name=""
              id="big-textbox"
              v-model="description"
              placeholder="Αναλυτική περιγραφή"
            />
          </form>
        </div>
      </div>

      <div class="right-new-listing">
        <div class="photo-div" id="photo-div">
          <input type="file" id="fileup" />
        </div>
        <button v-on:click="handleSubmit" id="blue-button" type="submit">
          Καταχώρηση αγγελίας
        </button>
      </div>
    </div>
    <div id="test"></div>
  </body>
</template>

<script>
import axios from "axios";
import { render } from "vue";
export default {
  name: "Newlisting",
  data() {
    return {
      sellrent: "",
      address: "",
      name: "",
      lastname: "",
      email: "",
      phone: "",
      type: "",
      price: "",
      bedrooms: "",
      bathrooms: "",
      floor: "",
      cm2: "",
      description: "",
      img: "",
    };
  },
  methods: {
    async handleSubmit() {
      let token = localStorage.getItem("authToken");

      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map(function(c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      var file = document.getElementById("fileup").files;
      if (file.length > 0) {
        var file = file[0];
        var fileReader = new FileReader();

        fileReader.onload = function(FileLoadEvent) {
          var srcData = FileLoadEvent.target.result;
          //   console.log(srcData);
          document.getElementById("test").innerHTML = srcData;
        };
        fileReader.readAsDataURL(file);
      }

      let option;

      if (this.sellrent == "rent") {
        option = 0;
      }
      if (this.sellrent == "sell") option = 1;
      try {
        await axios.post("https://localhost:5001/Houses", {
          userId: "test",
          sellRent: option,
          location: this.address,
          address: "string",
          floor: this.floor,
          sm: this.cm2,
          type: 0,
          beds: this.bedrooms,
          baths: this.bathrooms,
          heatingType: 0,
          description: this.description,
          contentImage: "",
          price: this.price,
        });

        this.$router.push("/");
      } catch (err) {
        console.log(err);
      }
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
  margin-top: 60px;
  font-size: 30px;
  font-weight: 600;
  letter-spacing: 0.5px;
}
#test {
  padding: 1px;
}
.photo-div {
  margin-top: 20vh;
}
.new-listing-container {
  display: flex;
}
.left-new-listing {
  width: 50%;
  padding: 2rem;
  margin-top: 20px;
  margin-left: 35px;
}
.sell-rent {
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
  grid-gap: 19px;
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
  height: 44px;
}
#big-textbox {
  height: 100px;
}

.photo-gallery {
  margin-left: 30px;
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
  margin-left: 155px;
  width: 274px;
  height: 45px;
  margin-top: 25px;
  font-size: 16px;
  font-weight: 500;
  letter-spacing: 0.5px;
}

#blue-button {
  margin-top: 215px;
  float: right;
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

.right-new-listing {
  margin-left: 100px;
}
</style>
