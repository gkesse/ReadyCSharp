//===============================================
using System;
//===============================================
public sealed class GString {
    //===============================================
    // property
    //===============================================
    private static GString m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
    //===============================================
    GString() {

    }
    //===============================================
    public static GString Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GString();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public string toUpper(string data) {
        return data.ToUpper();
    }
    //===============================================
    public string toLower(string data) {
        return data.ToLower();
    }
    //===============================================
}
//===============================================
