export const CategoryCard = ({ category }) => {
  return (
    <div className="relative overflow-hidden rounded-xl group h-full min-h-[240px] cursor-pointer">
      <div className="absolute inset-0 bg-gradient-to-t from-black/80 to-transparent z-10"></div>

      <img
        alt={category.name}
        className="absolute inset-0 w-full h-full object-cover group-hover:scale-105 transition-transform duration-500 z-0"
        src={category.image}
      />

      <div className="relative z-20 h-full flex items-end p-4">
        <h3 className="text-white text-xl font-semibold">{category.name}</h3>
      </div>
    </div>
  );
};
export const CategoryCardSkeleton = () => {
  return (
    <div className="relative overflow-hidden rounded-xl h-full min-h-[240px] bg-gray-200 animate-pulse">
      {/* Fake image */}
      <div className="absolute inset-0 bg-gray-300"></div>

      {/* Fake gradient */}
      <div className="absolute inset-0 bg-gradient-to-t from-gray-400/60 to-transparent"></div>

      {/* Fake title */}
      <div className="relative h-full flex items-end p-4">
        <div className="h-6 w-32 bg-gray-100 rounded"></div>
      </div>
    </div>
  );
};
