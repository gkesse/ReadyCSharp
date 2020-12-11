//===============================================
using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
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
        sGApp lApp = GManager.Instance().getData().app;
        CvInvoke.NamedWindow(lApp.app_name); 
        Mat lImg = new Mat(lApp.win_height, lApp.win_width, DepthType.Cv8U, 3); 
        lImg.SetTo(lApp.win_bg_color.MCvScalar); 
        CvInvoke.PutText(lImg, "HBonjour tout le monde", new System.Drawing.Point(10, 80), 
        FontFace.HersheyComplex, 1.0, lApp.win_fg_color.MCvScalar);
        CvInvoke.Imshow(lApp.app_name, lImg);
        CvInvoke.WaitKey(0);  
        CvInvoke.DestroyAllWindows();
    }
    //===============================================
}
//===============================================
