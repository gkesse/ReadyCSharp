//===============================================
using System;
using System.Collections.Generic;   
using QtWidgets;
using QtCore.Qt;
//===============================================
public sealed class GQt {
    //===============================================
    // property
    //===============================================
    private static GQt m_instance = null;
    private static readonly object padlock = new object();
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
    public unsafe void run(string[] args) {
        sGApp lApp = GManager.Instance().getData().app;
        
        int argc = 0;
        lApp.app = new QApplication (ref argc, null);        
        
        QLabel lLabel = new QLabel();
        lLabel.Text = "Bonjour tout le monde";
        lLabel.Alignment = AlignmentFlag.AlignCenter;
        
        QVBoxLayout lMainLayout = new QVBoxLayout();
        lMainLayout.AddWidget(lLabel);

        QWidget lWindow = new QWidget();
        lWindow.Layout = lMainLayout;
        lWindow.Resize(lApp.win_width, lApp.win_height);
        lWindow.WindowTitle = lApp.app_name;
        lWindow.Show();
        
        QApplication.Exec();
    }
    //===============================================
}
//===============================================
