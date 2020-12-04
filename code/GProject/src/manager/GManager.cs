//===============================================
using System;
using System.Diagnostics;
//===============================================
// manager
//===============================================
public sealed class GManager {
    //===============================================
    // property
    //===============================================
    private static GManager m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
    //===============================================
    GManager() {

    }
    //===============================================
    public static GManager Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GManager();
                }
                return m_instance;
            }
        }
    }
    //===============================================
    // data
    //===============================================
    public void showData(string[] data) {
        Console.Write("[");
        for(int i = 0; i < data.Length; i++) {
            if(i != 0) Console.Write(" ; ");
            string lData = data[i];
            Console.Write(lData);
        }
        Console.Write("]\n");
    }
    //===============================================
    // system
    //===============================================
    public void system(string command) {
    /*Process p = new Process();
    // Redirect the output stream of the child process.
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.FileName = "echo oooooo";
    p.Start();
    // Do not wait for the child process to exit before
    // reading to the end of its redirected stream.
    // p.WaitForExit();
    // Read the output stream first and then wait.
    string output = p.StandardOutput.ReadToEnd();
    p.WaitForExit();*/
    }
    //===============================================
    // env
    //===============================================
    public string getEnv(string lKey) {
        string lValue = Environment.GetEnvironmentVariable(lKey);
        Console.Write("{0}\n", lValue);
        return lValue;
    }
    //===============================================
}
//===============================================
// struct
//===============================================
//===============================================
