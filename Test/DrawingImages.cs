﻿
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

class Program
{
[DllImport("kernel32.dll", SetLastError = true)]
private static extern IntPtr GetConsoleWindow();

[DllImport("kernel32.dll", SetLastError = true)]
private static extern IntPtr CreateFile(
    string lpFileName,
    int dwDesiredAccess,
    int dwShareMode,
    IntPtr lpSecurityAttributes,
    int dwCreationDisposition,
    int dwFlagsAndAttributes,
    IntPtr hTemplateFile);

[DllImport("kernel32.dll", SetLastError = true)]
private static extern bool GetCurrentConsoleFont(
    IntPtr hConsoleOutput,
    bool bMaximumWindow,
    [Out][MarshalAs(UnmanagedType.LPStruct)]ConsoleFontInfo lpConsoleCurrentFont);

[StructLayout(LayoutKind.Sequential)]
internal class ConsoleFontInfo
{
    internal int nFont;
    internal Coord dwFontSize;
}

[StructLayout(LayoutKind.Explicit)]
internal struct Coord
{
    [FieldOffset(0)]
    internal short X;
    [FieldOffset(2)]
    internal short Y;
}

private const int GENERIC_READ = unchecked((int)0x80000000);
private const int GENERIC_WRITE = 0x40000000;
private const int FILE_SHARE_READ = 1;
private const int FILE_SHARE_WRITE = 2;
private const int INVALID_HANDLE_VALUE = -1;
private const int OPEN_EXISTING = 3;
    private static Size GetConsoleFontSize()
    {
        // getting the console out buffer handle
        IntPtr outHandle = CreateFile("CONOUT$", GENERIC_READ | GENERIC_WRITE,
            FILE_SHARE_READ | FILE_SHARE_WRITE,
            IntPtr.Zero,
            OPEN_EXISTING,
            0,
            IntPtr.Zero);
        int errorCode = Marshal.GetLastWin32Error();
        if (outHandle.ToInt32() == INVALID_HANDLE_VALUE)
        {
            throw new IOException("Unable to open CONOUT$", errorCode);
        }

        ConsoleFontInfo cfi = new ConsoleFontInfo();
        if (!GetCurrentConsoleFont(outHandle, false, cfi))
        {
            throw new InvalidOperationException("Unable to get font information.");
        }

        return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);
    }
    static void DrawImage(string path1, int point1, int point2, int ImgS1, int ImgS2)
    {
        Point location = new Point(point1, point2);
        Size imageSize = new Size(ImgS1, ImgS2); // desired image size in characters

        // draw some placeholders
        Console.SetCursorPosition(location.X - 1, location.Y);
        Console.Write(">");
        Console.SetCursorPosition(location.X + imageSize.Width, location.Y);
        Console.Write("<");
        Console.SetCursorPosition(location.X - 1, location.Y + imageSize.Height - 1);
        Console.Write(">");
        Console.SetCursorPosition(location.X + imageSize.Width, location.Y + imageSize.Height - 1);
        Console.WriteLine("<");

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures), path1);
        using (Graphics g = Graphics.FromHwnd(GetConsoleWindow()))
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                Size fontSize = GetConsoleFontSize();

                // translating the character positions to pixels
                Rectangle imageRect = new Rectangle(
                    location.X * fontSize.Width,
                    location.Y * fontSize.Height,
                    imageSize.Width * fontSize.Width,
                    imageSize.Height * fontSize.Height);
                g.DrawImage(image, imageRect);
            }
        }
    }


    static void Main(string[] args)
    {
        DrawImage(@"C:\Users\Amr\source\repos\ConsoleApp2\ConsoleApp2\Screenshot_3.png", 10, 10, 50, 10);
        DrawImage(@"C:\Users\Amr\source\repos\ConsoleApp2\ConsoleApp2\Screenshot_3.png", 10,20, 50, 10);
    }
}

