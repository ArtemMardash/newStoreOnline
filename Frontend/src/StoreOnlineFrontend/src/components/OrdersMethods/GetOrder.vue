<script setup lang="ts">
import OrderInfo from '../templates/OrderInfo.vue'
import TemplateForButton from '../templates/TemplateForButton.vue'
import TemplateHeader from '../templates/TemplateHeader.vue'
import TemplateToInputData from '../templates/TemplateToInputData.vue'
import { ref } from 'vue'

const id = ref('')
const idClass = ref('')
let responseResult = ref<IOrder>()

function validate() {
  const idError = isValidId(id.value)
  if (idError === false) {
    console.log('false')
    console.log(id.value)
    idClass.value = 'emptyField'
    return false
  } else {
    console.log(true)
    idClass.value = ''
    return true
  }
}

function onError() {
  console.error(id.value)
}

function isValidId(id) {
  const regEx =
    /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/
  return regEx.test(id)
}

async function onClick() {
  console.log('clicked')
  if (validate()) {
    const message = await sendGetOrder(id.value)
    if (message === 'Order not found') {
      console.error(message)
    } else {
      const order = JSON.parse(message)
      if (order) {
        responseResult.value = order
      }
    }
  } else {
    onError()
  }
}

async function sendGetOrder(id) {
  const response = await fetch(`http://localhost:5116/api/orders/${id}`)
  let message = ''
  if (response.status === 200) {
    message = JSON.stringify(await response.json())
  } else if (response.status === 204) {
    message = 'Order not found'
  } else {
    console.error(`Error ${response.status}: ${response.statusText}`)
  }
  return message
}
</script>

<template>
  <TemplateHeader header-value="Get Order by Id" />
  <TemplateToInputData dynamic-id="id" labelValue="ID:" v-model="id" :input-class="idClass" />
  <h1></h1>
  <TemplateForButton button-value="Get Data" @clicked="onClick" />
  <OrderInfo v-if="responseResult" :order="responseResult" />
</template>
