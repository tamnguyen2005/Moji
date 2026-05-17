import { Link } from "react-router-dom";
const NavBar = () => {
  return (
    <header className="hidden md:block docked full-width top-0 bg-surface shadow-sm z-50 sticky">
      <div className="sticky top-0 z-50 flex justify-between items-center px-margin-desktop w-full max-w-[1280px] mx-auto h-20">
        <div className="font-headline-lg text-headline-lg text-primary flex items-center gap-2">
          Moji
        </div>

        <nav className="flex items-center gap-lg">
          <Link
            to="/"
            className="font-headline-md text-headline-md font-body-md text-body-md text-on-surface-variant hover:text-primary transition-colors duration-200 cursor-pointer active:opacity-80"
          >
            Trang chủ
          </Link>

          <Link
            to="/Product"
            className="font-headline-md text-headline-md font-body-md text-body-md text-on-surface-variant hover:text-primary transition-colors duration-200 cursor-pointer active:opacity-80"
          >
            Giáo trình
          </Link>

          <Link
            to="/Product"
            className="font-headline-md text-headline-md font-body-md text-body-md text-on-surface-variant hover:text-primary transition-colors duration-200 cursor-pointer active:opacity-80"
          >
            Đồ điện tử
          </Link>

          <Link
            to="/Product"
            className="font-headline-md text-headline-md font-body-md text-body-md text-on-surface-variant hover:text-primary transition-colors duration-200 cursor-pointer active:opacity-80"
          >
            Đồ dùng KTX
          </Link>
        </nav>

        <div className="flex items-center gap-md text-primary">
          <button className="hover:bg-surface-container-high p-2 rounded-full transition-colors duration-200 cursor-pointer active:opacity-80">
            <span className="material-symbols-outlined">notifications</span>
          </button>

          <button className="hover:bg-surface-container-high p-2 rounded-full transition-colors duration-200 cursor-pointer active:opacity-80">
            <span className="material-symbols-outlined">mail</span>
          </button>
          <Link to="/Profile">
            <img
              alt="User profile photo"
              className="w-10 h-10 rounded-full border border-outline-variant ml-sm object-cover"
              src="https://lh3.googleusercontent.com/aida-public/AB6AXuBQDYB0CJokBadjYaCHcfaIvYCL2S9-g1eQuALBHgn_kSzwY74xLsq_eN66f9x4s_ndd7S5nYVZc687aZi14Cp6P7QU5of5BgyOvKvcrkL9ClMqodcmD6dkGROQmw10dIGXpuUl3dbDbSIsqeof3xGwYEagM6oFf5ucPstLCzsGAATgOMb0xR_x044qkfIkW3fnGj9aWTlwTxePiylYMrK70IiQ19aKev-NBiyZ2X8nL_ZAQMidPoUV7naFT3cEf6EPbVLvVx_dXcPe"
            />
          </Link>
        </div>
      </div>
    </header>
  );
};
export default NavBar;
