<script setup>
import TemplateForButton from './templates/TemplateForButton.vue'
import TemplateForReturnData from './templates/TemplateForReturnData.vue'
import TemplateHeader from './templates/TemplateHeader.vue'
import TemplateToInputData from './templates/TemplateToInputData.vue'
import { ref } from 'vue'

const id = ref('')
const idClass = ref('')
let responseResult = ref('')

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
  if (validate() === true) {
    responseResult.value = await sendGetUserById(id.value)
    console.log(responseResult.value)
  } else {
    onError()
  }
}

async function sendGetUserById(id) {
  const response = await fetch(`http://localhost:5115/api/storeOnline/users/${id}/User`)
  let message = ''
  if (response.status === 200) {
    message = JSON.stringify(await response.json())
  } else if (response.status === 204) {
    message = 'User not found'
  } else {
    console.error(`Error ${response.status}: ${response.statusText}`)
  }
  return message
}
</script>

<template>
  <TemplateHeader header-value="Get User's data by Id" />
  <TemplateToInputData dynamic-id="id" labelValue="ID:" v-model="id" :input-class="idClass" />
  <h1></h1>
  <TemplateForButton button-value="Get Data" @clicked="onClick" />
  <TemplateForReturnData :returnData="responseResult.value" />
</template>
