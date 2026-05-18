const SideBar = () => {
  return (
    <aside className="w-full md:w-[280px] md:flex-shrink-0">
      <div className="bg-white  rounded-2xl border border-gray-200 p-5 flex flex-col gap-6 md:sticky md:top-6">
        {/* Header */}
        <div className="flex items-center justify-between pb-3 border-b border-gray-200">
          <h2 className="text-xl font-semibold text-gray-900">Bộ lọc</h2>

          <button className="text-sm text-blue-600 hover:underline">
            Xóa tất cả
          </button>
        </div>

        {/* University */}
        <div className="flex flex-col gap-3">
          <h3 className="text-sm font-semibold text-gray-900">
            Trường đại học
          </h3>

          <div className="flex flex-col gap-2">
            {[
              "ĐH Bách Khoa",
              "ĐH Khoa học Tự nhiên",
              "ĐH Kinh tế Quốc dân",
              "ĐH FPT",
            ].map((u) => (
              <label key={u} className="flex items-center gap-3 cursor-pointer">
                <input
                  type="checkbox"
                  className="w-4 h-4 rounded border-gray-300 text-blue-600"
                />

                <span className="text-sm text-gray-700">{u}</span>
              </label>
            ))}
          </div>
        </div>

        {/* Condition */}
        <div className="flex flex-col gap-3">
          <h3 className="text-sm font-semibold text-gray-900">Tình trạng</h3>

          <div className="flex flex-wrap gap-2">
            {["Như mới", "Tốt", "Có thể dùng"].map((s) => (
              <button
                key={s}
                className="px-3 py-2 rounded-full border border-gray-300 text-sm hover:border-blue-500 hover:text-blue-600 transition"
              >
                {s}
              </button>
            ))}
          </div>
        </div>

        {/* Price */}
        <div className="flex flex-col gap-3">
          <h3 className="text-sm font-semibold text-gray-900">Khoảng giá</h3>

          <div className="flex gap-2">
            <input
              type="number"
              placeholder="Từ"
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm outline-none focus:border-blue-500"
            />

            <input
              type="number"
              placeholder="Đến"
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm outline-none focus:border-blue-500"
            />
          </div>

          <button className="w-full bg-blue-600 hover:bg-blue-700 text-white py-2 rounded-lg text-sm font-medium transition">
            Áp dụng
          </button>
        </div>
      </div>
    </aside>
  );
};
export default SideBar;
