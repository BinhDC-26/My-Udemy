<template>
  <section class="mb-16">
    <h1 class="mb-14 text-8xl font-bold tracking-tighter">
      <span :class="actionClasses">{{ action }}</span>
      <br />
      for everyone
    </h1>
    <h2 class="text-3xl font-light">Find your next job at Bobo Corp.</h2>
  </section>
</template>

<script setup>
import { computed, onBeforeMount, onBeforeUnmount, ref } from 'vue';

import nextElementInList from "@/utils/nextElementInList";

let action = ref("Build")
let interval = ref()

const changeTitle = () => {
  interval.value = setInterval(() => {
    const actions = ["Build", "Create", "Design", "Code"];
    action.value = nextElementInList(actions, action.value);
  }, 3000);

};
// Demo computed properties
const actionClasses = computed(()=>{
  return {
    [action.value.toLowerCase()]: true,
  };
});

// Demo lifecycle: onBeforeMount
// Composition API không có hook created, sử dụng onBeforeMount thay thế
// Tương tự hook 'created' trong Options API
onBeforeMount(() => {
  console.log("lifecycle: onBeforeMount");
  changeTitle();

});

// Demo lifecycle: onBeforeUnmount
onBeforeUnmount(()=>{
  console.log("lifecycle: onBeforeUnmount");
  clearInterval(interval.value);

});

</script>

<style scoped>
.build {
  color: #1a73e8;
}

.create {
  color: #34a853;
}

.design {
  color: #f9ab00;
}

.code {
  color: #d93025;
}
</style>
