export const ProductCard = ({ product }) => {
  return (
    <div className="group flex flex-col bg-white rounded-lg border border-gray-200 shadow-sm hover:shadow-md transition-all duration-200 overflow-hidden cursor-pointer h-full relative">
      {/* Image */}
      <div className="relative w-full aspect-square bg-gray-100 overflow-hidden">
        <img
          className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
          alt={product.name}
          src={product.image}
        />

        {/* Condition Tag */}
        <div className="absolute top-2 left-2 bg-blue-600/90 backdrop-blur-sm text-white px-2 py-1 rounded text-xs uppercase tracking-wider">
          {product.status}
        </div>

        {/* Favorite */}
        <button className="absolute top-2 right-2 w-8 h-8 rounded-full bg-white/80 backdrop-blur flex items-center justify-center text-gray-600 hover:text-red-500 hover:bg-white transition-all shadow-sm">
          <span className="material-symbols-outlined text-[20px]">
            favorite
          </span>
        </button>
      </div>

      {/* Content */}
      <div className="p-4 flex flex-col flex-1 gap-2">
        {/* Title */}
        <h3 className="text-base font-medium text-gray-900 line-clamp-2 leading-snug group-hover:text-blue-600 transition-colors">
          {product.name}
        </h3>

        {/* Bottom */}
        <div className="mt-auto pt-2 flex flex-col gap-1">
          {/* Price */}
          <span className="text-xl font-bold text-orange-600">
            {product.price.toLocaleString()}đ
          </span>

          {/* Location */}
          <div className="flex items-center gap-1 text-gray-500 text-sm mt-1">
            <span className="material-symbols-outlined text-[14px]">
              location_on
            </span>

            <span className="truncate">{product.location}</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export const ProductCardSkeleton = () => {
  return (
    <div className="flex flex-col bg-white rounded-lg border border-gray-200 overflow-hidden animate-pulse">
      {/* Fake image */}
      <div className="relative w-full aspect-square bg-gray-200">
        {/* Fake status */}
        <div className="absolute top-2 left-2 h-6 w-16 bg-gray-300 rounded"></div>

        {/* Fake favorite */}
        <div className="absolute top-2 right-2 w-8 h-8 rounded-full bg-gray-300"></div>
      </div>

      {/* Content */}
      <div className="p-4 flex flex-col gap-3">
        {/* Fake title */}
        <div className="space-y-2">
          <div className="h-4 bg-gray-200 rounded w-full"></div>
          <div className="h-4 bg-gray-200 rounded w-3/4"></div>
        </div>

        {/* Fake price */}
        <div className="h-6 bg-gray-200 rounded w-1/2 mt-2"></div>

        {/* Fake location */}
        <div className="flex items-center gap-2 mt-1">
          <div className="w-4 h-4 rounded-full bg-gray-200"></div>
          <div className="h-4 bg-gray-200 rounded w-1/3"></div>
        </div>
      </div>
    </div>
  );
};
