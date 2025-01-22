<template>
  <q-page padding>
    <!-- content -->
    <div class="q-pa-md">
      <q-table
        v-model:selected="selected"
        class="my-sticky-dynamic"
        flat
        bordered
        :columns="columns"
        :rows="rows"
        row-key="id"
        virtual-scroll
        :virtual-scroll-item-size="48"
        :virtual-scroll-sticky-size-start="48"
        title="Customers"
        @row-dblclick="onRowDblClick"
      >
        <template #top>
          <q-btn @click="addCustomerClickHandler"> Add customer </q-btn>
        </template>
        <template #body-cell-actions="props">
          <q-td :props="props">
            <q-btn icon="mode_edit" @click="onEdit(props.row)"></q-btn>
            <q-btn
              icon="delete"
              @click="onDelete(props.row, props.rowIndex)"
            ></q-btn>
          </q-td>
        </template>
      </q-table>
    </div>
  </q-page>
</template>
<script setup>
import { ref, onMounted, watch } from "vue";
import { useRouter } from "vue-router";
import customerService from "../../services/customer/CustomerService";
const router = useRouter();
const columns = [
  {
    name: "id",
    required: true,
    label: "id",
    align: "center",
    field: (row) => row.id,
    format: (val) => `${val}`,
    sortable: true,
  },
  {
    name: "customerName",
    align: "left",
    label: "Customer Name",
    field: "customerName",
    sortable: true,
  },
  {
    name: "contactName",
    align: "left",
    label: "Contact name",
    field: "contactName",
    sortable: true,
  },
  {
    name: "address",
    align: "left",
    label: "Address",
    field: "address",
    sortable: true,
  },
  { name: "city", align: "left", label: "City", field: "city", sortable: true },
  {
    name: "country",
    align: "left",
    label: "Country",
    field: "country",
    sortable: true,
  },
  {
    name: "postalCode",
    align: "left",
    label: "Postal Code",
    field: "postalCode",
    sortable: true,
  },
  {
    name: "actions",
  },
];
const rows = ref([]);
const selected = ref([]);

//onMounted
onMounted(() => {
  getAll();
});

//watch
watch(selected, (newselected) => {
  console.log(`selected is ${newselected}`);
});
function addCustomerClickHandler() {
  router.push({
    name: "customer",
    params: { id: 0 },
  });
}

function getAll() {
  customerService.getAll().then((res) => {
    rows.value = res.data;
  });
}

//methods
function onRowDblClick(evt, row) {
  console.log("clicked on:", row.id);
  router.push({
    name: "customer",
    params: { id: row.id },
  });
}

//methods
function onEdit(row) {
  router.push({
    name: "customer",
    params: { id: row.id },
  });
}

//methods
function onDelete(row, index) {
  customerService.delete(row.id);
  this.rows.splice(index, 1);
}
</script>
