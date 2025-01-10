<script setup>
defineProps({
  returnData: String,
})
</script>
<template>
  <div class="comment" id="comment">
    <h3>
      {{ returnData }}
    </h3>
  </div>
</template>
<style>
.comment {
  width: 100%;
  align-content: left;
}
</style>
