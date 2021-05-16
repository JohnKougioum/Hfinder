<template>
   <div class="login-container">
    <div class="left-login">
        <div class="circle">
            <div class="person-vector">
        <img src="../assets/images/Group.svg" alt="" />
            </div>
 
        </div>
        </div>
    
        <div class="right-login">
            <h1 id="login-subhead">Σύνδεση</h1>
            <div class="login-form">
                <form @submit.prevent="handleSubmit" class="login">
                    <label id="login-form-labels" for="username">Όνομα χρήστη</label><br>
                    <input v-model="username" type="text" name="username"><br>                
                    <label id="login-form-labels" for="passwd">Κωδικός πρόσβασης</label><br>
                    <input v-model="passwd" type="text" name="passwd">              <br>
                    <input type="checkbox" name="pass" id="store-pass" >
                    <label class="store-password" for="store-pass">Αποθήκευση κωδικού πρόσβασης</label><br>
                    <input id="login-button" type="submit" value="Σύνδεση"> 
                </form>
                
            </div>

                
        <p id="no-acc"> Δεν έχεις λογαριασμο; <span><router-link id="new-acc" to="/Register">Δημιουργία εδώ</router-link></span></p>
        </div>
    </div>

</template>

<script>
import axios from 'axios'

export default {
   name: "Login",
   data() {
      return {
         username: "",
         passwd: "",
      };
   },
   methods: {
      async handleSubmit(){
         try {
            const response = await axios.post('https://localhost:5001/Users/login', {
               username: this.username,
               password: this.passwd
            });
            localStorage.setItem('authToken', response.data);
            window.location.href = "http://localhost:8080/";
            //this.$router.push('/');
         } catch (err) {
            console.log(err);
         }
      }
   }
}
</script>

<style scoped>
h1{
   margin-top: 90px;
}
body{
   font-family: "Lato",sans-serif;
   background: white;
   box-sizing: border-box;
}
.login-container{
   width: 100%;
   display: flex;
   padding: 2rem;}
   .left-login {
      margin-left:10px;
      margin-top: 125px;
      flex: 30%;
      border-right:1px solid black ;}
      .circle{ 
         margin-top: 20px;
         margin-left: 50px;
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
      margin-left: 5rem;
      padding-left: 2em;}
      #login-subhead{
         font-size: 30px;
         font-weight: 600;
         letter-spacing: 0.5px;
      }

       .login-form{        
          margin-bottom: 1px;
         margin-top: 4rem;
         font-style: normal;}
         input[type=text], select {
            height: 50px;
            width: 40%;
            padding: 15px 25px;
            margin: 20px 0px 50px;
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
      margin-top: 19px;
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
     width: 50%;
   
        height: 50px;
         background: #0080FF;
         border-radius: 5px;
         font-style: normal;
         font-size: 24px;
         font-weight: 500;
         letter-spacing: 1px;
         line-height: 43px;
         color: #FFFBFB;   
   margin-top: 35px;
   margin-bottom: 10px;;
   color: #FFFBFB;    
   }
   #already-acc{
      margin-left: 40px;
      margin-top: 6em;
      font-weight: lighter;
      font-size: 18px;}

    
   
   #connect{
         margin-left: 15px;
         font-weight: 500;
         font-size: 19px;
         color: #0080FF;
      }


</style>