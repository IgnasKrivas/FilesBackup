using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace FilesBackupApp
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string inputFolder = @args[1];
                string outputFolder = @args[0];
                if (inputFolder.Equals(outputFolder))
                {
                    Console.WriteLine("Negalima saugoti archivuojame aplankale.");
                }
                else
                {
                    string dateAndTime = "Backup " + DateTime.Now.ToString("yyyy/M/dd") + " " +
                                         DateTime.Now.ToString("HH-mm");
                    FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    zip.CreateEmptyDirectories = true;
                    zip.CreateZip(inputFolder + "\\" + dateAndTime + ".zip", outputFolder, true, "");
                    if (File.Exists(inputFolder + "/" + dateAndTime + ".zip"))
                        Console.WriteLine("Užbaigta.");
                    else
                        Console.WriteLine("Nepavyko.");
                }
            }
            else
            {

                Console.WriteLine("Deklaruoti aplankalus. Parametrai:\n 1 - Archivuojamas aplankalas 2 - Saugojimo vieta.");
            }
        }
    }
}
