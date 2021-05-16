<template>
    <body>
        <div class="container">
            <h1>Επικοινώνησε μαζί μας</h1>
            <div class="wrapper">
                <div class="company-info">
                    <div class="contact" rows="3" columns="3">
                        <form action="https://formspree.io/f/mqkwplvl" method="POST">
                            <p>
                                <input type="text" name="firstname" placeholder="Όνομα" required>
                            </p>
                            <p>
                                <input type="text" name="lastname" placeholder="Επώνυμο" required>
                            </p>
                            <p>
                                <input type="text" name="subject" placeholder="Θέμα" required>
                            </p>
                            <p>
                                <input type="text" name="email" placeholder="Email" required>
                            </p>
                            <textarea class="full" name="message" rows="5" placeholder="Αναλυτική περιγραφή" required></textarea>
                            <p>
                                <button class="full" type="submit">Αποστολή</button>
                            </p>
                        </form>
                    </div>
                </div>
            </div>                
        </div>
    </body>
</template>

<script>

export default {
  name: "Contact",
  mounted: function(){
  window.onbeforeunload = function() {
    for(const form of document.getElementsByTagName('form')) {
    form.reset();
  }
  }
}
};
</script>

<style scoped>
    *{
    box-sizing: border-box;
}

body{
    background-color: white;
    color: #343434;
    line-height: 1.6;
    padding: 7em;
}

.container{
    max-width: 1170px;
    margin-left: auto;
    margin-right: auto;
    padding: 1em;
}

.wrapper > *{
    padding: 1em;
}

.contact form{
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-gap: 10px;
}

.contact form p{
    margin: 0;
}

.contact form .full{
    grid-column: 1/3;
}

.contact form button, .contact form input, .contact form textarea{
    width: 100%;
    padding: 1em;
    border: 1px solid black;
}

.contact form button{
    background: #0080FF;
    color: white;
    border: 0;
}

/* media */
@media(min-width:700px){
    .wrapper{
        display: grid;
        grid-template-columns: 1fr 0.5fr;
    }

    .wrapper > *{
        padding: 0.2em;
        padding-top: 2em;
    }
}
</style>
