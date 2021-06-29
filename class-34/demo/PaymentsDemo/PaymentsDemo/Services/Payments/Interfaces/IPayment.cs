using PaymentsDemo.Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsDemo.Payments.Services.Interfaces
{
  public interface IPayment
  {
    PaymentResponse ProcessPayment(Payment payment);
  }
}
