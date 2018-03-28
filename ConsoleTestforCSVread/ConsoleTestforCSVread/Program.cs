using ExcelDataReader;
using ExcelReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestforCSVread {
    class Program {
        static void Main(string[] args) {
            
            string excelfile = Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\ConditionsExcel.xlsx");
           
            using (dynamic rFile = new ExcelFileReader<dynamic>(excelfile)) {
               
                var ExcelSheet = new List<string[]>();
                foreach (var line in rFile) {
                    
                    string[] ConditionLine = { line.Name, line.Explanation, line.Action, line.Get("Commonly known as"),line.Abbrevations, line.Get("See also") };
                    ExcelSheet.Add(ConditionLine);
                    
                }
                var data = ExcelSheet.ToArray();

                for (int i = 0; i <= data.Length - 1; i++) {
                    var Array = data[i];
                    for (int j = 0; j <= Array.Length - 1; j++) {

                        Console.WriteLine(j + "  " + Array[j]);
                    }
                    string boundaries = "***********************";
                    Console.WriteLine(boundaries);
                    Console.ReadLine();
                }
            }

            /*
             * 
             *  
             *  StreamReader sr = new StreamReader(filepath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream) {
                string[] Line = sr.ReadLine().Split(',');

                lines.Add(Line);
                Row++;
            }
            var data = lines.ToArray();

            for (int i = 0; i <= data.Length - 1; i++) {
                var Array = data[i];
                for (int j = 0; j <= Array.Length - 1; j++) {

                    Console.WriteLine(j + "  " + Array[j]);
                }
                string boundaries = "***********************";
                Console.WriteLine(boundaries);
                Console.ReadLine();
            }
             * 
             * 
             * 
             */


            Console.ReadLine();
        }
    }
}
