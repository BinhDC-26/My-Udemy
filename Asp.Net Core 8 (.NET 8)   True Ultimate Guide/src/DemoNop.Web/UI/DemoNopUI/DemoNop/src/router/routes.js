const routes = [
  {
    path: "/",
    component: () => import("layouts/MainLayout.vue"),
    children: [
      {
        path: "/route",
        component: () => import("pages/RoutePage.vue"),
        children: [
          {
            path: "",
            component: () => import("pages/route/RouteSelect.vue"),
          },
        ],
      },
      {
        path: "/auth",
        component: () => import("pages/AuthPage.vue"),
        children: [
          {
            path: "",
            component: () => import("pages/auth/LoginSection.vue"),
          },
          {
            path: "register",
            component: () => import("pages/auth/RegisterSection.vue"),
          },
        ],
      },
      {
        path: "customer",
        component: () => import("pages/CustomerPage.vue"),
        children: [
          {
            path: "",
            component: () => import("pages/customer/CustomerListPage.vue"),
          },
          {
            path: "/:id",
            name: "customer",
            component: () => import("pages/customer/CustomerDetailPage.vue"),
          },
        ],
      },
    ],
  },
  // Always leave this as last one,
  // but you can also remove it
  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
