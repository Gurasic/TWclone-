
using System.IO;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

class DrawingImages
{
    public static string a = "";
    public static int b = 0;
    public static int c = 0;
    public static int d = 0;
    public static int e = 0;

    [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
    private static extern IntPtr GetConsoleHandle();

    [DllImport("user32.dll")]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    static void Main(string[] args)
    {
        Task.Factory.StartNew(ShowImage);

        Console.ReadLine();
    }

    static void ShowImage()
    {
        var form = new Form
        {
            BackgroundImage = System.Drawing.Image.FromFile(a),
            BackgroundImageLayout = ImageLayout.Stretch,
            FormBorderStyle = FormBorderStyle.None
        };

        var parent = GetConsoleHandle();
        var child = form.Handle;

        SetParent(child, parent);
        MoveWindow(child, b, c, c, e, true);

        System.Windows.Forms.Application.Run(form);
    }

    public static void DrawImage(string path1, int point1, int point2, int ImgS1, int ImgS2)
    {
        a = path1;
        b = point1;
        c = point2;
        d = ImgS1;
        e = ImgS1;
        Task.Factory.StartNew(ShowImage);
    }
}

