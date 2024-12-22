<template>
  <div class="row">
    <div class="labels">
      <label :for="dynamicId">
        {{ labelValue }}
      </label>
    </div>
    <div class="inputs">
      <input type="text" :id="dynamicId" v-model="text" :class="inputClass" />
    </div>
  </div>
</template>

<script setup>
// const props =defineProps({
//   dynamicId: String,
//   labelValue: String,
//   text: String,
// })
</script>

<script>
export default {
  props: { dynamicId: String, labelValue: String, modelValue: String, inputClass: String },
  data() {
    return { text: this.modelValue }
  },
  watch: {
    text(newValue) {
      this.$emit('update:modelValue', newValue)
    },
  },
}
</script>
<style>
.row {
  margin: 10px;
}

.labels {
  width: 50%;
  float: left;
}

.inputs {
  width: 30%;
  align-content: center;
}
.emptyField {
  border-color: red;
}
</style>
