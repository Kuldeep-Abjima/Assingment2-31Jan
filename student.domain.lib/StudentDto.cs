using System.ComponentModel.DataAnnotations;

namespace student.domain.lib
{

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