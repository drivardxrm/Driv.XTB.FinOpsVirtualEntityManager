using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Driv.XTB.FinOpsVirtualEntityManager
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "FinOps Virtual Entity Manager"),
        ExportMetadata("Description", "Finance and Operations Virtual Entity Manager for Dataverse"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAACk0lEQVR4nO2XTWgTQRTHF/w6Kh5E8OLJg1cRksysC7a2AT8OxSXdmc3ObHYNSmxJVGxRMU0REwS9VxBbqFAreJBai9KLN6/ehR7EDxRJw1YEbVfekq2bNc3msBMvPnjMzry3/H/zdl6GSJIgk3WrgSl3O7msW6ui9CUQKMxtdHTI6QlAX36sZecwFwKANVNBlNV9oZ5WAGkmxpR9knV+3INpAoR3L6QCKCQeBIi9AjJlJxFl4zBuAlD+Bsrfkqdbq7F2QYoaZ1JaNomJWcKEVxFhl5OUH8XEPCWJNkRZAhH+AWezh4LrMEeEf4S4WADCCkjjp9PpkV1p215UDP5j8Jz97LCq7oR1iAsFkDU+2ASxRiuXHOf9jFu4WXRkwrgXDxw+IYYoq/er+d2IsokHs5Ou+/WRCyMmvKwwtgfiQgEw5YuI8KEwAMwxNc9iyp4LET6Sz+/A1NQThnEgoVp72wEkdX2fkmEHxYgT/hRTPu+vtQOIXTgojghfgJO/FcCxLP8i6/xX2rKW/O6AMW3bL4KdIsUh3g6gOFlag44YnSg5wed2ndK1Ye+Xjr0EkHAsCPDu7ZTnnZ79TuksqJkXMOFjm07ZK88DaynCzocBuvGuzgmm3B0qz3d0/9YSBlCY23CHa8uuemuhxTO15ZZrUyhA5vbSXzuHtZ4BDIcq4O/+n1Ug09x9CwDhN+7PVNa7BZiarqxjyq5HAqihbx/2PxXg7Nqdq41uAcarVxpIN4zovqes1tGJWYJchbH9fWZurb4yHSn+beWh289z3+EdKU4byNn3LpZLzs/Ps1uKQ6xQLjoDpnlXitsUpbz9hGm9fvykuiUAxCBHVdVtkghDEd0g9KYE+w+AKRuJ+tMBOV65Iuw3qRJqgDA4pM4AAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#6d8383"),
        ExportMetadata("PrimaryFontColor", "WhiteSmoke"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class FinOpsVirtualEntityManagerPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new FinOpsVirtualEntityManagerControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public FinOpsVirtualEntityManagerPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}