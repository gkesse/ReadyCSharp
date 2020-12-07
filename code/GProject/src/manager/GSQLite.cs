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
    public void open() {

    }
    //===============================================
}
//===============================================
