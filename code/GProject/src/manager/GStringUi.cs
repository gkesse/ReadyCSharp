//===============================================
using System;
//===============================================
public sealed class GStringUi {
    //===============================================
    // property
    //===============================================
    private static GStringUi m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    private string G_STATE;
    //===============================================
    // constructor
    //===============================================
    GStringUi() {

    }
    //===============================================
    public static GStringUi Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GStringUi();
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
            else if(G_STATE == "S_TO_UPPER_STRING_DATA") {run_TO_UPPER_STRING_DATA(args);}
            else if(G_STATE == "S_TO_UPPER") {run_TO_UPPER(args);}
            //
            else if(G_STATE == "S_TO_LOWER_STRING_DATA") {run_TO_LOWER_STRING_DATA(args);}
            else if(G_STATE == "S_TO_LOWER") {run_TO_LOWER(args);}
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
        Console.Write("STRING_ADMIN !!!\n");
        Console.Write("\t{0,-2} : {1}\n", "-q", "quitter l'application");
        Console.Write("\t{0,-2} : {1}\n", "-i", "reinitialiser l'application");
        Console.Write("\t{0,-2} : {1}\n", "-a", "redemarrer l'application");
        Console.Write("\t{0,-2} : {1}\n", "-v", "valider les configurations");
        Console.Write("\n");
        G_STATE = "S_LOAD";
    }
    //===============================================
    public void run_METHOD(string[] args) {
        Console.Write("STRING_ADMIN :\n");
        Console.Write("\t{0,-2} : {1}\n", "1", "lettre en majuscule");
        Console.Write("\t{0,-2} : {1}\n", "2", "lettre en minuscule");
        Console.Write("\t{0,-2} : {1}\n", "3", "lettre en capital");
        Console.Write("\n");
        G_STATE = "S_CHOICE";
    }
    //===============================================
    public void run_CHOICE(string[] args) {
        string lLast = GConfig.Instance().getData("G_STRING_ID");
        Console.Write("STRING_ADMIN ({0}) ? : ", lLast);
        string lAnswer = Console.ReadLine();
        if(lAnswer == "") lAnswer = lLast;
        if(lAnswer == "-q") G_STATE = "S_END";
        else if(lAnswer == "-i") G_STATE = "S_INIT";
        else if(lAnswer == "-a") G_STATE = "S_ADMIN";
        //
        else if(lAnswer == "1") {G_STATE = "S_TO_UPPER_STRING_DATA"; GConfig.Instance().setData("G_STRING_ID", lAnswer);} 
        else if(lAnswer == "2") {G_STATE = "S_TO_LOWER_STRING_DATA"; GConfig.Instance().setData("G_STRING_ID", lAnswer);} 
        //
    }
    //===============================================
    public void run_TO_UPPER_STRING_DATA(string[] args) {
        string lLast = GConfig.Instance().getData("G_STRING_DATA");
        Console.Write("G_STRING_DATA ({0}) ? : ", lLast);
        string lAnswer = Console.ReadLine();
        if(lAnswer == "") lAnswer = lLast;
        if(lAnswer == "-q") G_STATE = "S_END";
        else if(lAnswer == "-i") G_STATE = "S_INIT";
        else if(lAnswer == "-a") G_STATE = "S_ADMIN";
        else if(lAnswer == "-v") {G_STATE = "S_TO_UPPER";} 
        else if(lAnswer != "") {G_STATE = "S_TO_UPPER"; GConfig.Instance().setData("G_STRING_DATA", lAnswer);} 
    }
    //===============================================
    public void run_TO_UPPER(string[] args) {
        Console.Write("\n");
        string lData = GConfig.Instance().getData("G_STRING_DATA");
        lData = GString.Instance().toUpper(lData);
        Console.Write("{0}\n", lData);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_TO_LOWER_STRING_DATA(string[] args) {
        string lLast = GConfig.Instance().getData("G_STRING_DATA");
        Console.Write("G_STRING_DATA ({0}) ? : ", lLast);
        string lAnswer = Console.ReadLine();
        if(lAnswer == "") lAnswer = lLast;
        if(lAnswer == "-q") G_STATE = "S_END";
        else if(lAnswer == "-i") G_STATE = "S_INIT";
        else if(lAnswer == "-a") G_STATE = "S_ADMIN";
        else if(lAnswer == "-v") {G_STATE = "S_TO_LOWER";} 
        else if(lAnswer != "") {G_STATE = "S_TO_LOWER"; GConfig.Instance().setData("G_STRING_DATA", lAnswer);} 
    }
    //===============================================
    public void run_TO_LOWER(string[] args) {
        Console.Write("\n");
        string lData = GConfig.Instance().getData("G_STRING_DATA");
        lData = GString.Instance().toLower(lData);
        Console.Write("{0}\n", lData);
        G_STATE = "S_SAVE";
    }
    //===============================================
    public void run_SAVE(string[] args) {
        GConfig.Instance().saveData("G_STRING_ID");
        GConfig.Instance().saveData("G_STRING_DATA");
        G_STATE = "S_QUIT";
    }
    //===============================================
    public void run_LOAD(string[] args) {
        GConfig.Instance().loadData("G_STRING_ID");
        GConfig.Instance().loadData("G_STRING_DATA");
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
