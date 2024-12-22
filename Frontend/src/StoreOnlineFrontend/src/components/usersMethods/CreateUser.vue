<script setup>
import TemplateForButton from './templates/TemplateForButton.vue'
import TemplateForReturnData from './templates/TemplateForReturnData.vue'
import TemplateHeader from './templates/TemplateHeader.vue'
import TemplateToInputData from './templates/TemplateToInputData.vue'
import { ref } from 'vue'

const email = ref('')
const emailClass = ref('')

const phoneNumber = ref('')
const phoneNumberClass = ref('')

const firstName = ref('')
const firstNameClass = ref('')

const lastName = ref('')
const lastNameClass = ref('')

const responseResult = ref('')

function validate() {
  const emailError = validateEmail(email.value)
  const phoneError = validatePhoneNumber(phoneNumber.value)
  const firstNameError = validateNotEmptyStringWithLength(firstName.value, 30)
  const lastNameError = validateNotEmptyStringWithLength(lastName.value, 50)
  let isValid = true
  if (emailError === false) {
    emailClass.value = 'emptyField'
    isValid = false
  } else {
    emailClass.value = ''
  }
  if (phoneError === false) {
    phoneNumberClass.value = 'emptyField'
    isValid = false
  } else {
    phoneNumberClass.value = ''
  }
  if (firstNameError === false) {
    firstNameClass.value = 'emptyField'
    isValid = false
  } else {
    firstNameClass.value = ''
  }
  if (lastNameError === false) {
    lastNameClass.value = 'emptyField'
    isValid = false
  } else {
    lastNameClass.value = ''
  }
  return isValid
}

function onError() {
  console.error(email.value)
  console.error(phoneNumber.value)
  console.error(firstName.value)
  console.error(lastName.value)
}

async function onClick() {
  console.log('clicked')
  if (validate() === true) {
    responseResult.value = await sendCreateUser({
      email: email.value,
      phoneNumber: phoneNumber.value,
      firstName: firstName.value,
      lastName: lastName.value,
    })
    console.log(responseResult.value)
  } else {
    onError()
  }
}

function validateEmail(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  if (email.trim() === '' || !emailRegex.test(email)) {
    console.error('Invalid email address')
    return false
  }
  return true
}
function validatePhoneNumber(phoneNumber) {
  const phoneRegex = /\(?\d{3}\)?-? *\d{3}-? *-?\d{4}/
  if (phoneNumber.trim() !== '' && phoneRegex.test(phoneNumber)) {
    return true
  }
  console.error('Invalid phone number')
  return false
}
function validateNotEmptyStringWithLength(firstName, length, errorMessage) {
  if (firstName.trim() === '' || firstName.length > length) {
    console.error(errorMessage ? errorMessage : `invalid value`)
    return false
  }
  return true
}

async function sendCreateUser(payload) {
  const response = await fetch('http://localhost:5115/api/storeOnline/users/create', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(payload),
  })
  if (response.ok) {
    return await response.json()
  } else {
    console.error(response.statusText)
  }
}
</script>

<template>
  <TemplateHeader header-value="Create New User" />
  <TemplateToInputData
    dynamic-id="email"
    label-value="Email:"
    v-model="email"
    :input-class="emailClass"
  />
  <TemplateToInputData
    dynamic-id="phoneNumber"
    label-value="Phone number:"
    v-model="phoneNumber"
    :input-class="phoneNumberClass"
  />
  <TemplateToInputData
    dynamic-id="firstName"
    label-value="First Name:"
    v-model="firstName"
    :input-class="firstNameClass"
  />
  <TemplateToInputData
    dynamic-id="lastName"
    label-value="Last Name:"
    v-model="lastName"
    :input-class="lastNameClass"
  />
  <TemplateForButton button-value="Create User" @clicked="onClick" />
  <TemplateForReturnData v-if="responseResult" :returnData="responseResult.id" />
</template>
