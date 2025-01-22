<template>
  <div>Job Page for job {{ currentJobId }}</div>
</template>

<script setup>
import { computed } from 'vue';

import { onBeforeRouteUpdate, useRoute } from 'vue-router';
const route = useRoute();

const currentJobId = computed(() => {
  return route.params.id;
});

onBeforeRouteUpdate((to, from, next) => {
  console.log('Route is changing...');
  console.log('Current user ID:', currentJobId.value);
  console.log('New user ID:', to.params.id);

  // Cập nhật lại userId khi route thay đổi
  currentJobId.value = to.params.id;

  // Tiếp tục điều hướng
  next();
});
</script>
