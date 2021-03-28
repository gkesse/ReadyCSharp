//===============================================
using System;
using System.Collections.Generic;   
//===============================================
public sealed class GConfig {
    //===============================================
    // property
    //===============================================
    private static GConfig m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    private Dictionary<string, string> m_dataMap;
    //===============================================
    // constructor
    //===============================================
    GConfig() {
        m_dataMap = new Dictionary<string, string>();
    }
    //===============================================
    public static GConfig Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GConfig();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public void setData(string key, string valueId) {
        m_dataMap[key] = valueId;
    }
    //===============================================
    public string getData(string key) {
        string lValue = "";
        m_dataMap.TryGetValue(key, out lValue);
        return lValue;
    }
    //===============================================
    public void saveData(string key) {
        string lValue = getData(key);
        int lCount = countData(key);
        if(lCount == 0) insertData(key, getData(key));
        else updateData(key, getData(key));
    }
    //===============================================
    public void loadData(string key) {
        string lQuery = String.Format(@"
        select config_value from config_data
        where config_key = '{0}'
        ", key);
        string lValue = GSQLite.Instance().queryValue(lQuery);
        setData(key, lValue);
    }
    //===============================================
    public int countData(string key) {
        string lQuery = String.Format(@"
        select count(*) from config_data
        where config_key = '{0}'
        ", key);
        int lCount = int.Parse(GSQLite.Instance().queryValue(lQuery));
        return lCount;
    }
    //===============================================
    public void insertData(string key, string valueId) {
        key = key.Replace("'", "''");
        valueId = valueId.Replace("'", "''");
        string lQuery = String.Format(@"
        insert into config_data (config_key, config_value)
        values ('{0}', '{1}')
        ", key, valueId);
        GSQLite.Instance().queryWrite(lQuery);
    }
    //===============================================
    public void updateData(string key, string valueId) {
        key = key.Replace("'", "''");
        valueId = valueId.Replace("'", "''");
        string lQuery = String.Format(@"
        update config_data 
        set config_value = '{1}'
        where config_key = '{0}'
        ", key, valueId);
        GSQLite.Instance().queryWrite(lQuery);
    }
    //===============================================
}
//===============================================
