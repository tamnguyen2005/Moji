import { useParams } from "react-router-dom";
import api from "./Config";
export const GetPost = async () => {
  var response = await api.get("/Post");
  return response;
};
export const GetPostByCategoryId = async (id) => {
  var response = await api.get(`/Post?categoryId=${id}`);
  return response;
};
export const GetPostWithQuery = async (categoryId, universityId) => {
  const searchParams = new URLSearchParams();
  if (categoryId) {
    searchParams.append("categoryId", categoryId);
  }

  const normalizeIds = (value) =>
    String(value)
      .split("||")
      .map((id) => id.trim())
      .filter(Boolean);

  if (universityId) {
    const ids = Array.isArray(universityId)
      ? universityId.flatMap((value) => normalizeIds(value))
      : normalizeIds(universityId);
    ids.forEach((id) => searchParams.append("universityId", id));
  }

  const response = await api.get(`/Post?${searchParams.toString()}`);
  return response;
};
