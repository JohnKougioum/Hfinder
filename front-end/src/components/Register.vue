
<template>
  <body>


<div class="register-container">
    <div class="left-register">
        <div class="circle">
            <div class="person-vector">
                <img src="Images/Group.svg" alt="">
            </div>
        </div>
        <div class="already-acc">
            <p id="already-acc">Έχεις ήδη λογαριασμό<span class="connect"><a href="#" id="connect">Σύνδεση</a></span></p>
        </div>
    </div>
    
    <div class="right-register">  
         <h1 id="create-account"> Δημιουργία λογαριασμού</h1>      
         <div class="wrapper">
         <form id="register-form-id" action="#"> 
                    <label for="fname">Όνομα</label> 
                    <label  for="lname">Επώνυμο</label>
                    <input  type="text" >
                    <input  type="text"  >                       
                    <label   for="fname">Όνομα χρήστη</label>
                    <label  for="fname">Email</label>
                    <input  type="text" >
                    <input  type="text" >           
                    <label  for="fname">Κωδικός πρόσβασης</label>
                    <label  for="fname">Επαλήθευση κωδικού</label>
                    <input type="text"  > 
                    <input type="text"  > 
                    <label   for="fname">Τηλέφωνο επικοινωνίας</label>
                    <label   for="fname"></label>
                    <input   type="text"  >     
                    <input id="register-button" type="submit" value="Εγγραφή">                                                                                          
                                    
            </form>
        </div>  
    </div>
</div>    
</body>
</template>

<script>

export default {

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
    margin-top: 12vh;
    width: 100%;
    display: flex;
    padding: 2rem;}
     .left-register{
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
        margin-left: 2rem;
        padding-left: 2em;}
            h1{
                margin-left: 15px;
                font-size: 30px;
                font-weight: 600;
                letter-spacing: 0.5px;            
        }
        #register-button{
         margin-top: -8px;
        height: 50px;
         background: #0080FF;
         border-radius: 5px;
         font-style: normal;
         font-size: 24px;
         font-weight: 500;
         letter-spacing: 1px;
         line-height: 43px;
         color: #FFFBFB;    
         }

 form{
     font-style: normal;
     width: 70%;
    padding: 40px 25px 0 20px;
    margin: 10px 0 25px;
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-gap: 30px;
    box-sizing: border-box;
    font-size: 23px;
    font-weight: 400;}
    input[type=text], select {
    border: 1.5px solid #000000;
    box-sizing: border-box;
    width: 100%;
    height: 40px;      }
</style>