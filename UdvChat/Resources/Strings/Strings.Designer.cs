﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UdvChat.Resources.Strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UdvChat.Resources.Strings.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Udv чат.
        /// </summary>
        internal static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Иван.
        /// </summary>
        internal static string DefaultUserName {
            get {
                return ResourceManager.GetString("DefaultUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Начните первый чат!.
        /// </summary>
        internal static string EmptyChatListText {
            get {
                return ResourceManager.GetString("EmptyChatListText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Секундочку, я сейчас покручу шестеренками в своей голове....
        /// </summary>
        internal static string FirstPhrase {
            get {
                return ResourceManager.GetString("FirstPhrase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Привет! Я ваш виртуальный помощник. Чем могу помочь?.
        /// </summary>
        internal static string HelloPhrase {
            get {
                return ResourceManager.GetString("HelloPhrase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Робот.
        /// </summary>
        internal static string RobotName {
            get {
                return ResourceManager.GetString("RobotName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кажется, мне пора на подзарядку... Но сначала отвечу на ваше сообщение!.
        /// </summary>
        internal static string SecondPhrase {
            get {
                return ResourceManager.GetString("SecondPhrase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кстати, бананы — это ягоды, а клубника — нет. Вот такой вот фруктовый обман!.
        /// </summary>
        internal static string ThirdPhrase {
            get {
                return ResourceManager.GetString("ThirdPhrase", resourceCulture);
            }
        }
    }
}
