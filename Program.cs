using System;
using System.Windows.Forms;

namespace Chương_trình_quản_lý_tài_khoản_ngân_hàng
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Nạp font kèm dự án trước khi khởi tạo bất kỳ Form nào.
            FontManager.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                using (var frm = new frmKhachhang())
                    Application.Run(frm);
            }
            finally
            {
                FontManager.Unload();
            }
        }
    }
}
