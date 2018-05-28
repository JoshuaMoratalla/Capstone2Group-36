using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public static string ACCESS;

        public App()
        {
            InitializeComponent();

            string Excelstring = "";
            string Access = "";

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("CalculatorTest.ConditionsExcel.xlsx"))
            {
                using (var reader = new System.IO.StreamReader(stream))
                {
                    Excelstring = reader.ReadToEnd();
                }
            }

            using (Stream stream = assembly.GetManifestResourceStream("CalculatorTest.Access.txt"))
            {
                using (var reader = new System.IO.StreamReader(stream))
                {
                    Access = reader.ReadToEnd();
                }
            }

            if (Access != "")
            {
                MainPage = new CalculatorTest.MainPage();
            }
            else
            {
                MainPage = new CalculatorTest.Login();
                ACCESS = Access;
            }

            #region Excel Processing
            using (Stream testing = assembly.GetManifestResourceStream("CalculatorTest.ConditionsExcel.xlsx"))//Stream generated
            {
                using (var reader = ExcelReaderFactory.CreateReader(testing))//Excelread
                {
                    var ExcelSheet = new ObservableCollection<Condition>();//Builds Collection
                    do
                    {
                        int IDvar = -1;
                        while (reader.Read())
                        {
                            IDvar++;
                            Condition ConditionLine = new Condition
                            {
                                ID = IDvar,
                                Name = Trimwhitespaces(reader.GetString(0)),
                                Explanation = Trimwhitespaces(reader.GetString(1)),
                                Action = Trimwhitespaces(reader.GetString(2)),
                                Commonlyknownas = Trimwhitespaces(reader.GetString(3)),
                                Abbreviations = Trimwhitespaces(reader.GetString(4)),
                                Seealso = Trimwhitespaces(reader.GetString(5)),
                                ActionColor = SetColour(Trimwhitespaces(reader.GetString(6)))
                            };

                            ExcelSheet.Add(ConditionLine);
                        }
                    } while (reader.NextResult());

                    ExcelSheetFinal = ExcelSheet;
                }
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

        private static string SetColour(string input)
        {
            string output = "#FFFFFF";
            if (input == "")
            {
                output = "#FEF200";
            }
            else if (input.ToLower() == "mnd")
            {
                output = "#ED3125";
            }
            else if (input.ToLower() == "a")
            {
                output = "#00853E";
            }
            else if (input.StartsWith("#") && input.Length == 7)
            {
                output = input;
            }

            return output;
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
