<template>
  <header :class="['w-full', 'text-sm', headerHeightClass]">
    <div class="fixed left-0 top-0 h-16 w-full bg-white">
      <div class="mx-auto flex h-full flex-nowrap border-b border-solid border-brand-gray-1 px-8">
        <router-link :to="{ name: 'Home' }" class="flex h-full items-center text-xl"
          >Bobo Careers
        </router-link>

        <nav class="ml-12 h-full">
          <ul class="flex h-full list-none">
            <li v-for="menuItem in menuItems" :key="menuItem.text" class="ml-9 h-full first:ml-0">
              <router-link :to="menuItem.url" class="flex h-full items-center py-2.5">{{
                menuItem.text
              }}</router-link>
            </li>
          </ul>
        </nav>

        <div class="ml-auto flex h-full items-center">
          <!-- Demo directives v-if -->
          <div v-if="appStore.isLoggedIn" class="flex items-center" >
            pinia getters DoubleCount: {{ appStore.doubleCount }}
            <profile-image />
            <action-button type="secondary" text="Logout" @click="appStore.logoutUser" />
          </div>
          <action-button v-else text="Sign in" @click="appStore.loginUser" />
        </div>
      </div>

      <the-subnav v-if="appStore.isLoggedIn" />
    </div>
  </header>
</template>

<script setup>
import ActionButton from "@/components/Shared/ActionButton.vue";
import ProfileImage from "@/components/Navigation/ProfileImage.vue";
import TheSubnav from "@/components/Navigation/TheSubnav.vue";
import { computed } from 'vue';

// Demo pinia: actions, states
import { useAppStore } from '@/stores/app-store';
const appStore  = useAppStore();

const menuItems = [
  { text: 'Slot Demo', url: '/slot' },
  { text: 'Demo Hook Lifecycle component 1', url: '/jobs/results/1' },
  { text: 'Demo Hook Lifecycle component 2', url: '/jobs/results/2' },
  { text: 'Demo Route-Specific Navigation Guards 3', url: '/jobs/results/3' },
  { text: 'Jobs', url: '/jobs/results' },
];

//Demo computed
const headerHeightClass = computed(() => {
return {
        "h-16": !appStore.isLoggedIn,
        "h-32": appStore.isLoggedIn,
      };
});
</script>
