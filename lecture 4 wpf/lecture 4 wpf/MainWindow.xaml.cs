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

namespace lecture_4_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            lstNames.Items.Add(srFullname);

        }

        private void btnInsertName_Click(object sender, RoutedEventArgs e)
        {
            string srFullname = txtFirstName.Text + " | " + txtLastName.Text;
            int irInsertIndex = 0;
            Int32.TryParse(txtinserindex.Text, out irInsertIndex);

            if (irInsertIndex > lstNames.Items.Count)
                irInsertIndex = lstNames.Items.Count;

            irInsertIndex = (irInsertIndex < 0) ? 0 : irInsertIndex;//this is if and else in a single line and it is equal to below

            if (irInsertIndex < 0)
            {
                irInsertIndex = 0;
            }
            else
            {
                irInsertIndex = irInsertIndex;
            }

            lstNames.Items.Insert(irInsertIndex, srFullname);
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbSortOptions.SelectedIndex)
            {
                case 0:

                    break;

                case 1:
                    lstNames.Items.SortDescriptions.Clear();
                    lstNames.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("",System.ComponentModel.ListSortDirection.Ascending));
                    break;
                case 2:
                    lstNames.Items.SortDescriptions.Clear();
                    lstNames.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Descending));
                    break;
            }
        }
    }
}
