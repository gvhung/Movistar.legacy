﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DvbIpTv.RecorderLauncher.Properties {
    using System;
    
    
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
    internal class Texts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Texts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Project.DvbIpTv.RecorderLauncher.Properties.Texts", typeof(Texts).Assembly);
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
        ///   Looks up a localized string similar to EXCEPTION: {1}.
        /// </summary>
        internal static string DisplayExceptionFormat {
            get {
                return ResourceManager.GetString("DisplayExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ERROR: Unable to load the XML recording task configuration file..
        /// </summary>
        internal static string ErrorLoadTaskFile {
            get {
                return ResourceManager.GetString("ErrorLoadTaskFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ERROR: No arguments have been specified.
        ///Use /HELP for more information..
        /// </summary>
        internal static string ErrorNoArguments {
            get {
                return ResourceManager.GetString("ErrorNoArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Info: Loading XML task file....
        /// </summary>
        internal static string InfoLoadingTaskFile {
            get {
                return ResourceManager.GetString("InfoLoadingTaskFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OK.
        /// </summary>
        internal static string InfoOk {
            get {
                return ResourceManager.GetString("InfoOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press any key to exit....
        /// </summary>
        internal static string PressAnyKeyEnd {
            get {
                return ResourceManager.GetString("PressAnyKeyEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IPTV Recorder launcher utility.
        /// </summary>
        internal static string ProgramCaption {
            get {
                return ResourceManager.GetString("ProgramCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} XMLTaskFile
        ///{0} /help | /h | /? | -help | -h | -?
        ///
        ///XMLTaskFile     XML file containing the record task definition.
        ///                Loads the task and launches the recorder.
        ///
        ////help      Displays this help message.
        ///
        ///-- General options --
        ////nologo     Supresses the banner.
        ///Options and switches can be specified with &apos;/&apos; or with &apos;-&apos;.
        /// </summary>
        internal static string ProgramHelp {
            get {
                return ResourceManager.GetString("ProgramHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IPTV Recorder launcher utility
        ///Version {0}
        ///(C) 2014. All rights reserved..
        /// </summary>
        internal static string StartLogo {
            get {
                return ResourceManager.GetString("StartLogo", resourceCulture);
            }
        }
    }
}
