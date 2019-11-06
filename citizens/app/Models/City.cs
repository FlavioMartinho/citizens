using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citizens.Models
{
  public class City
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("StateId")]
    public int StateId { get; set; }
    public State State { get; set; }
    [NotMapped]
    public List<Address> Adresses { get; set; }
  }
}
