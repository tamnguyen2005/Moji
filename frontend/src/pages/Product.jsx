import { useEffect, useState } from "react";
import SideBar from "../components/SideBar";
import { ProductCard, ProductCardSkeleton } from "../components/ProductCard";
import { useSearchParams } from "react-router-dom";
import { GetPostWithQuery } from "../Api/Post";
const Product = () => {
  const [post, setPost] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [searchParam] = useSearchParams();
  const categoryId = searchParam.get("categoryId");
  const universityId = searchParam.getAll("universityId");
  const categoryName = searchParam.get("categoryName");
  const universityIdKey = universityId.join(",");

  useEffect(() => {
    GetPostWithQuery(categoryId, universityId);
    console.log({ categoryId, universityId });
  }, [categoryId, universityIdKey]);
  return (
    <main className="w-full max-w-7xl mx-auto px-4 md:px-6 py-6">
      <div className="flex gap-6 items-start">
        {/* Sidebar */}
        <SideBar />

        {/* Right content */}
        <section className="flex-1 flex flex-col gap-6">
          {/* Header */}
          <div className="flex items-center justify-between">
            <div>
              <h1 className="text-3xl font-bold text-gray-900">
                {categoryName}
              </h1>
              <p className="text-gray-500 mt-1">Hiển thị 124 kết quả</p>
            </div>

            <select className="border border-gray-300 rounded-lg px-4 py-2 text-sm outline-none focus:border-blue-500">
              <option>Mới nhất</option>
              <option>Giá tăng dần</option>
              <option>Giá giảm dần</option>
            </select>
          </div>

          {/* Product grid */}
          <div className="grid grid-cols-2 lg:grid-cols-3 gap-4 md:gap-6">
            {isLoading
              ? Array.from({ length: 6 }).map((_, i) => (
                  <ProductCardSkeleton key={i} />
                ))
              : post.map((p) => <ProductCard key={p.id} product={p} />)}
          </div>
        </section>
      </div>
    </main>
  );
};
export default Product;
