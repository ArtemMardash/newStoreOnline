<script setup>
import TemplateForButton from '../templates/TemplateForButton.vue'
import TemplateForReturnData from '../templates/TemplateForReturnData.vue'
import TemplateForSelectbox from '../templates/TemplateForSelectbox.vue'
import TemplateHeader from '../templates/TemplateHeader.vue'
import TemplateToInputData from '../templates/TemplateToInputData.vue'
import { ref } from 'vue'

const deliveryTypes = ['Not Selected', 'PickUp', 'Terminal', 'Courier']
const deliveryType = ref('')
const deliveryTypeClass = ref('')

const systemId = ref('')
const systemIdClass = ref('')

const publicId = ref('')
const publicIdClass = ref('')

const price = ref('')
const priceClass = ref('')

const quantity = ref('')
const quantityClass = ref('')

const systemUserId = ref('')
const systemUserIdClass = ref('')

const publicUserId = ref('')
const publicUserIdClass = ref('')

const responseResult = ref('')

function validate() {
  const deliveryTypeIsError = validateDeliveryType(deliveryType.value)
  const systemIdIsError = isValidId(systemId.value)
  const systemUserIdIsError = isValidId(systemUserId.value)
  const publicIdIsError = validatePublicId(publicId.value)
  const publicUserIdIsError = validatePublicId(publicUserId.value)
  const priceIsError = validateNumbers(price.value)
  const quantityIsError = validateNumbers(quantity.value)
  let isValid = true

  if (deliveryTypeIsError === false) {
    deliveryTypeClass.value = 'emptyField'
    isValid = false
  } else {
    deliveryTypeClass.value = ''
  }
  if (systemIdIsError === false) {
    systemIdClass.value = 'emptyField'
    console.error('Invalid System Id')
    isValid = false
  } else {
    systemIdClass.value = ''
  }

  if (systemUserIdIsError === false) {
    systemUserIdClass.value = 'emptyField'
    console.error('Invalid System User id')
    isValid = false
  } else {
    systemUserIdClass.value = ''
  }

  if (publicIdIsError === false) {
    publicIdClass.value = 'emptyField'
    console.error('Invalid Public Id')
    isValid = false
  } else {
    publicIdClass.value = ''
  }

  if (publicUserIdIsError === false) {
    publicUserIdClass.value = 'emptyField'
    console.error('Invalid publicUser Id')
    isValid = false
  } else {
    publicUserIdClass.value = ''
  }

  if (priceIsError === false) {
    priceClass.value = 'emptyField'
    console.error('Invalid price')
    isValid = false
  } else {
    priceClass.value = ''
  }

  if (quantityIsError === false) {
    quantityClass.value = 'emptyField'
    console.error('Invalid quantity')
    isValid = false
  } else {
    quantityClass.value = ''
  }

  return isValid
}

function onError() {
  console.error(deliveryType.value)
  console.error(publicId.value)
  console.error(systemId.value)
  console.error(quantity.value)
  console.error(price.value)
  console.error(systemUserId.value)
  console.error(publicUserId.value)
}

async function onClick() {
  console.log('clicked')
  if (validate() === true) {
    responseResult.value = await sendCreateOrder({
      deliveryType: deliveryType.value,
      products: [
        {
          systemId: systemId.value,
          publicId: publicId.value,
          price: price.value,
          quantity: quantity.value,
        },
      ],
      systemUserId: systemUserId.value,
      publicUserId: publicUserId.value,
    })
    console.log(responseResult.value)
  } else {
    onError()
  }
}

async function sendCreateOrder(payload) {
  const response = await fetch('http://localhost:5116/api/orders/create', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(payload),
  })
  if (response.ok) {
    const formattedMessage = response.json
      .replace(/^{|}$/g, '')
      .replace(/"/g, '')
      .split(',')
      .join('\n')
    return formattedMessage
  } else {
    console.error(response.statusText)
  }
}

function validateDeliveryType(deliveryType) {
  if (deliveryType === '1' || deliveryType === '2' || deliveryType === '3') {
    return true
  } else {
    console.error('Invalid delivery type')
    return false
  }
}

function validateNumbers(input) {
  const regEx = /^[1-9]\d*$/
  return regEx.test(input)
}

function validatePublicId(input) {
  const regEx = /^[a-z]{3}-\d{6}-\d{4}$/
  return regEx.test(input)
}

function isValidId(id) {
  const regEx =
    /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/
  return regEx.test(id)
}
</script>

<template>
  <TemplateHeader header-value="Create New Order" />
  <TemplateToInputData
    dynamic-id="deliveryType"
    label-value="DeliveryType:"
    v-model="deliveryType"
    :input-class="deliveryTypeClass"
  />
  <TemplateForSelectbox
    dynamic-id="SelectDelivery"
    label-value="Select Delivery Type"
    :values="deliveryTypes"
  />
  <TemplateToInputData
    dynamic-id="systemId"
    label-value="Product System Id:"
    v-model="systemId"
    :input-class="systemIdClass"
  />
  <TemplateToInputData
    dynamic-id="publicId"
    label-value="Product Public Id:"
    v-model="publicId"
    :input-class="publicIdClass"
  />
  <TemplateToInputData
    dynamic-id="price"
    label-value="Product Price:"
    v-model="price"
    :input-class="priceClass"
  />
  <TemplateToInputData
    dynamic-id="quantity"
    label-value="Product Quantity:"
    v-model="quantity"
    :input-class="quantityClass"
  />
  <TemplateToInputData
    dynamic-id="systemUserId"
    label-value="System User Id:"
    v-model="systemUserId"
    :input-class="systemUserIdClass"
  />
  <TemplateToInputData
    dynamic-id="publicUserId"
    label-value="Public User Id:"
    v-model="publicUserId"
    :input-class="publicUserIdClass"
  />
  <TemplateForButton button-value="Create Order" @clicked="onClick" />

  <TemplateForReturnData v-if="responseResult" :returnData="responseResult.id" />
</template>
