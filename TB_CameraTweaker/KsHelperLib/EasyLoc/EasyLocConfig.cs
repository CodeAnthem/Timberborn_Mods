using System;
using System.Collections.Generic;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc
{
    public static class EasyLocConfig
    {
        public static List<string> HeaderLines => _headerLines;
        public static string LocTag => _locTag;
        public static string FallbackLanguageTag => _fallbackLanguageTag;

        private static readonly List<string> _headerLines = new List<string>();
        private static string _locTag = $"{MyPluginInfo.PLUGIN_NAME.ToLower()}";
        private static string _fallbackLanguageTag = "enUS";
        private static readonly List<string> _additionalLanguageTags = new();

        public static IEnumerable<string> GetLanguages() => _additionalLanguageTags;

        public static void AddHeaderLine(string line)
        {
            _headerLines.Add(line);
        }

        public static void SetLocTag(string tag)
        {
            _locTag = tag;
        }

        public static void SetFallbackLanguageTag(string tag)
        {
            _fallbackLanguageTag = tag;
        }

        public static void AddAdditionalLanguage(string tag)
        {
            bool alreadyInList = _additionalLanguageTags.Contains(tag);
            if (alreadyInList)
            {
                throw new Exception("Language tag already listed as additional language");
            }
            _additionalLanguageTags.Add(tag);
        }
    }
}