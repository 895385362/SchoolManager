using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public static string ReadFile(string filePath)
        {
            string fileValue = string.Empty;

            if (!IsFileExists(filePath))

                return fileValue;

            StreamReader rd = new StreamReader(filePath, Encoding.Default);

            fileValue = rd.ReadToEnd();

            rd.Close();

            return fileValue;
        }

        public static bool WriteFile(string filePath, string fileContent)
        {

            FileInfo info = new FileInfo(filePath);

            if (!Directory.Exists(info.DirectoryName))
            {
                Directory.CreateDirectory(info.DirectoryName);
            }

            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            try
            {
                writer.Write(fileContent);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                writer.Flush();
                stream.Flush();
                writer.Close();
                stream.Close();
            }

        }

    }
}
