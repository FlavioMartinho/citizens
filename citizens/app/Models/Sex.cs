using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citizens.Models
{
  public class Sex
  {
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    [NotMapped]
    public List<Person> Persons { get; set; }
  }
}
