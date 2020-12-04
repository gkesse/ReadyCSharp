//===============================================
using System;
//===============================================
public sealed class GProcess {
    //===============================================
    // property
    //===============================================
    private static GProcess m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
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
    // method
    //===============================================
    public void run(string[] args) {
        string lKey = "test";
        if(args.Length > 0) lKey = args[0];
        if(lKey == "test") {runTest(args); return;}
        if(lKey == "ui") {runUi(args); return;}
        runTest(args);
    }
    //===============================================
    public void runTest(string[] args) {
        sGApp lApp = GManager.Instance.getData().app;
        GManager.Instance.showData(GManager.Instance.system(lApp.bin_path + " ui"));
    }
    //===============================================
    public void runUi(string[] args) {
        GProcessUi.Instance.run(args);
    }
    //===============================================
}
//===============================================
