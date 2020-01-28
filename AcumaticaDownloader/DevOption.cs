using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaDeployer
{
    public class DevOption
    {
        public DevOption()
        {
            Area = "AppSettings";
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public string Area { get; set; }
        public string Recommend { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
    }
    public class DevOptions : List<DevOption>
    {
        public DevOptions()
        {
            AddRange(new List<DevOption>() {
            new DevOption()
            {
                Label = "Automation Debug",
                Name = "AutomationDebug",
                Desc = "An indicator of whether an information about the current automation step (state of a form of Acumatica ERP) is displayed on the form. If you set the value of the key to true, the text box with the current automation state is displayed on the Info area of a form of Acumatica ERP.",
                Type = "boolean",
                Recommend="False"

            },
            new DevOption()
            {
                Label = "CheckCustomization Compatibility",
                Name = "CheckCustomizationCompatibility",
                Desc = "If the key is True, the platform checks compatibility of the code included in a customization project with the original application code every time while publishing the project. If there are any compatibility errors, the platform displays the warning and error messages in the сompilation window and breaks the publication process.",
                Type = "boolean",
                Recommend="True"

            },
            new DevOption()
            {
                Label = "Compile Pages",
                Name = "CompilePages",
                Desc = "An indicator of whether the application compiles the website pages at the website launching to warm up the application. Better to have it false on development instance to speed up performance. InstantiateAllCaches(Default true) – creates a separate thread to create all possible PXCache objects.That helps to run screens faster on first access",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label= "Instantiate All Caches ",
                Name = "InstantiateAllCaches ",
                Desc = "creates a separate thread to create all possible PXCache objects. That helps to run screens faster on first access",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Disable Customization",
                Name = "DisableCustomization",
                Desc = "Can permanently disable customization tools on Acumatica Instance. Might be good for better controlling.",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Disable Extensions",
                Name = "DisableExtensions",
                Desc = "If you set the key to true, at run time, during the first initialization of a base class, Acumatica Customization Platform does not find the class extension to replace the base class with the merged result of the base class and the extension discovered.",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Disable Schedule Processor",
                Name = "DisableScheduleProcessor",
                Desc = "An indicator of whether the operations scheduled in the application are disabled. As a rule, developers set the key to true to prevent launching scheduled operation at the code debugging",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label = "Enable Application Shutdown Logging",
                Name = "EnableApplicationShutdownLogging",
                Desc = "An indicator of whether the AppDomain writes a message that contains the start or stop event information and the application stack to MS Windows Event Log",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Enable Auto Numbering In Separate Connection",
                Name = "EnableAutoNumberingInSeparateConnection",
                Desc = "If a process uses auto-numbering during creation of a business entity, the process blocks an access to the numbering sequence for this entity. Therefore, other processes that use the same numbering sequence may wait for a long time when the numbering sequence is unblocked. To avoid blocking the numbering sequence, you can set the key to true. As a result, a new number is created asynchronously in a separate connection scope.",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Enable First Chance Exceptions Logging",
                Name = "EnableFirstChanceExceptionsLogging",
                Desc = "An indicator of whether the system logs first chance exceptions",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Mobile Sitemap Debug",
                Name = "MobileSitemapDebug",
                Desc = "The Mobile Site Map Definition Language (MSDL) interpreter can work in the following modes: Production mode, in which the interpreter ignores most errors while processing the MSDL code for greater stability; Debugging mode, in which the interpreter logs every error and stops executing the MSDL code if an error occurs. In production mode the interpreter ignores any MSDL file that contains a syntax error. It also ignores any instruction that contains a semantic error. If such an instruction contains nested instructions and assignment commands, the interpreter also ignores them. If the key is turned on, the MSDL interpreter logs errors and sends the error messages to the mobile app, which displays these messages on the mobile device",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Page Validation",
                Name = "PageValidation",
                Desc = "Validation Policy for developers, show banners with warnings if automatic validation has found any error on your screen",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label  = "Reminder Visible",
                Name = "ReminderVisible",
                Desc = "An indicator of whether reminders are visible of forms of Acumatica ERP",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Reminder Active Mode",
                Name = "ReminderActiveMode",
                Desc = "An indicator of whether the reminder is activated. To activate reminders in the application, set both the ReminderActiveMode and ReminderVisible keys to true.",
                Type = "boolean",
                Recommend="False"
            },
            new DevOption()
            {
                Label = "Reminder Request Period",
                Name = "ReminderRequestPeriod",
                Desc = "The reminder frequency in seconds.",
                Type = "int",
                Recommend="60"
            },
            new DevOption()
            {
                Label = "SQL Optimize For Unknown",
                Name = "SqlOptimizeForUnknown",
                Desc = "Does recommended SQL query optimizations",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label = "Use Runtime Compilation",
                Name = "UseRuntimeCompilation",
                Desc = "An indicator of whether the customization platform uses the App_RuntimeCode folder as the destination folder for the Code files of customization project. Usage of this folder does not require the domain restart. If you set the key to false, the platform uses the App_Code/Caches folder for the customization code",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label = "Restrict Updates",
                Name = "RestrictUpdates",
                Desc = "Manages possibility of installing updates by using Acumatica ERP web interface (the Apply Updates form). If the parameter is true, updates can be installed only manually on the Acumatica ERP server",
                Type = "boolean",
                Recommend="True"
            },
            new DevOption()
            {
                Label = "Optimize Compilations",
                Name = "OptimizeCompilations",
                Desc = "read more on MSDN",
                Type = "boolean",
                Recommend="True",
                Area="compilation"
            },
            new DevOption()
            {
                Label = "Batch",
                Name = "Batch",
                Desc = "batch mode will compile multiple pages at once. For debuggin purpose we most probably need only one or 2 pages, so compilation without batch will be faster",
                Type = "boolean",
                Recommend="False",
                Area="compilation"
            }}
            ); ;
        }
    }
}
