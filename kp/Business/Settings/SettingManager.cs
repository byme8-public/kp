using System;
using System.Globalization;

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

            if (this.Settings.SelectedLanguage == null)
                this.Settings.SelectedLanguage = "ru-ru";

            CultureInfo.CurrentUICulture = new CultureInfo(this.Settings.SelectedLanguage);
        }

        public void Save()
        {
            this.Storage.Save(this.Settings);
        }
    }
}
