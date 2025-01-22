<template>
  <div class="flex h-screen flex-col p-20">
    <p class="pb-10 text-[#b91c1c]">Title component parent: Demo slot</p>

    <!-- Demo dèault slot -->
    <default-slot-child>
      <p>Nội dung truyền từ component cha vào component con DefaultSlotChild.</p>
      <template v-slot:slotNo1>
        <h2>Nội dung truyền vào slot có tên: 'slotNo1'</h2>
      </template>
    </default-slot-child>

    <!-- Demo named slot -->
    <named-slot-child>
      <p>Nội dung truyền từ component cha vào component con NamedSlotChild.</p>
      <template v-slot:slotNo1>
        <p>Nội dung truyền vào slot có tên: 'slotNo1'</p>
      </template>
      <template v-slot:slotNo2>
        <hr />
        <h2>Nội dung truyền vào slot có tên: 'slotNo2'</h2>
      </template>
    </named-slot-child>

    <!-- Demo scoped slot -->
     <scoped-slot-child v-slot:default="{ message }">
      {{
        message
      }}
    </scoped-slot-child>
  </div>
</template>

<script setup>
import DefaultSlotChild from '@/components/Slot/DefaultSlotChild.vue';
import NamedSlotChild from '@/components/Slot/NamedSlotChild.vue';
import ScopedSlotChild from '@/components/Slot/ScopedSlotChild.vue';
</script>
