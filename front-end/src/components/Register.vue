
<template>
  <body>


<div class="register-container">
    <div class="left-register">
        <div class="circle">
            <div class="person-vector">
        <img src="../assets/images/Group.svg" alt="" />
            </div>
        </div>
        <div class="already-acc">
            <p id="already-acc">Έχεις ήδη λογαριασμό;<span class="connect"><router-link to="/Login" id="connect">Σύνδεση</router-link></span></p>
        </div>
    </div>
    
    <div class="right-register">  
         <h1 id="create-account"> Δημιουργία λογαριασμού</h1>      
         <div class="wrapper">
         <form id="register-form-id" @submit.prevent="handleSubmit"> 
                    <label for="fname">Όνομα</label> 
                    <label  for="lname">Επώνυμο</label>
                    <input v-model="firstname"  type="text" >
                    <input v-model="lastname" type="text"  >                       
                    <label   for="fname">Όνομα χρήστη</label>
                    <label  for="fname">Email</label>
                    <input v-model="username" type="text" >
                    <input v-model="email" type="text" >           
                    <label  for="fname">Κωδικός πρόσβασης</label>
                    <label  for="fname">Επαλήθευση κωδικού</label>
                    <input v-model="passwd" type="text"  > 
                    <input type="text"  > 
                    <label   for="fname">Τηλέφωνο επικοινωνίας</label>
                    <label   for="fname"></label>
                    <input v-model="phone_num"  type="text"  >     
                    <input id="register-button" type="submit" value="Εγγραφή">                                                                                          
                                    
            </form>
        </div>  
    </div>
</div>    
</body>
</template>

<script>
import axios from 'axios'

export default {
   name: "Register",
   data() {
      return {
        firstname: "",
        lastname: "",
        username: "",
        email: "",
        passwd: "",
        phone_num: ""
      };
   },
   methods: {
      async handleSubmit(){
         try {
            await axios.post('https://localhost:5001/Users/register', {
                username: this.username,
                password: this.passwd,
                email: this.email,
                firstname: this.firstname,
                lastname: this.lastname,
                phone_num: parseInt(this.phone_num)
            });
            
            this.$router.push('/Login');
         } catch (err) {
            console.log(err);
         }
      }
   }
}
</script>

<style scoped>

@import url("https://fonts.googleapis.com/css2?family=Lato:wght@700&family=Poppins:wght@100&display=swap");


body{
   margin: 0;
   font-family: "Lato",sans-serif;
   background: white;
   box-sizing: border-box;
}



.register-container{
 width: 100%;
   display: flex;
   padding: 2rem;}
     .left-register{
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
        .already-acc{
            font-weight: lighter;
            margin-top: 5em;
            margin-left: 35px;
            font-size: larger;

        }
        #connect{
            margin-left: 15px;
            color: #0080FF;
        }
    

    .right-register{
      flex: 70%;
      margin-left: 5rem;
      padding-left: 2em;}
            h1{   margin-top: 90px;
                font-size: 30px;
                font-weight: 600;
                letter-spacing: 0.5px;            
        }
        #register-button{
        height: 50px;
         background: #0080FF;
         border-radius: 5px;
         font-style: normal;
         font-size: 24px;
         font-weight: 500;
         letter-spacing: 1px;
         line-height: 43px;
         color: #FFFBFB;    
         width: 90%;
         }

 form{
     margin-top: 64px;
     font-style: normal;
     width: 90%;
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-gap: 19.4px;
    box-sizing: border-box;
    font-size: 23px;
    font-weight: 400;}
    input[type=text], select {
    margin-top: 1px;
    border: 1.5px solid #000000;
    box-sizing: border-box;
    width: 91.2%;
        height: 50px;
  }
</style>