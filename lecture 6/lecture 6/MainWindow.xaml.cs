using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace lecture_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPerformance_Click(object sender, RoutedEventArgs e)
        {
            customFormatNumberTest();
            Stopwatch swTimer = new Stopwatch();

            swTimer.Start();
            writeWithStreamWriter();
            swTimer.Stop();

            var Vr1 = swTimer.ElapsedMilliseconds.ToString("N0");

            swTimer.Reset();//this will reset elapsed time
            swTimer.Start();
            writeAutoFlush();
            swTimer.Stop();

            var Vr2 = swTimer.ElapsedMilliseconds.ToString("N0");

            swTimer.Reset();//this will reset elapsed time
            swTimer.Start();
            mostSecureFlush();
            swTimer.Stop();

            var Vr3 = swTimer.ElapsedMilliseconds.ToString("N0");

            swTimer.Reset();//this will reset elapsed time
            swTimer.Start();
            mostPerformanceWay();
            swTimer.Stop();

            var Vr4 = swTimer.ElapsedMilliseconds.ToString("N0");

            MessageBox.Show($"fastest way: {Vr1} \t more secure way {Vr2} \t most secure way {Vr3} \t another way {Vr4}");
        }

        private static void writeWithStreamWriter()
        {
            StreamWriter swWrite = new StreamWriter("writeWithStreamWriter.txt");
            swWrite.AutoFlush = false;

            for (uint i = 0; i < 10000000; i++)//uint.MaxValue will loop 0 to 2^32 = 4,294,967,296
            {
                swWrite.WriteLine(i.ToString("N0"));
            }
            swWrite.Close();
        }

        private static void writeAutoFlush()
        {
            //this is more secure
            using (StreamWriter swWriteWithFlush = new StreamWriter("writeWithFlush.txt"))
            {
                swWriteWithFlush.AutoFlush = true;

                for (uint i = 0; i < 10000000; i++)//uint.MaxValue will loop 0 to 2^32 = 4,294,967,296
                {
                    swWriteWithFlush.WriteLine(i.ToString("N0"));
                }
            }
        }

        private static void mostSecureFlush()
        {
            //this is more secure
            using (StreamWriter swWriteMostSecure = new StreamWriter("mostSecureFlush.txt"))
            {
                for (uint i = 0; i < 10000000; i++)//uint.MaxValue will loop 0 to 2^32 = 4,294,967,296
                {
                    swWriteMostSecure.WriteLine(i.ToString("N0"));
                    swWriteMostSecure.Flush();
                }
            }
        }

        private static void mostPerformanceWay()
        {
            List<string> lstNumbers = new List<string>();
            for (uint i = 0; i < 10000000; i++)//uint.MaxValue will loop 0 to 2^32 = 4,294,967,296
            {
                lstNumbers.Add(i.ToString("N0"));
            }
            File.WriteAllLines("most_performance.txt", lstNumbers);
        }

        private static void customFormatNumberTest()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings

            List<string> lstFormats = new List<string> { "N0", "N1", "N2", "N3", "#####", "##,#", "%#0.00", "#0.00‰" };

            // \t is tab \r\n is new line
            foreach (var vrFormat in lstFormats)
            {
                File.AppendAllText("format_test.txt", $"{vrFormat} format:\t {324121.412312.ToString(vrFormat)}\r\n");
            }

            File.AppendAllText("format_test.txt", DateTime.Now.ToString("yyyyy:MMMM:dddd" + Environment.NewLine));
            File.AppendAllText("format_test.txt", DateTime.Now.ToString("yyyy | MM | dd  | mm || ss | fffff" + "\r\n"));
        }

        private void btnReturnStudents_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtStudents = DbOperations.selectTable("select * from tblStudents");

            foreach (DataRow drw in dtStudents.Rows)
            {
                MessageBox.Show($"student id: {drw["StudentId"].ToString()} \t student name: {drw["StudentName"].ToString()}");
            }
        }
    }
}
