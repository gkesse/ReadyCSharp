//===============================================
using System;
//===============================================
public sealed class GSQLiteUi {
    //===============================================
    // property
    //===============================================
    private static GSQLiteUi m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    private string G_STATE;
    //===============================================
    // constructor
    //===============================================
    GSQLiteUi() {

    }
    //===============================================
    public static GSQLiteUi Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GSQLiteUi();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public void run(string[] args) {
        G_STATE = "S_INIT";
        while(true) {
            if(G_STATE == "S_ADMIN") {run_ADMIN(args);}
            else if(G_STATE == "S_INIT") {run_INIT(args);}
            else if(G_STATE == "S_METHOD") {run_METHOD(args);}
            else if(G_STATE == "S_CHOICE") {run_CHOICE(args);}
            //
            else if(G_STATE == "S_SHOW_TABLES") {run_SHOW_TABLES(args);}
            else if(G_STATE == "S_CONFIG_SHARP_SHOW_DATA") {run_CONFIG_SHARP_SHOW_DATA(args);}
            else if(G_STATE == "S_CONFIG_SHARP_SHOW_SCHEMA") {run_CONFIG_SHARP_SHOW_SCHEMA(args);}
            else if(G_STATE == "S_CONFIG_SHARP_DELETE") {run_CONFIG_SHARP_DELETE(args);}
            //
            else if(G_STATE == "S_SAVE") {run_SAVE(args);}
            else if(G_STATE == "S_LOAD") {run_LOAD(args);}
            else if(G_STATE == "S_QUIT") {run_QUIT(args);}
            else break;
        }
    }
    //===============================================
    public void run_ADMIN(string[] args) {
        GProcessUi.Instance().run(args);
        G_STATE = "S_END";
    }
    //===============================================
    public void run_INIT(string[] args) {
        Console.Write("\n");
        Console.Write("SQLITE_ADMIN !!!\n");
        Console.Write("\t{0,-2} : {1}\n", "-q", "quitter l'application");
        Console.Write("\t{0,-2} : {1}\n", "-i", "reinitialiser l'application");
        Console.Write("\t{0,-2} : {1}\n", "-a", "redemarrer l'application");
        Console.Write("\t{0,-2} : {1}\n", "-v", "valider les configurations");
        Console.Write("\n");
        G_STATE = "S_LOAD";
    }
    //===============================================
    public void run_METHOD(string[] args) {
        Console.Write("SQLITE_ADMIN :\n");
        Console.Write("\t{0,-2} : {1}\n", "1", "afficher les tables");
        Console.Write("\t{0,-2} : {1}\n", "2", "afficher les donnees CONFIG_SHARP");
        Console.Write("\t{0,-2} : {1}\n", "3", "afficher le schema CONFIG_SHARP");
        Console.Write("\t{0,-2} : {1}\n", "4", "supprimer la table CONFIG_SHARP");
        Console.Write("\n");
        G_STATE = "S_CHOICE";
    }
    //===============================================
    public void run_CHOICE(string[] args) {
        string lLast = GConfig.Instance().getData("G_SQLITE_ID");
        Console.Write("SQLITE_ADMIN ({0}) ? : ", lLast);
        string lAnswer = Console.ReadLine();
        if(lAnswer == "") lAnswer = lLast;
        if(lAnswer == "-q") G_STATE = "S_END";
        else if(lAnswer == "-i") G_STATE = "S_INIT";
        else if(lAnswer == "-a") G_STATE = "S_ADMIN";
        //
        else if(lAnswer == "1") {G_STATE = "S_SHOW_TABLES"; GConfig.Instance().setData("G_SQLITE_ID", lAnswer);} 
        else if(lAnswer == "2") {G_STATE = "S_CONFIG_SHARP_SHOW_DATA"; GConfig.Instance().setData("G_SQLITE_ID", lAnswer);} 
        else if(lAnswer == "3") {G_STATE = "S_CONFIG_SHARP_SHOW_SCHEMA"; GConfig.Instance().setData("G_SQLITE_ID", lAnswer);} 
        else if(lAnswer == "4") {G_STATE = "S_CONFIG_SHARP_DELETE"; GConfig.Instance().setData("G_SQLITE_ID", lAnswer);} 
        //
    }
    //===============================================
    public void run_SHOW_TABLES(string[] args) {
        Console.Write("\n");
        string lQuery = String.Format(@"
        select name from sqlite_master
        where type = 'table'
        ");
        GSQLite.Instance().queryShow(lQuery);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_CONFIG_SHARP_SHOW_DATA(string[] args) {
        Console.Write("\n");
        string lQuery = String.Format(@"
        select * from config_data
        ");
        GSQLite.Instance().queryShow(lQuery);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_CONFIG_SHARP_SHOW_SCHEMA(string[] args) {
        Console.Write("\n");
        string lQuery = String.Format(@"
        select sql from sqlite_master
        where type = 'table'
        and name = 'config_data'
        ");
        string lValue = GSQLite.Instance().queryValue(lQuery);
        GManager.Instance().showData(lValue);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_CONFIG_SHARP_DELETE(string[] args) {
        Console.Write("\n");
        string lQuery = String.Format(@"
        drop table if exists config_data
        ");
        GSQLite.Instance().queryWrite(lQuery);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_SAVE(string[] args) {
        GConfig.Instance().saveData("G_SQLITE_ID");
        G_STATE = "S_QUIT";
    }
    //===============================================
    public void run_LOAD(string[] args) {
        GConfig.Instance().loadData("G_SQLITE_ID");
        G_STATE = "S_METHOD";
    }
    //===============================================
    public void run_QUIT(string[] args) {
        Console.Write("\n");
        Console.Write("CSHARP_QUIT (Oui/[N]on) ? : ");
        string lAnswer = Console.ReadLine();
        if(lAnswer == "-q") G_STATE = "S_END";
        else if(lAnswer == "-i") G_STATE = "S_INIT";
        else if(lAnswer == "-a") G_STATE = "S_ADMIN";
        else if(lAnswer == "o") {G_STATE = "S_END";} 
        else if(lAnswer == "n") {G_STATE = "S_INIT";} 
        else if(lAnswer == "") {G_STATE = "S_INIT";} 
    }
    //===============================================
}
//===============================================
