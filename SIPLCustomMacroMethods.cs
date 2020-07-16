using CMS;
using CMS.CustomTables;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.MacroEngine;

// Makes all methods in the 'CustomMacroMethods' container class available for string objects
[assembly: RegisterExtension(typeof(SIPLCustomMacroMethods), typeof(string))]
// Registers methods from the 'CustomMacroMethods' container into the "String" macro namespace
[assembly: RegisterExtension(typeof(SIPLCustomMacroMethods), typeof(StringNamespace))]
/// <summary>
/// Summary description for SIPLCustomMacroMethods
/// </summary>
public class SIPLCustomMacroMethods : MacroMethodContainer
{
    public SIPLCustomMacroMethods()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    [MacroMethod(typeof(object), "This macro is used to fetch column field value from a custom table on passing Custom table name, Unique ID and Column name", 3)]
    [MacroMethodParam(0, "CustomTableName", typeof(string), "Custom Table Name")]
    [MacroMethodParam(1, "ItemID", typeof(string), "ItemID to get the record of the custom table from which the field value is to be returned.")]
    [MacroMethodParam(2, "ColumnName", typeof(string), "Column Name")]

    public static object GetValueFromCustomTableByItemID(EvaluationContext context, params object[] parameters)
    {

        if (parameters[0] == null || parameters[1] == null || parameters[2] == null)
            return null;

        string CustomTableName = ValidationHelper.GetString(parameters[0], "");
        string UniqueID = ValidationHelper.GetString(parameters[1], "");
        string ColumnName = ValidationHelper.GetString(parameters[2], "");

        DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(CustomTableName);

        if (customTable != null)
        {
            var ds = CustomTableItemProvider.GetItems(CustomTableName)
                                                         .Column(ColumnName)
                                                        .WhereEquals("ItemID", UniqueID)
                                                        .TopN(1);

            if (!DataHelper.DataSourceIsEmpty(ds) && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0];
            }
        }

        return null;

    }

    [MacroMethod(typeof(object), "This macro is used to fetch column field value from a custom table on passing Custom table name, Unique ID and Column name", 3)]
    [MacroMethodParam(0, "CustomTableName", typeof(string), "Custom Table Name")]
    [MacroMethodParam(1, "ItemGUID", typeof(string), "ItemGUID to get the record of the custom table from which the field value is to be returned.")]
    [MacroMethodParam(2, "ColumnName", typeof(string), "Column Name")]

    public static object GetValueFromCustomTableByItemGUID(EvaluationContext context, params object[] parameters)
    {

        if (parameters[0] == null || parameters[1] == null || parameters[2] == null)
            return null;

        string CustomTableName = ValidationHelper.GetString(parameters[0], "");
        string UniqueID = ValidationHelper.GetString(parameters[1], "");
        string ColumnName = ValidationHelper.GetString(parameters[2], "");

        DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(CustomTableName);

        if (customTable != null)
        {
            var ds = CustomTableItemProvider.GetItems(CustomTableName)
                                                         .Column(ColumnName)
                                                        .WhereEquals("ItemGUID", UniqueID)
                                                        .TopN(1);

            if (!DataHelper.DataSourceIsEmpty(ds) && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0];
            }
        }

        return null;

    }

}