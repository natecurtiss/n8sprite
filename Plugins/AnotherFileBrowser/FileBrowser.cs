#if UNITY_STANDALONE_WIN
using Ookii.Dialogs;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AnotherFileBrowser.Windows
{
    public sealed class FileBrowser
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        /// <summary>
        /// FileDialog for picking a single file
        /// </summary>
        /// <param name="browserProperties">Special Properties of File Dialog</param>
        /// <param name="filepath">User picked path (Callback)</param>
        public void OpenFileBrowser(BrowserProperties browserProperties, Action<string> filepath)
        {
            VistaOpenFileDialog __openFileDialog = new VistaOpenFileDialog
            {
                Multiselect = false,
                Title = browserProperties.Title ?? "Select a File",
                InitialDirectory = browserProperties.InitialDirectory ?? @"C:\",
                Filter = browserProperties.Filter ?? "All files (*.*)|*.*",
                FilterIndex = browserProperties.FilterIndex + 1,
                RestoreDirectory = browserProperties.RestoreDirectory
            };

            if (__openFileDialog.ShowDialog(new WindowWrapper(GetActiveWindow())) == DialogResult.OK) 
                filepath(__openFileDialog.FileName);
        }

        /// <summary>
        /// FileDialog for picking multiple file(s)
        /// </summary>
        /// <param name="browserProperties">Special Properties of File Dialog</param>
        /// <param name="filepath">User picked path(s) (Callback)</param>
        public void OpenMultiSelectFileBrowser(BrowserProperties browserProperties, Action<string[]> filepath)
        {
            VistaOpenFileDialog __openFileDialog = new VistaOpenFileDialog
            {
                Multiselect = true,
                Title = browserProperties.Title ?? "Select a File",
                InitialDirectory = browserProperties.InitialDirectory ?? @"C:\",
                Filter = browserProperties.Filter ?? "All files (*.*)|*.*",
                FilterIndex = browserProperties.FilterIndex + 1,
                RestoreDirectory = browserProperties.RestoreDirectory
            };

            if (__openFileDialog.ShowDialog(new WindowWrapper(GetActiveWindow())) == DialogResult.OK) 
                filepath(__openFileDialog.FileNames);
        }

        /// <summary>
        /// FileDialog for selecting any folder 
        /// </summary>
        /// <param name="browserProperties">Special Properties of File Dialog</param>
        /// <param name="folderpath">User picked path(s) (Callback)</param>
        public void OpenFolderBrowser(BrowserProperties browserProperties, Action<string> folderpath)
        {
            VistaFolderBrowserDialog __openFolderDialog = new VistaFolderBrowserDialog
            {
                Description = browserProperties.Title, 
                UseDescriptionForTitle = true
            };

            if (__openFolderDialog.ShowDialog(new WindowWrapper(GetActiveWindow())) == DialogResult.OK) 
                folderpath(__openFolderDialog.SelectedPath);
        }

        /// <summary>
        /// FileDialog for saving any file, returns path with extension for further uses
        /// </summary>
        /// <param name="browserProperties">Special Properties of File Dialog</param>
        /// <param name="defaultFileName">Default File Name</param>
        /// <param name="defaultExt">Default File name extension, adds after default file name.</param>
        /// <param name="savepath">User picked path(s) (Callback)</param>
        public void SaveFileBrowser(BrowserProperties browserProperties, string defaultFileName, string defaultExt, Action<string> savepath)
        {
            VistaSaveFileDialog __saveFileDialog = new VistaSaveFileDialog
            {
                FileName = defaultFileName,
                DefaultExt = defaultExt,
                CheckPathExists = true,
                OverwritePrompt = true,
                Title = browserProperties.Title,
                InitialDirectory = browserProperties.InitialDirectory ?? @"C:\",
                Filter = browserProperties.Filter,
                FilterIndex = browserProperties.FilterIndex + 1,
                RestoreDirectory = browserProperties.RestoreDirectory
            };

            if (__saveFileDialog.ShowDialog(new WindowWrapper(GetActiveWindow())) == DialogResult.OK) 
                savepath(__saveFileDialog.FileName);
        }
    }

    public sealed class BrowserProperties
    {
        public string Title { get; set; } 
        public string InitialDirectory;
        public string Filter;
        public int FilterIndex; 
        public bool RestoreDirectory = true;

        public BrowserProperties() { }
        public BrowserProperties(string title) { Title = title; }
    }
    
    public sealed class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle) => Handle = handle;

        public IntPtr Handle { get; }
    }
}
#endif