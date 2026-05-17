const ProductCard = ({ product }) => {
  return (
    <div className="bg-surface rounded-lg shadow-ambient hover:shadow-ambient-lg transition-shadow duration-200 overflow-hidden flex flex-col group cursor-pointer border border-surface-container-highest">
      <div className="relative aspect-[4/5] overflow-hidden bg-surface-container">
        <img
          alt="Calculus Textbook"
          className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-300"
          src={product.url}
        />

        {/* Favorite */}
        <div className="absolute top-sm right-sm bg-surface/90 backdrop-blur px-2 py-1 rounded-full flex items-center shadow-sm">
          <span className="material-symbols-outlined text-[16px] text-tertiary">
            favorite_border
          </span>
        </div>

        {/* Condition */}
        <div className="absolute bottom-sm left-sm bg-primary-fixed text-on-primary-fixed-variant px-2 py-1 rounded-md font-caption text-caption font-semibold">
          {product.status}
        </div>
      </div>

      <div className="p-sm flex flex-col flex-grow">
        <div className="flex justify-between items-start mb-1">
          <h3 className="font-headline-md text-[16px] leading-tight text-on-background line-clamp-2">
            {product.name}
          </h3>
        </div>

        <p className="font-body-md text-caption text-on-surface-variant mb-2">
          Math Dept • 2 mins ago
        </p>

        <div className="mt-auto flex justify-between items-center">
          <span className="font-headline-md text-headline-md text-secondary">
            {product.price}
          </span>

          <div className="flex items-center gap-1 text-on-surface-variant">
            <span className="material-symbols-outlined text-[14px]">
              {product.location}
            </span>

            <span className="font-caption text-caption">North Hall</span>
          </div>
        </div>
      </div>
    </div>
  );
};
export default ProductCard;
