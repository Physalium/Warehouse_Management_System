﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse_Management.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Warehouse_Management.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Map.
        /// </summary>
        public static string MapTabHeader {
            get {
                return ResourceManager.GetString("MapTabHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Orders.
        /// </summary>
        public static string OrderTabHeader {
            get {
                return ResourceManager.GetString("OrderTabHeader", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Orders.
        /// </summary>
        public static string SupplyTabHeader {
            get {
                return ResourceManager.GetString("SupplyTabHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] PolandMapHQ {
            get {
                object obj = ResourceManager.GetObject("PolandMapHQ", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Products.
        /// </summary>
        public static string ProductsLabel {
            get {
                return ResourceManager.GetString("ProductsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Semitrailers.
        /// </summary>
        public static string SemitrailersLabel {
            get {
                return ResourceManager.GetString("SemitrailersLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trucks.
        /// </summary>
        public static string TrucksLabel {
            get {
                return ResourceManager.GetString("TrucksLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] warehouseIcon {
            get {
                object obj = ResourceManager.GetObject("warehouseIcon", resourceCulture);
                return ((byte[])(obj));
            }
        }

        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] customerIcon {
            get {
                object obj = ResourceManager.GetObject("customerIcon", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
