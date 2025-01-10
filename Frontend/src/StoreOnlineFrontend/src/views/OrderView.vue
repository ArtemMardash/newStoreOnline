<script setup>
//import TheWelcome from '../components/TheWelcome.vue'
import ChangeOrderStatus from '@/components/ordersMethods/ChangeOrderStatus.vue'
import CreateOrder from '@/components/ordersMethods/CreateOrder.vue'
import GetOrder from '@/components/ordersMethods/GetOrder.vue'
import { ref } from 'vue'

const selected = ref('create')

function selectPage(input) {
  if (input === 'create') {
    selected.value = 'create'
  } else if (input === 'get') {
    selected.value = 'get'
  } else if (input === 'change') {
    selected.value = 'change'
  } else {
    selected.value = 'create'
  }
}
</script>

<template>
  <main>
    <div>
      <ul>
        <li>
          <a href="#create-order" @click="selectPage('create')">Create Order</a>
        </li>
        <li>
          <a href="#get-order-by-id" @click="selectPage('get')">Get Order By Id</a>
        </li>
        <li>
          <a href="#change-order-status" @click="selectPage('change')">Change Status</a>
        </li>
      </ul>
    </div>
    <div>
      <CreateOrder v-if="selected === 'create'" />
      <GetOrder v-if="selected === 'get'" />
      <ChangeOrderStatus v-if="selected === 'change'" />
    </div>
  </main>
</template>

<style>
ul {
  text-align: left;
}
</style>
