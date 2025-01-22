<template>
  <div class="">
    <hr />
    <h1 class="text-[#c026d3] pt-10">Title of the component scoped slot child</h1>
    <div>
       <div class="pb-10 pt-10">

      <slot :message="message"></slot>
      </div>
    </div>
  </div>
</template>

<script setup>
 const message = 'Nội dung truyền từ component con qua scoped slot!';
</script>
