using System.Collections.Generic;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc.Models
{
    public interface ILanguage
    {
        string LanguageTag { get; }

        IEnumerable<LanguageEntry> GetEntries();
    }
}