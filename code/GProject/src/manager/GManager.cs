//===============================================
using System;
using System.Diagnostics;
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
        Process cmd = new Process();
cmd.StartInfo.FileName = "cmd.exe";
cmd.StartInfo.RedirectStandardInput = true;
cmd.StartInfo.RedirectStandardOutput = true;
cmd.StartInfo.CreateNoWindow = true;
cmd.StartInfo.UseShellExecute = false;
cmd.Start();

cmd.StandardInput.WriteLine(@"echo Oscar");
cmd.StandardInput.Flush();
cmd.StandardInput.Close();
cmd.WaitForExit();
Console.WriteLine(cmd.StandardOutput.ReadToEnd());
    }
    //===============================================
}
//===============================================
