using Class06Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
  class Employee : Person, IDrive
  {
    public int AnnualSalary { get; set; }
    public int VacationLeft { get; set; }
    public string StateLicense { get; set; }

    public Employee(int annual, string state)
    {
      AnnualSalary = annual;
      StateLicense = state;
    }
    public string AdjustSettings()
    {
      return "All my settings are adjusted!";
    }

    public double GetHourlyRate()
    {
      return (AnnualSalary / 52) / 40;
    }

    public void UseVacation(int days)
    {
      // logic to remove vacation days
    }

    public string Drive(IDrivable drivable)
    {
      drivable.Accelerate();
      drivable.Brake();
      return "I Drove!";
    }

  }
}
