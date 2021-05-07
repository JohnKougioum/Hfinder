

<template>
  <body>
    <div class="new-listing-container">
        <div class="left-new-listing">
            <h1>Συμπληρώστε τα στοιχεία</h1>
            <div class="sell-rent">
                <p>Διάθεση προς:
                <input type="radio" id="sell" name="sell-rent" value="sell">
                <label for="radio">Πώληση</label>
                <input type="radio" id="rent" name="sell-rent" value="rent">
                <label for="radio">Ενοικίαση</label></p>
            </div>
            <div class="left-form">
                <form class="new-listing" action="">
                    <input type="text" name="" id="" placeholder="Διεύθυνση ακινήτου">
                    <div class="same-row">
                    <input type="text" name="" id="" placeholder="Όνομα">
                    <input type="text" name="" id="" placeholder="Επίθετο">
                    </div>
                    <div class="same-row">
                    <input type="text" name="" id="" placeholder="Email επικοινωνίας">
                    <input type="text" name="" id="" placeholder="Τηλέφωνο επικοινωνίας"> 
                    </div>                   
                    <div class="same-row">
                        <select name="" id="">
                          <option value="" disabled selected>Είδος ακινήτου</option>
                          <option value="volvo">Μονοκατοικία</option>
                          <option value="saab">Πολυκατοικία</option>
                        </select>  
                    <input type="text" name="" id="" placeholder="Τιμή"> 
                    </div> 
                    
                    <input type="text" name="" id="" placeholder="Βασικά χαρακτηριστικά ακινήτου">
                    <input type="text" name="" id="big-textbox" placeholder="Αναλυτική περιγραφή">
                </form>
            </div>

        </div>

        <div class="right-new-listing">
            <div class="photo-div">
                <div class="photo-gallery">
                    <p>PHOTO GALLERY</p> 
                </div>
                <input id="grey-button" type="submit" value="Εισαγωγή φωτογραφιών">
            </div>
            <input id="blue-button" type="submit" value="Καταχώρηση αγγελίας">


        </div>
    </div>
</body>
</template>

<script>

export default {

}
</script>

<style scoped>
body{
    margin: 0;
    font-family: "Lato",sans-serif;
    background: white;
    box-sizing: border-box;
 }
 h1{
     margin-top: 60px;
    font-size: 30px;
    font-weight: 600;
    letter-spacing: 0.5px;            
}
 .new-listing-container{
     display: flex;
 }
 .left-new-listing{
    width: 50%;
    padding: 2rem;
    margin-top: 20px;
    margin-left: 35px;
 }
 .sell-rent{
    margin-top: 55px;
 }
 #sell,#rent{
     margin-left: 19px;
     margin-right: 5px;
 }
 
 .same-row{
     display: grid;
     grid-template-columns: 1fr 1fr;
     grid-gap: 30px;
 }
 form{
    font-style: normal;
    width: 94%;
   padding: 20px 15px 0px 0px;
   margin: 10px 0 25px;
   display: grid;
   grid-template-columns: 1fr ;
   grid-gap: 22px;
   box-sizing: border-box;
   font-size: 23px;
   font-weight: 400;}
   input[type=text], select {
   border: 1.5px solid #000000;
   box-sizing: border-box;
   width: 100%;
   height: 50px;      }
   #big-textbox{
       height: 100px;
   }

   .photo-gallery{
       margin-left: 30px;
       margin-top: 180px;
       background-color: #C4C4C4;
       width: 400px;
       height: 200px;
       text-align: center;
       font-size: 30px;
       font-weight: 500;
       letter-spacing: 0.5px;

   }
   #grey-button{
       background-color: #DDDDDD;
       margin-left: 155px;
       width: 274px;
       height: 45px;
       margin-top: 25px;
       font-size: 16px;
       font-weight: 500;
       letter-spacing: 0.5px; 
   }

   #blue-button{
       margin-top: 215px;
        float: right;
        width: 290px;
        height: 50px;
         background: #0080FF;
         border-radius: 5px;
         font-style: normal;
         font-size: 21px;
         font-weight: 500;
         letter-spacing: 1px;
         line-height: 43px;
         color: #FFFBFB;    
         
   }

   .right-new-listing{
       margin-left: 190px;
   }
</style>
