<script setup lang="ts">
import { ref, defineProps } from 'vue'

interface IProps {
  user: IUser
}

const props = defineProps<IProps>()
</script>
<template>
  <h2>User Info</h2>
  <table>
    <tr>
      <td>First Name:</td>
      <td>{{ props.user.firstName }}</td>
    </tr>
    <tr>
      <td>Last Name:</td>
      <td>{{ props.user.lastName }}</td>
    </tr>
    <tr>
      <td>Phone Number:</td>
      <td>{{ props.user.phoneNumber }}</td>
    </tr>
    <tr>
      <td>Email:</td>
      <td>{{ props.user.email }}</td>
    </tr>
  </table>
</template>
