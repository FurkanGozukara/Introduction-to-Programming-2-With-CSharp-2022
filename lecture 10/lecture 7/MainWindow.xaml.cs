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
using System.Data;
using System.Globalization;
using System.Threading;
using System.IO;

namespace lecture_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("tr-TR");
            // Put the following code before InitializeComponent()
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            lstFirstNames = File.ReadAllLines("first-names.txt").ToList();
            lstLastNames = File.ReadAllLines("last-names.txt").ToList();
        }

        private void btnLoadDataGrid_Click(object sender, RoutedEventArgs e)
        {
            refreshDataGrid();
        }

        int irPageSize = 100;

        int irCountOfPages;

        int irPrevPageNumber, irNextPageNumber;

        private void refreshDataGrid()
        {
            int irSelectedIndex = cbmPages.SelectedIndex;

            int irRecordcount = DbOperations.selectTable("select COUNT (*) from tblStudents").Rows[0][0].ToString().toInt32();

            irCountOfPages = irRecordcount / irPageSize + 1;

            cbmPages.Items.Clear();
            for (int i = 1; i < irCountOfPages+1; i++)
            {
                cbmPages.Items.Add("Page: " + i);
            }
            cbmPages.SelectedIndex = irSelectedIndex;
            int irCurrentRecordPage = irSelectedIndex+1 ;

            if (irCurrentRecordPage < 1)
                irCurrentRecordPage = 1;

            irPrevPageNumber = ((irCurrentRecordPage < 2) ? irCountOfPages : irCurrentRecordPage - 1);

            irNextPageNumber = ((irCurrentRecordPage == irCountOfPages) ? 1 : irCurrentRecordPage + 1);

            btnPrev.Content = "Goto Page: " + irPrevPageNumber;
            btnNext.Content = "Goto Page: " + irNextPageNumber;
            lblCurrentPage.Content = irCurrentRecordPage;

            string srQuery = $@"DECLARE @PageNumber AS INT
DECLARE @RowsOfPage AS INT
SET @PageNumber={irCurrentRecordPage}
SET @RowsOfPage={irPageSize}
SELECT * FROM tblStudents
ORDER BY StudentId 
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY";

            DataTable dtData = DbOperations.selectTable(srQuery);

            //for (int i = 0; i < dtData.Rows.Count; i++)
            //{
            //    var vrVal = dtData.Rows[i]["BirthDate"].ToString();
            //    if (string.IsNullOrEmpty(vrVal.Trim()))
            //        continue;
            //    dtData.Rows[i]["BirthDate"] = Convert.ToDateTime(dtData.Rows[i]["BirthDate"].ToString()).ToString("yyyy-MM-dd");
            //}

            DataView dvData = new DataView(dtData);


            dtStudents.ItemsSource = dvData;
          


        }

        private void btnSaveNewStudent_Click(object sender, RoutedEventArgs e)
        {
            string srAddNewStudent = @"insert into tblStudents (StudentId,StudentName,PhoneNumber,Email,BirthDate,LastLoginDate) 
                values ({0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')";

            srAddNewStudent = string.Format(srAddNewStudent,
                txtStudentId.Text,
                txtStudentName.Text,
                txtPhoneNumber.Text,
                txtEmail.Text,
                dateBirth.SelectedDate.Value.ToString(),
                dateLogin.SelectedDate.Value.ToString());

            int irResult = DbOperations.updateDeleteInsert(srAddNewStudent);
            displayResult(irResult);
        }

        private void displayResult(int irResult)
        {
            if (irResult == -1)
            {
                MessageBox.Show("an SQL error occured. Please check the logs");
                return;
            }

            MessageBox.Show("success query. number of rows affected : " + irResult);

            refreshDataGrid();
        }

        private void btnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (dtStudents.SelectedItem == null)
                return;

            DataRowView vrItem = (DataRowView)dtStudents.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you sure to delete Student Id {vrItem.Row["StudentId"]} - {vrItem.Row["StudentName"]}?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes)
            {
                return;
            }

            int irResult = DbOperations.updateDeleteInsert($"delete from tblStudents where StudentId={vrItem.Row["StudentId"]}");

            displayResult(irResult);
        }

        private void btnUpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dtStudents.SelectedItem == null)
                return;

            DataRowView vrItem = (DataRowView)dtStudents.SelectedItem;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you sure to update Student Id {vrItem.Row["StudentId"]} - {vrItem.Row["StudentName"]}?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes)
            {
                return;
            }

            DateTime dtBirth = Convert.ToDateTime(vrItem["BirthDate"]);
            DateTime dtLastLogin = Convert.ToDateTime(vrItem["LastLoginDate"]);

            int irResult = DbOperations.updateDeleteInsert(@$"  update tblStudents set StudentName=N'{vrItem["StudentName"]}',PhoneNumber=N'{vrItem["PhoneNumber"]}',Email=N'{vrItem["Email"]}',BirthDate=N'{dtBirth.ToString("yyyy-MM-dd")}',LastLoginDate=N'{dtLastLogin.ToString("yyyy-MM-dd hh:mm:ss.000")}' 
                    where StudentId = {vrItem["StudentId"]}");

            displayResult(irResult);
        }

        private void btnRandomStudent_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => { generateRandomStudents(); });
        }

        private void generateRandomStudents()
        {
            string srBaseQuery = "insert into tblStudents (StudentName,PhoneNumber,Email,BirthDate) values (N'{0}',N'{1}',N'{2}',N'{3}')";

            HashSet<string> hsUsedEmails = new HashSet<string>();

            foreach (DataRow drw in DbOperations.selectTable("select Email from tblStudents").Rows)
            {
                hsUsedEmails.Add(drw[0].ToString());
            }

            StringBuilder srQueries = new StringBuilder();

            int irCounter2 = 1;

            for (int i = 0; i < 100000; i++)
            {
                string srName = generateRandomName();
                string srPhone = generateRandomPhoneNumber();
                string srEmail = srName.Replace(" ", "_") + returnEmailProvider();
                while (true)
                {
                    int irCounter = 0;
                    if (hsUsedEmails.Contains(srEmail))
                    {
                        srEmail = srName.Replace(" ", "_") + irCounter + returnEmailProvider();
                        irCounter++;
                    }
                    else
                    {
                        hsUsedEmails.Add(srEmail);
                        break;
                    }
                }
                string srBirthDate = generateRandomBirthdate();

                string srFormattedQuery = string.Format(srBaseQuery, srName, srPhone, srEmail, srBirthDate);

                srQueries.Append(srFormattedQuery + ";");

                //  DbOperations.updateDeleteInsert(srFormattedQuery);

                if (irCounter2 > 250)
                {
                    DbOperations.updateDeleteInsert(srQueries.ToString());
                    srQueries = new StringBuilder();
                    irCounter2 = 1;
                }
                irCounter2++;
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    lblProgress.Content = "so far processed student count: " + i.ToString("N0");
                }));
              
            }

            DbOperations.updateDeleteInsert(srQueries.ToString());
        }

        static List<string> lstProviders = new List<string> { "gmail", "outlook", "hotmail", "yahoo", "dmail", "yandex", "live" };

        private static string returnEmailProvider()
        {
            return "@" + lstProviders[myRand.Next(0, lstProviders.Count)] + ".com";
        }


        static List<string> lstFirstNames = new List<string>();
        static List<string> lstLastNames = new List<string>();

        private static Random myRand = new Random();

        private static string generateRandomName()
        {
            return lstFirstNames[myRand.Next(0, lstFirstNames.Count)] + " " + lstLastNames[myRand.Next(0, lstLastNames.Count)];
        }

        private static string generateRandomPhoneNumber()
        {
            //+90-5**-***-**-**
            return $"+90-5{myRand.Next(0, 10)}{myRand.Next(0, 10)}-{myRand.Next(0, 10)}{myRand.Next(0, 10)}{myRand.Next(0, 10)}-{myRand.Next(0, 10)}{myRand.Next(0, 10)}-{myRand.Next(0, 10)}{myRand.Next(0, 10)}";
        }

        private static string generateRandomBirthdate()
        {
            //1900-12-12
            return $"19{myRand.Next(0, 10)}{myRand.Next(0, 10)}-{myRand.Next(1, 13)}-{myRand.Next(1, 29)}";
        }

        private void btnOpenHashSet_Click(object sender, RoutedEventArgs e)
        {
            HashandDictionary newWindow = new HashandDictionary();
            newWindow.Show();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            cbmPages.SelectedIndex = irNextPageNumber-1;
            refreshDataGrid();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to delete all existing records?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
                return;

                DbOperations.updateDeleteInsert("truncate table tblstudents;");
            DbOperations.updateDeleteInsert("DBCC CHECKIDENT(tblstudents, RESEED, 1)");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var vrResult = PublicMethods.checkUserName(txtUserName.Text);
            if(vrResult.blResult==false)
            {
                MessageBox.Show("Error: " + vrResult.srMsg);
                return;
            }
            vrResult = PublicMethods.checkUserName(txtRegisterEmail.Text);
            if (vrResult.blResult == false)
            {
                MessageBox.Show("Error: " + vrResult.srMsg);
                return;
            }

            if(pw1.Password.ToString()!=pw2.Password.ToString())
            {
                MessageBox.Show("Error: Entered passwords are not matching!");
                return;
            }

            int irUserSalt = new Random().Next();

            string srUserSaltedPw = pw1.Password.ToString() + irUserSalt;

            string srUserHashedPassword = PublicMethods.ComputeSha256Hash(srUserSaltedPw);


        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            cbmPages.SelectedIndex = irPrevPageNumber-1;
            refreshDataGrid();
        }
    }
}
