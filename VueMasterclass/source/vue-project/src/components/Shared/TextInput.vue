<template>
  <input
    type="text"
    :value="modelValue"
    class="w-full text-lg font-normal focus:outline-none"
    @input="handleInput"
  />
</template>

<script setup>

//Demo props
// eslint-disable-next-line no-unused-vars
const props = defineProps({
   modelValue: {
      type: String,
      required: true,
    },
})

const emit = defineEmits(["update:modelValue"]);

//Demo emit
function handleInput($event) {
  emit("update:modelValue", $event.target.value);
};

// export default {
//   name: "TextInput",
//   props: {
//     modelValue: {
//       type: String,
//       required: true,
//     },
//   },
//   emits: ["update:modelValue"],
//   methods: {
//     handleInput($event) {
//       this.$emit("update:modelValue", $event.target.value);
//     },
//   },
// };
</script>
