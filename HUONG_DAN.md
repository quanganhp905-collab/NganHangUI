# Code giao diện khách hàng — Size 1200 × 720

Bản này giữ bố cục và màu của giao diện đã dựng: hồ sơ khách hàng bên trái; thẻ tài khoản ở giữa; Nạp tiền, Rút tiền bên phải; các dịch vụ và nút Thoát phía dưới. Mã dựng các panel, label, textbox, button và biểu tượng. Các nút chưa được gắn sự kiện Click.

## Mở trong Visual Studio

1. Trong File Explorer (Trình quản lý tệp của Windows), chọn file ZIP đã tải → nhấn Alt + Enter → General (Chung) → tích Unblock (Bỏ chặn) nếu có → Apply (Áp dụng) → OK. Sau đó chọn Extract All / Giải nén tất cả để giải nén vào một thư mục mới. Không mở dự án ngay bên trong ZIP.
2. Mở `NganHangUI.sln` trong thư mục `NganHangUI`.
3. Bấm chuột phải Solution → **Restore NuGet Packages** (khôi phục thư viện NuGet).
4. Chọn **Build → Rebuild Solution** (biên dịch lại toàn bộ).
5. Bấm chuột phải `frmKhachhang.cs` → **View Designer** (xem thiết kế), hoặc nhấn **F5** để xem giao diện khi chạy.

Dự án dùng .NET Framework 4.8 và Guna.UI2.WinForms 2.0.4.8. Visual Studio cần có **.NET desktop development** (phát triển ứng dụng máy tính .NET) và bộ tham chiếu .NET Framework 4.8.

Hai font Be Vietnam Pro nằm trong `Fonts`. Chương trình tự nạp font khi chạy; để Designer cũng dùng đúng font, mở hai file TTF → **Install** (cài đặt) rồi mở lại Visual Studio.

## Namespace

Tất cả các file C# và RootNamespace của dự án đều dùng:

```csharp
namespace Chương_trình_quản_lý_tài_khoản_ngân_hàng
```

Tên lớp Form được giữ là `frmKhachhang`. Tên thư mục và solution vẫn là `NganHangUI` để bạn mở file thuận tiện; namespace của mã đã được đổi đúng theo yêu cầu.

## File code chính

- `frmKhachhang.Designer.cs`: toàn bộ mã bố cục, màu sắc và kích thước.
- `frmKhachhang.cs`: phần khởi tạo Form, chỉ gọi `InitializeComponent()`.
- `frmKhachhang.resx`: tài nguyên ảnh để Designer hiển thị các biểu tượng.
- `Assets`: các file ảnh nguồn. Giữ nguyên thư mục này đi cùng `.resx`.
- `Giao_dien_1200x720.png`: bản dựng tham khảo theo cùng thông số bố cục; không phải ảnh chụp Windows.

Nếu sao chép vào dự án có sẵn, cài Guna.UI2.WinForms phiên bản 2.0.4.8 và giữ các file `.cs`, `.Designer.cs`, `.resx` và Assets đi cùng nhau. Cả hai phần của lớp phải cùng namespace `Chương_trình_quản_lý_tài_khoản_ngân_hàng` và cùng tên lớp `frmKhachhang`. Không dán Designer vào file `frmKhachhang.cs`. Nếu dự án có sẵn đang dùng `Form1`, hãy thêm Form tên `frmKhachhang` rồi thay các file tương ứng; trong `Program.cs`, dùng `Application.Run(new frmKhachhang());`.

Phần `frmKhachhang.cs`:

```csharp
using System.Windows.Forms;

namespace Chương_trình_quản_lý_tài_khoản_ngân_hàng
{
    public partial class frmKhachhang : Form
    {
        public frmKhachhang()
        {
            InitializeComponent();
        }
    }
}
```

## Kích thước

```csharp
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.WindowState = System.Windows.Forms.FormWindowState.Normal;
this.Size = new System.Drawing.Size(1200, 720);
this.MinimumSize = new System.Drawing.Size(1200, 720);
this.MaximumSize = new System.Drawing.Size(1200, 720);
```

`Size` tính cả viền và thanh tiêu đề. `ClientSize` là vùng nội dung bên trong nên có giá trị nhỏ hơn. Font theo pixel và `AutoScaleMode.None` giữ bố cục khi Windows đặt phóng đại 125%. Tại DPI thiết kế 96, 12pt tương đương 16px; 14pt tương đương khoảng 18,67px; 16pt tương đương khoảng 21,33px.

Panel gốc dùng Dock; các vùng cần thiết có Anchor để vừa phần nội dung khi viền cửa sổ thay đổi. Tên hiển thị mặc định là “Khách hàng”. Muốn thay tên, sửa `lbTenKH.Text` trong Designer.

## Nếu lỗi MSB3821: tệp bị Windows chặn

Đóng Visual Studio. Mở thư mục đã giải nén bằng Windows + E. Tệp hiển thị tên `frmKhachhang` với loại **Tệp RESX** chính là `frmKhachhang.resx` khi Windows đang ẩn đuôi tệp. Chọn tệp → Alt + Enter → General (Chung) → Unblock (Bỏ chặn) nếu có → Apply (Áp dụng) → OK. Mở lại `NganHangUI.sln` trong thư mục đã giải nén rồi Rebuild Solution (biên dịch lại dự án).

## Kiểm tra

Mã C# được kiểm tra biên dịch bằng Roslyn với các reference .NET Framework 4.8 và DLL Guna UI2 2.0.4.8 thực tế. Bố cục và đường dẫn tài nguyên đã được kiểm tra. Môi trường thực hiện là Linux, chưa mở trực tiếp Visual Studio Designer hoặc chạy WinForms trên Windows.

Nếu Designer báo lỗi tại `Guna2Panel`, đóng tab thiết kế, Restore NuGet và Rebuild trước khi mở lại. Dự án có đủ các reference `System.Design`, `System.Web`, `System.Management`, `System.Runtime.Serialization` mà DLL Guna sử dụng.

Nguồn thư viện: https://www.nuget.org/packages/Guna.UI2.WinForms/2.0.4.8

Font có giấy phép OFL trong thư mục Fonts. Guna dùng giấy phép của nhà cung cấp mà nhóm đang sử dụng.
