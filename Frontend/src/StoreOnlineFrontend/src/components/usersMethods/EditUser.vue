<script setup>
import TemplateForButton from '../templates/TemplateForButton.vue'
import TemplateForReturnData from '../templates/TemplateForReturnData.vue'
import TemplateHeader from '../templates/TemplateHeader.vue'
import TemplateToInputData from '../templates/TemplateToInputData.vue'
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

const id = ref('')
const idClass = ref('')

function validate() {
  const emailError = validateEmail(email.value)
  const phoneError = validatePhoneNumber(phoneNumber.value)
  const firstNameError = validateNotEmptyStringWithLength(firstName.value, 30)
  const lastNameError = validateNotEmptyStringWithLength(lastName.value, 50)
  const idError = isValidId(id.value)
  let isValid = true

  if (idError === false) {
    idClass.value = 'emptyField'
    isValid = false
  } else {
    idClass.value = ''
  }

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
  console.error(id.value)
  console.error(email.value)
  console.error(phoneNumber.value)
  console.error(firstName.value)
  console.error(lastName.value)
}

async function onClick() {
  console.log('clicked')
  if (validate() === true) {
    responseResult.value = await sendEditUser({
      id: id.value,
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

async function sendEditUser(payload) {
  const response = await fetch('http://localhost:5115/api/storeOnline/users/update', {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(payload),
  })
  let message = ''
  if (response.status === 200) {
    message = "User's data successfully updated"
  } else {
    console.error(`Error ${response.status}: ${response.statusText}`)
  }
  return message
}

function validateEmail(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  if (!emailRegex.test(email)) {
    console.error('Invalid email address')
    return false
  }
  return true
}
function validatePhoneNumber(phoneNumber) {
  const phoneRegex = /\(?\d{3}\)?-? *\d{3}-? *-?\d{4}/
  if ((phoneNumber.trim() !== '' && phoneRegex.test(phoneNumber)) || phoneNumber === '') {
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

function isValidId(id) {
  const regEx =
    /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/
  return regEx.test(id)
}
</script>
<template>
  <TemplateHeader header-value="Edit User" />

  <TemplateToInputData dynamic-id="id" label-value="Id:" v-model="id" :input-class="idClass" />

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
  <TemplateForButton button-value="Edit User" @clicked="onClick" />
  <TemplateForReturnData v-if="responseResult" :returnData="responseResult" />
</template>
