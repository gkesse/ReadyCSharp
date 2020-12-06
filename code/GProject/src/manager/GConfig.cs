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
    public static GConfig Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GConfig();
                }
                return m_instance;
            }
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
}
//===============================================
