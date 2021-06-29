using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsDemo.Payments.Models
{
  public class Payment
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingZip { get; set; }
    public decimal Amount { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public string Expiration { get; set; }

  }
}
