using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citizens.Models
{
  public class Person
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Telephone { get; set; }
    public string Mobile { get; set; }
    [ForeignKey("SexId")]
    public int SexId { get; set; }
    public Sex Sex { get; set; }
    [ForeignKey("AddressId")]
    public int AddressId { get; set; }
    public Address Address { get; set; }
  }
}
