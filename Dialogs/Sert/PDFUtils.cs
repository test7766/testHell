﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using WMSOffice.Dialogs.Sert.GhostscriptSharp;
using WMSOffice.Dialogs.Sert.GhostscriptSharp.Settings;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Wrapper над библиотекой Ghostscript
    /// </summary>
    public static class PDFUtils
    {
        /// <summary>
        /// Извлечение страниц из PDF-документа, представленных как отдельные изображения
        /// </summary>
        /// <param name="pdfBytes"></param>
        /// <returns></returns>
        public static List<Image> ExtractPages(byte[] pdfBytes)
        {
            var pdfImages = new List<Image>();

            try
            {
                string tmpFile = Path.GetTempFileName();
                File.WriteAllBytes(tmpFile, pdfBytes);

                var numPages = 0;
                if (File.Exists(tmpFile))
                    numPages = Regex.Matches(File.ReadAllText(tmpFile), @"/Type\s*/Page[^s]").Count;

                var tmpfilePages = new List<string>();

                for (int i = 0; i < numPages; i++)
                {
                    try
                    {
                        var tmpFilePage = string.Empty;
                        tmpfilePages.Add(tmpFilePage = Path.GetTempFileName());

                        GhostscriptWrapper.GenerateOutput(tmpFile, tmpFilePage,
                           new GhostscriptSettings()
                           {
                               Device = GhostscriptDevices.tiffgray,
                               Page = new GhostscriptPages
                               {
                                   Start = i + 1,
                                   End = i + 1
                               },
                               Resolution = new Size
                               {
                                   Height = 300,
                                   Width = 300
                               },
                               Size = new GhostscriptPageSize
                               {
                                   Native = GhostscriptPageSizes.a4
                               }
                           });

                        if (File.Exists(tmpFilePage))
                            pdfImages.Add(Image.FromFile(tmpFilePage));

                        //if (File.Exists(tmpFilePage))
                        //    File.Delete(tmpFilePage);
                    }
                    catch (Exception ex)
                    { 
                    
                    }
                }

                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);

                foreach (var tmpFilePage in tmpfilePages)
                    if (File.Exists(tmpFilePage))
                        File.Delete(tmpFilePage);
            }
            catch (Exception ex)
            {
                
            }

            return pdfImages;
        }

        /// <summary>
        /// Извлечение страниц из PDF-документа, представленных как отдельные изображения
        /// </summary>
        /// <param name="pdfBytes"></param>
        /// <returns></returns>
        public static List<byte[]> ExtractPagesEx(byte[] pdfBytes)
        {
            var pdfImages = new List<byte[]>();

            try
            {
                string tmpFile = Path.GetTempFileName();
                File.WriteAllBytes(tmpFile, pdfBytes);

                var numPages = 0;
                if (File.Exists(tmpFile))
                    numPages = Regex.Matches(File.ReadAllText(tmpFile), @"/Type\s*/Page[^s]").Count;

                var tmpfilePages = new List<string>();

                for (int i = 0; i < numPages; i++)
                {
                    try
                    {
                        var tmpFilePage = string.Empty;
                        tmpfilePages.Add(tmpFilePage = Path.GetTempFileName());

                        GhostscriptWrapper.GenerateOutput(tmpFile, tmpFilePage,
                           new GhostscriptSettings()
                           {
                               Device = GhostscriptDevices.tiffgray,
                               Page = new GhostscriptPages
                               {
                                   Start = i + 1,
                                   End = i + 1
                               },
                               Resolution = new Size
                               {
                                   Height = 300,
                                   Width = 300
                               },
                               Size = new GhostscriptPageSize
                               {
                                   Native = GhostscriptPageSizes.a4
                               }
                           });

                        if (File.Exists(tmpFilePage))
                        {
                            var fs = File.OpenRead(tmpFilePage);
                            byte[] buffer = new byte[(int)fs.Length];
                            fs.Read(buffer, 0, (int)fs.Length);
                            pdfImages.Add(buffer);
                        }

                        //if (File.Exists(tmpFilePage))
                        //    File.Delete(tmpFilePage);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);

                foreach (var tmpFilePage in tmpfilePages)
                    if (File.Exists(tmpFilePage))
                        File.Delete(tmpFilePage);
            }
            catch (Exception ex)
            {

            }

            return pdfImages;
        }
    }

    namespace GhostscriptSharp
    {
        /// <summary>
        /// Wraps the Ghostscript API with a C# interface
        /// </summary>
        public class GhostscriptWrapper
        {
            #region Hooks into Ghostscript DLL
            //[DllImport("gsdll32.dll", EntryPoint = "gsapi_new_instance")]
            //private static extern int CreateAPIInstance(out IntPtr pinstance, IntPtr caller_handle);

            //[DllImport("gsdll32.dll", EntryPoint = "gsapi_init_with_args")]
            //private static extern int InitAPI(IntPtr instance, int argc, string[] argv);

            //[DllImport("gsdll32.dll", EntryPoint = "gsapi_exit")]
            //private static extern int ExitAPI(IntPtr instance);

            //[DllImport("gsdll32.dll", EntryPoint = "gsapi_delete_instance")]
            //private static extern void DeleteAPIInstance(IntPtr instance);

            private static GhostscriptHooks hooks;

            static GhostscriptWrapper()
            {
                CreateHooks();
            }

            public static void CreateHooks()
            {
                hooks = IntPtr.Size == 8 ? (GhostscriptHooks)new GhostscriptHooks64() : (GhostscriptHooks)new GhostscriptHooks32();
            }

            #endregion

            #region Globals

            private static readonly string[] ARGS = new string[] {
				// Keep gs from writing information to standard output
                "-q",                     
                "-dQUIET",
               
                "-dPARANOIDSAFER",       // Run this command in safe mode
                "-dBATCH",               // Keep gs from going into interactive mode
                "-dNOPAUSE",             // Do not prompt and pause for each page
                "-dNOPROMPT",            // Disable prompts for user interaction           
                "-dMaxBitmap=500000000", // Set high for better performance
				"-dNumRenderingThreads=4", // Multi-core, come-on!
                
                // Configure the output anti-aliasing, resolution, etc
                "-dAlignToPixels=0",
                "-dGridFitTT=0",
                "-dTextAlphaBits=4",
                "-dGraphicsAlphaBits=4"
		};
            #endregion

            /// <summary>
            /// Generates a thumbnail jpg for the pdf at the input path and saves it 
            /// at the output path
            /// </summary>
            public static void GeneratePageThumb(string inputPath, string outputPath, int page, int width, int height)
            {
                GeneratePageThumbs(inputPath, outputPath, page, page, width, height);
            }

            /// <summary>
            /// Generates a collection of thumbnail jpgs for the pdf at the input path 
            /// starting with firstPage and ending with lastPage.
            /// Put "%d" somewhere in the output path to have each of the pages numbered
            /// </summary>
            public static void GeneratePageThumbs(string inputPath, string outputPath, int firstPage, int lastPage, int width, int height)
            {
                CallAPI(GetArgs(inputPath, outputPath, firstPage, lastPage, width, height));
            }

            /// <summary>
            /// Rasterises a PDF into selected format
            /// </summary>
            /// <param name="inputPath">PDF file to convert</param>
            /// <param name="outputPath">Destination file</param>
            /// <param name="settings">Conversion settings</param>
            public static void GenerateOutput(string inputPath, string outputPath, GhostscriptSettings settings)
            {
                CallAPI(GetArgs(inputPath, outputPath, settings));
            }

            /// <summary>
            /// Calls the Ghostscript API with a collection of arguments to be passed to it
            /// </summary>
            private static void CallAPI(string[] args)
            {
                // Get a pointer to an instance of the Ghostscript API and run the API with the current arguments
                IntPtr gsInstancePtr;
                lock (resourceLock)
                {
                    hooks.CreateAPIInstance(out gsInstancePtr, IntPtr.Zero);
                    try
                    {
                        int result = hooks.InitAPI(gsInstancePtr, args.Length, args);

                        if (result < 0)
                        {
                            throw new ExternalException("Ghostscript conversion error", result);
                        }
                    }
                    finally
                    {
                        Cleanup(gsInstancePtr);
                    }
                }
            }

            /// <summary>
            /// GS can only support a single instance, so we need to bottleneck any multi-threaded systems.
            /// </summary>
            private static object resourceLock = new object();

            /// <summary>
            /// Frees up the memory used for the API arguments and clears the Ghostscript API instance
            /// </summary>
            private static void Cleanup(IntPtr gsInstancePtr)
            {
                hooks.ExitAPI(gsInstancePtr);
                hooks.DeleteAPIInstance(gsInstancePtr);
            }

            /// <summary>
            /// Returns an array of arguments to be sent to the Ghostscript API
            /// </summary>
            /// <param name="inputPath">Path to the source file</param>
            /// <param name="outputPath">Path to the output file</param>
            /// <param name="firstPage">The page of the file to start on</param>
            /// <param name="lastPage">The page of the file to end on</param>
            private static string[] GetArgs(string inputPath,
                string outputPath,
                int firstPage,
                int lastPage,
                int width,
                int height)
            {
                // To maintain backwards compatibility, this method uses previous hardcoded values.

                GhostscriptSettings s = new GhostscriptSettings();
                s.Device = Settings.GhostscriptDevices.jpeg;
                s.Page.Start = firstPage;
                s.Page.End = lastPage;
                s.Resolution = new System.Drawing.Size(width, height);

                Settings.GhostscriptPageSize pageSize = new Settings.GhostscriptPageSize();
                pageSize.Native = GhostscriptSharp.Settings.GhostscriptPageSizes.a7;
                s.Size = pageSize;

                return GetArgs(inputPath, outputPath, s);
            }

            /// <summary>
            /// Returns an array of arguments to be sent to the Ghostscript API
            /// </summary>
            /// <param name="inputPath">Path to the source file</param>
            /// <param name="outputPath">Path to the output file</param>
            /// <param name="settings">API parameters</param>
            /// <returns>API arguments</returns>
            private static string[] GetArgs(string inputPath,
                string outputPath,
                GhostscriptSettings settings)
            {
                System.Collections.ArrayList args = new System.Collections.ArrayList(ARGS);

                if (settings.Device == Settings.GhostscriptDevices.UNDEFINED)
                {
                    throw new ArgumentException("An output device must be defined for Ghostscript", "GhostscriptSettings.Device");
                }

                if (settings.Page.AllPages == false && (settings.Page.Start <= 0 && settings.Page.End < settings.Page.Start))
                {
                    throw new ArgumentException("Pages to be printed must be defined.", "GhostscriptSettings.Pages");
                }

                if (settings.Resolution.IsEmpty)
                {
                    throw new ArgumentException("An output resolution must be defined", "GhostscriptSettings.Resolution");
                }

                if (settings.Size.Native == Settings.GhostscriptPageSizes.UNDEFINED && settings.Size.Manual.IsEmpty)
                {
                    throw new ArgumentException("Page size must be defined", "GhostscriptSettings.Size");
                }

                // Output device
                args.Add(String.Format("-sDEVICE={0}", settings.Device));

                // Pages to output
                if (settings.Page.AllPages)
                {
                    args.Add("-dFirstPage=1");
                }
                else
                {
                    args.Add(String.Format("-dFirstPage={0}", settings.Page.Start));
                    if (settings.Page.End >= settings.Page.Start)
                    {
                        args.Add(String.Format("-dLastPage={0}", settings.Page.End));
                    }
                }

                // Page size
                if (settings.Size.Native == Settings.GhostscriptPageSizes.UNDEFINED)
                {
                    args.Add(String.Format("-dDEVICEWIDTHPOINTS={0}", settings.Size.Manual.Width));
                    args.Add(String.Format("-dDEVICEHEIGHTPOINTS={0}", settings.Size.Manual.Height));
                }
                else
                {
                    args.Add(String.Format("-sPAPERSIZE={0}", settings.Size.Native.ToString()));
                }

                // Page resolution
                args.Add(String.Format("-dDEVICEXRESOLUTION={0}", settings.Resolution.Width));
                args.Add(String.Format("-dDEVICEYRESOLUTION={0}", settings.Resolution.Height));

                // Files
                args.Add(String.Format("-sOutputFile={0}", outputPath));
                args.Add(inputPath);

                return (string[])args.ToArray(typeof(string));

            }
        }

        public abstract class GhostscriptHooks
        {
            public abstract int CreateAPIInstance(out IntPtr pinstance, IntPtr caller_handle);
            public abstract int InitAPI(IntPtr instance, int argc, string[] argv);
            public abstract int ExitAPI(IntPtr instance);
            public abstract void DeleteAPIInstance(IntPtr instance);
        }

        public class GhostscriptHooks32 : GhostscriptHooks
        {
            #region Hooks into Ghostscript DLL
            [DllImport("gsdll32.dll", EntryPoint = "gsapi_new_instance")]
            private static extern int CreateAPIInstance32(out IntPtr pinstance, IntPtr caller_handle);

            [DllImport("gsdll32.dll", EntryPoint = "gsapi_init_with_args")]
            private static extern int InitAPI32(IntPtr instance, int argc, string[] argv);

            [DllImport("gsdll32.dll", EntryPoint = "gsapi_exit")]
            private static extern int ExitAPI32(IntPtr instance);

            [DllImport("gsdll32.dll", EntryPoint = "gsapi_delete_instance")]
            private static extern void DeleteAPIInstance32(IntPtr instance);
            #endregion

            public override int CreateAPIInstance(out IntPtr pinstance, IntPtr caller_handle)
            {
                return CreateAPIInstance32(out pinstance, caller_handle);
            }

            public override int InitAPI(IntPtr instance, int argc, string[] argv)
            {
                return InitAPI32(instance, argc, argv);
            }

            public override int ExitAPI(IntPtr instance)
            {
                return ExitAPI32(instance);
            }

            public override void DeleteAPIInstance(IntPtr instance)
            {
                DeleteAPIInstance32(instance);
            }
        }

        public class GhostscriptHooks64 : GhostscriptHooks
        {
            #region Hooks into Ghostscript DLL
            [DllImport("gsdll64.dll", EntryPoint = "gsapi_new_instance")]
            private static extern int CreateAPIInstance64(out IntPtr pinstance, IntPtr caller_handle);

            [DllImport("gsdll64.dll", EntryPoint = "gsapi_init_with_args")]
            private static extern int InitAPI64(IntPtr instance, int argc, string[] argv);

            [DllImport("gsdll64.dll", EntryPoint = "gsapi_exit")]
            private static extern int ExitAPI64(IntPtr instance);

            [DllImport("gsdll64.dll", EntryPoint = "gsapi_delete_instance")]
            private static extern void DeleteAPIInstance64(IntPtr instance);
            #endregion

            public override int CreateAPIInstance(out IntPtr pinstance, IntPtr caller_handle)
            {
                return CreateAPIInstance64(out pinstance, caller_handle);
            }

            public override int InitAPI(IntPtr instance, int argc, string[] argv)
            {
                return InitAPI64(instance, argc, argv);
            }

            public override int ExitAPI(IntPtr instance)
            {
                return ExitAPI64(instance);
            }

            public override void DeleteAPIInstance(IntPtr instance)
            {
                DeleteAPIInstance64(instance);
            }
        }

        /// <summary>
        /// Ghostscript settings
        /// </summary>
        public class GhostscriptSettings
        {
            private Settings.GhostscriptDevices _device;
            private Settings.GhostscriptPages _pages = new Settings.GhostscriptPages();
            private System.Drawing.Size _resolution;
            private Settings.GhostscriptPageSize _size = new Settings.GhostscriptPageSize();

            public Settings.GhostscriptDevices Device
            {
                get { return this._device; }
                set { this._device = value; }
            }

            public Settings.GhostscriptPages Page
            {
                get { return this._pages; }
                set { this._pages = value; }
            }

            public System.Drawing.Size Resolution
            {
                get { return this._resolution; }
                set { this._resolution = value; }
            }

            public Settings.GhostscriptPageSize Size
            {
                get { return this._size; }
                set { this._size = value; }
            }
        }
    }

    namespace GhostscriptSharp.Settings
    {
        /// <summary>
        /// Which pages to output
        /// </summary>
        public class GhostscriptPages
        {
            private bool _allPages = true;
            private int _start;
            private int _end;

            /// <summary>
            /// Output all pages avaialble in document
            /// </summary>
            public bool AllPages
            {
                set
                {
                    this._start = -1;
                    this._end = -1;
                    this._allPages = true;
                }
                get
                {
                    return this._allPages;
                }
            }

            /// <summary>
            /// Start output at this page (1 for page 1)
            /// </summary>
            public int Start
            {
                set
                {
                    this._allPages = false;
                    this._start = value;
                }
                get
                {
                    return this._start;
                }
            }

            /// <summary>
            /// Page to stop output at
            /// </summary>
            public int End
            {
                set
                {
                    this._allPages = false;
                    this._end = value;
                }
                get
                {
                    return this._end;
                }
            }
        }

        /// <summary>
        /// Output devices for GhostScript
        /// </summary>
        public enum GhostscriptDevices
        {
            UNDEFINED,
            png16m,
            pnggray,
            png256,
            png16,
            pngmono,
            pngalpha,
            jpeg,
            jpeggray,
            tiffgray,
            tiff12nc,
            tiff24nc,
            tiff32nc,
            tiffsep,
            tiffcrle,
            tiffg3,
            tiffg32d,
            tiffg4,
            tifflzw,
            tiffpack,
            faxg3,
            faxg32d,
            faxg4,
            bmpmono,
            bmpgray,
            bmpsep1,
            bmpsep8,
            bmp16,
            bmp256,
            bmp16m,
            bmp32b,
            pcxmono,
            pcxgray,
            pcx16,
            pcx256,
            pcx24b,
            pcxcmyk,
            psdcmyk,
            psdrgb,
            pdfwrite,
            pswrite,
            epswrite,
            pxlmono,
            pxlcolor
        }

        /// <summary>
        /// Output document physical dimensions
        /// </summary>
        public class GhostscriptPageSize
        {
            private GhostscriptPageSizes _fixed;
            private System.Drawing.Size _manual;

            /// <summary>
            /// Custom document size
            /// </summary>
            public System.Drawing.Size Manual
            {
                set
                {
                    this._fixed = GhostscriptPageSizes.UNDEFINED;
                    this._manual = value;
                }
                get
                {
                    return this._manual;
                }
            }

            /// <summary>
            /// Standard paper size
            /// </summary>
            public GhostscriptPageSizes Native
            {
                set
                {
                    this._fixed = value;
                    this._manual = new System.Drawing.Size(0, 0);
                }
                get
                {
                    return this._fixed;
                }
            }

        }

        /// <summary>
        /// Native page sizes
        /// </summary>
        /// <remarks>
        /// Missing 11x17 as enums can't start with a number, and I can't be bothered
        /// to add in logic to handle it - if you need it, do it yourself.
        /// </remarks>
        public enum GhostscriptPageSizes
        {
            UNDEFINED,
            ledger,
            legal,
            letter,
            lettersmall,
            archE,
            archD,
            archC,
            archB,
            archA,
            a0,
            a1,
            a2,
            a3,
            a4,
            a4small,
            a5,
            a6,
            a7,
            a8,
            a9,
            a10,
            isob0,
            isob1,
            isob2,
            isob3,
            isob4,
            isob5,
            isob6,
            c0,
            c1,
            c2,
            c3,
            c4,
            c5,
            c6,
            jisb0,
            jisb1,
            jisb2,
            jisb3,
            jisb4,
            jisb5,
            jisb6,
            b0,
            b1,
            b2,
            b3,
            b4,
            b5,
            flsa,
            flse,
            halfletter
        }
    }
}
