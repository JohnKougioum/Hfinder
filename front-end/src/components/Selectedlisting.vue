<template>
  <body>
    <div class="selected-container">
      <div class="left-selected">
        <h1>Φωτογραφίες</h1>
        <div class="photo-gallery">
          <p>PHOTO GALLERY</p>
        </div>
        <div class="description">
          <label id="description" for="fname">Περιγραφή</label> <br />
          <input type="text" id="big-textbox" name="fname" />
        </div>
      </div>

      <div class="right-selected">
        <div class="title-heart">
          <div class="title">
            <h1>Χαρακτηριστικά</h1>
          </div>
          <div class="heart">
            <img src="../assets/images/heart.svg" alt="" />
          </div>
        </div>
        <div class="top-labels">
          <label for="fname">Τιμή</label> <br /><br />
          <label for="fname">Δωμάτια</label> <br /><br />
          <label for="fname">Τετραγωνικά μέτρα</label><br />
          <br />
          <label for="fname">Περιοχή</label> <br /><br />
          <label for="fname">Διεύθυνση</label> <br /><br />
          <label for="fname">Τηλ. επικοινωνίας:</label> <br /><br />
        </div>
        <div class="bottom-form">
          <form action="#">
            <div class="left-bottom-form">
              <input
                type="text"
                name=""
                class="no-border"
                placeholder="Όνομα"
              />
              <br />
              <input
                type="text"
                name=""
                class="no-border"
                placeholder="Επίθετο"
              />
              <br />
              <input
                type="text"
                name=""
                class="no-border"
                placeholder="Email"
              /><br />
              <input
                type="text"
                name=""
                class="no-border"
                placeholder="Τηλέφωνο"
              /><br />
            </div>
            <div class="right-bottom-form">
              <input
                type="text"
                id="big-textbox2"
                placeholder="Αναλυτική Περιγραφή"
              /><br />
              <div class="blue-button">
                <input id="blue-button" type="submit" value="Αποστολή" />
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </body>
</template>

<script>
export default {
  name: "Selectedlisting",
  props: {
    id: {
      type: String,
    },
  },
};
</script>

<style scoped>
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
  margin-top: 40px;
  background-color: #c4c4c4;
  width: 400px;
  height: 200px;
  text-align: center;
  font-size: 30px;
  font-weight: 500;
  letter-spacing: 0.5px;
}

#blue-button {
  margin-top: 2px;
  width: 230px;
  height: 50px;
  background: #0080ff;
  border-radius: 5px;
  font-style: normal;
  font-size: 21px;
  font-weight: 500;
  letter-spacing: 1px;
  line-height: 43px;
  color: #fffbfb;
  margin-left: 195px;
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
  margin-left: 440px;

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
.right-bottom-form {
  margin-left: 250px;
  margin-top: -210px;
}
#big-textbox2 {
  width: 400px;
  height: 205px;
}
.no-border {
  border: 3.5px solid white !important;
}
</style>
