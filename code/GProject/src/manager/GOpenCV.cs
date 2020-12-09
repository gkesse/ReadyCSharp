//===============================================
using System;
using System.Collections.Generic;   
//===============================================
public sealed class GOpenCV {
    //===============================================
    // property
    //===============================================
    private static GOpenCV m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    // constructor
    //===============================================
    GOpenCV() {

    }
    //===============================================
    public static GOpenCV Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GOpenCV();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public void run(string[] args) {

    }
    //===============================================
}
//===============================================
