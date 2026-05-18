import api from "./Config";
export const GetPost = async () => {
  var response = await api.get("/Post");
  return response;
};
export const GetPostByCategoryId = async (id) => {
  var response = await api.get(`/Post?categoryId=${id}`);
  return response;
};
