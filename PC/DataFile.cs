/* DataFile.cs
 * Written by Chuck Bolin, October 22, 2014
 * Purpose: Provide code to read and parse 'photo_transfer_data.txt' file
 */
using System.IO;
using System;
using System.Windows.Forms;

namespace PhotoTransferNamespace
{
    

    public class PhotoTransferClass
    {

        public static string cameraFolderPath;
        public static string localFolderPath;
        public static string remoteFolderPath;

        public Boolean readPhotoTransferDataFile()
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + @"\photo_transfer_data.txt";

            if (!System.IO.File.Exists(filename))
            {
                return false;
            }//if
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    char[] delimiter = { ',' };
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] keyValuePair = line.Split(delimiter);
                        if (keyValuePair[0] == "camera")
                        {
                             cameraFolderPath = keyValuePair[1];
                        }
                        else if (keyValuePair[0] == "local")
                        {
                            localFolderPath = keyValuePair[1];
                        }
                        else if (keyValuePair[0] == "remote")
                        {
                            remoteFolderPath = keyValuePair[1];
                        }
                    }

                    return true;
                }//using

            }//else
        }//readPhotoTransferDataFile()
    }//class
}//namespace