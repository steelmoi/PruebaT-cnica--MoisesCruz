<template>
  <div class="roulette-game">
    <div id="heading">Juego de Ruleta</div>
    <div class="container">
      <div class="row align-items-start">
        <div class="col">
          <div class="row mb-3">
            <label for="" class="col-sm-2 col-form-label col-form-label-sm">Nombre</label>
            <div class="col-sm-10">
              <input type="text" @input="handleUser" v-model="userName" class="form-control form-control-sm" id="" placeholder="">
            </div>
          </div>
        </div>
        <div class="col">
          <center>
            <button type="submit" class="btn btn-danger">Guardar Juego</button>&nbsp;&nbsp;&nbsp;
            <button type="submit" :disabled="CanLoad" @click="LoadBalance" class="btn btn-danger">Cargar Saldo</button>
          </center>
        </div>
        <div class="col">
          <div class="row mb-3">
            <label for="" class="col-sm-2 col-form-label col-form-label-sm">Saldo</label>
            <div class="col-sm-10">
              <input type="number" :value="Balance" disabled class="form-control form-control-sm" id="Balance" placeholder="">
            </div>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script>
import {ref} from 'vue'

export default {
  name: 'HeaderBoard',
  props:{
    UserName: String,
    Balance: Number
  },
  data() {
    return {
      userName : this.UserName,
      CanLoad: ref(this.UserName == ""),
      gameStarted: false,
    };
  },
  methods: {

    handleUser(event){
      this.$emit("handleUser", event.target.value);
      this.CanLoad = ref(event.target.value == "")
    },

    LoadBalance() {
      var Balance = 0;
      do {
        let res = prompt("Saldo:");

        if(!isNaN(res))
          Balance = res;
      }while(Balance <=0);

      this.$emit("handleBalance", Balance);
    }
  },
}
</script>

<style scoped>
.roulette-game {
  background-color: #198754;
}
#heading {
      font-size: 42px;
      font-weight: bold;
      color: #dc3545;
      margin-left: 20px;
      margin-top: 5px;
      text-align: center;
  }
</style>