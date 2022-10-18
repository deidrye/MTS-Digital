using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {       //... write your code here 	}

        // Environment.Exit(0);

        // Process.GetCurrentProcess().Kill();

        /*
        string procName = Process.GetCurrentProcess().ProcessName;
        foreach (Process process in Process.GetProcessesByName(procName))
        {
            process.Kill();
        }
        */

        /*
        int procId = Process.GetCurrentProcess().Id;
        Process.GetProcessById(procId).Kill();
        */

    }


}
