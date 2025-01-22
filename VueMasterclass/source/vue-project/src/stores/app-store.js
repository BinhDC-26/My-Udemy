// store/app-store.js
import { defineStore } from 'pinia';

export const useAppStore = defineStore('appStore', {
  state: () => {
    return {
      isLoggedIn: false,
      count: 2,
    };
  },
  actions: {
    //Demo pinia
    loginUser() {
      console.log("runing: pinia action loginUser()");
      this.isLoggedIn = true;
      this.count++;
    },

    logoutUser() {
      console.log("runing: pinia action logoutUser()");
      this.isLoggedIn = false;
      this.count++;
    },
  },
  getters: {
    // Các thuộc tính tính toán từ state, tương tự như computed properties.
    doubleCount: (state) => state.count * 2,
  },
});
