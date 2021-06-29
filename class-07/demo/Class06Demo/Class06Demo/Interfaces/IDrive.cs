using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Interfaces
{
    /// <summary>
    /// Convention and Industry standard reccomends that we name our Interfaces with the "I" on the front of the name. This gives us a visual repersentation that we are working with an interface directly. 
    /// </summary>
    interface IDrive
    {
        /// <summary>
        /// The state that the drivers license was issued
        /// </summary>
        string StateLicense { get; set; }

        /// <summary>
        /// Adjust the settings of the vehichle. 
        /// </summary>
        /// <returns>all of the settings adjusted</returns>
        string AdjustSettings();

    }
}
