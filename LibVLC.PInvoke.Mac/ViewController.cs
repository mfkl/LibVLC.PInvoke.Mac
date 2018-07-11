using System;
using System.Runtime.InteropServices;
using AppKit;

namespace LibVLC.PInvoke.Mac
{
    public partial class ViewController : NSViewController
    {
        const string LibraryName = "@executable_path/lib/libvlc.5.dylib";
        //const string LibraryName = "libvlc.5";

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var libvlc = LibVLCNew();
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "libvlc_new")]
        internal static extern IntPtr LibVLCNew(int argc = 0, IntPtr[] argv = default(IntPtr[]));
    }
}
