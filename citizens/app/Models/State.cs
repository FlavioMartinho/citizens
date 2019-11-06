using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citizens.Models
{
  public class State
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string UF { get; set; }
    [NotMapped]
    public List<City> Cities { get; set; }
  }
}
