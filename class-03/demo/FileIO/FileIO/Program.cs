using System;

// JS Equivalent: const system = require('system/io'); or import IO from 'system';
using System.IO;

namespace FileIO
{
  class Program
  {
    static void Main(string[] args)
    {

      string filePath = "../../../data.txt";
      string newFilePath = "../../../new-data.txt";


      FileReadAllTextAsBytes(filePath);
      //FileReadAllText(filePath);
      //FileReadAllTextAsArray(filePath);
      //FileAddSomeLines(filePath);
      //FileReadAllText(filePath);
      //FileCreateNewFile(newFilePath);
      //FileReadAllText(newFilePath);
    }

    static void FileReadAllTextAsBytes(string file)
    {
      byte[] bytes  = File.ReadAllBytes(file);
      foreach( byte character in bytes )
      {
        Console.Write($"{character} ");
      }
    }

    static void FileReadAllText(string file)
    {
      Console.WriteLine("----- READ AS STRING -----");
      string myFileContents = File.ReadAllText(file);
      Console.WriteLine(myFileContents);
    }

    static void FileReadAllTextAsArray( string file )
    {
      Console.WriteLine("----- READ AS ARRAY -----");
      string[] lines = File.ReadAllLines(file);

      foreach(string line in lines)
      {
        Console.WriteLine(line);
      }
    }

    static void FileAddSomeLines(string file) 
    {
      Console.WriteLine("----- ADD LINES -----");
      string phrase = "John likes his dog";
      File.AppendAllText(file, "\n");  // \n \r \cM
      File.AppendAllText(file, phrase);

      string[] words = {
        "sunny",
        "hot",
        "loud"
      };

      File.AppendAllText(file, "\n");  // \n \r \cM
      File.AppendAllLines(file, words);
       
    }

    static void FileCreateNewFile(string file)
    {
      string[] words = { "I", "love", "my", "family" };

      try { 
        using ( StreamWriter sw = new StreamWriter(file) )
        { 
	        try {
            foreach( string word in words )
            {
              sw.Write(word);
              sw.Write("\n");
	          }
	        }
          catch(Exception e)
          {
            throw;
	        }
          finally
          {
            sw.Close();
	        }
	      }
      }
      catch(Exception e)
      {
        throw;
      }
    
    }
  }
}

