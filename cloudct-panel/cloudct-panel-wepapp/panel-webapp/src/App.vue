<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<!-- menu topo -->
<template> 

<link href="https://cdn.jsdelivr.net/npm/vuetify@3.3.2/dist/vuetify.min.css" rel="stylesheet">

  <v-card class="container">
  <v-app>
    <div class="header">
      <h3 class="logo-title">
        <span class="icon-wrapper">
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 24 24" fill="white" stroke="black" 
            stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity">
            <path d="M18 10h-1.26A8 8 0 1 0 9 20h9a5 5 0 0 0 0-10z"></path>
          </svg>
        </span>
        <span class="text-wrapper">CloudCT</span>
      </h3>

      <v-row class="d-flex align-center justify-end">
          <v-col md="2" class="text-right">
            <!-- Barra de pesquisa -->
              <!-- <v-text-field 
              label="Pesquisar..." 
              variant="solo-filled"
              class="search-bar"
              density="compact"
              :rounded="true"
              bg-color="#eef7ff"
              :clearable="true"
              ></v-text-field> -->
          </v-col>
          
            <v-col cols="auto" class="bell">
              <!-- Sino de notificação -->
              <v-btn 
                icon size="x-small" 
                color="var(--vt-c-dark-blue)" 
                variant="text">
                <svg 
                  xmlns="http://www.w3.org/2000/svg" 
                  width="20" 
                  height="20" 
                  viewBox="2 0 24 24" 
                  fill="none" 
                  stroke="white" 
                  stroke-width="2" 
                  stroke-linecap="round" 
                  stroke-linejoin="round">
                    <path d="M22 17H2a3 3 0 0 0 3-3V9a7 7 0 0 1 14 0v5a3 3 0 0 0 3 3zm-8.27 4a2 2 0 0 1-3.46 0"></path>
                </svg>
              </v-btn>
            </v-col>

            <v-col cols="auto" class="picuser">
              <!-- Foto do usuário -->
              <v-avatar size="35">
                <v-img src="/user-photo.jpg" alt="User Photo"></v-img>
              </v-avatar>
            </v-col>
          </v-row>

        <nav class="panel-content">
          <ul>
            <li>
              <a href="#" class="a">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="black" 
                  stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity" style="margin-right: 10px;">
                  <path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"></path>
                  <polyline points="9 22 9 12 15 12 15 22"></polyline>
                </svg>
                <div class="panel-div">
                  Painel
                </div>
                <svg xmlns="http://www.w3.org/2000/svg" width="19" height="19" viewBox="0 0 20 20" 
                  fill="none" stroke="black" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" style="margin-left: 10px;">
                  <polyline points="6 9 12 15 18 9"></polyline>
                </svg>
              </a>
            </li>
          </ul>
        </nav>
    </div>

      <div class="main-content ">
        <RouterView />  
      </div>
  </v-app>
</v-card> 

</template>


<style scoped>

.bell{
  padding: 0.1rem;
}
.picuser{
  padding: 0.6rem;
  margin-right: 0.7rem;
}
.icon-wrapper {
  width: 30px; 
  margin-right: 0.6rem;
  margin-left: 0.2rem; 
}

.text-wrapper {
  margin: 0;  
}

.logo-title {
  font-size: 1.1rem;
  color: white;
  display: flex;
  align-items: flex-start;
}

li {
  list-style: none;
}

.header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  height: 12%;
  width: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  padding-top: 0;
  background-color: var(--vt-c-dark-blue);
  z-index: 999;
}

.search-bar {
  height: 2.7rem;
  margin-top: 0.2rem;
  width: 13rem;
}

.panel-content {
  position: fixed;
  top: 5.4rem;
  margin-left: 5%;
  background-color: #eef7ff;
  border-radius: 10px;
  box-shadow: 0 0 0 5px #eef7ff;
  padding: 1.2rem 1rem;
}

.a {
  display: flex;
  align-items: center;
  margin-top: -10px;
}

.panel-div {
  color: black;
  margin-right: 10px;
}

.main-content {
  margin-top: 2rem;
}

.align-center {
  justify-content: center;
}

</style>
