<template>
  <div class="menu-item" @click="isOpen = !isOpen">
    <a href="#">
      <img src="../assets/images/user.png" alt="Admin" width="40"><i class="fas fa-angle-down"></i>
      {{ title }}
    </a>
    <svg viewBox="0 0 1030 638" width="10">
      <path d="M1017 68L541 626q-11 12-26 12t-26-12L13 68Q-3 49 6 24.5T39 0h952q24 0 33 24.5t-7 43.5z" fill="#FFF"></path>
    </svg>
    
    <transition name="fade" appear>
      <div class="sub-menu" v-if="isOpen">
        <div v-for="(item, i) in items" :key="i" class="menu-item">
          <a :href="item.link">{{ item.title }}</a>
        </div>
      </div>
    </transition>
  </div>


                
               

        <!-- <div class="right">
            <ul>
              <li>
                <a href="#">
                  <img src="../assets/images/user.png" alt="Admin" width="40"><i class="fas fa-angle-down"></i>
                </a>
              </li>
          </ul>
        </div>   -->
</template>

<script>
export default {
  name: 'dropdown',
  props: ['title', 'items'],
  data () {
    return {
      isOpen: false
    }
  }
}
</script>