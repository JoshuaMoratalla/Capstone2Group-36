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

        public static ObservableCollection<Condition> ExcelSheetFinal = new ObservableCollection<Condition>();

        public class Condition
        {
            public int ID { get; set; }//Assigns 0..X So 0 can be the titles of the database
            public string Name { get; set; }
            public string Explanation { get; set; }
            public string Action { get; set; }
            public string Commonlyknownas { get; set; }
            public string Abbreviations { get; set; }
            public string Seealso { get; set; }
            public string ActionColor { get; set; }
        }

        public App()//Default App load. Doesnt set excel sheet.
        {
            InitializeComponent();

            MainPage = new CalculatorTest.MainPage();
        }

        public App(string Excelstring)//New App load. Grabs string from Android/iOS
        {
            InitializeComponent();

            MainPage = new CalculatorTest.MainPage();

            #region Excel Processing
            if (Excelstring != "")
            {
                using (Stream testing = GenerateStreamFromString(Excelstring))//Stream generated
                {
                    using (var reader = ExcelReaderFactory.CreateOpenXmlReader(testing))//Excelread
                    {
                        var ExcelSheet = new ObservableCollection<Condition>();//Builds Collection
                        do
                        {
                            int IDvar = -1;
                            int colortest = 6;
                            while (reader.Read())
                            {
                                IDvar++;
                                if (colortest == 0)
                                {
                                    colortest = 1;
                                }
                                else if (colortest == 1)
                                {
                                    colortest = 2;
                                }
                                else if (colortest == 2)
                                {
                                    colortest = 3;
                                }
                                else if (colortest == 3)
                                {
                                    colortest = 4;
                                }
                                else if (colortest == 4)
                                {
                                    colortest = 5;
                                }
                                else if (colortest == 5)
                                {
                                    colortest = 6;
                                }
                                else if (colortest == 6)
                                {
                                    colortest = 0;
                                }
                                Condition ConditionLine = new Condition
                                {
                                    ID = IDvar,
                                    Name = Trimwhitespaces(reader.GetString(0)),
                                    Explanation = Trimwhitespaces(reader.GetString(1)),
                                    Action = Trimwhitespaces(reader.GetString(2)),
                                    Commonlyknownas = Trimwhitespaces(reader.GetString(3)),
                                    Abbreviations = Trimwhitespaces(reader.GetString(4)),
                                    Seealso = Trimwhitespaces(reader.GetString(5)),
                                    ActionColor = SetColour(colortest)
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
                throw new System.ArgumentException("Excel File did not load Correctly");//TESTING_JASON
            }
            #endregion
        }

        private static string Trimwhitespaces(string input)//trims white space
        {
            string output = "";
            if (input == null)
            {
                output = "";
            }
            else
            {
                output = input.Trim();
            }
            return output;
        }

        private static string SetColour(int input)
        {
            string output = "#FFFFFF";
            if (input == 0)
            {
                output = "#FFFFFF";
            }
            else if (input == 1)
            {
                output = "#ED3125";
            }
            else if (input == 2)
            {
                output = "#FEF200";
            }
            else if (input == 3)
            {
                output = "#00853E";
            }
            else if (input == 4)
            {
                output = "#8A2529";
            }
            else if (input == 5)
            {
                output = "#00A6DA";
            }
            else if (input == 6)
            {
                output = "#013D79";
            }


            return output;
        }
        //Converts the string to a strem
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
