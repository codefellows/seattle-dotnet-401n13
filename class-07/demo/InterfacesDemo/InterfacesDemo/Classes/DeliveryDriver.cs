using InterfacesDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo.Classes
{
  public class DeliveryDriver : Person, IDrive
  {
    public string StateLicense { get; set; }
    public DateTime LastAssessment { get; set; }
    public int TicketsInLastSixMonths { get; set; }
    public int DaysWhereEverythingGotDelivered { get; set; }

    public void AdjustSeat()
    {
      Console.WriteLine("Seat feels good");
    }

    public void InsertKey()
    {
      throw new NotImplementedException();
    }

    public void PutOnGloves()
    {
      Console.WriteLine("If it doesn't fit .... ");
    }
  }
}
