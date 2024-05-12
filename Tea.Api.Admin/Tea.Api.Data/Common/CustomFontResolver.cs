using Microsoft.Extensions.Configuration;
using PdfSharp.Fonts;
using System.Reflection;

namespace Tea.Api.Data.Common
{
    public class CustomFontResolver : IFontResolver
    {
        readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        public CustomFontResolver()
        {
            _config = config;
        }
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Ignore case of font names.
            var name = familyName.ToLower().TrimEnd('#');

            // Deal with the fonts we know.
            switch (name)
            {
                case "arial":
                    if (isBold)
                    {
                        if (isItalic)
                            return new FontResolverInfo("Arial#bi");
                        return new FontResolverInfo("Arial#b");
                    }
                    if (isItalic)
                        return new FontResolverInfo("Arial#i");
                    return new FontResolverInfo("Arial#");
            }

            // We pass all other font requests to the default handler.
            // When running on a web server without sufficient permission, you can return a default font at this stage.
            return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
        }

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "Arial#":
                    return LoadFontData("Tea.Api.Print.font.Arial.Arial.ttf"); ;

                //case "Arial#b":
                //    return LoadFontData("MyProject.fonts.arial.arialbd.ttf"); ;

                //case "Arial#i":
                //    return LoadFontData("MyProject.fonts.arial.ariali.ttf");

                //case "Arial#bi":
                //    return LoadFontData("MyProject.fonts.arial.arialbi.ttf");
            }

            return null;
        }
        /// <summary>
        /// Returns the specified font from an embedded resource.
        /// </summary>
        private byte[] LoadFontData(string? name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Test code to find the names of embedded fonts - put a watch on "ourResources"
            //var ourResources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);

                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }

        internal static CustomFontResolver OurGlobalFontResolver = null;
        /// <summary>
        /// Ensure the font resolver is only applied once (or an exception is thrown)
        /// </summary>
        internal static void Apply()
        {
            if (OurGlobalFontResolver == null || GlobalFontSettings.FontResolver == null)
            {
                if (OurGlobalFontResolver == null)
                    OurGlobalFontResolver = new CustomFontResolver();

                GlobalFontSettings.FontResolver = OurGlobalFontResolver;
            }
        }
    }
}
