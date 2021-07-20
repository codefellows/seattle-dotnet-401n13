using System;

namespace WelcomeToCsharp
{
  class Program
  {
    static void Main(string[] args)
    {
      TryCatchExample.CatchUserError();
      CallStackExample.ShowTheCallStack();
      ExceptionsExample.GenerateSomeErrors();
    }
  }
}
