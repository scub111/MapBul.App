﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Map_Bul_App.ResX {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Map_Bul_App.ResX.ExceptionResources", typeof(ExceptionResources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No internet connection..
        /// </summary>
        internal static string ConnectException {
            get {
                return ResourceManager.GetString("ConnectException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not allowed to add pins....
        /// </summary>
        internal static string NotAllowedToAddPins {
            get {
                return ResourceManager.GetString("NotAllowedToAddPins", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка..
        /// </summary>
        internal static string RequestException {
            get {
                return ResourceManager.GetString("RequestException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Превышено время ожидания ответа от сервера..
        /// </summary>
        internal static string TimeOutException {
            get {
                return ResourceManager.GetString("TimeOutException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Неправльный логин/пароль..
        /// </summary>
        internal static string WrongAuth {
            get {
                return ResourceManager.GetString("WrongAuth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Конечная дата даолжна быть больше начальной..
        /// </summary>
        internal static string WrongDate {
            get {
                return ResourceManager.GetString("WrongDate", resourceCulture);
            }
        }
    }
}