//===============================================
using System;
using System.Collections.Generic;
using System.Data.SQLite;
//===============================================
public sealed class GSQLite {
    //===============================================
    // property
    //===============================================
    private static GSQLite m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
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
    }
    //===============================================
    public static GSQLite Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GSQLite();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public SQLiteCommand open() {
        sGApp lApp = GManager.Instance().getData().app;
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
    public void queryShow(string sqlQuery, string widthMap = "", int defaultWidth = 20) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        string[] lWidthMap = widthMap.Split(';');
        // sep
        Console.Write("+-");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write("-+-");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance().getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
        // header
        Console.Write("| ");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write(" | ");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance().getWidth(widthMap, i, defaultWidth);
            Console.Write("{0," + (-lWidth) + "}", lData);  
        }
        Console.Write(" |");
        Console.Write("\n");
        // sep
        Console.Write("+-");
        for(int i = 0; i < lReader.FieldCount; i++) {
            if(i != 0) Console.Write("-+-");
            string lData = lReader.GetName(i);
            int lWidth = GManager.Instance().getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
        // row
        while(lReader.Read()) {
            Console.Write("| ");
            for(int i = 0; i < lReader.FieldCount; i++) {
                if(i != 0) Console.Write(" | ");
                string lData = lReader[i].ToString();
                int lWidth = GManager.Instance().getWidth(widthMap, i, defaultWidth);
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
            int lWidth = GManager.Instance().getWidth(widthMap, i, defaultWidth);
            for(int j = 0; j < lWidth; j++) {
                Console.Write("-");
            }
        }
        Console.Write("-+");
        Console.Write("\n");
        lReader.Close();
    }
    //===============================================
    public string queryValue(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        string lData = "";
        while(lReader.Read()) {
            lData = lReader[0].ToString();
            break;
        }
        lReader.Close();
        return lData;
    }
    //===============================================
    public List<string> queryCol(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        List<string> lDataMap = new List<string>();
        while(lReader.Read()) {
            string lData = lReader[0].ToString();
            lDataMap.Add(lData);
        }
        lReader.Close();
        return lDataMap;
    }
    //===============================================
    public List<string> queryRow(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        List<string> lDataMap = new List<string>();
        while(lReader.Read()) {
            for(int i = 0; i < lReader.FieldCount; i++) {
                string lData = lReader[i].ToString();
                lDataMap.Add(lData);
            }
            break;
        }
        lReader.Close();
        return lDataMap;
    }
    //===============================================
    public List<List<string>> queryMap(string sqlQuery) {
        SQLiteCommand lCmd = open();
        lCmd.CommandText = sqlQuery;
        SQLiteDataReader lReader = lCmd.ExecuteReader();
        List<List<string>> lDataMap = new List<List<string>>();
        while(lReader.Read()) {
            List<string> lDataRow = new List<string>();
            for(int i = 0; i < lReader.FieldCount; i++) {
                string lData = lReader[i].ToString();
                lDataRow.Add(lData);
            }
            lDataMap.Add(lDataRow);
        }
        lReader.Close();
        return lDataMap;
    }
    //===============================================
}
//===============================================
