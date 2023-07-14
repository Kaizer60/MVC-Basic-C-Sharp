using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณากรอก ชื่อ-สกุล")]
        [DisplayName("ชื่อ-สกุล")]
        public string Name { get; set; }
        [DisplayName("คะแนน")]
        [Range(0,100,ErrorMessage = "กรุณากรอกคะแนน 0-100")]
        public int Score { get; set; }
    }
}
