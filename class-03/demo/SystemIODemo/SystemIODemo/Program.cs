using System;
using System.IO;
using System.Text;

namespace SystemIODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = "../../../myFile.txt";
            FileWriteAllText(path);
            FileReadAllText(path);
            FileReadAllLines(path);
            FileAppendText(path);
            FileReadAllLines(path);
            WritingToCSV(path);

            // CreateFile();
            //FileAlreadyExists();
            // ReadFile(path);
            //UpdateAFile();
            //DeleteAFile();
            //PracticeUsingSplit();
        }

        static void FileWriteAllText(string filePath)
        {
            string myInfo = "The time has come, the walrus said...";
            File.WriteAllText(filePath, myInfo);
        }

        static void FileReadAllText(string path)
        {
            string myFile = File.ReadAllText(path);
            Console.WriteLine(myFile);

        }

        static void FileReadAllLines(string path)
        {
            string[] myFile = File.ReadAllLines(path);
            for (int i = 0; i < myFile.Length; i++)
            {
                Console.WriteLine(myFile[i]);
            }

        }

        static void FileAppendText(string path)
        {
            string[] words = {
                "to think of many things!",
                "of ships and shoes and ceiling wax",
                "and cabbages and kings!"
            };
            File.AppendAllLines(path, words);

            string phrase = "Cat in the Hat!";
            File.AppendAllText(path, phrase);
        }

        static void WritingToCSV(string path)
        {
            string catInformation = "Name,Age\n";
            catInformation += "Belle,6\n";
            catInformation += "Josie,6\n";

            File.WriteAllText(path, catInformation);

            string[] catNames = File.ReadAllLines(path);

            for (int i = 1; i < catNames.Length; i++)
            {
                string[] fields = catNames[i].Split(',');
                string name = fields[0];
                int age = Convert.ToInt32(fields[1]);
                Console.WriteLine($"Name: {name} Age: {age}");
            }
        }
        static void CreateFile()
        {
            string path = "myFile.txt";
            string[] myARray = { "I", "Love", "cats" };

            // first way
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.Write(myARray);
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }

            }
            catch (FileNotFoundException e)
            {

                throw;
            }


            //using (StreamWriter sw = new StreamWriter(path))
            //{
            //    try
            //    {
            //        sw.WriteLine("Hello World!!!!");
            //    }
            //    catch (Exception e)
            //    {

            //        throw;
            //    }
            //    finally
            //    {
            //        sw.Close();
            //    }
            //}
            //// Second Way
            //using (FileStream fs = File.Create(path))
            //{
            //	Byte[] myWords = new UTF8Encoding(true).GetBytes("All of the words!");
            //	fs.Write(myWords, 0, myWords.Length);
            //}
        }

        static void ReadFile(string path)
        {
            //path = "myFile.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw e;
                //Console.WriteLine("File was not found....");
            }
            finally
            {
                Console.WriteLine("Process Complete");
            }


            // Second way... 
            try
            {
                string[] worrds = File.ReadAllLines(path);

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...");
            }

        }

        static void UpdateAFile()
        {
            string path = "MyFile.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(i);
                }

            }
        }

        static void DeleteAFile()
        {
            string path = "MyFile.txt";

            File.Delete(path);
        }

        static void PracticeUsingSplit()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string text = "one\ttwo three:four,five six seven";
            string[] words = text.Split(delimiterChars);

            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }
        }
    }


}
