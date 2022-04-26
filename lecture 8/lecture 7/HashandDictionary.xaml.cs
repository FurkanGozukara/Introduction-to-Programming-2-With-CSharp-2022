using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.IO;

namespace lecture_7
{
    /// <summary>
    /// Interaction logic for HashandDictionary.xaml
    /// </summary>
    public partial class HashandDictionary : Window
    {
        public HashandDictionary()
        {
            InitializeComponent();
        }

        Dictionary<string, double> dicTest = new Dictionary<string, double>();
        List<KeyValuePair<string, double>> listKeyValuePair = new List<KeyValuePair<string, double>>();
        List<Tuple<string, double>> listTuple = new List<Tuple<string, double>>();
        HashSet<KeyValuePair<string, double>> hashSetKeyValue = new HashSet<KeyValuePair<string, double>>();

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch swTimer = new Stopwatch();

            swTimer.Start();

            for (int i = 0; i < 10000; i++)
            {
                var vrUId = generateID();
                if (!dicTest.ContainsKey(vrUId))
                {
                    dicTest.Add(vrUId, 1);
                }
                else
                {
                    dicTest[vrUId]++;
                }
            }

            swTimer.Stop();

            //stringOperations(dicTest);

            for (int i = 0; i < 10000; i++)
            {
                var vrUId = generateID();

                if(listKeyValuePair.Where(kvp => kvp.Key == vrUId).Count() == 0)
                {
                    listKeyValuePair.Add(new KeyValuePair<string, double>(vrUId, 1));
                }
                else
                {
                    //what would you write here
                }
            }
        }

        private void stringOperations(Dictionary<string, double> dicTest)
        {
            Stopwatch swTimer = new Stopwatch();

            dicTest = dicTest.OrderBy(kvp => kvp.Key).ToDictionary(pr => pr.Key, pr => pr.Value);

            lstBoxResults.Items.Add("dictionary value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            swTimer.Restart();

            StringBuilder sbDictionary = new StringBuilder();

            foreach (var vrPerItem in dicTest)
            {
                sbDictionary.AppendLine($"Key: {vrPerItem.Key} \t\t Value: {vrPerItem.Value}");
            }

            swTimer.Stop();

            File.WriteAllText("dictionary_Values.txt", sbDictionary.ToString());

            lstBoxResults.Items.Add("string buildier methodoloy took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            string srResult = "";

            swTimer.Restart();

            foreach (var vrPerItem in dicTest)
            {
                //   srResult = srResult + $"Key: {vrPerItem.Key} \t\t Value: {vrPerItem.Value}\r\n";
            }

            swTimer.Stop();

            File.WriteAllText("dictionary_Values_string_method.txt", srResult);

            lstBoxResults.Items.Add("string methodoloy took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");
        }

        public string generateID()
        {
            var vrUId = Guid.NewGuid().ToString("N");
            return vrUId.Substring(0, 4);
        }
    }
}
