using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhotoTransferNamespace;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace TEF_Photo_Transfer
{
    public partial class formMain : Form
    {
        string mRemoteFilecount = "";
        string mLocalFilecount = "";

        public formMain()
        {
           InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            PhotoTransferClass ptc = new PhotoTransferClass();
            Boolean bReturn = ptc.readPhotoTransferDataFile();
            int folderCount = 0;
            int minFolderCount = 0;

            if (bReturn)
            {
                //write pathes to the three folder textboxes
                textCameraFolder.Text = PhotoTransferNamespace.PhotoTransferClass.cameraFolderPath;
                textLocalFolder.Text = PhotoTransferNamespace.PhotoTransferClass.localFolderPath;
                textRemoteFolder.Text = PhotoTransferNamespace.PhotoTransferClass.remoteFolderPath;
                
                //verify all three folders exist
                if (!System.IO.Directory.Exists(textCameraFolder.Text))
                {
                    MessageBox.Show(textCameraFolder.Text + Environment.NewLine + " Does not exist! Aborting application.");
                    Application.Exit();
                }
                else
                {
                    folderCount++;
                    minFolderCount++;
                }

                if (!System.IO.Directory.Exists(textLocalFolder.Text))
                {
                    MessageBox.Show(textLocalFolder.Text + Environment.NewLine + " Does not exist! Aborting application.");
                    Application.Exit();
                }
                else
                {
                    folderCount++;
                    minFolderCount++;
                }

                if (!System.IO.Directory.Exists(textRemoteFolder.Text))
                {
                    //remote does not exist
                }
                else
                {
                    folderCount++;
                }

                //okay to operate remotely
                if (folderCount == 3)
                {
                    //program proceeds, all is normal
                    checkBoxNetwork.Enabled = true;
                }
                //okay to operate locally
                else if (folderCount == 2 && minFolderCount == 2)
                {
                    checkBoxNetwork.Checked = false;
                    checkBoxNetwork.Enabled = false;
                }
                //failure
                else
                {
                    MessageBox.Show("Failed to locate all three folders!");
                    Application.Exit();
                }

                //start time to update listbox for camera folder
                timerUpdateListbox.Enabled = true;
                timerUpdateListbox.Start();
                timerUpdateFilecount.Enabled = true;
                timerUpdateFilecount.Start();

            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (textPartNumber.TextLength < 12)
            {
                MessageBox.Show("Part number is too short!");
                return;
            }
            else if (textPartNumber.TextLength > 12)
            {
                MessageBox.Show("Part number is too long!");
                return;
            }

            timerUpdateListbox.Stop();
            //timerUpdateFilecount.Stop();

            if (listCameraFolder.Items.Count > 0)
            {
                int index = Convert.ToInt32(textIndex.Text.ToString());

                foreach (string s in listCameraFolder.Items)
                {
                    string sourceFile = System.IO.Path.Combine(textCameraFolder.Text, s);
                    string newDestFilename = getDestFilename(index);
                    string destFile = System.IO.Path.Combine(textRemoteFolder.Text, newDestFilename);//remote filename
                    string destMoveFile = System.IO.Path.Combine(textLocalFolder.Text, newDestFilename);//local filename


                    if (checkBoxNetwork.Checked == true)
                    {
                        if (File.Exists(destFile))
                        {
                            MessageBox.Show("UBK part number " + newDestFilename + " already exists in network folder. Picture will not be transferred. \nVerify that the picture on the website is the correct picture for the UBK number.");
                            return;
                        } else {
                          Debug.WriteLine("Pos1");
                            //insertIntoSQL(newDestFilename, destFile); //update SQL
                            Debug.WriteLine("Pos2");
                            System.IO.File.Copy(sourceFile, destFile, true); //copy file to remote folder
                            Debug.WriteLine("Pos3");
                        }
                    }
                    try
                    {
                        System.IO.File.Move(sourceFile, destMoveFile);
                        index++;
                    }
                    catch (IOException e0)
                    {
                        MessageBox.Show("UBK part number " + newDestFilename + " already exists in local machine. Picture will not be transferred. \nVerify that the picture of the part on the computer is the same item.");
                        return;
                    }
                }

                textPartNumber.Clear();
            }
            timerUpdateListbox.Start();
            //timerUpdateFilecount.Start();
        }

      //NOTE: Modified database table to run on new server from 2008
      //      --alter table dbo.t_tefPhotos drop column ID
      //--alter table dbo.t_tefPhotos add ID int identity(1,1)
/*
        private void insertIntoSQL(string fileName, string filePath)
        {
            string query = "insert into dbo.t_tefPhotos (PhotoName, Filepath)  values(\'" + fileName + "\',\'" + filePath + "\')";
            Debug.WriteLine(query);

          //Moved app database table to ICO database
            try
            {
              SQL_Class sql = new SQL_Class(SERVER,DBNAME,USER,PWD);
              Debug.WriteLine("Instantiated");
              string result = sql.Execute(query);
              Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
              Debug.WriteLine("Error: " + ex.ToString());

            }
        }
*/
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //clears listbox and
        private void updateListbox()
        {
            DirectoryInfo dinfo = new DirectoryInfo(textCameraFolder.Text);
            FileInfo[] Files = dinfo.GetFiles("*.jpg");
            listCameraFolder.BeginUpdate();
            listCameraFolder.Items.Clear();
            foreach (FileInfo file in Files)
            {
                listCameraFolder.Items.Add(file.Name);
            }
            listCameraFolder.EndUpdate();
        }


        //all references to GUI has been removed so this may run within a thread
        private void updateFileCounts(ref string localCount, ref string remoteCount)
        {

            int fileLocalCount = Directory.GetFiles(textLocalFolder.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).Length;
            localCount = fileLocalCount.ToString();
            if (checkBoxNetwork.Checked == true)
            {
                int fileRemoteCount = Directory.GetFiles(textRemoteFolder.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).Length;
                remoteCount = fileRemoteCount.ToString();
            }
            else
            {
                labelRemoteCount.Text = "";
                remoteCount = "";
            }

        }

        //private void updateFileCounts()
        //{

        //    int fileLocalCount = Directory.GetFiles(textLocalFolder.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).Length;
        //    labelLocalCount.Text = fileLocalCount.ToString();

        //    if (checkBoxNetwork.Checked == true)
        //    {
        //        int fileRemoteCount = Directory.GetFiles(textRemoteFolder.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).Length;
        //        labelRemoteCount.Text = fileRemoteCount.ToString();
        //    }
        //    else
        //    {
        //        labelRemoteCount.Text = "";
        //    }

        //}

        private string getDestFilename(int index)
        {           

            return textPartNumber.Text + "_" + index.ToString() + ".jpg";
        }

        private void timerUpdateListbox_Tick(object sender, EventArgs e)
        {
            //Updates listbox showing files to be processed //TODO flicker
            updateListbox();

            //The file counts are updated within a thread and saved to module
            //level variables, and updated here for convenience
            labelRemoteCount.Text = mRemoteFilecount;
            labelLocalCount.Text = mLocalFilecount;

        }

        //Added 2015.07.17, Allows for determining filecount on server
        //without bogging down the app. Requested by Drew W. - CBolin
        private void timerUpdateFilecount_Tick(object sender, EventArgs e)
        {
            if (checkBoxNetwork.Checked == false)
                return;

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            string localCount = "";
            string remoteCount="";

            //change interval to 60 seconds after initial update
            timerUpdateFilecount.Interval = 60000;
            //timerUpdateFilecount.Stop();
            
            Task.Factory.StartNew(()=> {
              updateFileCounts(ref localCount, ref remoteCount);
              //Debug.WriteLine("InsideEnd: " + localCount + ", " + remoteCount);
              mRemoteFilecount = remoteCount;
              mLocalFilecount = localCount;
            });

            ts.Cancel();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textPartNumber.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            textPartNumber.Text= buttonClear1.Text;
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            textPartNumber.Text= buttonClear2.Text;
        }

        private void buttonClear3_Click(object sender, EventArgs e)
        {
            textPartNumber.Text= buttonClear3.Text;
        }

        private void buttonClear4_Click(object sender, EventArgs e)
        {
            textPartNumber.Text= buttonClear4.Text;
        }

        private void buttonCustomClear_Click(object sender, EventArgs e)
        {
            textPartNumber.Text= textCustomClear.Text;
        }

        //This will generate a new HTML page
        //I:\Projects\TEF\TEF3 Crib Photos\cribphotos.html
        //***************************************************************
        private void buttonHTML_Click(object sender, EventArgs e)
        {
            //delete templisting.txt file if it exists
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templisting.txt"))
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\templisting.txt");

            //run query to extract all data in the photos table
            string query = "select * from dbo.t_tefPhotos order by PhotoName";
            buttonHTML.Enabled = false;
            //SQL_Class sql = new SQL_Class(SERVER,DBNAME,USER,PWD);
            //string result = sql.Execute(query);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\templisting.txt", false))
            {
                try
                {                    
               //     file.Write(result);
                    file.Close();
                }
                catch (IOException ex)
                {
                }
                catch (Exception ex)
                {
                }
                buttonHTML.Enabled = true;
            }
            
            //Verify file exists
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\templisting.txt"))
            {
                StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\templisting.txt");
                StreamWriter writer = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\cribphotos.html", false);
                
                string header = "<html><head><title>Crib Parts Photos</title></head><body>";
                string footer = "</body></html>";
                DateTime dt = DateTime.Now;

                writer.WriteLine(header);
                writer.WriteLine("<a1>Updated by TEF Photo Transfer App at " + dt.ToString() + "</a1><br><br>");
                writer.WriteLine("<a1>When looking for a particular part number, use Ctrl+F, type in the part number, and then hit Enter.</a1><br><br>");

                //loop through file to create an HTML file
                string line;

                char[] delimiter = { ',' };
                while ((line = reader.ReadLine()) != null)
                {
                    string[] photoData = line.Split(delimiter);
                    string output = "<a href=\"file://" + photoData[2] + "\">" + photoData[1] + "</a><br>";

                    writer.WriteLine(output);
                }
                writer.WriteLine(footer);
                writer.Close();
                reader.Close();


                //copy created HTML file to remote location
                string srcFile = AppDomain.CurrentDomain.BaseDirectory + @"\cribphotos.html";
                string destFile = System.IO.Path.Combine(textRemoteFolder.Text,  @"cribphotos.html");
                try
                {
                    File.Copy(srcFile, destFile, true);
                    if (File.Exists(destFile))
                        MessageBox.Show("Crib HTML file has been created in the remote folder!");
                    else
                        MessageBox.Show("Oops! This is embarrassing. Failed to create cribphotos.html file");
                }
                catch (UnauthorizedAccessException e0)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e0.Message);
                }
                catch (ArgumentException e1)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e1.Message);
                }
                catch (PathTooLongException e2)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e2.Message);
                }
                catch (DirectoryNotFoundException e3)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e3.Message);
                }
                catch (FileNotFoundException e4)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e4.Message);
                }
                catch (IOException e5)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e5.Message);
                }
                catch (NotSupportedException e6)
                {
                    MessageBox.Show("Failed to copy cribphotos.html file to the remote location\n" + e6.Message);
                }


            }
        }

        private void listCameraFolder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxNetwork_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
