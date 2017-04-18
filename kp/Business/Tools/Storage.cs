using System.IO;
using Newtonsoft.Json;

namespace Storage
{
    public class Storage
    {
        public Storage()
        {
            this.Path = "settings.json";
            this.Settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };
        }

        JsonSerializerSettings Settings
        {
            get;
        }

        string Path
        {
            get;
        }

        public void Save(object value)
        {
            File.WriteAllText(this.Path, JsonConvert.SerializeObject(value, this.Settings));
        }

        public TValue Load<TValue>()
            where TValue : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<TValue>(File.ReadAllText(Path), Settings);
            }
            catch (System.Exception)
            {
                return new TValue();
            }
        }
    }
}
