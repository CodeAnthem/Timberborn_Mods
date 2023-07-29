using BepInEx;
using System;
using System.IO;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc.FileIO
{
    internal class LangFolderCreater
    {
        private const string _languageFolderName = "lang";
        private DirectoryInfo _languageDirectory;

        public DirectoryInfo CreateFolder() {
            GetLanguageDirectoryInfo();
            if (!_languageDirectory.Exists) {
                CreateLanguageDirectory();
            }
            return _languageDirectory;
        }

        private void GetLanguageDirectoryInfo() {
            //string pathOfPlugin = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pathOfPlugin = Paths.PluginPath;
            string pathOfLanguageFolder = Path.Combine(pathOfPlugin, _languageFolderName);
            _languageDirectory = new DirectoryInfo(pathOfLanguageFolder);
        }

        private void CreateLanguageDirectory() {
            try {
                _languageDirectory.Create();
            }
            catch (Exception e) {
                throw new DirectoryNotFoundException($"Couldn't create folder: {_languageDirectory.FullName}\n" + e);
            }
        }
    }
}