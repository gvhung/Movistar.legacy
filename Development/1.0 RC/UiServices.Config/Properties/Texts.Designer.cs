﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.DvbIpTv.UiServices.Configuration.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Project.DvbIpTv.UiServices.Configuration.Properties.Texts", typeof(Texts).Assembly);
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
        ///   Looks up a localized string similar to Application not correctly installed.
        /// </summary>
        internal static string AppConfigRegistryCaption {
            get {
                return ResourceManager.GetString("AppConfigRegistryCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find or open &apos;HKCU\{0}&apos;..
        /// </summary>
        internal static string AppConfigRegistryMissingKey {
            get {
                return ResourceManager.GetString("AppConfigRegistryMissingKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &apos;{1}&apos; is missing under &apos;HKCU\{0}&apos;..
        /// </summary>
        internal static string AppConfigRegistryMissingValue {
            get {
                return ResourceManager.GetString("AppConfigRegistryMissingValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is a problem accessing application configuration from the Windows Registry:
        ///{0}
        ///
        ///Please install the application using the official installer or repair the installation..
        /// </summary>
        internal static string AppConfigRegistryText {
            get {
                return ResourceManager.GetString("AppConfigRegistryText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find the &apos;base&apos; folder at &apos;{0}&apos;..
        /// </summary>
        internal static string AppConfigValidationBasePath {
            get {
                return ResourceManager.GetString("AppConfigValidationBasePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to locate the &apos;logos&apos; folder at &apos;{0}&apos;..
        /// </summary>
        internal static string AppConfigValidationLogosPath {
            get {
                return ResourceManager.GetString("AppConfigValidationLogosPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated domain name &apos;{0}&apos; in &apos;logos/services/domain-mappings.xml&apos;.
        /// </summary>
        internal static string ExceptionLogosDomainMappingsDuplicatedDomain {
            get {
                return ResourceManager.GetString("ExceptionLogosDomainMappingsDuplicatedDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to load provider logo file\r\n{0}.
        /// </summary>
        internal static string ExceptionLogosProviderImageLoadError {
            get {
                return ResourceManager.GetString("ExceptionLogosProviderImageLoadError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provider logo file not found.
        /// </summary>
        internal static string ExceptionLogosProviderImageNotFound {
            get {
                return ResourceManager.GetString("ExceptionLogosProviderImageNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated domain name &apos;{0}&apos; in &apos;logos/providers/provider-mappings.xml&apos;.
        /// </summary>
        internal static string ExceptionLogosProviderMappingsDuplicatedDomain {
            get {
                return ResourceManager.GetString("ExceptionLogosProviderMappingsDuplicatedDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to load service logo file\r\n{0}.
        /// </summary>
        internal static string ExceptionLogosServiceImageLoadError {
            get {
                return ResourceManager.GetString("ExceptionLogosServiceImageLoadError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service logo file not found.
        /// </summary>
        internal static string ExceptionLogosServiceImageNotFound {
            get {
                return ResourceManager.GetString("ExceptionLogosServiceImageNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated domain name &apos;{0}&apos; in &apos;logos/services/service-mappings.xml&apos;.
        /// </summary>
        internal static string ExceptionLogosServiceMappingsDuplicatedDomain {
            get {
                return ResourceManager.GetString("ExceptionLogosServiceMappingsDuplicatedDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated service name &apos;{0}&apos; in &apos;logos/services/service-mappings.xml&apos; for domain &apos;{1}&apos;.
        /// </summary>
        internal static string ExceptionLogosServiceMappingsDuplicatedService {
            get {
                return ResourceManager.GetString("ExceptionLogosServiceMappingsDuplicatedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user configuration file &apos;{0}&apos; is invalid or has severe errors.
        ///{1}
        ///
        ///Please verify the XML syntax of the file and correct the detected errors..
        /// </summary>
        internal static string LoadConfigUserConfigValidation {
            get {
                return ResourceManager.GetString("LoadConfigUserConfigValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to See exception details (below) for detailed error information..
        /// </summary>
        internal static string LoadConfigUserConfigValidationException {
            get {
                return ResourceManager.GetString("LoadConfigUserConfigValidationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Application configuration verification failure.
        /// </summary>
        internal static string LoadConfigValidationCaption {
            get {
                return ResourceManager.GetString("LoadConfigValidationCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to load the content provider data.
        /// </summary>
        internal static string LoadContentProviderDataExceptionCaption {
            get {
                return ResourceManager.GetString("LoadContentProviderDataExceptionCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The content provider information file &apos;{0}&apos; is invalid or has severe errors.
        ///{1}
        ///
        ///Please verify the XML syntax of the file and correct the detected errors..
        /// </summary>
        internal static string LoadContentProviderDataValidation {
            get {
                return ResourceManager.GetString("LoadContentProviderDataValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Content provider data verification failure.
        /// </summary>
        internal static string LoadContentProviderDataValidationCaption {
            get {
                return ResourceManager.GetString("LoadContentProviderDataValidationCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to See exception details (below) for detailed error information..
        /// </summary>
        internal static string LoadContentProviderDataValidationException {
            get {
                return ResourceManager.GetString("LoadContentProviderDataValidationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to load the user configuration.
        /// </summary>
        internal static string LoadUserConfigExceptionCaption {
            get {
                return ResourceManager.GetString("LoadUserConfigExceptionCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User configuration verification failure.
        /// </summary>
        internal static string LoadUserConfigValidationCaption {
            get {
                return ResourceManager.GetString("LoadUserConfigValidationCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} player can not be found at &apos;{1}&apos;..
        /// </summary>
        internal static string PlayerConfigValidationPathNotFound {
            get {
                return ResourceManager.GetString("PlayerConfigValidationPathNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} recorder can not be found at &apos;{1}&apos;.
        /// </summary>
        internal static string RecorderConfigValidationPathNotFound {
            get {
                return ResourceManager.GetString("RecorderConfigValidationPathNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &lt;{1}&gt; path value &apos;{0}&apos; has to be either an absolute volume path (like &apos;C:\folder&apos;) or an UNC (like &apos;\\server\share&apos;)..
        /// </summary>
        internal static string RecordSaveLocationValidationAbsolutePath {
            get {
                return ResourceManager.GetString("RecordSaveLocationValidationAbsolutePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &lt;{1}&gt; Task Scheduler folder value &apos;{0}&apos; must start with &apos;\&apos; and must not end with &apos;\&apos;.
        /// </summary>
        internal static string RecordTaskSchedulerFolderValidationPath {
            get {
                return ResourceManager.GetString("RecordTaskSchedulerFolderValidationPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one &lt;{0}&gt; tag has to be specified at &lt;{1}&gt; tag..
        /// </summary>
        internal static string UserConfigValidationAtLeastOne {
            get {
                return ResourceManager.GetString("UserConfigValidationAtLeastOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated &lt;{1}&gt; item in &lt;{0}&gt; list. &apos;{2}&apos; value is &apos;{3}&apos;.
        /// </summary>
        internal static string UserConfigValidationDuplicatedEntry {
            get {
                return ResourceManager.GetString("UserConfigValidationDuplicatedEntry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IP address.
        /// </summary>
        internal static string UserConfigValidationIpAddress {
            get {
                return ResourceManager.GetString("UserConfigValidationIpAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IP port number.
        /// </summary>
        internal static string UserConfigValidationIpPort {
            get {
                return ResourceManager.GetString("UserConfigValidationIpPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;{0}&gt; tag is missing or empty..
        /// </summary>
        internal static string UserConfigValidationMissingEmpty {
            get {
                return ResourceManager.GetString("UserConfigValidationMissingEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attribute &apos;{0}&apos; is missing or empty at &lt;{1}&gt; tag..
        /// </summary>
        internal static string UserConfigValidationMissingEmptyAttribute {
            get {
                return ResourceManager.GetString("UserConfigValidationMissingEmptyAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;{0}&gt; tag is missing or empty under &lt;{1}&gt; tag..
        /// </summary>
        internal static string UserConfigValidationMissingEmptyOwner {
            get {
                return ResourceManager.GetString("UserConfigValidationMissingEmptyOwner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;{0}&gt; tag is missing or empty under &lt;{1}&gt; tag. Value of &apos;{2}&apos; is &apos;{3}&apos;..
        /// </summary>
        internal static string UserConfigValidationMissingEmptyValue {
            get {
                return ResourceManager.GetString("UserConfigValidationMissingEmptyValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;{0}&gt; tag is missing under &lt;{1}&gt; tag..
        /// </summary>
        internal static string UserConfigValidationMissingTag {
            get {
                return ResourceManager.GetString("UserConfigValidationMissingTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value &apos;{2}&apos; specified at &lt;{0}&gt; tag is not a valid {1}..
        /// </summary>
        internal static string UserConfigValidationValueType {
            get {
                return ResourceManager.GetString("UserConfigValidationValueType", resourceCulture);
            }
        }
    }
}
