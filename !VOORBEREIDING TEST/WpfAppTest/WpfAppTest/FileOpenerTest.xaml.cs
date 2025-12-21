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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfAppTest
{
    public partial class FileOpener : Window
    {
        public FileOpener()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Files | *.pdf";
            fileDialog.Title = "hello i am here as a test...";
            
            // je kan meerdere bestandjes selecteren YAY
            // maar om dit te laten werken moet je van 'string path' = fileDialog.FileName -> 'string[] paths = fileDialog.FileNames' maken
            fileDialog.Multiselect = true; 

            bool? success = fileDialog.ShowDialog();
            if (success == true)
            {
                string path = fileDialog.FileName;
                string fileNameWithoutPath = fileDialog.SafeFileName;

                tbInfo.Text = fileNameWithoutPath;
            }
            else
            {
                // user didn't pick anything...
            }
        }
    }
}
