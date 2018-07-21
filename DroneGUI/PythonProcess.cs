using System;
using System.Diagnostics;
using System.IO;

namespace DroneGUI
{
    class PythonProcess
    {
        // Private Attributes
        private float _X;
        private float _Y;
        private float _Z;
        
        // Custom Constructor
        public PythonProcess(string x, string y, string z)
        {
            _X = Math.Abs(float.Parse(x));
            _Y = Math.Abs(float.Parse(y));
            _Z = Math.Abs(float.Parse(z));


            RunPythonApplication();
        }

        private void RunPythonApplication()
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();

                // Paths must be changed according to local machine
                start.FileName = @"C:\Users\<USERNAME>\AppData\Local\Programs\Python\Python37-32\python.exe";
                start.Arguments = string.Format("C:\\<DIRECTORY PATH>\\proto_v3.py {0} {1} {2}", _X, _Y, _Z);

                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
