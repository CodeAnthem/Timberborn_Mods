using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Models;

namespace TB_CameraTweaker.KsHelperLib.EasyLoc.Reflection
{
    public class LanguageFinderByReflection
    {
        public IEnumerable<ILanguage> GetAndInitializeLanguagesInCode() {
            var languageTypes = FindLanguagesDefinedInCode();
            return CreateInstancesOf(languageTypes);
        }

        private IEnumerable<Type> FindLanguagesDefinedInCode() {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ILanguage).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        }

        private IEnumerable<ILanguage> CreateInstancesOf(IEnumerable<Type> languageTypes) {
            IEnumerable<ILanguage> languagesDefinedInCode = new List<ILanguage>();
            foreach (var languageType in languageTypes) {
                var l = (ILanguage)Activator.CreateInstance(languageType);
                languagesDefinedInCode.AddItem(l);
            }
            return languagesDefinedInCode;
        }
    }
}