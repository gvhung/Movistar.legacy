﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DvbIpTv.UiServices.DvbStpClient.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Project.DvbIpTv.UiServices.DvbStpClient.Properties.Texts", typeof(Texts).Assembly);
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
        ///   Looks up a localized string similar to Please wait. Canceling download....
        /// </summary>
        internal static string CancellingDownloadOperation {
            get {
                return ResourceManager.GetString("CancellingDownloadOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data reception is complete.
        /// </summary>
        internal static string CompletedDownloadDataReception {
            get {
                return ResourceManager.GetString("CompletedDownloadDataReception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error has ocurred while fetching data.
        /// </summary>
        internal static string HelperExceptionCaption {
            get {
                return ResourceManager.GetString("HelperExceptionCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request cancelled.
        /// </summary>
        internal static string HelperUserCancelledCaption {
            get {
                return ResourceManager.GetString("HelperUserCancelledCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The received data can&apos;t be successfully parsed and extracted.
        ///Payload Id: 0x{0:X2}. Data type: {1}..
        /// </summary>
        internal static string ParsePayloadException {
            get {
                return ResourceManager.GetString("ParsePayloadException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to cancel.
        /// </summary>
        internal static string UnableCancelDownloadCaption {
            get {
                return ResourceManager.GetString("UnableCancelDownloadCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to cancel right now. Please try again in a few seconds.
        ///
        ///The operation has been scheduled and cannot be cancelled until it has started..
        /// </summary>
        internal static string UnableCancelDownloadMessage {
            get {
                return ResourceManager.GetString("UnableCancelDownloadMessage", resourceCulture);
            }
        }
    }
}
