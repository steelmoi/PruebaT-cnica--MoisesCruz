<template>
    <div class="Board">
        <div class="row">
            <div class="col-3">
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        Color
                        <ItemOption v-for="(Color, x) in Colors" :key="x" v-bind:Item="Color" @selectItemGroup="SelectItemGroup($event)"/> 
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <ItemOption v-for="(Number, x) in Numbers" :key="x" v-bind:Item="Number" @selectItemGroup="SelectItemGroup($event)"/> 
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div class="container">
                    <div class="row"> 
                        <center>
                        <ItemBoard v-bind:Item="Item" @selectItem="SelectItem($event)"/> 
                    </center>
                    </div>
                    <div class="row"> 
                        <ItemBoard v-for="(Item, x) in Items" :key="x" v-bind:Item="Item" @selectItem="SelectItem($event)"/> 
                    </div>
                </div>
            </div>

            <div class="col-3">
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        &nbsp;
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="row mb-3">
                            <label for="" class="col-sm-2 col-form-label col-form-label-sm">Apostar</label>                            
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="row mb-3">
                            <div class="col-sm-10">
                            <input type="number" @input="handleAmount" class="form-control form-control-sm" id="" placeholder="">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <button v-show="CanStart" type="submit" @click="StartGame" class="btn btn-danger bet-button">Jugar</button>
                    </div>
                </div>
            </div>            
        </div>

        <BetResult v-bind:Message="Message" />
    </div>
</template>

<script>
import ItemBoard from './ItemBoard.vue'
import ItemOption from './ItemOption.vue'
import BetResult from './BetResult.vue'

import {ref} from 'vue'
import axios from 'axios';
import Config from './Constants.js'

export default {
  name: 'HeaderBoard',
  components: {
    ItemBoard,
    ItemOption,
    BetResult
  },
  props: {
    'Items': Array,
    'Item': Object,
    'Colors': Array,
    'Numbers': Array,
    'Bet': Object,
    'Message': String,
    'Balance': Number
  },
  data() {
    return{
        CanStart: ref(false),
        CurBet: ref(this.Bet),
        CanWrite: ref(this.Bet.UserName == "" ? true : false)
    }
  },
  methods: {
    SelectItem(Item) {
      Item.IsSelected = !Item.IsSelected
      this.$emit("SelectNumber", Item);
    },

    SelectItemGroup(Item) {
        Item.IsSelected = !Item.IsSelected
        this.$emit("SelectItemGroup", Item);
    },

    StartGame() {
        console.log("==================================")
        console.log(this.Bet)
        console.log(this.Balance)
        console.log("==================================")
       axios
        .get(Config.URL_API+'GetBet')
        .then(response => this.$emit("startGame", response.data))
        .catch(error => {
            console.log(error)
            this.$emit("startGame", null)
        })
    },

    handleAmount(event){
        let amount = (event.target.value != "") ? parseFloat(event.target.value) : 0
        this.$emit("handleAmount", amount);

        this.isReady2Star()
    },

    isReady2Star() {
        this.CanStart = (   this.Balance > 0 && this.CurBet.BetAmount  > 0 && 
                            this.CurBet.UserName !="" && 
                            this.CurBet.BetAmount <=this.Balance
                        )
    }
  }
}
</script>

<style scoped>
.Board{
    background-color: #198754;
    height: 550px;
    position: relative;
}

.bet-button {
    height: 50px;
    width: 180px !important;
    text-align: center;
    margin-bottom: 5px;
    margin-left: 5px;
}
</style>