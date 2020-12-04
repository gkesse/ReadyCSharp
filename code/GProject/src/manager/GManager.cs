//===============================================
using System;
//===============================================
public sealed class GManager {
    //===============================================
    // property
    //===============================================
    private static GManager m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
    //===============================================
    GManager() {

    }
    //===============================================
    public static GManager Instance {
        get {
            lock (padlock) {
                if (m_instance == null) {
                    m_instance = new GManager();
                }
                return m_instance;
            }
        }
    }
    //===============================================
    // data
    //===============================================
    public void showData(string[] data) {
        Console.WriteLine("[");
        for(int i = 0; i < data.Length; i++) {
            if(i != 0) Console.WriteLine(" ; ");
            string lData = data[i];
            Console.WriteLine(lData);
        }
        Console.WriteLine("]");
    }
    //===============================================
}
//===============================================
