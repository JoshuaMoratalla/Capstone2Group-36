using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;
using Xamarin.Forms;

namespace CalculatorTest
{
    public partial class App : Application
    {

        public static ObservableCollection<ConditionTest> ExcelSheetFinal = new ObservableCollection<ConditionTest>();

        public class ConditionTest
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Explanation { get; set; }
            public string Action { get; set; }
            public string Commonlyknownas { get; set; }
            public string Abbreviations { get; set; }
            public string Seealso { get; set; }
        }

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
                using (Stream testing = GenerateStreamFromString(Excelstring))
                {
                    using (var reader = ExcelReaderFactory.CreateOpenXmlReader(testing))
                    {
                        var ExcelSheet = new ObservableCollection<ConditionTest>();
                        do
                        {
                            int IDvar = -1;
                            while (reader.Read())
                            {
                                IDvar++;
                                ConditionTest ConditionLine = new ConditionTest
                                {
                                    ID = IDvar,
                                    Name = reader.GetString(0),
                                    Explanation = reader.GetString(1),
                                    Action = reader.GetString(2),
                                    Commonlyknownas = reader.GetString(3),
                                    Abbreviations = reader.GetString(4),
                                    Seealso = reader.GetString(5)
                                };

                                ExcelSheet.Add(ConditionLine);
                            }
                        } while (reader.NextResult());
                        ExcelSheetFinal = ExcelSheet;
                    }
                }
            }
            else
            {
                throw new System.ArgumentException("Broken");//TESTING_JASON
            }

        }

        public static Stream GenerateStreamFromString(string s)
        {
            // convert string to stream
            byte[] byteArray = Encoding.GetEncoding(1252).GetBytes(s);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);
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
