using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo.Interfaces
{
  interface IDrive
  {

    string StateLicense { get; set; }
    void PutOnGloves();
    void InsertKey();
    void AdjustSeat();
  }
}
