using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Models;

namespace TB_CameraTweaker.KsHelperLib.Localization
{
    internal class LocLangFileHandler
    {
        private TextWriter _textWriter;

        internal void WriteUpdatedContent(FileInfo langFile, List<LanguageEntry> currentEntries) {
            if (langFile.Exists) { langFile.Delete(); }

            using (FileStream fs = new(langFile.FullName, FileMode.Append)) {
                using (_textWriter = new StreamWriter(fs)) {
                    _textWriter.WriteLine("ID,Text,Comment");
                    WriteHeaderLines();
                    WriteLanguageEntries(currentEntries);
                }
            }
        }

        private void WriteHeaderLines() {
            foreach (var headerLine in LocConfig.Header) {
                _textWriter.WriteLine(headerLine);
            }
        }

        private void WriteLanguageEntries(List<LanguageEntry> currentEntries) {
            foreach (var entry in currentEntries) {
                if (entry.Comment == string.Empty) {
                    _textWriter.WriteLine(string.Format($"{entry.Key}, {entry.Text}"));
                    continue;
                }
                _textWriter.WriteLine(string.Format($"{entry.Key}, {entry.Text}, {entry.Comment}"));
            }
        }

        internal List<LanguageEntry> GetCurrentContent(FileInfo langFile) {
            List<LanguageEntry> currentEntries = new();
            if (!langFile.Exists) return currentEntries;

            var lines = File.ReadAllLines(langFile.FullName);

            for (var i = 0; i < lines.Length; i += 1) {
                string line = lines[i];

                if (i <= LocConfig.Header.Count) continue;

                if (!string.IsNullOrEmpty(line) && line.Contains(",")) {
                    string[] parts = line.Split(",");
                    switch (parts.Length) {
                        case 2:
                            currentEntries.Add(new LanguageEntry(parts[0], parts[1].Trim(), string.Empty));
                            break;

                        case 3:
                            currentEntries.Add(new LanguageEntry(parts[0], parts[1].Trim(), parts[2].Trim()));
                            break;

                        default:
                            throw new InvalidDataException($"Language file {langFile.Name} corrupted data");
                    };
                }
            }
            return currentEntries;
        }
    }
}