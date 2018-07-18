using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using AppKit;

namespace LibVLC.PInvoke.Mac
{
    public partial class ViewController : NSViewController
    {
        const string LibraryName = "libvlc.5";

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var libvlc = LibVLCNew();

            if (libvlc == IntPtr.Zero){
                var error = ErrorMessage();
                var msg = Marshal.PtrToStringAnsi(error);
            }
        }
       
        static string AppExecutionDirectory => 
        Path.GetDirectoryName(new Uri(typeof(ViewController).Assembly.CodeBase).LocalPath);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "libvlc_new")]
        internal static extern IntPtr LibVLCNew(int argc = 0, IntPtr[] argv = default(IntPtr[]));

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "libvlc_get_version")]
        internal static extern IntPtr LibVLCVersion();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "libvlc_errmsg")]
        internal static extern IntPtr ErrorMessage();
    }
}