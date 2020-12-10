//===============================================
using System;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;  
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
            CvInvoke.CheckLibraryLoaded();
            String win1 = "Test Window"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyAllWindows(); //Destroy all windows if key is pressed
    }
    //===============================================
}
//===============================================
