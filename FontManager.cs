using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chương_trình_quản_lý_tài_khoản_ngân_hàng
{
    internal static class FontManager
    {
        private static readonly PrivateFontCollection Fonts = new PrivateFontCollection();
        private static readonly List<string> LoadedPaths = new List<string>();
        private const uint FrPrivate = 0x10;

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern int AddFontResourceEx(string file, uint flags, System.IntPtr reserved);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern bool RemoveFontResourceEx(string file, uint flags, System.IntPtr reserved);

        internal static void Load()
        {
            foreach (string file in new[] { "BeVietnamPro-Regular.ttf", "BeVietnamPro-Bold.ttf" })
            {
                string path = Path.Combine(Application.StartupPath, "Fonts", file);
                if (!File.Exists(path)) continue; // Windows tự dùng font thay thế nếu thiếu tệp.
                Fonts.AddFontFile(path);
                if (AddFontResourceEx(path, FrPrivate, System.IntPtr.Zero) > 0)
                    LoadedPaths.Add(path);
            }
        }

        internal static void Unload()
        {
            foreach (string path in LoadedPaths)
                RemoveFontResourceEx(path, FrPrivate, System.IntPtr.Zero);
            LoadedPaths.Clear();
            Fonts.Dispose();
        }
    }
}
