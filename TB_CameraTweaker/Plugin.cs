using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using TB_CameraTweaker.KsHelperLib.EasyLoc;
using TB_CameraTweaker.KsHelperLib.Localization;
using TB_CameraTweaker.KsHelperLib.Logger;

namespace TB_CameraTweaker
{
    [BepInPlugin("Kumare." + MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        internal new static ConfigFile Config;
        internal static LogProxy Log;

        public Plugin() {
            SetupLogger();
            Config = base.Config;
            Config.SaveOnConfigSet = true;
            SetupEasyLoc();
            Log.LogInfo($"Plugin '{MyPluginInfo.PLUGIN_GUID}' is loaded!");
        }

        private void SetupEasyLoc() {
            EasyLocConfig.AddHeaderLine($"{MyPluginInfo.PLUGIN_NAME}, Updated: {DateTime.Now}");
            EasyLocConfig.AddHeaderLine("");
            EasyLocConfig.AddAdditionalLanguage("deDE");
        }

        private void SetupLogger() {
            Log = new("[Core] ");
            LogProxy.Level = BepInEx.Logging.LogLevel.Warning;
            LogProxy.Logger = Logger;
#if (DEBUG)
            LogProxy.Level = BepInEx.Logging.LogLevel.All;
#endif
        }
    }
}