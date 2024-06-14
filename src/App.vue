<template>
  <HeaderBoard  v-model:UserName="UserName" 
                v-model:Balance="Balance"                 
                @handleUser="HandleUser"
                @handleBalance="HandleBalance"/>

  <MainBoard    v-model:Items="Items" 
                v-model:Bet="Bet" 
                v-bind:-Message="Message"
                v-model:Balance="Balance"
                v-model:Item="Item" v-model:Colors="Colors"  
                v-model:Numbers="Numbers" 
                @selectNumber="SelectNumber($event)"  
                @selectItemGroup="SelectItemGroup($event)"
                @handleAmount="HandleAmount"
                @start-game="StartGame" />
</template>

<script>
import HeaderBoard from './components/HeaderBoard.vue'
import MainBoard from './components/MainBoard.vue'
import Data from './data/data.json'
import Colors from './data/Colors.json'
import Numbers from './data/Numbers.json'

import Config from './components/Constants'
import axios from 'axios';

import {ref} from 'vue'

export default {
  name: 'App',
  components: {
    HeaderBoard,
    MainBoard
  },
  data() {
    return {
      Items:      ref(Data.filter(x => x.Value !== 0)),
      Item:       ref(Data[0]),    
      UserName:   ref(""),
      Balance:    ref(0),     
      Colors:     ref(Colors),
      Numbers:    ref(Numbers),
      Bet : ref(
          {
            BetNumber:  -1,
            BetAmount:  0,
            BetColor:   "",
            BetType:    -1,
            UserName:   ""
          }
      ),
      Message: ref("")
    }
  },
  methods: {
    SelectItem(Item) {
      console.log(Item)
    },

    SelectNumber(Item) {
      let IsSelected = Item.IsSelected
      this.SetSelectedItem(this.Items, false)
      this.Item.IsSelected = false
      this.Bet.BetNumber = IsSelected ? parseInt(Item.Value) : -1   
      Item.IsSelected = IsSelected 

      if(Item.Value == 0)
        this.Item.IsSelected = IsSelected
    },

    SelectItemGroup(Item) {
        let IsSelected = Item.IsSelected
        if(Item.Type =='COLOR')
        {
            this.SetSelectedItem(this.Colors, false)
            this.Bet.BetColor = IsSelected ? Item.Value : ""
        }else
        {
            this.SetSelectedItem(this.Numbers, false)
            this.Bet.BetType = IsSelected ? parseInt(Item.Value) : -1
        }
    },

    SetSelectedItem(Data, value) {
      Data.forEach((D) => D.IsSelected = value );
    },

    SaveGame() {
      alert("go to save game")      
    },

    StartGame(Result) {
      console.log(Config.URL_API)
      
      if(Result != null) {
        this.Message = this.BuildResponse(Result)
        this.CheckWin(Result)
      } else {
        this.Message = ""
        alert("Error, vuelva a intentar")
      }
    },

    CheckWin(Result) {
      let Data = {
                    "Bet": this.Bet,
                    "Result": Result
                  }

      axios.post(
                  Config.URL_API+"GetAmountWin", 
                  Data
                )
      .then(response => this.ParserWin(parseFloat(response.data)));
    },

    ParserWin(Amount) {
      var Msg = ""
      console.log("=================")
      console.log(typeof Amount)
      console.log(typeof this.Balance)
console.log("Saldo anterior:" + this.Balance)
      if(Amount > 0) {
        this.Balance += Amount
        Msg = "Ganaste: " + Amount
      } else {
        this.Balance -= this.Bet.BetAmount
        Msg = "Perdiste la partida"
      }
      console.log("Saldo final:" + this.Balance)
      console.log("=================")
      this.ResetGame()
      alert(Msg)
    },

    BuildResponse(Result) {
      let Color = Result.Color == "BLACK" ? "Negro" : "Rojo"
      let BetType = Result.BetTYpe == 1 ? "PAR" : "IMPAR"

      var msg = `Numero: ${Result.WinNumber} ${Color}, ${BetType}` 

      return  msg
    },

    ResetGame() {
      this.SetSelectedItem(this.Numbers, false)
      this.SetSelectedItem(this.Colors, false)
      this.SetSelectedItem(this.Items, false)
      this.Item.IsSelected = false
    },

    HandleUser(User) {
      this.Bet.UserName = User
    },

    HandleAmount(Amount) {
      this.Bet.BetAmount= Amount
    },

    HandleBalance(Amount){
      this.Balance = Amount
      this.Message = ""
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #dc3545;
  font-size: large;
  margin-top: 60px;
}

body {
  background-color: black !important;
}

.bet-result-title{
    font-size: large !important;
    color: white !important;
}
.bet-result {
    font-size: x-large !important;
    color: white !important;
}
</style>
