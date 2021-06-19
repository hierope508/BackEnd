using System;
using System.IO;

namespace LogHelper
{
    public static class LogHelper
    {

        private static string _path = "/Log";
        private static string _filename = "Log.txt";
        private static string _fullPath = Path.Combine(_path, _filename);
        private static int _maxFileSize = 1;

        public static void LogMessage(string text)
        {
            Write(text);
        }

        public static void LogException(Exception ex)
        {
            if (ex.InnerException != null)
                LogException(ex.InnerException);

            Write(ex.Message);
            Write(ex.StackTrace);

        }


        public static void SetLogPath(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            _path = path;
            SetFullPath();
        }

        public static void SetLogFileName(string fileName)
        {
            _filename = fileName;
            SetFullPath();
        }

        public static void SetMaxFileSize(int size)
        {
            _maxFileSize = size;
        }

        private static void SetFullPath()
        {
            _fullPath = Path.Combine(_path, _filename);
        }

        private static void CheckFileSize()
        {
            FileInfo fileInfo = new FileInfo(_fullPath);
           
            if (File.Exists(_fullPath))
            {
                if ((fileInfo.Length / 1024) / 1024 >= _maxFileSize)
                    fileInfo.MoveTo(_fullPath + DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
        }

        private static void Write(string text)
        {
            CheckFileSize();

            using FileStream fs = new(_fullPath, FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new(fs))
            {
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff") + " - " + text);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            fs.Close();
            fs.Dispose();
        }

    }
}
