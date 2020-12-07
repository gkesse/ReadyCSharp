//===============================================
using System;
using System.Diagnostics;
using System.IO;
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
        mgr.app.bin_path = getEnv("GBIN_PATH");
        mgr.app.sqlite_db_path = getEnv("GSQLITE_DB_PATH");
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
    public void showData(string data) {
        Console.Write(data + "\n");
    }
    //===============================================
    // system
    //===============================================
    public string system(string command) {
        File.WriteAllText(mgr.app.cmd_path, "@echo off\n");
        File.AppendAllText(mgr.app.cmd_path, command + "\n");
        Process lProcess = new Process();
        lProcess.StartInfo.UseShellExecute = false;
        lProcess.StartInfo.RedirectStandardOutput = true;
        lProcess.StartInfo.FileName = mgr.app.cmd_path;
        lProcess.Start();
        string lOutput = lProcess.StandardOutput.ReadToEnd();
        lProcess.WaitForExit();
        return lOutput;
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
    // bin
    public string bin_path;
    // sqlite
    string sqlite_db_path;
}
//===============================================
