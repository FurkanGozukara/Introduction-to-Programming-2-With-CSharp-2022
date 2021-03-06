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
        }

        private void btnLoadDataGrid_Click(object sender, RoutedEventArgs e)
        {
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            DataTable dtData = DbOperations.selectTable("select * from tblStudents");

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
    }
}
