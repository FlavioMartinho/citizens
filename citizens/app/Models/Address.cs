using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citizens.Models
{
  public class Address
  {
    public string CEP { get; set; }
    public string AddressDescription { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    [Key, ForeignKey("PersonId")]
    public int PersonAddressId { get; set; }
    public Person Person { get; set; }
    [ForeignKey("CityId")]
    public int CityId { get; set; }
    public City City { get; set; }
  }
}
