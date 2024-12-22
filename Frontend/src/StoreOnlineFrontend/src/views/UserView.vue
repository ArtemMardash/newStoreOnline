<script setup>
//import TheWelcome from '../components/TheWelcome.vue'
import GetUserById from '@/components/usersMethods/GetUserById.vue'
import CreateUser from '../components/usersMethods/CreateUser.vue'
import EditUser from '../components/usersMethods/EditUser.vue'
import { ref } from 'vue'

const selected = ref('create')

function selectPage(input) {
  if (input === 'create') {
    selected.value = 'create'
  } else if (input === 'get') {
    selected.value = 'get'
  } else if (input === 'edit') {
    selected.value = 'edit'
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
          <a href="#create-user" @click="selectPage('create')">Create User</a>
        </li>
        <li>
          <a href="#get-user" @click="selectPage('get')">Get User By Id</a>
        </li>
        <li>
          <a href="#edit-user" @click="selectPage('edit')">Edit User</a>
        </li>
      </ul>
    </div>
    <div>
      <CreateUser v-if="selected === 'create'" />
      <EditUser v-if="selected === 'edit'" />
      <GetUserById v-if="selected === 'get'" />
    </div>
  </main>
</template>
