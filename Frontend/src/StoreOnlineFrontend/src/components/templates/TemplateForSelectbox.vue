<template>
  <label :for="dynamicId"> {{ labelValue }}</label>
  <select :id="dynamicId" v-model="index">
    <option v-for="(value, index) in values" :key="index" :value="value">
      {{ value }}
    </option>
  </select>
</template>
<script setup>
defineProps({
  dynamicId: String,
  labelValue: String,
  values: Array,
})
</script>
