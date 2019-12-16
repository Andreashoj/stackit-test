import apiUrl from "./config.json";
import http from "./http";

const apiEndpoint = apiUrl + "/cities";

export function register(city){
  http.post(apiEndpoint, {
    id: city.id,
    name: city.name,
    zipCode: city.zipCode
  });
}