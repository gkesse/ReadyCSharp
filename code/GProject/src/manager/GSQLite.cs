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
        config_value text
        )";
        queryWrite(lQuery);
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
    public void queryValue(string sqlQuery) {

    }
    //===============================================
}
//===============================================
