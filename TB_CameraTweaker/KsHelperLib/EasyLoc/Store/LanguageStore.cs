using System;
using System.Collections.Generic;
using System.Linq;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Factory;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Models;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc.Store
{
    internal class LanguageStore
    {
        private readonly LanguageEntryFactory _entryFactory;

        public LanguageStore(LanguageEntryFactory entryFactory) {
            _entryFactory = entryFactory;
        }

        private Dictionary<string, List<LanguageEntry>> _languages = new Dictionary<string, List<LanguageEntry>>();

        public void InsertLanguage(ILanguage language) {
            if (IsLanguageKnown(language)) {
                throw new Exception("Language already listed: " + language.LanguageTag);
            }
            AddLanguage(language);
        }

        public bool IsLanguageKnown(ILanguage language) {
            return _languages.ContainsKey(language.LanguageTag);
        }

        private void AddLanguage(ILanguage language) {
            var entries = language.GetEntries().ToList();
            foreach (var entry in entries) {
                string keyWithPrefix = EasyLocConfig.LocTag + entry.Key;
                entry.Key = keyWithPrefix;
            }

            var entriesWithPrefix = PrefixEntries(entries);

            bool successfullyAdded = _languages.TryAdd(language.LanguageTag, entries);
            if (!successfullyAdded) { throw new Exception("Failed to add language: " + language.LanguageTag); }
        }

        private IEnumerable<LanguageEntry> PrefixEntries(List<LanguageEntry> entries) {
            throw new NotImplementedException();
        }
    }
}