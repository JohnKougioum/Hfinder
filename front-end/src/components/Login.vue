<template>
   <div class="login-container">
    <div class="left-login">
        <div class="circle">
            <div class="person-vector">
                <img src="Images/Group.svg" alt="">
            </div>
 
        </div>
        </div>
    
        <div class="right-login">
            <h1 id="login-subhead">Σύνδεση</h1>
            <div class="login-form">
                <form class="username" action="">
                    <label id="login-form-labels" for="name">Όνομα χρήστη</label><br>
                    <input type="text"><br>
                </form>
                <form class="password" action="">
                    <label id="login-form-labels" for="name">Κωδικός πρόσβασης</label><br>
                    <input type="text">              <br> 
                </form>
                <input type="checkbox" name="pass" id="store-pass" >
                <label class="store-password" for="store-pass">Αποθήκευση κωδικού πρόσβασης</label>
            </div>

                <input id="login-button" type="submit" value="Σύνδεση">
        <p id="no-acc"> Δεν έχεις λογαριασμο; <span><a id="new-acc" href="#">Δημιουργία εδώ</a></span></p>
        </div>
    </div>

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
.login-container{
   width: 100%;
   display: flex;
   padding: 2rem;}
   .left-login {
      margin-top: 45px;
      flex: 30%;
      border-right:1px solid black ;}
      .circle{ 
         margin-left: 35px;;
         height: 200px;
         border: 4px solid #D6D6D6;
         border-radius: 50% ;
         object-fit: cover;
         width: 200px;}
         .person-vector{
            width: 50%;
            transform:translate(-50%,-50%) ;
            position: relative;
            top: 50%;
            left: 50%;}
            img{
               width: 100px;
            }
         .right-login{
      flex: 70%;
      margin-left: 2rem;
      padding-left: 2em;}
      #login-subhead{
         font-size: 30px;
         font-weight: 600;
         letter-spacing: 0.5px;
      }

       .login-form{        
         margin-top: 4rem;
         font-style: normal;}
         input[type=text], select {
            width: 25%;
            padding: 15px 25px;
            margin: 25px 0 25px;
            display: inline-block;
            border: 1.5px solid black;
            border-radius: 2px;
            box-sizing: border-box;
          }
         #login-form-labels{
            font-size: 23px;
            font-weight: 400;
         }
      

      .store-password{
         margin-left: 7px;
         margin-top: 10px;
         font-size: 21px;
         font-weight:lighter;
         font-style: normal;
      }


          

   #login-button{
      width: 25%;
   
   background: #0080FF;
   border-radius: 5px;
   font-style: normal;
   font-size: 30px;
   font-weight: 500;
   letter-spacing: 1px;
   line-height: 43px;
   margin-top: 30px;
   margin-bottom: 10px;;
   color: #FFFBFB;    
   }
   #no-acc{
      font-weight: lighter;
      font-size: 18px;
   }
   #new-acc{
      margin-left: 15px;
      font-weight: 500;
      font-size: 19px;
      color: #0080FF;
   }
   
   
   #register-button{
      width: 25%;
   
   background: #0080FF;
   border-radius: 5px;
   font-style: normal;
   font-size: 30px;
   font-weight: 500;
   letter-spacing: 1px;
   line-height: 43px;
   margin-top: 30px;
   margin-bottom: 10px;;
   color: #FFFBFB;    
   }
   #already-acc{
      margin-left: 40px;
      margin-top: 5em;
      font-weight: lighter;
      font-size: 18px;}

    
   
   #connect{
         margin-left: 15px;
         font-weight: 500;
         font-size: 19px;
         color: #0080FF;
      }


</style>