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
            if(G_STATE == "S_ADMIN") {run_ADMIN(args);}
            else if(G_STATE == "S_INIT") {run_INIT(args);}
            else if(G_STATE == "S_METHOD") {run_METHOD(args);}
            else if(G_STATE == "S_CHOICE") {run_CHOICE(args);}
            else if(G_STATE == "S_SQLITE") {run_SQLITE(args);}
            else if(G_STATE == "S_SAVE") {run_SAVE(args);}
            else if(G_STATE == "S_LOAD") {run_LOAD(args);}
            else if(G_STATE == "S_QUIT") {run_QUIT(args);}
            else break;
        }
    }
    //===============================================
    public void run_ADMIN(string[] args) {
        G_STATE = "S_END";
    }
    //===============================================
    public void run_INIT(string[] args) {
        Console.WriteLine("run_INIT");
        G_STATE = "S_LOAD";
    }
    //===============================================
    public void run_METHOD(string[] args) {
        Console.WriteLine("run_METHOD");
        G_STATE = "S_CHOICE";
    }
    //===============================================
    public void run_CHOICE(string[] args) {
        Console.WriteLine("run_CHOICE");
        G_STATE = "S_SQLITE";
    }
    //===============================================
    public void run_SQLITE(string[] args) {
        Console.WriteLine("run_SQLITE");
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_SAVE(string[] args) {
        Console.WriteLine("run_SAVE");
        G_STATE = "S_QUIT";
    }
    //===============================================
    public void run_LOAD(string[] args) {
        Console.WriteLine("run_LOAD");
        G_STATE = "S_METHOD";
    }
    //===============================================
    public void run_QUIT(string[] args) {
        Console.WriteLine("run_QUIT");
        G_STATE = "S_END";
    }
    //===============================================
}
//===============================================
