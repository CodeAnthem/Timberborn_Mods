using System.Collections.Generic;

namespace TB_CameraTweaker.KsHelperLib.DataSaver
{
    internal interface IDataSaver<T>
    {
        IEnumerable<T> Load();

        string PathOfSaveFile { get; set; }

        bool Save(List<T> objectsToSave);
    }
}