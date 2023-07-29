using System.IO;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Models;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc.FileIO
{
    internal class LangFileWriter
    {
        private readonly DirectoryInfo _langDirectory;
        private TextWriter _textWriter;

        public LangFileWriter(DirectoryInfo langDirectory) {
            _langDirectory = langDirectory;
        }

        public void WriteLangFile(ILanguage language) {
            FileInfo langFile = CreateFreshLangFile(language.LanguageTag);
            using (FileStream fs = new(langFile.FullName, FileMode.Append)) {
                using (_textWriter = new StreamWriter(fs)) {
                    _textWriter.WriteLine("ID,Text,Comment");
                    WriteHeaderLines();
                    WriteLanguageEntries(language);
                }
            }
        }

        private FileInfo CreateFreshLangFile(string languageTag) {
            string filePath = Path.Combine(_langDirectory.FullName, languageTag);
            FileInfo langFile = new FileInfo(filePath);
            if (langFile.Exists) {
                langFile.Delete();
            }
            return langFile;
        }

        private void WriteHeaderLines() {
            foreach (var headerLine in EasyLocConfig.HeaderLines) {
                _textWriter.WriteLine(headerLine);
            }
        }

        private void WriteLanguageEntries(ILanguage language) {
            foreach (var entry in language.GetEntries()) {
                if (string.IsNullOrEmpty(entry.Comment)) {
                    _textWriter.WriteLine(string.Format($"{entry.Key}, {entry.Text}"));
                    continue;
                }
                _textWriter.WriteLine(string.Format($"{entry.Key}, {entry.Text}, {entry.Comment}"));
            }
        }
    }