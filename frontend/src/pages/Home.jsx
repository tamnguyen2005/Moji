import { useEffect, useState } from "react";
import { GetPost } from "../Api/Post";
import { GetCategory } from "../Api/Category";
import { ProductCard, ProductCardSkeleton } from "../components/ProductCard";
import { CategoryCard, CategoryCardSkeleton } from "../components/CategoryCard";

const Home = () => {
  const [post, setPost] = useState([]);
  const [category, setCategory] = useState([]);
  const [isLoadingPost, setLoadingPost] = useState(true);
  const [isLoadingCategory, setLoadingCategory] = useState(true);
  useEffect(() => {
    const fetchPost = async () => {
      const response = await GetPost();
      setPost(response.data.items);
      setLoadingPost(false);
    };
    const fetchCategory = async () => {
      const response = await GetCategory();
      setCategory(response.data);
      setLoadingCategory(false);
    };
    fetchCategory();
    fetchPost();
  }, []);
  return (
    <>
      <main className="w-full max-w-[1280px] mx-auto px-margin-mobile md:px-margin-desktop py-lg">
        {/* Hero Section */}
        <section className="relative bg-surface-container-low rounded-xl overflow-hidden mb-xl shadow-ambient">
          <div className="absolute inset-0 z-0">
            <img
              alt="Campus background"
              className="w-full h-full object-cover opacity-20"
              src="https://lh3.googleusercontent.com/aida-public/AB6AXuBc_V0ywVHOrnNum07E8OB6d_Daxy9-Q4SdmoBhS0IxxOPi4iMSh0C4mcH6gBIP4RQtcr7uOQdbl8tIYMHldywVbtZyaOsovQJ14kFtcOB7CV7_YMqd-aKkPUWcoT6zDiccWMgFu7RAFMMs_F0p9AEPPM7G5CY66eOc-C2Vkyy26OLTLYpRbfk5Hc-2T5HE22sPKKbEuicMjj8XeaMQhMbVQZobz19U_xF7iy-rh_NMjCw02UwNIgdoRM53vFNlq19WW9kJcrck3QLg"
            />

            <div className="absolute inset-0 bg-gradient-to-r from-surface-container-low via-surface-container-low/90 to-transparent"></div>
          </div>

          <div className="relative z-10 p-lg md:p-[80px] flex flex-col items-start max-w-2xl">
            <h1 className="font-display-lg text-display-lg text-on-background mb-sm">
              Trade Smart. <br />
              <span className="text-primary">Campus Life Made Easy.</span>
            </h1>

            <p className="font-body-lg text-body-lg text-on-surface-variant mb-lg">
              The trusted marketplace exclusively for your university. Buy,
              sell, and trade securely with your fellow students.
            </p>

            {/* Search */}
            <div className="w-full relative shadow-ambient-lg rounded-full">
              <span className="material-symbols-outlined absolute left-sm top-1/2 -translate-y-1/2 text-outline">
                search
              </span>

              <input
                className="w-full bg-surface py-[16px] pl-[48px] pr-[120px] rounded-full border border-outline-variant focus:border-primary focus:ring-1 focus:ring-primary outline-none font-body-md text-body-md transition-all text-on-surface placeholder:text-outline"
                placeholder="Search textbooks, dorm decor, bikes..."
                type="text"
              />

              <button className="absolute right-xs top-xs bottom-xs bg-secondary-container text-on-secondary-container px-md rounded-full font-label-md text-label-md hover:bg-secondary transition-colors shadow-sm">
                Search
              </button>
            </div>
          </div>
        </section>

        {/* Categories */}
        <section className="mb-xl">
          <div className="flex justify-between items-end mb-md">
            <h2 className="font-headline-lg text-headline-lg text-on-background">
              Explore Categories
            </h2>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-md h-auto md:h-[240px]">
            {/* CategoryCard component */}
            {isLoadingCategory
              ? Array.from({ length: 3 }).map((_, i) => (
                  <CategoryCardSkeleton key={i} />
                ))
              : category.map((c) => <CategoryCard key={c.id} category={c} />)}
          </div>
        </section>

        {/* Products */}
        <section>
          <div className="flex justify-between items-center mb-md">
            <h2 className="font-headline-lg text-headline-lg text-on-background">
              Fresh on Campus
            </h2>

            <button className="font-label-md text-label-md text-primary flex items-center gap-1 hover:text-primary-fixed-variant transition-colors">
              View All
              <span className="material-symbols-outlined text-[18px]">
                arrow_forward
              </span>
            </button>
          </div>

          <div className="grid grid-cols-2 lg:grid-cols-4 gap-gutter md:gap-md">
            {/* ProductCard component */}
            {isLoadingPost
              ? Array.from({ length: 4 }).map((_, i) => (
                  <ProductCardSkeleton key={i} />
                ))
              : post.map((p) => <ProductCard key={p.id} product={p} />)}
          </div>
        </section>
      </main>

      {/* Mobile Bottom Nav */}
      <nav className="md:hidden docked full-width bottom-0 z-50 bg-surface shadow-[0_-2px_10px_rgba(0,0,0,0.08)] fixed w-full flex justify-around items-center px-4 py-3">
        {/* Active Tab */}
        <a
          className="flex flex-col items-center justify-center text-secondary font-bold hover:bg-surface-container-low transition-all active:scale-95 duration-150 w-16 rounded-lg p-1"
          href="#"
        >
          <span
            className="material-symbols-outlined"
            style={{ fontVariationSettings: "'FILL' 1" }}
          >
            home
          </span>

          <span className="font-label-md text-[10px] mt-1">Home</span>
        </a>

        {/* Search */}
        <a
          className="flex flex-col items-center justify-center text-on-surface-variant hover:bg-surface-container-low transition-all active:scale-95 duration-150 w-16 rounded-lg p-1"
          href="#"
        >
          <span className="material-symbols-outlined">search</span>

          <span className="font-label-md text-[10px] mt-1">Search</span>
        </a>

        {/* Sell Button */}
        <a
          className="flex flex-col items-center justify-center -mt-6 active:scale-95 duration-150 group"
          href="#"
        >
          <div className="bg-secondary-container text-on-secondary-container rounded-full p-3 shadow-ambient-lg group-hover:bg-secondary transition-colors">
            <span className="material-symbols-outlined text-[28px]">
              add_circle
            </span>
          </div>

          <span className="font-label-md text-[10px] mt-1 text-on-surface-variant font-bold">
            Sell
          </span>
        </a>

        {/* Messages */}
        <a
          className="flex flex-col items-center justify-center text-on-surface-variant hover:bg-surface-container-low transition-all active:scale-95 duration-150 w-16 rounded-lg p-1 relative"
          href="#"
        >
          <span className="material-symbols-outlined">chat_bubble</span>

          <span className="absolute top-1 right-3 w-2 h-2 bg-error rounded-full"></span>

          <span className="font-label-md text-[10px] mt-1">Messages</span>
        </a>

        {/* Profile */}
        <a
          className="flex flex-col items-center justify-center text-on-surface-variant hover:bg-surface-container-low transition-all active:scale-95 duration-150 w-16 rounded-lg p-1"
          href="#"
        >
          <span className="material-symbols-outlined">person</span>

          <span className="font-label-md text-[10px] mt-1">Profile</span>
        </a>
      </nav>
    </>
  );
};
export default Home;
