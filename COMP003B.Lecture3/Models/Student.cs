// TODO: add data annotations library
using System.ComponentModel.DataAnnotations;
namespace COMP003B.Lecture3.Models
{
    public class Student // make sure properties are in the class
    {
        // TODO: data in square brackets are data annotations
        [Required]
        // TODO: below is an example of a property
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, 120)]
        public string Grade { get; set; }
    }
}
