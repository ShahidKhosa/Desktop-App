using System;
using System.IO;
using System.Windows;
using Renci.SshNet;
using Microsoft.Win32;
using System.ComponentModel;

namespace SchoolSafeIDUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string host = "176.9.91.107";
        int port = 22;
        string username = "buyappco";
        string password = "AkR2jj15m2";
        string uploadfile = "";

        private BackgroundWorker worker = null;


        public MainWindow()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Properties.Settings.FirstUserSetting))
            {
                Properties.Settings.FirstUserSetting = "abc";
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Value saved " + Properties.Settings.FirstUserSetting);
            }

            
        }


        private void openDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"F:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "txt",
                //Filter = "txt files (*.txt)|*.txt",
                //FilterIndex = 2,

                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            // Show Open file dialog box
            Nullable<bool> result = openFileDialog1.ShowDialog();

            if (result == true)
            {
                uploadfile = openFileDialog1.FileName;
            } 
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                worker.CancelAsync();
                worker = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            enableFields();
        }


        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            worker.CancelAsync();
            worker = null;
            uploadCompleted();

            MessageBox.Show("File uploaded successfully!");
        }


        private void BrowseFile_Click(object sender, RoutedEventArgs e)
        {
            openDialog();

            if (!string.IsNullOrEmpty(uploadfile))
            {
                disableFields();
                
                if (worker == null)
                {
                    worker = new BackgroundWorker();
                    worker.DoWork += worker_DoWork;
                    worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                    //worker.ProgressChanged += worker_ProgressChanged;
                    //worker.WorkerReportsProgress = true;
                    worker.WorkerSupportsCancellation = true;                    
                }
                if (worker.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    worker.RunWorkerAsync();
                }
                
            }
                        
        }


        private void enableFields()
        {
            txtDistrictCode.IsEnabled   = true;
            txtSchoolCode.IsEnabled     = true;
            btnBrowseFile.Content       = "Browse File";
            btnBrowseFile.IsEnabled     = true;

            txtMessage.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
        }


        private void disableFields()
        {
            btnCancel.Visibility = Visibility.Visible;
            txtDistrictCode.IsEnabled = false;
            txtSchoolCode.IsEnabled = false;
            btnBrowseFile.Content = "Uploading...";
            btnBrowseFile.IsEnabled = false;
            txtMessage.Visibility = Visibility.Visible;
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string filename = Path.GetFileName(uploadfile);            

            const string workingdirectory = "/home2/buyappco/ftptesting";

            Console.WriteLine("Creating client and connecting");

            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("Connected to {0}", host);
                    
                    client.ChangeDirectory(workingdirectory);
                    Console.WriteLine("Changed directory to {0}", workingdirectory);

                    if (! client.Exists(workingdirectory + "/newdir"))
                    {
                        client.CreateDirectory(workingdirectory + "/newdir");
                    }                    

                    var listDirectory = client.ListDirectory(workingdirectory);
                    Console.WriteLine("Listing directory:");

                    foreach (var fi in listDirectory)
                    {
                        Console.WriteLine(" - " + fi.Name);
                    }

                    using (var fileStream = new FileStream(uploadfile, FileMode.Open))
                    {
                        Console.WriteLine("Uploading {0} ({1:N0} bytes)", uploadfile, fileStream.Length);
                        client.BufferSize = 100 * 1024; // bypass Payload error large files
                        client.UploadFile(fileStream, filename, true);                        
                    }
                }                            
            }
        }


        private void uploadCompleted()
        {
            enableFields();
            
            Console.WriteLine("File uploaded successfully!");
        }

    }
}
