<template>
  <body>
    <div class="selected-container">
      <div class="reported-left">
        <h1 id="reported">Reported houses</h1>
        <div class="report" :key="add.id" v-for="add in getReportedAdds">
          <a>{{ add.id }}</a>
        </div>
      </div>
      <div class="left-selected">
        <h1>Φωτογραφίες</h1>
        <div class="photo-gallery">
          <p>PHOTO GALLERY</p>
        </div>
        <div class="description">
          <label id="description" for="fname">Περιγραφή</label> <br />
          <div id="big-textbox">asd</div>
        </div>
      </div>

      <div class="right-selected">
        <div class="blue-button">
          <input id="blue-button" type="submit" value="Διαγραφή" />
        </div>
        <div class="title-heart">
          <div class="title">
            <h1>Χαρακτηριστικά</h1>
          </div>
        </div>
        <div class="top-labels">
          <label class="left-label" for="fname">Τιμή</label> <span></span>
          <br /><br />
          <label class="right-label" for="fname">Δωμάτια</label><span></span>
          <br /><br />
          <label class="left-label" for="fname">Όροφος</label><span></span>
          <br /><br />
          <label class="right-label" for="fname">Μπάνιο</label><span></span>
          <br /><br />
          <label class="left-label" for="fname">Τετραγωνικά μέτρα</label
          ><span></span> <br /><br />
          <label class="right-label" for="fname">Περιοχή</label><span></span>
          <br /><br />
          <label class="left-label" for="fname">Διεύθυνση</label> <span></span>
          <br /><br />
          <label class="right-label" for="fname">Τηλ. επικοινωνίας:</label>
          <br /><br />
        </div>
      </div>
    </div>
  </body>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
export default {
  name: "Selectedlisting",
  props: {
    id: {
      type: String,
    },
  },
  created() {
    this.setReportedAdds();
  },
  methods: {
    ...mapActions(["setReportedAdds"]),
  },
  computed: {
    ...mapGetters(["getReportedAdds"]),
  },
};
</script>

<style lang="scss" scoped>
.top-labels {
  margin-left: -32px;
}
body {
  margin: 0;
  font-family: "Lato", sans-serif;
  background: white;
  box-sizing: border-box;
}

h1 {
  margin-top: 80px;
  font-size: 30px;
  font-weight: 600;
  letter-spacing: 0.5px;
}
.selected-container {
  display: flex;
}
.bottom-form {
  margin-left: -300px;
  display: flex;
}
.photo-gallery {
  margin-top: 60px;
  background-color: #c4c4c4;
  width: 400px;
  height: 200px;
  text-align: center;
  font-size: 30px;
  font-weight: 500;
  letter-spacing: 0.5px;
}

#blue-button {
  margin-top: 100px;
  width: 270px;
  height: 60px;
  background: white;
  border-radius: 1px;
  font-style: normal;
  font-size: 24px;
  font-weight: 500;
  letter-spacing: 1px;
  line-height: 43px;
  color: black;
  margin-left: -30px;
}
.left-selected {
  flex: 30%;
  margin-left: 100px;
  margin-top: 60px;
}

.description {
  margin-top: 40px;
  font-size: 21px;
  font-weight: lighter;
}
#big-textbox {
  margin-top: 10px;
  margin-left: 0px;
  width: 440px;
  height: 195px;
}
.right-selected {
  margin-left: 220px;

  flex: 50%;
  margin-top: 60px;
}
.title-heart {
  margin-left: -32px;
  margin-bottom: 30px;
  display: flex;
}
.heart {
  margin-left: 155px;
  margin-top: 80px;
}
.bottom-form {
  margin-top: -5px;
  width: 165%;
  display: flex;
  background: rgba(196, 196, 196, 0.1);
}
.report {
  padding: 10px 5px 5px 5px;
  a {
    cursor: pointer;
  }
}
form {
  font-style: normal;
  width: 25%;
  padding: 20px 15px 10px 0px;
  box-sizing: border-box;
  font-size: 23px;
  font-weight: 400;
}
input[type="text"],
select {
  margin-bottom: 8px;
  margin-left: 25px;
  padding-left: 30px;
  margin-top: 5px;
  border: 1.5px solid black;
  box-sizing: border-box;
  width: 100%;
  height: 40px;
}

#big-textbox2 {
  width: 400px;
  height: 205px;
}
.no-border {
  border: 3.5px solid white !important;
}
.reported-left {
  width: 800px;
  margin-left: 30px;
  margin-top: 60px;
  border-right: 1px solid black;
}

#reported {
  margin-left: 50px;
  text-decoration: underline;
  font-size: 24px;
}
</style>
