using System;

namespace kp.Business.Settings
{
    public class AppSettings
    {
        public Guid? UserToken
        {
            get;
            set;
        }

        public string SelectedLanguage
        {
            get;
            set;
        }
    }

    public class SettingManager
    {
        Storage.Storage Storage
        {
            get;
        }

        public AppSettings Settings
        {
            get;
        }

        public SettingManager(Storage.Storage storage)
        {
            this.Storage = storage;
            this.Settings = this.Storage.Load<AppSettings>();
        }

        public void Save()
        {
            this.Storage.Save(this.Settings);
        }
    }
}
