using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public List<Department> Depts { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageBase64 => ImageData != null ? $"data:image/png;base64,{Convert.ToBase64String(ImageData)}" : null;
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }  
    }
}
