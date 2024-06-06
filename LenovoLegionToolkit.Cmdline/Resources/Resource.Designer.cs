﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LenovoLegionToolkit.Cmdline.Resources {
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
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LenovoLegionToolkit.Cmdline.Resources.Resource", typeof(Resource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Illegal command-line arguments. Use `--help` for help messages..
        /// </summary>
        public static string Error_IllegalCommandLineArgument_Text {
            get {
                return ResourceManager.GetString("Error_IllegalCommandLineArgument_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show this help message..
        /// </summary>
        public static string HelpMessage_Argument_Help {
            get {
                return ResourceManager.GetString("HelpMessage_Argument_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute Quick Actions created in LLT..
        /// </summary>
        public static string HelpMessage_Argument_Run {
            get {
                return ResourceManager.GetString("HelpMessage_Argument_Run", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run silently, no output will be write to console..
        /// </summary>
        public static string HelpMessage_Argument_Silent {
            get {
                return ResourceManager.GetString("HelpMessage_Argument_Silent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Available arguments:.
        /// </summary>
        public static string HelpMessage_AvailableArguments {
            get {
                return ResourceManager.GetString("HelpMessage_AvailableArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Simple command-line interface for calling LLT functions..
        /// </summary>
        public static string HelpMessage_ExeDescription {
            get {
                return ResourceManager.GetString("HelpMessage_ExeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Version.
        /// </summary>
        public static string HelpMessage_Version {
            get {
                return ResourceManager.GetString("HelpMessage_Version", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quick Action not found..
        /// </summary>
        public static string QuickActionRun_Error_ActionNotFound_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_ActionNotFound_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to run Quick Action due to the following reason: {0}.
        /// </summary>
        public static string QuickActionRun_Error_ActionRunFailed_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_ActionRunFailed_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LLT host failed to deserialize request..
        /// </summary>
        public static string QuickActionRun_Error_DeserializeFailed_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_DeserializeFailed_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to connect to LLT host due to the following reason: {0}.
        /// </summary>
        public static string QuickActionRun_Error_PipeConnectFailed_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_PipeConnectFailed_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LLT host hasn&apos;t been started. Run LLT first and then try executing Quick Actions..
        /// </summary>
        public static string QuickActionRun_Error_ServerNotRunning_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_ServerNotRunning_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot deserialize LLT host&apos;s response..
        /// </summary>
        public static string QuickActionRun_Error_Undefined_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Error_Undefined_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run Quick Action successfully..
        /// </summary>
        public static string QuickActionRun_Ok_Text {
            get {
                return ResourceManager.GetString("QuickActionRun_Ok_Text", resourceCulture);
            }
        }
    }
}
