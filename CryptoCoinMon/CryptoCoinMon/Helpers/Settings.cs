using System;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CryptoCoinMon.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        private const string First_Time_Run = "firstTime";
        private static readonly string FirstTimeDefault = "yes";
        /// <summary>
        /// THis settings is for storing the Default user of the App as 
        /// A Json Serialized String.
        /// </summary>
        private const string Current_User_Key = "AppUser";
        private static readonly string UserDefault = null;

        private const string User_Saved = "UserSaved";
        private static readonly string UserSavedDefault = "false";

        private const string Currency = "Currency";
        private static readonly string CurrencyDefault = "euro";

        private const string User_Data_Entered_Correctly = "user_data";
        private static readonly string UserDataDefault = "false";
        #endregion

        public static string PrefferedCurrency
        {
            get => AppSettings.GetValueOrDefault(Currency, CurrencyDefault);
            set => AppSettings.AddOrUpdateValue(Currency, value);
        }
        

        public static string IsFirstTimeRun
        {
            get => AppSettings.GetValueOrDefault(First_Time_Run, FirstTimeDefault);
            set => AppSettings.AddOrUpdateValue(First_Time_Run, value);
        }

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }



    }
}
