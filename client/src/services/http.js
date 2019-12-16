import axios from "axios";

axios.defaults.headers.get["Access-Control-Allow-Origin"] = "*";

axios.interceptors.response.use(null, error => {
  const expectedError =
    error.response &&
    error.response.status >= 400 &&
    error.response.status < 500;

  if (!expectedError) {
    console.log("logging the error:", error);
  }
  return Promise.reject(error);
});

export default {
  get: function getData(endpoint, token) {
    return axios
      .get(endpoint, {
        headers: { Authorization: `Bearer ${token}` }
      })
      .then(res => res.data)
      .catch(e => console.log(e));
  },
  post: function postData(endpoint, token, body) {
    return axios
      .post(endpoint, body, { headers: { Authorization: `Bearer ${token}` } })
      .then(res => res.data)
      .catch(e => console.log(e));
  }
};
