<template>
  <q-page padding>
    <!-- <div class="q-pb-md">
      <q-btn icon="arrow_back" class="!border-none" @click="backToList">
        Go back
      </q-btn>
    </div> -->
    <q-form class="q-gutter-md" @submit="onSubmit" @reset="onReset">
      <q-input
        v-model="customerModel.customerName"
        filled
        label="Customer name"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />

      <q-input
        v-model="customerModel.contactName"
        filled
        label="Contact name"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />
      <q-input
        v-model="customerModel.city"
        filled
        label="City"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />
      <q-input
        v-model="customerModel.address"
        filled
        label="Address"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />
      <q-input
        v-model="customerModel.country"
        filled
        label="Country"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />
      <q-input
        v-model="customerModel.postalCode"
        filled
        label="Postal Code"
        lazy-rules
        :rules="[(val) => (val && val.length > 0) || 'Please type something']"
      />
      <div>
        <q-btn label="Submit" type="submit" color="primary" />
        <q-btn
          label="Reset"
          type="reset"
          color="primary"
          flat
          class="q-ml-sm"
        />
      </div>
    </q-form>
  </q-page>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import customerService from "../../services/customer/CustomerService";
import { CustomerModel } from "../../model/CustomerModel";
const route = useRoute();
const emits = defineEmits(["changeToList"]);

let customerModel = ref<CustomerModel>({
  id: 0,
  address: "",
  city: "",
  contactName: "",
  country: "",
  customerName: "",
  postalCode: "",
});

const backToList = () => {
  emits("changeToList");
};

onMounted(() => {
  if (route.params.id != "0") {
    getCustomer(route.params.id);
  }
});

function getCustomer(id) {
  customerService
    .get(id)
    .then((response) => {
      customerModel.value = response.data;
    })
    .catch((e) => {
      console.log(e);
    });
}

function onSubmit() {
  if (customerModel.value.id > 0) customerService.update(customerModel.value);
  else customerService.insert(customerModel.value);
}

function onReset() {
  console.log("onReset");
}
</script>
