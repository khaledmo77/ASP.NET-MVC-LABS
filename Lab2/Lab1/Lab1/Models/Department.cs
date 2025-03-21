using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Department
    {
        [Key]
        public int deptid { get; set; }
        public string deptname { get; set; }
        public List<UserModel> user { get; set; }

    }
}
