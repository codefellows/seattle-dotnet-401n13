using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqInManhatten
{
    class Program
    {
        static void Main(string[] args)
        {
            RootObject data = GetData();
            Questions(data);
        }

        /// <summary>
        /// Filtering through the data and outputting data to the console
        /// </summary>
        /// <param name="data">JSON converted data of neighborhood data</param>
        static void Questions(RootObject data)
        {
            //1.Output all of the neighborhoods in this data list

            // total of 147 neighborhoods with 4 as "empties"
            var q1 = from neighborhood in data.features
                          select neighborhood;

            int count = 0;
            foreach (var answer in q1)
            {
                Console.WriteLine($"{++count}. {answer.properties.neighborhood}");
            }


            //2.Filter out all the neighborhoods that do not have any names
            Console.WriteLine("====== Q2 ==========");

            // Total of 143 neighborhoods.
            var q2 = q1.Where(x => x.properties.neighborhood != "");
            count = 0;
            foreach (var item in q2)
            {
                Console.WriteLine($"{++count}. {item.properties.neighborhood}");

            }

            //3.Remove the Duplicates
            // gives me 39 unique neighborhoods

            Console.WriteLine("====== Q3 ==========");
            var q3 = q2.GroupBy(x => x.properties.neighborhood)
                       .Select(grp => grp.First());

            count = 0;
            foreach (var item in q3)
            {
                Console.WriteLine($"{++count}. {item.properties.neighborhood}");

            }

            //4.Rewrite the queries from above, and consolidate all into one single query.

            Console.WriteLine("====== Q4 ==========");

            var final = data.features.Where(x => x.properties.neighborhood != "")
                                     .GroupBy(x => x.properties.neighborhood)
                                     .Select(x => x.First());
            count = 0;
            foreach (var item in final)
            {
                Console.WriteLine($"{++count}. {item.properties.neighborhood}");

            }

            //5.Rewrite at least one of these questions only using the opposing method(example: Use LINQ Query statements instead of LINQ method calls and vice versa.)
           
            // rewriting 2nd question
            var rewrite = from name in q1
                          where name.properties.neighborhood != ""
                          select name;

            count = 0;
            foreach (var item in rewrite)
            {
                Console.WriteLine($"{++count}. {item.properties.neighborhood}");

            }

        }


        /// <summary>
        /// Reading JSON data and conerting to C# object
        /// </summary>
        static RootObject GetData()
        {
          using (StreamReader sr = File.OpenText("../../../data.json"))
          {
            string jsonData = sr.ReadLine();
            // convert JSON to classes

            // gives me 147 neighborhoods
            // Note that we specify a type <RootObject> that JsonConvert will map all properties into
            // This is a class which maps the entire JSON object
            RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(jsonData);

            // Questions(deserializedProduct);
            return deserializedProduct;

          }
        }
    }


    public class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

    public class Feature
    {
      public string type { get; set; }
      public Geometry geometry { get; set; }
      public Properties properties { get; set; }
    }


    public class Properties
    {
      public string zip { get; set; }
      public string city { get; set; }
      public string state { get; set; }
      public string address { get; set; }
      public string borough { get; set; }
      public string neighborhood { get; set; }
      public string county { get; set; }
    }

    public class Geometry
    {
      public string type { get; set; }
      public List<double> coordinates { get; set; }
    }


}
