<script setup lang="ts">
import TemplateForButton from '../templates/TemplateForButton.vue'
import TemplateForReturnData from '../templates/TemplateForReturnData.vue'
import TemplateForSelectbox from '../templates/TemplateForSelectbox.vue'
import TemplateHeader from '../templates/TemplateHeader.vue'
import TemplateToInputData from '../templates/TemplateToInputData.vue'
import { ref } from 'vue'

const id = ref('')

const statuses = [
  'Not Selected',
  'New',
  'Wait to Payment',
  'Assembly',
  'Transferred to Delivery Services',
  'Wait To Delivery',
  'Delivering',
  'Issued To Courier',
  'Rejected',
  'Cancelled',
]
const selectedStatus = ref(0)

const responseResult = ref('')

async function onIdChanged() {
  const message = await sendGetStatus(id.value)
  console.log(message)
  selectedStatus.value = message
}

function isValidId(id) {
  const regEx =
    /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/
  return regEx.test(id)
}

async function onClick() {
  console.log('clicked')
  responseResult.value = await sendChangeStatus(id.value, selectedStatus.value)
  console.log(responseResult.value)
}

//Order Id is guid
async function sendChangeStatus(orderId, newStatus) {
  const response = await fetch(`http://localhost:5116/api/orders/${orderId}/status/${newStatus}`)
  if (response.status !== 200) {
    console.error(`Error ${response.status}: ${response.statusText}`)
  } else {
    return response.json()
  }
}

async function sendGetStatus(id) {
  const response = await fetch(`http://localhost:5116/api/orders/${id}/status`)
  if (response.status === 204) {
    console.error('Order not found')
  } else if (response.status !== 200) {
    console.error(`Error ${response.status}: ${response.statusText}`)
  }
  return response.json()
}
</script>

<template>
  <TemplateHeader header-value="Change Order Status" />
  <TemplateToInputData
    dynamic-id="id"
    label-value="Id:"
    v-model="id"
    :input-class="id"
    :on-lost-focus="onIdChanged"
    :pre-send-validate="isValidId"
  />
  <TemplateForSelectbox
    dynamic-id="SelectStatus"
    label-value="Select Status to change"
    :values="statuses"
    :index="selectedStatus"
  />
  <TemplateForButton button-value="Change Order Status" @clicked="onClick" />
  <TemplateForReturnData v-if="responseResult" :returnData="responseResult" />
</template>
