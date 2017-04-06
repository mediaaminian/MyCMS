using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCMS.Utilities
{
    public class ZipAndUnzipHelper
    {

        public static void Compress(DirectoryInfo directoryPath)
        {
            foreach (DirectoryInfo directory in directoryPath.GetDirectories())
            {
                var path = directoryPath.FullName;
                var newArchiveName = Regex.Replace(directory.Name, "[0-9]{8}", "20130913");
                newArchiveName = Regex.Replace(newArchiveName, "[_]+", "_");
                string startPath = path + directory.Name;
                string zipPath = path + "" + newArchiveName + ".zip";

                ZipFile.CreateFromDirectory(startPath, zipPath);
            }

        }

        public static void Decompress(DirectoryInfo directoryPath)
        {
            foreach (FileInfo file in directoryPath.GetFiles())
            {
                var path = directoryPath.FullName;
                string zipPath = path + file.Name;
                string extractPath = Regex.Replace(path + file.Name, file.Name, "");

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }

        public static bool Decompress(string zipPath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Decompress(ZipArchive ZipArchive, string extractPath, bool overwrite)
        {
            try
            {
                if (!overwrite)
                {
                    ZipArchive.ExtractToDirectory(extractPath);
                    return true;
                }
                foreach (ZipArchiveEntry file in ZipArchive.Entries)
                {
                    if (!Directory.Exists(extractPath))
                        Directory.CreateDirectory(extractPath);

                    string completeFileName = Path.Combine(extractPath, file.FullName);
                    if (file.Name == "")
                    {
                        // Assuming Empty for Directory
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        continue;
                    }
                    file.ExtractToFile(completeFileName, true);
                }
                //ZipArchive.ExtractToDirectory(extractPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
