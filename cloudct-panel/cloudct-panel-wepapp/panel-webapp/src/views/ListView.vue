<script setup>
import { ref, onMounted } from 'vue'

const facts = ref([]);
const filteredFacts = ref([]);
const dialogVisible = ref(false);


const fetchData = async () => {
  const url = 'https://localhost:7156/service';
  const response = await fetch(url);
  const data = await response.json();

  facts.value = data;
  filteredFacts.value = data;
}

onMounted(async () => {
  await fetchData();
});


function filtrar() {
  const termo = document.getElementById('pesquisa').value.toUpperCase();
  const resultadosFiltrados = facts.value.filter(fact => fact.names.toUpperCase().indexOf(termo) !== -1);
  filteredFacts.value = resultadosFiltrados;
}

</script> 


<!-- <template>
  <div class="overlay">
    <div class="upper-div">
      <h3><strong class="highlight">Visualizar Containers</strong></h3>
        <div class="inner-div text-center">
     
        <v-table fixed-header height="23rem">
          <thead>
            <tr>
              <th class="text-left mr-5 font-medium truncate">
                Nome
              </th>
            </tr>
          </thead>

        <tbody>
          <tr v-for="(fact, index) in facts" :key="fact.names">
            <td>
              <v-dialog
                :model-value="activeIndex === index"
                @update:model-value="activeIndex = $event ? index : null"
                transition="dialog-top-transition"
                width="auto"
              >
                <template v-slot:activator="{ on }">
                  <v-btn v-bind="on" variant="plain" @click="activeIndex = index">
                    {{ fact.names }}
                  </v-btn>
                </template>

                <template v-slot:default="{ isActive }" :class="model">
                  <v-card 
                  value="rounded-xl"
                  :class="model"
                  >
                    <v-toolbar 
                    :rounded="true" 
                    class="custom-title" 
                    color="#0000CD"
                    >
                      <span>{{ fact.names }}</span>
                    </v-toolbar>

                    <v-card-text>
                      <div class="text-h6 pa-12 modern-style">
                        <ul>
                          <li><strong>Id:</strong> {{ fact.id }}</li>
                          <li><strong>Command:</strong> {{ fact.command }}</li>
                          <li><strong>Imagem:</strong> {{ fact.image }}</li>
                          <li><strong>Criado em:</strong> {{ fact.created }}</li>
                          <li><strong>Status:</strong> {{ fact.status }}</li>
                          <li><strong>Origem IPV4:</strong> {{ fact.originIPV4 }}</li>
                          <li><strong>Porta do server IPV4:</strong> {{ fact.serverPortIPV4 }}</li>
                          <li><strong>Porta do container IPV4:</strong> {{ fact.containerPortIPV4 }}</li>
                          <li><strong>Origem IPV6:</strong> {{ fact.originIPV6 }}</li>
                          <li><strong>Porta do server IPV6:</strong> {{ fact.serverPortIPV6 }}</li>
                          <li><strong>Porta do container IPV6:</strong> {{ fact.containerPortIPV6 }}</li>
                        </ul> 
                      </div>
                    </v-card-text>

                    <v-card-actions class="justify-end">
                      <v-btn variant="text" @click="activeIndex = null">
                        Fechar
                      </v-btn>
                    </v-card-actions>

                  </v-card>
                </template>
              </v-dialog>
            </td>
          </tr>
        </tbody>
      </v-table>
    </div>
  </div>
</div>
</template> -->


<template>
  <div class="overlay">
    <div class="upper-div">
      <h3><strong class="highlight">Visualizar Containers</strong></h3>

      <div class="inner-div text-center">
        <v-table fixed-header height="auto">

            
          <div class="d-flex justify-between mb-1">
            <div class="text-subtitle-h1 mt-7 mb-1 ml-5 text-left pa-1 truncate">
              Nome
            </div>

            <v-card-actions class="ml-auto mr-3">
              <v-text-field label="Pesquisar..." 
                            variant="underlined"
                            id="pesquisa" @input="filtrar()"></v-text-field> 
            </v-card-actions>
          </div>

          <div class="text-subtitle-h1 mt-4 mb-1 ml-5 text-left pa-1 truncate"  v-if="filteredFacts.length === 0" 
            style="display: flex; justify-content: center; align-items: center; height: 18rem; font-size: 1.3rem;">
            Nenhum resultado encontrado...
          </div>
                

          <v-expansion-panels variant="popout" class="my-4">
            <v-expansion-panel 
              v-for="(fact) in filteredFacts" 
              :key="fact.names" 
              :title="fact.names" 
              id="lista"
              >             
              <template v-slot:title>
                <v-row align="center">
                  <v-col cols="auto"> 
                    <v-icon>
                      <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity">
                        <path d="M12.89 1.45l8 4A2 2 0 0 1 22 7.24v9.53a2 2 0 0 1-1.11 1.79l-8 4a2 2 0 0 1-1.79 0l-8-4a2 2 0 0 1-1.1-1.8V7.24a2 2 0 0 1 1.11-1.79l8-4a2 2 0 0 1 1.78 0z"></path>
                        <polyline points="2.32 6.16 12 11 21.68 6.16"></polyline>
                        <line x1="12" y1="22.76" x2="12" y2="11"></line>
                      </svg>
                    </v-icon> 
                  </v-col>

                  <v-col class="mt-1">
                    {{ fact.names }}
                  </v-col> 

                  <v-btn variant="text"
                         class="ma-2 ml-auto d-flex justify-end mr-0"
                         @click="dialogVisible = true">
                      Editar
                    <svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" viewBox="0 0 25 32" fill="none" stroke="currentColor" 
                         stroke-width="1" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity ml-2 mt-2">
                      <polygon points="14 2 18 6 7 17 3 17 3 13 14 2"></polygon>
                      <line x1="3" y1="22" x2="21" y2="22"></line>
                    </svg>
                  </v-btn>
                  
                </v-row>
              </template>


              <v-expansion-panel-text>
                  <div class="text-h10 pa-3 text-left">
                    <ul>
                      <li><strong>Id:</strong> {{ fact.id }}</li>
                      <v-divider></v-divider>
                      <li><strong>Command:</strong> {{ fact.command }}</li>
                      <v-divider></v-divider>
                      <li><strong>Imagem:</strong> {{ fact.image }}</li>
                      <v-divider></v-divider>
                      <li><strong>Criado em:</strong> {{ fact.created }}</li>
                      <v-divider></v-divider>
                      <li><strong>Status:</strong> {{ fact.status }}</li>
                      <v-divider></v-divider>
                      <li><strong>Origem IPV4:</strong> {{ fact.originIPV4 }}</li>
                      <v-divider></v-divider>
                      <li><strong>Porta do server IPV4:</strong> {{ fact.serverPortIPV4 }}</li>
                      <v-divider></v-divider>
                      <li><strong>Porta do container IPV4:</strong> {{ fact.containerPortIPV4 }}</li>
                      <v-divider></v-divider>
                      <li><strong>Origem IPV6:</strong> {{ fact.originIPV6 }}</li>
                      <v-divider></v-divider>
                      <li><strong>Porta do server IPV6:</strong> {{ fact.serverPortIPV6 }}</li>
                      <v-divider></v-divider>
                      <li><strong>Porta do container IPV6:</strong> {{ fact.containerPortIPV6 }}</li>
                    </ul>
                  </div>
                </v-expansion-panel-text>
        
                <td> 
                  <v-dialog v-model="dialogVisible" fullscreen transition="dialog-bottom-transition"> 

                    <template v-slot:default="{ isActive }" :class="{ 'model': isActive }">
                      <v-card value="rounded-xl" :class="{ 'model': isActive }">
                        <v-toolbar 
                        :rounded="true" 
                        class="custom-title" 
                        color="#0000CD"
                        >
                          <span>{{ fact.names }}</span>
                        </v-toolbar>

                        <v-card-text>
                          <td>
                            <v-dialog v-model="dialogVisible" fullscreen transition="dialog-bottom-transition">
                              <template v-slot:default="{ isActive }">
                                <v-card value="rounded-xl">
                                  <v-toolbar class="custom-title text-h6" color="#0000CD">
                                    <span>Editar: <strong>{{ fact.names }}</strong></span>
                                  </v-toolbar>

                                  <v-card-text>
                                    <div class="text-h6 pa-5 ml-6 modern-style">
                                      <ul>
                                        <li><strong>Id:</strong> {{ fact.id }}</li>
                                        <li><strong>Command:</strong> {{ fact.command }}</li>
                                        <li><strong>Imagem:</strong> {{ fact.image }}</li>
                                        <li><strong>Criado em:</strong> {{ fact.created }}</li>
                                        <li><strong>Status:</strong> {{ fact.status }}</li>
                                        <li><strong>Origem IPV4:</strong> {{ fact.originIPV4 }}</li>
                                        <li><strong>Porta do server IPV4:</strong> {{ fact.serverPortIPV4 }}</li>
                                        <li><strong>Porta do container IPV4:</strong> {{ fact.containerPortIPV4 }}</li>
                                        <li><strong>Origem IPV6:</strong> {{ fact.originIPV6 }}</li>
                                        <li><strong>Porta do server IPV6:</strong> {{ fact.serverPortIPV6 }}</li>
                                        <li><strong>Porta do container IPV6:</strong> {{ fact.containerPortIPV6 }}</li>
                                      </ul>
                                    </div>
                                  </v-card-text>

                                  <v-card-actions class="pa-5">
                                    <v-btn variant="flat" color="success" class="justify-start" background-color="success">
                                      Salvar
                                    </v-btn>
                                    <v-btn  variant="outlined" class="ml-auto" @click="dialogVisible = false">
                                      Fechar
                                    </v-btn>
                                  </v-card-actions>

                                </v-card>
                              </template>
                            </v-dialog>
                          </td> 
                        </v-card-text>

                      <v-card-actions class="justify-end">
                        <v-btn variant="text" @click="dialogVisible = false"> 
                          Fechar
                        </v-btn>
                      </v-card-actions>

                    </v-card>
                  </template>
                </v-dialog>
              </td>
                
            </v-expansion-panel>
          </v-expansion-panels>
        </v-table>
      </div>
    </div>
  </div>
</template>


<style scoped>
@media (min-width: 1024px) {

  .v-text-field{
    width: 18rem;
  }

  ul{
    list-style: none;
  }

  .edit-input {
    border-bottom: 1px solid #d3d2d2;
    border-radius: 0;
    padding: 0.4rem;
    width: auto;
    height: 2rem;
    font-size: 1.2rem;
    box-sizing: border-box;
    margin-left: 0.3rem;
  }

  .edit-input:focus {
    outline: none;
    border-color: #000000;
  }

  .custom-title{
    color: white;
    padding: 0;
    padding-left: 2rem;
    font-size: 2rem;
  }
  .truncate {
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    font-size: 1.1rem;
  }
  .overlay {
    position: fixed;
    top: 8rem; 
    width: calc(100% - 4%); /* largura da tela - espaçamento à esquerda e direita */
    height: calc(100% - 4%); /* altura da tela - altura do menu do topo */
    background-color: #eef7ff;
    left: 2%;
    right: 2%;
    border-top-left-radius: 30px; 
    border-top-right-radius: 30px; 
    overflow-y: auto; 
  }
  .inner-div {
    position: fixed;
    background-color: white;
    width:  calc(100% - 8%);
    height: calc(100% - 4%); /* altura da tela - altura do menu do topo */
    padding: 1rem;
    border-radius: 10px;
    max-height: 500px; /* Defina uma altura máxima */
    overflow-y: auto; /* Habilita a rolagem vertical */
  }
  .upper-div {
    position: relative;
    top: 1.3rem;
    left: 1.4%;
    width: 30%;
    height: 10%;
    padding: 0.7rem;
    overflow-y: auto;
  }
  .highlight {
    color: #2f2f2f; 
  }
}

  h3 {
    margin-bottom: 1rem;
    margin-left: 5px;
    align-items: left;
    font-size: 1.2em;
    font-family: Arial, sans-serif;
    top: 0;
  }
  
  li{
    padding: 0.4rem;
  }

</style>


