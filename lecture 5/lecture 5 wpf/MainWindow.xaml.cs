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
using System.Reflection;

namespace lecture_5_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum enListBoxNames
        {
            lstBoxNames,
            lstBoxGrades
        }

        public MainWindow()
        {
            InitializeComponent();
            populateComboBox();

        }

        private void populateComboBox()
        {
            cmbSortOptions.Items.Add("Pick a sorting option");
            cmbSortOptions.Items.Add("Sort list by ascending order");
            cmbSortOptions.Items.Add("Sort list by descending order");
            cmbSortOptions.Items.Add("Sort list randomly");

            cmbSortOptions.SelectedIndex = 0;
        }

        private void btnAddNames_Click(object sender, RoutedEventArgs e)
        {
            string srFullname = txtFirstName.Text + " | " + txtLastName.Text;
            //  MessageBox.Show(srFullname);
            //   MessageBox.Show(srFullname, "Your Name");
            //  MessageBox.Show(srFullname + "\n" + "second line");

            lstBoxNames.Items.Add(srFullname);

        }

        private void btnInsertName_Click(object sender, RoutedEventArgs e)
        {
            string srFullname = txtFirstName.Text + " | " + txtLastName.Text;
            int irInsertIndex = 0;
            Int32.TryParse(txtinserindex.Text, out irInsertIndex);

            if (irInsertIndex > lstBoxNames.Items.Count)
                irInsertIndex = lstBoxNames.Items.Count;

            irInsertIndex = (irInsertIndex < 0) ? 0 : irInsertIndex;//this is if and else in a single line and it is equal to below

            if (irInsertIndex < 0)
            {
                irInsertIndex = 0;
            }
            else
            {
                irInsertIndex = irInsertIndex;
            }

            lstBoxNames.Items.Insert(irInsertIndex, srFullname);
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbSortOptions.SelectedIndex)
            {
                case 0:

                    break;

                case 1:
                    lstBoxNames.Items.SortDescriptions.Clear();
                    lstBoxNames.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));
                    break;
                case 2:
                    lstBoxNames.Items.SortDescriptions.Clear();
                    lstBoxNames.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Descending));
                    break;
                case 3:
                    string[] myItems = new string[lstBoxNames.Items.Count];
                    lstBoxNames.Items.CopyTo(myItems, 0);

                    List<string> lstItems = new List<string>();
                    foreach (var vrItem in lstBoxNames.Items)
                    {
                        lstItems.Add(vrItem.ToString());
                    }
                    lstItems = shuffleList(lstItems);

                    //lstBoxNames.Items.Clear();
                    //foreach (string item in lstItems)
                    //{
                    //    lstBoxNames.Items.Add(item);
                    //}

                    //for (int i = 0; i < lstBoxNames.Items.Count; i++)
                    //{
                    //    lstBoxNames.Items[i] = lstItems[i];
                    //}

                    loadIntoListBox(enListBoxNames.lstBoxNames, lstItems, this);
                    break;
            }
        }

        private static void loadIntoListBox(enListBoxNames whichBox, List<string> lstValues, MainWindow myMain)
        {
            switch (whichBox)
            {
                case enListBoxNames.lstBoxNames:
                    myMain.lstBoxNames.Items.Clear();
                    foreach (var vrVal in lstValues)
                    {
                        myMain.lstBoxNames.Items.Add(vrVal);
                    }
                    break;
                case enListBoxNames.lstBoxGrades:
                    myMain.lstBoxGrades.Items.Clear();
                    foreach (var vrVal in lstValues)
                    {
                        myMain.lstBoxGrades.Items.Add(vrVal);
                    }
                    break;
                default:
                    break;
            }
        }

        private static List<string> shuffleList(List<string> lstMyList)
        {
            Random rng = new Random();
            List<string> lstNewList = new List<string>();
            while (lstMyList.Count > 0)
            {
                int irNewIndex = rng.Next(0, lstMyList.Count);
                lstNewList.Add(lstMyList[irNewIndex]);
                lstMyList.RemoveAt(irNewIndex);
            }
            return lstNewList;
        }

        private void btnSaveListBoxContent_Click(object sender, RoutedEventArgs e)
        {
            //if you dont provide a full path it will compose file inside the debug folder where the exe is running
            writeToFile_v5("test.txt", lstBoxNames.Items.Cast<string>().ToList());
            Directory.CreateDirectory(@"C:\a\");
            writeToFile_v1(@"C:\a\test.txt", lstBoxNames.Items.Cast<string>().ToList());

            //use all 5 different methods to write different files into different folders
        }

        private static void writeToFile_v1(string srFileName, List<string> lstContent)
        {
            File.WriteAllLines(srFileName, lstContent);
        }

        private static void writeToFile_v2(string srFileName, List<string> lstContent)
        {
            using (StreamWriter swWrite = new StreamWriter(srFileName))
            {
                swWrite.AutoFlush = true;
                foreach (var vrPerLine in lstContent)
                {
                    swWrite.WriteLine(vrPerLine);
                }
            }
        }

        private static void writeToFile_v3(string srFileName, List<string> lstContent)
        {
            StreamWriter swWrite = new StreamWriter(srFileName);
            swWrite.AutoFlush = true;
            foreach (var vrPerLine in lstContent)
            {
                swWrite.WriteLine(vrPerLine);
            }
            swWrite.Flush();
            swWrite.Close();
        }

        private static void writeToFile_v4(string srFileName, List<string> lstContent)
        {
            File.Delete(srFileName);
            foreach (var vrLine in lstContent)
            {
                File.AppendAllText(srFileName, vrLine);
            }
        }

        private static void writeToFile_v5(string srFileName, List<string> lstContent)
        {
            var vrFile = String.Join("\r\n", lstContent);
            File.WriteAllText(srFileName, vrFile);
        }

        private void btnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            var vrPath = Assembly.GetEntryAssembly().Location;
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            var vrPath3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            var vrDefaultPath = "test.txt";
            if(txtReadFilePath.Text !="null")
            {
                vrDefaultPath = txtReadFilePath.Text;
            }

            loadIntoListBox(enListBoxNames.lstBoxNames, readFromFile_v4(vrDefaultPath), this);

            //loadIntoListBox(enListBoxNames.lstBoxGrades, readFromFile_v4(@"C:\Users\Furkan Gözükara\Desktop\2022 advanced programming\lecture 5\lecture 5 wpf\bin\Debug\net6.0-windows\test.txt"), this);
        }

        private static List<string> readFromFile_v1(string srPath)
        {
            return File.ReadAllText(srPath).Split(Environment.NewLine).ToList();
        }

        private static List<string> readFromFile_v2(string srPath)
        {
            return File.ReadAllLines(srPath).ToList();
        }

        private static List<string> readFromFile_v3(string srPath)
        {
            List<string> lstValues = new List<string>();
            foreach (var vrPerLine in File.ReadLines(srPath))
            {
                lstValues.Add(vrPerLine);
            }
            return lstValues;
        }

        private static List<string> readFromFile_v4(string srPath)
        {
            List<string> lstValues = new List<string>();
            using (StreamReader swRead = new StreamReader(srPath))
            {
                while (true)
                {
                    var vrLine = swRead.ReadLine();
                    if (vrLine == null)
                        break;
                    lstValues.Add(vrLine);
                }
            }

            return lstValues;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstBoxNames.Items.Clear();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            string srPath = "null";
            var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                srPath = dialog.FileName;
            }
            txtReadFilePath.Text = srPath;
        }

        private void lstBoxNames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vrSelectedIndex = lstBoxNames.SelectedIndex;
            lstBoxNames.Items[vrSelectedIndex] = DateTime.Now.ToString();
            lstBoxNames.SelectedIndex = vrSelectedIndex;
            MessageBox.Show(lstBoxNames.SelectedItem?.ToString());
        }

        //write a method to load into listbox from file using above methods


    }

}

