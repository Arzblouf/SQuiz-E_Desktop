using PdfSharp.Fonts;
using System;
using System.IO;
using System.Windows.Forms;

namespace StadiumProject
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class WindowsFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            string fontsFolder = @"C:\Windows\Fonts\";

            switch (faceName)
            {
                case "Arial":
                    return File.ReadAllBytes(Path.Combine(fontsFolder + "arial.ttf"));
                case "Arial#b":
                    return File.ReadAllBytes(Path.Combine(fontsFolder + "arialbd.ttf"));
                case "Arial#i":
                    return File.ReadAllBytes(Path.Combine(fontsFolder + "ariali.ttf"));
                case "Arial#bi":
                    return File.ReadAllBytes(Path.Combine(fontsFolder + "arialbi.ttf"));
                default:
                    return File.ReadAllBytes(Path.Combine(fontsFolder + "arial.ttf"));
            }
            ;
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string faceName;

            if (familyName == "Arial" && isBold && isItalic)
            {
                faceName = "Arial#bi";
            }
            else if (familyName == "Arial" && isBold)
            {
                faceName = "Arial#b";
            }
            else if (familyName == "Arial" && isItalic)
            {
                faceName = "Arial#i";
            }
            else
            {
                faceName = familyName;
            }
            return new FontResolverInfo(faceName);
        }
    }
}
