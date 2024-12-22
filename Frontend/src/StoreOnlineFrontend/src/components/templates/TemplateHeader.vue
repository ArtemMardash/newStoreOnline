<script setup>
defineProps({
  headerValue: String,
})
</script>
<template>
  <div class="header">
    <h2>
      {{ headerValue }}
    </h2>
  </div>
</template>
<style>
.header {
  width: 75%;
  align-content: center;
}
</style>
