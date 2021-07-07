using System;
using System.Runtime.InteropServices;

namespace N8Sprite.SaveSystem
{
    /// <see> https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox </see>
    public static class NativeWindowsAlert
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();
        
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int MessageBox(IntPtr windowHandle, string text, string caption, uint uType);

        public static IntPtr GetWindowHandle() => GetActiveWindow();

        /// <summary>
        /// Shows Error alert box with OK button.
        /// </summary>
        /// <param name="text">Main alert text / content.</param>
        /// <param name="caption">Message box title.</param>
        public static void Error(string text, string caption)
        {
            try
            {
                MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
            }
            catch
            {
                // ignored
            }
        }
    }
}