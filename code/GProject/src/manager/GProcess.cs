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
    public static GProcess Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GProcess();
            }
            return m_instance;
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
        if(lKey == "qt") {runQt(args); return;}
        if(lKey == "opencv") {runOpenCV(args); return;}
        runTest(args);
    }
    //===============================================
    public void runTest(string[] args) {
        GSQLite.Instance();
    }
    //===============================================
    public void runUi(string[] args) {
        GProcessUi.Instance().run(args);
    }
    //===============================================
    public void runQt(string[] args) {
        GQt.Instance().run(args);
    }
    //===============================================
    public void runOpenCV(string[] args) {
        GOpenCV.Instance().run(args);
    }
    //===============================================
}
//===============================================
