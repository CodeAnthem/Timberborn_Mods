﻿namespace TB_CameraTweaks.Lang
{
    internal class TocEntryModel
    {
        public TocEntryModel(string key, string text, string comment)
        {
            Key = key;
            Text = text;
            Comment = comment;
        }

        public string Key { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
    }
}