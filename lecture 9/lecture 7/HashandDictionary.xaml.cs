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
using System.Threading;

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
            Debug.WriteLine($"main window thread id : {Thread.CurrentThread.ManagedThreadId}");
        }

        public class keysAndValues
        {
            public keysAndValues(string _srKey, double _dblValue)
            {
                srKey = _srKey;
                dblValue= _dblValue;
            }

            public string srKey { get; set; }
            public double dblValue { get; set; }
        }

        Dictionary<string, double> dicTest = new Dictionary<string, double>();
        List<KeyValuePair<string, double>> listKeyValuePair = new List<KeyValuePair<string, double>>();
        List<Tuple<string, double>> listTuple = new List<Tuple<string, double>>();
        HashSet<KeyValuePair<string, double>> hashSetKeyValue = new HashSet<KeyValuePair<string, double>>();

        List<keysAndValues> lstMyCustomClass = new List<keysAndValues>();

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            int irHowMany = 100000;

            Stopwatch swTimer = new Stopwatch();

            swTimer.Start();

            for (int i = 0; i < irHowMany; i++)
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

            lstBoxResults.Items.Add("dictionary value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            //stringOperations(dicTest);

            swTimer.Restart();

            for (int i = 0; i < irHowMany; i++)
            {
                var vrUId = generateID();

                if (listKeyValuePair.Where(kvp => kvp.Key == vrUId).Count() == 0)
                {
                    listKeyValuePair.Add(new KeyValuePair<string, double>(vrUId, 1));
                }
                else
                {
                    for (int index_of_key = 0; index_of_key < listKeyValuePair.Count; index_of_key++)
                    {
                        if (listKeyValuePair[index_of_key].Key == vrUId)
                            listKeyValuePair[index_of_key] = new KeyValuePair<string, double>(listKeyValuePair[index_of_key].Key, (listKeyValuePair[index_of_key].Value + 1));
                    }
                }
            }

            swTimer.Stop();

            lstBoxResults.Items.Add("listKeyValuePair value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");


            swTimer.Restart();

            for (int i = 0; i < irHowMany; i++)
            {
                var vrUId = generateID();

                if (listTuple.Where(kvp => kvp.Item1 == vrUId).Count() == 0)
                {
                    listTuple.Add(new Tuple<string, double>(vrUId, 1));
                }
                else
                {
                    for (int index_of_key = 0; index_of_key < listTuple.Count; index_of_key++)
                    {
                        if (listTuple[index_of_key].Item1 == vrUId)
                            listTuple[index_of_key] = new Tuple<string, double>(vrUId, listTuple[index_of_key].Item2 + 1);

                        //listTuple.RemoveAt(index_of_key);
                        //index_of_key--;
                    }
                }
            }

            swTimer.Stop();

            lstBoxResults.Items.Add("listTuple value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");


            swTimer.Restart();

            for (int i = 0; i < irHowMany; i++)
            {
                var vrUId = generateID();

                if (lstMyCustomClass.Where(kvp => kvp.srKey == vrUId).Count() == 0)
                {
                    lstMyCustomClass.Add(new keysAndValues(vrUId,1));
                }
                else
                {
                    lstMyCustomClass.Where(pr => pr.srKey == vrUId).FirstOrDefault().dblValue++;
                }
            }

            swTimer.Stop();

            lstBoxResults.Items.Add("lstMyCustomClass value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            swTimer.Restart();

            for (int i = 0; i < irHowMany; i++)
            {
                var vrUId = generateID();

                bool blFound = false;

                foreach (var vrPerValue in hashSetKeyValue)
                {
                    if(vrPerValue.Key==vrUId)
                    {
                        hashSetKeyValue.Remove(vrPerValue);
                        hashSetKeyValue.Add(new KeyValuePair<string, double>(vrUId, (vrPerValue.Value+1)));
                        blFound = true;
                        break;
                    }
                }

                if (blFound == false)
                    hashSetKeyValue.Add(new KeyValuePair<string, double>(vrUId, 1));
            }

            swTimer.Stop();

            lstBoxResults.Items.Add("hashSetKeyValue value generation took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");


            writeListKeyValue(listKeyValuePair);
        }

        private void writeListKeyValue(List<KeyValuePair<string, double>> varList)
        {
            StringBuilder sbDictionary = new StringBuilder();

            foreach (var vrPerItem in varList)
            {
                sbDictionary.AppendLine($"Key: {vrPerItem.Key} \t\t Value: {vrPerItem.Value}");
            }

            File.WriteAllText("list_key_Value.txt", sbDictionary.ToString());
        }

        private void stringOperations(Dictionary<string, double> dicTest)
        {
            Stopwatch swTimer = new Stopwatch();

            dicTest = dicTest.OrderBy(kvp => kvp.Key).ToDictionary(pr => pr.Key, pr => pr.Value);



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
            return vrUId.Substring(0, 20);
        }

        HashSet<string> hsUids = new HashSet<string>();
        List<string> lstUids = new List<string>();
        Dictionary<string, string> dicUids = new Dictionary<string, string>();

        private void btnSpeedtest_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine($"btnSpeedtest_Click click thread id : {Thread.CurrentThread.ManagedThreadId}");

            Task.Factory.StartNew(() => {

                Debug.WriteLine($"inside of Task.Factory.StartNew: {Thread.CurrentThread.ManagedThreadId}");
                doSpeedTask(); });


        }

       

        private void doSpeedTask()
        {
            Debug.WriteLine($"doSpeedTask click thread id : {Thread.CurrentThread.ManagedThreadId}");

            int irCounter = 30000;

            Stopwatch swTimer = new Stopwatch();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                hsUids.Add(vrUid);
            }

            swTimer.Stop();

            insertListBoxResult("hashset unique adding took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");
     
            swTimer.Restart();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                if (hsUids.Contains(vrUid))
                {
                    vrUid = "1";
                }
            }

            swTimer.Stop();

            insertListBoxResult("hashset searching took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            hsUids = new HashSet<string>();

            swTimer.Restart();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                lstUids.Add(vrUid);
            }

            lstUids = lstUids.Distinct().ToList();

            swTimer.Stop();

            insertListBoxResult("list unique adding took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");


            swTimer.Restart();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                if (lstUids.Contains(vrUid))
                {
                    vrUid = "1";
                }
            }

            swTimer.Stop();

            insertListBoxResult("list searching took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            lstUids = new List<string>();

            swTimer.Restart();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                if (dicUids.ContainsKey(vrUid) == false)
                    dicUids.Add(vrUid, null);
            }

            swTimer.Stop();

            insertListBoxResult("dictionary unique adding took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");

            swTimer.Restart();

            for (int i = 0; i < irCounter; i++)
            {
                var vrUid = generateID();
                if (dicUids.ContainsKey(vrUid) == true)
                {
                    vrUid = "1";
                }
            }

            swTimer.Stop();

            insertListBoxResult("dictionary searching took: " + swTimer.ElapsedMilliseconds.ToString("N0") + " miliseconds");
        }

        private void insertListBoxResult(string srMsg)
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, () => {

                lstBoxResults.Items.Add(srMsg);
            });
        }
    }
}
