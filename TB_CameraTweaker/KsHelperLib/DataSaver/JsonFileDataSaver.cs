using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TB_CameraTweaker.KsHelperLib.Logger;

namespace TB_CameraTweaker.KsHelperLib.DataSaver
{
    internal class JsonFileDataSaver<T> : IDataSaver<T>
    {
        private readonly LogProxy _log = new("Json Saver: " + nameof(T));
        public string PathOfSaveFile { get; set; }

        public IEnumerable<T> Load() {
            IEnumerable<T> loadedData = new List<T>();

            if (!File.Exists(PathOfSaveFile)) {
                _log.LogDebug("Load() - Failed: file does not exist: " + PathOfSaveFile);
                return loadedData;
            }

            try {
                var deserializedJson = ReadAndDeserializeJsonFile();
                if (deserializedJson != null) {
                    loadedData = deserializedJson;
                    _log.LogDebug("Load() - Success: #" + loadedData.Count());
                }
            }
            catch (System.Exception e) {
                _log.LogError("Load() - Failed: Unable to load data " + e.Message);
            }
            return loadedData;
        }

        private IEnumerable<T> ReadAndDeserializeJsonFile() {
            using (StreamReader r = new(PathOfSaveFile)) {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public bool Save(List<T> objectsToSave) {
            if (objectsToSave == null || objectsToSave?.Count == 0) {
                DeleteSaveFile();
                return false;
            }

            try {
                string objectsAsJsonString = JsonConvert.SerializeObject(objectsToSave, Formatting.Indented);
                using (StreamWriter w = new(PathOfSaveFile, false)) {
                    w.WriteLine(objectsAsJsonString);
                }
            }
            catch (System.Exception e) {
                _log.LogFatal("Save() - Failed: Unable to save data. Error: " + e);
                DeleteSaveFile();
                return false;
            }
            return true;
        }

        private void DeleteSaveFile() {
            if (File.Exists(PathOfSaveFile)) {
                File.Delete(PathOfSaveFile);
                _log.LogDebug("DeleteSaveFile() - Failed: No objects, deleted save file");
            }
        }
    }
}