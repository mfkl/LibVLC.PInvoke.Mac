using System;
using System.IO;
using AppKit;

namespace LibVLC.PInvoke.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }

        static string AppExecutionDirectory => Path.GetDirectoryName(new Uri(typeof(MainClass).Assembly.CodeBase).LocalPath);
    }
}