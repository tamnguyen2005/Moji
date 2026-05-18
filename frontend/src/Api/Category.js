import api from "./Config";
export const GetCategory = async () => {
  var response = await api.get("/Category");
  return response;
};
