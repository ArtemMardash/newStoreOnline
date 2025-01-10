<script setup lang="ts">
import { ref, defineProps } from 'vue'

interface IProps {
  order: IOrder
}

const props = defineProps<IProps>()
</script>
<template>
  <h2>Order Info</h2>
  <table>
    <tr>
      <td>System Id</td>
      <td>{{ props.order.systemId }}</td>
    </tr>
    <tr>
      <td>Public Id</td>
      <td>{{ props.order.publicId }}</td>
    </tr>
    <tr>
      <td>Delivery Type</td>
      <td>{{ props.order.deliveryType }}</td>
    </tr>
    <tr>
      <td>System User Id</td>
      <td>{{ props.order.systemUserId }}</td>
    </tr>
    <tr>
      <td>Public User Id</td>
      <td>{{ props.order.publicUserId }}</td>
    </tr>
  </table>
  <h2>Products in order</h2>
  <table v-for="(product, index) in props.order.products">
    <tr>
      <td>System Id:</td>
      <td>{{ product.systemId }}</td>
    </tr>
    <tr>
      <td>Public Id:</td>
      <td>{{ product.publicId }}</td>
    </tr>
    <tr>
      <td>Price:</td>
      <td>{{ product.price }}</td>
    </tr>
    <tr>
      <td>Quantity:</td>
      <td>{{ product.quantity }}</td>
    </tr>
    <hr />
  </table>
</template>
