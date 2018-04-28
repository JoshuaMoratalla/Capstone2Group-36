using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;
using Xamarin.Forms;

namespace CalculatorTest
{
    public partial class App : Application
    {

        public static List<string[]> ExcelSheetFinal = new List<string[]>();

        public App()
        {
            InitializeComponent();

            MainPage = new CalculatorTest.MainPage();
        }

        public App(string Excelstring)
        {
            InitializeComponent();

            MainPage = new CalculatorTest.MainPage();
            if (Excelstring != "")
            {
                using (var reader = ExcelReaderFactory.CreateReader(GenerateStreamFromString(Excelstring)))
                {
                    var ExcelSheet = new List<string[]>();
                    do
                    {
                        while (reader.Read())
                        {
                            string[] ConditionLine = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) };
                            ExcelSheet.Add(ConditionLine);
                        }
                    } while (reader.NextResult());
                    ExcelSheetFinal = ExcelSheet;
                }
            }
            else
            {
                throw new System.ArgumentException("Broken");//TESTING_JASON
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
