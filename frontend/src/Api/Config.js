import axios from "axios";
const api = axios.create({
  baseURL: "https://localhost:7158/api",
});
export default api;
