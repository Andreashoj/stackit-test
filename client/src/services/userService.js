import apiUrl from "./config.json";
import http from "./http";

const apiEndpoint = apiUrl + "users";

export function register(user){
  http.post(apiEndpoint, {
    username: user.username,
    password: user.password,
    email: user.email
  });
}