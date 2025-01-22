<template>
  <!-- content -->
  <q-page id="registrationPage">
    <q-toolbar class="text-white bg-teal">
      <q-toolbar-title> Register </q-toolbar-title>
      <q-btn flat round dense icon="more_vert" />
    </q-toolbar>

    <q-scroll-area class="form-style">
      <div class="text-h6 text-center q-mt-md">
        <q-img src="../../../logo.png" height="60px" width="60px" />
        <div>DemoNop</div>
      </div>
    </q-scroll-area>
  </q-page>
</template>

<script>
export default {
  // name: 'PageName',
};
</script>
<style lang="scss">
#registrationPage {
  .form-style {
    margin: 0 auto;
    height: calc(100vh - 180px);
    max-width: 500px;
  }

  @media (min-width: $breakpoint-sm-max) {
    .form-style {
      margin: 0 auto;
      height: calc(100vh - 100px);
      max-width: 500px;
    }
  }
}
</style>
