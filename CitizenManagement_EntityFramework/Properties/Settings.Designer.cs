﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CitizenManagement_EntityFramework.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=VANHOANG;Initial Catalog=CityzenManagement;User ID={0};Password={1};C" +
            "onnect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=R" +
            "eadWrite;MultiSubnetFailover=False")]
        public string cnnManager {
            get {
                return ((string)(this["cnnManager"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=VANHOANG;Initial Catalog=CityzenManagement;User ID=sa;Password=sa;Con" +
            "nect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=Rea" +
            "dWrite;MultiSubnetFailover=False")]
        public string cnnCityzen {
            get {
                return ((string)(this["cnnCityzen"]));
            }
        }
    }
}
