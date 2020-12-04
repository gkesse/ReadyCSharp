//===============================================
using System;
//===============================================
public sealed class GProcess {
    //===============================================
    private static GProcess m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    GProcess() {

    }
    //===============================================
    public static GProcess Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GProcess();
                }
                return m_instance;
            }
        }
    }
    //===============================================
    public void run(string[] args) {
        GManager.Instance.showData(args);
        Console.WriteLine(args.Length);
        string lKey = "test";
        if(args.Length > 1) lKey = args[1];
        if(lKey == "test") {runTest(args); return;}
        if(lKey == "ui") {runUi(args); return;}
        runTest(args);
    }
    //===============================================
    public void runTest(string[] args) {
        Console.WriteLine("runTest");
    }
    //===============================================
    public void runUi(string[] args) {
        Console.WriteLine("runUi");
    }
    //===============================================
}
//===============================================
