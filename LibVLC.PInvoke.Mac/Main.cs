using System;
using System.IO;
using AppKit;

namespace LibVLC.PInvoke.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            var libvlccoreDylibPath = Path.Combine(AppExecutionDirectory, $"lib/libvlccore.9.dylib");
            var libvlcDylibPath = Path.Combine(AppExecutionDirectory, $"lib/libvlc.5.dylib");

            var libvlccoreHandle = ObjCRuntime.Dlfcn.dlopen(libvlccoreDylibPath, 0);
            System.Diagnostics.Debug.WriteLine(libvlccoreHandle);

            var libvlcHandle = ObjCRuntime.Dlfcn.dlopen(libvlcDylibPath, 0);
            System.Diagnostics.Debug.WriteLine(libvlcHandle);

            NSApplication.Init();
            NSApplication.Main(args);
        }

        static string AppExecutionDirectory => Path.GetDirectoryName(new Uri(typeof(MainClass).Assembly.CodeBase).LocalPath);
    }
}