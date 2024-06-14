<template>
    <div class="col-2">
        <div :class="ItemClass" @click="SelectItemGroup">
            {{ Item.Text }}
        </div>
    </div>
</template>

<script>
import {ref} from 'vue'

export default {
    name: 'ItemOption',
    props:{
        'Item': Object
    },
    methods: {
        SelectItemGroup() {
            this.ItemClass = this.MyItem.IsSelected ?  this.MyItem.Class + " btn-check:checked" : this.MyItem.Class
            this.$emit("SelectItemGroup", this.Item);
        }
    },

    data() {
        return {
            ItemClass: ref(this.Item.Class),
            MyItem : ref(this.Item)
        }
    }
}
</script>

<style scoped>
.btn-item {
    height: 50px;
    width: 180px !important;
    text-align: center;
    margin-bottom: 5px;
    margin-left: 5px;
}

.btn-check:checked + .btn, :not(.btn-check) + .btn:active, .btn:first-child:active, .btn.active, .btn.show {
    color: var(--bs-btn-active-color);
    background-color: var(--bs-btn-active-bg);
    border-color: var(--bs-btn-active-border-color);
}
</style>