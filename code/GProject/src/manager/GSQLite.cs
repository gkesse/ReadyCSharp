//===============================================
using System;
using System.Data.SQLite;
//===============================================
public sealed class GSQLite {
    //===============================================
    private static GSQLite m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    GSQLite() {
        string lQuery;
        // config_data
        lQuery = @"
        create table if not exists config_data (
        config_key text,
        config_value text)
        ";
        queryWrite(lQuery);
        // tables
        lQuery = @"
        select * from sqlite_master
        where type = 'table'
        ";
        queryShow(lQuery);
    }
    //===============================================
    public static GSQLite Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GSQLite();
                }
                return m_instance;
            }
        }
    }
    //===============================================
    // method
    //===============================================
    public SQLiteCommand open() {
        sGApp lApp = GManager.Instance.getData().app;
        SQLiteConnection lCon = new SQLiteConnection("Data Source=" + lApp.sqlite_db_path);
        lCon.Open();
        SQLiteCommand lCmd = new SQLiteCommand(lCon);
        return lCmd;
    }
    //===============================================
    public void queryWrite(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        lCmd.ExecuteNonQuery();
    }
    //===============================================
    public void queryShow(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        //
        string widthMap = "20;20;20;10";
        int defaultWidth = 30;
        string[] lWidthMap = widthMap.Split(';');
        // sep
        Console.Write("+-");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write("-+-");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance.getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
        // header
        Console.Write("| ");
        for(int i= 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write(" | ");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance.getWidth(widthMap, i, defaultWidth);
            Console.Write("{0," + (-lWidth) + "}", lData);  
        }
        Console.Write(" |");
        Console.Write("\n");
        // sep
        Console.Write("+-");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write("-+-");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance.getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
        // row
        while(lReader.Read()) {
            Console.Write("| ");
            for(int i= 0; i < lReader.FieldCount; i++) {
                if(i != 0) Console.Write(" | ");
                string lData = lReader[i].ToString();
                int lWidth = GManager.Instance.getWidth(widthMap, i, defaultWidth);
                Console.Write("{0," + (-lWidth) + "}", lData);  
            }
            Console.Write(" |");
            Console.Write("\n");
        }
        // sep
        Console.Write("+-");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write("-+-");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance.getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
    }
    //===============================================
    public void queryValue(string sqlQuery) {

    }
    //===============================================
}
//===============================================
