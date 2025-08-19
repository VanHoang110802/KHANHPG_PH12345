namespace AppData.Models
{
    public class NhanVien
    {
        public Guid ID { get; set; }           // Mã định danh duy nhất
        public string Ten { get; set; }        // Tên nhân viên
        public int Tuoi { get; set; }          // Tuổi
        public int Role { get; set; }          // Vai trò (có thể dùng enum sau)
        public string Email { get; set; }      // Địa chỉ email
        public int Luong { get; set; }         // Lương
        public bool TrangThai { get; set; }    // Trạng thái hoạt động
    }
}
