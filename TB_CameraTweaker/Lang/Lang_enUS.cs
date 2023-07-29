using System.Collections.Generic;
using TB_CameraTweaker.KsHelperLib.EasyLoc.Models;

namespace TB_CameraTweaker.Lang
{
    internal class Lang_enUS : ILanguage
    {
        public string LanguageTag => "enUS";

        public IEnumerable<LanguageEntry> GetEntries() {
            return new List<LanguageEntry>()
            {
                // menu itself
                new LanguageEntry("menu.title", "Camera Tweaker", "Title of menu" ),
                new LanguageEntry("menu.options", "Options", "Options header of menu" ),

                // menu tweaks part
                new LanguageEntry("menu.tweakstitle", "Camera Tweaks", "Sub title of camera tweaks" ),
                new LanguageEntry("menu.zoomfactor", "Zoom Factor", "Header of option: Zoom Factor" ),
                new LanguageEntry("menu.zoomspeed", "Zoom Speed", "Header of option: Zoom Speed" ),
                new LanguageEntry("menu.VerticalLimiter", "Disable Automatic Camera Snap Back", "Header of option: Vertical Angel Limiter" ),
                new LanguageEntry("menu.fov", "Field Of View", "Header of option: FOV" ),

                // menu position part
                new LanguageEntry("menu.positiontitle", "Camera Position Manager", "Sub title of camera tweaks" ),
                new LanguageEntry("menu.freeze", "Freeze Camera", "Header of option: Freeze" ),

                // interface
                new LanguageEntry("interface.label", "Camera Manager" ),
                new LanguageEntry("interface.freezebutton", "Freeze" ),
                new LanguageEntry("interface.addbutton", "Add" ),
                new LanguageEntry("interface.removebutton", "Delete" ),
                new LanguageEntry("interface.entername", "Enter Camera Name" ),

                // menu global keywords
                new LanguageEntry("single.default", "Default" ),
                new LanguageEntry("single.original", "Original" ),
                new LanguageEntry("single.on", "On" ),
                new LanguageEntry("single.off", "Off" ),
            };
        }
    }
}