import http from "../http-common";

class CustomerService {
  getAll() {
    return http.get("/customer/list");
  }

  get(id) {
    return http.get(`/customer/getcustomer/${id}`);
  }

  insert(data) {
    console.log(data);
    return http.post(`/customer/insert`, data);
  }

  update(data) {
    return http.post(`/customer/update`, data);
  }

  delete(id) {
    return http.delete(`/customer/delete/${id}`);
  }
}

export default new CustomerService();
