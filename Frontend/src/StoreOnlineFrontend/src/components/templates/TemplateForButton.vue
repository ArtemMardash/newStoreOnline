<script setup>
const props = defineProps({
  buttonValue: String,
})
const emits = defineEmits(['clicked'])
</script>
<template>
  <div class="button">
    <button type="button" id="someButton" @click="emits('clicked')">
      {{ props.buttonValue }}
    </button>
  </div>
</template>

<style>
.button {
  width: 30%;
  align-content: center;
}
</style>
