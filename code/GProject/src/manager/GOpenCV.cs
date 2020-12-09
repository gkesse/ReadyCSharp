//===============================================
using System;
using System.Collections.Generic;   
using QtGui;
using QtWidgets;
//===============================================
public sealed class GQt {
    //===============================================
    // property
    //===============================================
    private static GQt m_instance = null;
    private static readonly object padlock = new object();
    //===============================================
    private static QApplication m_app = null;
    //===============================================
    // constructor
    //===============================================
    GQt() {

    }
    //===============================================
    public static GQt Instance() {
        lock (padlock) {
            if (m_instance == null) {
                m_instance = new GQt();
            }
            return m_instance;
        }
    }
    //===============================================
    // method
    //===============================================
    public void run(string[] args) {
        QApplication lApp = App(args);
        QPushButton lWindow = new QPushButton("TEXT", null);
        lWindow.Show();
        QApplication.Exec();
    }
    //===============================================
    public static unsafe QApplication App(string[] args) {
        if(m_app == null) {
            int argc = 0;
            m_app = new QApplication (ref argc, null);        
        }
        return m_app;
    }
    //===============================================
}
//===============================================
