import http from "./http";
import apiUrl from "./config.json";

//Skift endpointet i config
const apiEndpoint = apiUrl.apiEndpoint + "/auth";

export function login(email, password){
  return http.post(apiEndpoint, {email, password})
}
