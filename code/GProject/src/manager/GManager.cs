//===============================================
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Emgu.CV.Structure;
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
        mgr.app.win_width = 640;
        mgr.app.win_height = 480;
        mgr.app.win_bg_color = new Bgr(0x10, 0x10, 0x30);
        mgr.app.win_fg_color = new Bgr(0xFF, 0xFF, 0xFF);
    }
    //===============================================
    public static GManager Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GManager();
            }
            return m_instance;
        }
    }
    //===============================================
    // data
    //===============================================
    public sGManager getData() {
        return mgr;
    }
    //===============================================
    public void showData(string data) {
        Console.Write("[{0}]\n", data);
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
    public void showData(List<string> data) {
        Console.Write("[");
        for(int i = 0; i < data.Count; i++) {
            if(i != 0) Console.Write(" ; ");
            string lData = data[i];
            Console.Write(lData);
        }
        Console.Write("]\n");
    }
    //===============================================
    public void showData(List<List<string>> data) {
        for(int i = 0; i < data.Count; i++) {
            List<string> lDataMap = data[i];
            Console.Write("[");
            for(int j = 0; j < lDataMap.Count; j++) {
                if(j != 0) Console.Write(" ; ");
                string lData = lDataMap[j];
                Console.Write(lData);
            }
            Console.Write("]\n");
        }
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
    // string
    //===============================================
    public int getWidth(string widthMap, int index, int defaultWidth) {
        string[] lWidthMap = widthMap.Split(';');
        int lLength = lWidthMap.Length;
        if(index >= lLength) return defaultWidth;
        string lWidthId = lWidthMap[index]; int lOut;
        if(!int.TryParse(lWidthId, out lOut)) return defaultWidth;
        int lWidth = int.Parse(lWidthId);
        return lWidth;
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
    public string sqlite_db_path;
    // win
    public int win_width;
    public int win_height;
    public Bgr win_bg_color;
    public Bgr win_fg_color;
}
//===============================================
