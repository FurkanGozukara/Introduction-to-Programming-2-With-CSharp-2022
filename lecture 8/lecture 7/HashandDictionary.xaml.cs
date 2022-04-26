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
                if(!dicTest.ContainsKey(vrUId))
                {
                    dicTest.Add(vrUId,1);
                }
                else
                {
                    dicTest[vrUId]++;
                }
            }
        }

        public string generateID()
        {
            var vrUId = Guid.NewGuid().ToString("N");
            return vrUId.Substring(0,2);
        }
    }
}
