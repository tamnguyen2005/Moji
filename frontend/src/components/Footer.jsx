const Footer = () => {
  return (
    <footer className="bg-surface-container-low border-t border-surface-variant pt-xl pb-[120px] md:pb-xl mt-xl">
      <div className="max-w-[1280px] mx-auto px-margin-mobile md:px-margin-desktop">
        <div className="grid grid-cols-1 md:grid-cols-12 gap-lg mb-lg border-b border-outline-variant pb-lg">
          {/* Brand Section */}
          <div className="md:col-span-4 flex flex-col gap-md">
            <a
              className="font-headline-lg text-headline-lg text-primary"
              href="#"
            >
              Moji
            </a>

            <p className="font-body-md text-body-md text-on-surface-variant max-w-[300px]">
              Chợ sinh viên - Mua bán dễ dàng, an toàn và tiện lợi ngay trong
              khuôn viên trường đại học của bạn.
            </p>

            <div className="flex gap-sm">
              <a
                className="w-10 h-10 rounded-full bg-surface-container-high flex items-center justify-center text-primary hover:bg-primary hover:text-on-primary transition-colors"
                href="#"
              >
                <span className="material-symbols-outlined">facebook</span>
              </a>

              <a
                className="w-10 h-10 rounded-full bg-surface-container-high flex items-center justify-center text-primary hover:bg-primary hover:text-on-primary transition-colors"
                href="#"
              >
                <span className="material-symbols-outlined">photo_camera</span>
              </a>

              <a
                className="w-10 h-10 rounded-full bg-surface-container-high flex items-center justify-center text-primary hover:bg-primary hover:text-on-primary transition-colors"
                href="#"
              >
                <span className="material-symbols-outlined">work</span>
              </a>
            </div>
          </div>

          {/* Links Grid */}
          <div className="md:col-span-8 grid grid-cols-2 md:grid-cols-3 gap-md">
            <div className="flex flex-col gap-sm">
              <h3 className="font-label-md text-label-md text-on-surface uppercase tracking-wider">
                Về Moji
              </h3>

              <ul className="flex flex-col gap-xs">
                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Giới thiệu
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Quy chế hoạt động
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Liên hệ
                  </a>
                </li>
              </ul>
            </div>

            <div className="flex flex-col gap-sm">
              <h3 className="font-label-md text-label-md text-on-surface uppercase tracking-wider">
                Hỗ trợ
              </h3>

              <ul className="flex flex-col gap-xs">
                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Trung tâm trợ giúp
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    An toàn mua bán
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Phản hồi
                  </a>
                </li>
              </ul>
            </div>

            <div className="flex flex-col gap-sm col-span-2 md:col-span-1">
              <h3 className="font-label-md text-label-md text-on-surface uppercase tracking-wider">
                Danh mục
              </h3>

              <ul className="flex flex-col gap-xs">
                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Sách &amp; Giáo trình
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Đồ điện tử
                  </a>
                </li>

                <li>
                  <a
                    className="font-body-md text-body-md text-on-surface-variant hover:text-primary"
                    href="#"
                  >
                    Đồ dùng KTX
                  </a>
                </li>
              </ul>
            </div>
          </div>
        </div>

        {/* Bottom Footer */}
        <div className="flex flex-col md:flex-row justify-between items-center gap-md">
          <p className="font-caption text-caption text-outline">
            © 2024 Moji. All rights reserved.
          </p>

          <div className="flex items-center gap-md opacity-60 grayscale">
            <span className="font-label-md text-label-md">
              Đối tác liên kết:
            </span>

            <div className="flex gap-sm">
              <span className="material-symbols-outlined">school</span>

              <span className="material-symbols-outlined">account_balance</span>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};
export default Footer;
