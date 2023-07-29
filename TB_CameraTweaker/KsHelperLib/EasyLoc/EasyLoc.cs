using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TB_CameraTweaker.KsHelperLib.EasyLoc.FileIO;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Reflection;
using TB_CameraTweaker.KsHelperLib.Logger;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc
{
    internal class EasyLoc
    {
        private readonly LogProxy _log = new("EasyLoc", LogLevel.None);
        private LangFileWriter _langFileWriter;

        public EasyLoc() {
            Initialize();
            HandlePredefinedLanguages();
        }

        public void Initialize() {
            _log.LogDebug("Initialize() - Start");
            var langDirectory = new LangFolderCreater().CreateFolder();
            _langFileWriter = new LangFileWriter(langDirectory);
        }

        private void HandlePredefinedLanguages() {
            var languagesPreDefinedInCode = new LanguageFinderByReflection().GetAndInitializeLanguagesInCode();
            foreach (var predefinedLanguage in languagesPreDefinedInCode) {
            }
        }
    }
}