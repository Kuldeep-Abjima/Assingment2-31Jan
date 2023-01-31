using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Domain
{
    [Table("[dbo].[Student]")]
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }
        public string? StudentName { get; set; }

        public string? ContactNumber { get; set; }

        public string? FatherName { get; set; }

        public int? Class { get; set; }

    }
}