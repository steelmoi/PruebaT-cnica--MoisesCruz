<template>
    <div class="col-2">
      <div class="item" v-bind:class="{ 'item-selected': Item.IsSelected }" @click="SelectItem">
        {{ Item.Text }}
      </div>     
      </div>
</template>

<script>
export default {
  name: 'ItemBoard',
  props: {'Item': Object},
  data() {
    return {

    }
  },
  methods:{
    SelectItem() {
      this.$emit("SelectItem", this.Item);
    }
  }
}
</script>

<style>
.item {
      width: 50px;
      height: 50px;
      float: left;
      margin: 3px;

      border-color: #dc3545;
      border-style: solid;
      color: white !important;
      text-align: center !important;
  }
  .item-selected {
    width: 50px;
      height: 50px;
      float: left;
      margin: 3px;

      font-weight: 100;
      border-color: #dc3545;
      border-style: dotted;
      color: white !important;
      text-align: center !important;
  }
</style>