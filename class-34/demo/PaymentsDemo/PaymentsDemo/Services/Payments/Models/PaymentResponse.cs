using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsDemo.Payments.Models
{
  public class PaymentResponse
  {

    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }

  }
}
