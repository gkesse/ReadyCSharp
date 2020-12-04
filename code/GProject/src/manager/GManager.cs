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
    private sGManager mgr;
    //===============================================
    // constructor
    //===============================================
    GManager() {
        // manager
        mgr = new sGManager();
        // app
        mgr.app = new sGApp();
        mgr.app.app_name = "ReadyApp";
        mgr.app.cmd_path = getEnv("GCMD_PATH");
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
    public sGManager getData() {
        return mgr;
    }
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
        Process p = new Process();
        lProcess.StartInfo.UseShellExecute = false;
        lProcess.StartInfo.RedirectStandardOutput = true;
        lProcess.StartInfo.FileName = mgr.app.cmd_path;
        lProcess.Start();
        string output = lProcess.StandardOutput.ReadToEnd();
        Console.Write(output + "\n");
        lProcess.WaitForExit();
    }
    //===============================================
    // env
    //===============================================
    public string getEnv(string lKey) {
        string lValue = Environment.GetEnvironmentVariable(lKey);
        return lValue;
    }
    //===============================================
}
//===============================================
// struct
//===============================================
public struct sGManager {
    public sGApp app;
}
//===============================================
public struct sGApp {
    // app
    public string app_name;
    // cmd
    public string cmd_path;
}
//===============================================
