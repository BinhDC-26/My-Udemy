<template>
  <div class="">
    <hr />
    <h1 class="text-[#0ea5e9]">Title of the component Named Slot child</h1>
    <div>
      <!-- Named Slots -->
      <div class="pb-10 pt-10">
        <slot name="slotNo1"></slot>
        <!-- Slot với tên 'slotNo1' -->
        <slot name="slotNo2"></slot>
      </div>
    </div>
  </div>
</template>

<script setup>
</script>
