
<template>
  <body>
    <div class="edit-profile-container">
        <div class="left-edit-profile">
            <div class="circle">
                <div class="person-vector">
               <img src="../assets/images/Group.svg" alt="" />
                 </div>
            </div>  
        </div> 
        
        <div class="right-edit-profile">  
            <h1 id="edit-profile"> Επεξεργασία λογαριασμού</h1>      
            <div class="wrapper">
            <form id="edit-profile-form-id" action="#"> 
                       <label for="fname">Όνομα</label> 
                       <label  for="lname">Επώνυμο</label>
                       <input  type="text" >
                       <input  type="text"  >                       
                       <label   for="fname">Όνομα χρήστη</label>
                       <label  for="fname">Email</label>
                       <input  type="text" >
                       <input  type="text" >           
                       <label  for="fname">Κωδικός πρόσβασης</label>
                       <label  for="fname">Τηλέφωνο επικοινωνίας</label>
                       <input type="text"  > 
                       <input type="text"  > 
                       <label   for="fname"></label>
                       <label   for="fname"></label>
                       <label   for="fname"></label>
                       <input id="save-button" type="submit" value="Αποθήκευση">                                                                                          
                                       
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

<style lang="scss" scoped>
body{
    margin: 0;
    font-family: "Lato",sans-serif;
    background: white;
    box-sizing: border-box;
 }
 .edit-profile-container{
    width: 100%;
    display: flex;
    padding: 2rem;}
     .left-edit-profile{
       margin-top: 135px;
       flex: 35%;
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
             
        
    
    .right-edit-profile{
        margin-top: 70px;
        flex: 65%;
      margin-left: 4rem;
        padding-left: 2em;}
            h1{
                margin-left: 15px;
                font-size: 30px;
                font-weight: 600;
                letter-spacing: 0.5px;            
        }
 

    #save-button{
    
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
    margin-top: 0;
 font-style: normal;
 width: 70%;
padding: 40px 25px 0 20px;
margin-bottom: 15px;
display: grid;
grid-template-columns: 1fr 1fr;
grid-gap: 30px;
box-sizing: border-box;
font-size: 23px;
font-weight: 400;}
input[type=text], select {
border: 1.5px solid #000000;
margin-bottom: 15px;
box-sizing: border-box;
width: 100%;
height: 40px;      }
</style>
