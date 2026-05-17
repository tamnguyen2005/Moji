const CategoryCard = ({ category }) => {
  return (
    <>
      <div className="absolute inset-0 bg-gradient-to-t from-on-background/80 to-transparent z-10"></div>

      <img
        alt="Textbooks category"
        className="absolute inset-0 w-full h-full object-cover group-hover:scale-105 transition-transform duration-500 z-0"
        src={category.url}
      />

      <div className="relative z-20">
        <h3 className="font-headline-md text-headline-md text-surface">
          {category.name}
        </h3>
      </div>
    </>
  );
};
export default CategoryCard;
