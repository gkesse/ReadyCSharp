//===============================================
using System;
//===============================================
public sealed class GProcessUi {
    //===============================================
    private static GProcessUi m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    private string G_STATE;
    //===============================================
    GProcessUi() {

    }
    //===============================================
    public static GProcessUi Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GProcessUi();
                }
                return m_instance;
            }
        }
    }
    //===============================================
    public void run(string[] args) {
        G_STATE = "S_INIT";
        while(true) {
            if(G_STATE == "S_INIT") {run_INIT(args);}
            else if(G_STATE == "S_METHOD") {run_METHOD(args);}
            else if(G_STATE == "S_CHOICE") {run_CHOICE(args);}
            //
            else if(G_STATE == "S_SQLITE") {run_SQLITE(args);}
            else if(G_STATE == "S_OPENCV") {run_OPENCV(args);}
            //
            else if(G_STATE == "S_SAVE") {run_SAVE(args);}
            else if(G_STATE == "S_LOAD") {run_LOAD(args);}
            else break;
        }
    }
    //===============================================
    public void run_INIT(string[] args) {
        Console.Write("\n");
        Console.Write("CSHARP_ADMIN !!!\n");
        Console.Write("\t{0,-2} : {1}\n", "-q", "quitter l'application");
        Console.Write("\n");
        G_STATE = "S_LOAD";
    }
    //===============================================
    public void run_METHOD(string[] args) {
        Console.Write("CSHARP_ADMIN :\n");
        Console.Write("\t{0,-2} : {1}\n", "1", "S_SQLITE");
        Console.Write("\t{0,-2} : {1}\n", "2", "S_OPENCV");
        Console.Write("\n");
        G_STATE = "S_CHOICE";
    }
    //===============================================
    public void run_CHOICE(string[] args) {
        string lLast = "3";
        Console.Write("CSHARP_ADMIN ({0}) ? : ", lLast);
        string lAnswer = Console.ReadLine();
        if(lAnswer == "") lAnswer = lLast;
        if(lAnswer == "-q") G_STATE = "S_END";
        //
        else if(lAnswer == "1") {G_STATE = "S_SQLITE";} 
        else if(lAnswer == "2") {G_STATE = "S_OPENCV";}
        //
    }
    //===============================================
    public void run_SQLITE(string[] args) {
        GSQLiteUi.Instance.run(args);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_OPENCV(string[] args) {
        Console.WriteLine("run_OPENCV");
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_SAVE(string[] args) {
        G_STATE = "S_QUIT";
    }
    //===============================================
    public void run_LOAD(string[] args) {
        G_STATE = "S_METHOD";
    }
    //===============================================
}
//===============================================
