using CMS.CustomTables;
using CMS.DataEngine;
using CMS.Ecommerce;
using CMS.Helpers;
using CMS.Taxonomy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;



namespace CMS.DocumentEngine.Web.UI
{
    /// <summary>
    /// Extends the CMSTransformation partial class.
    /// </summary>
    public partial class CMSTransformation
    {
        /// <summary>
        /// Get Value From CustomTable By ItemID
        /// </summary>
        /// <param name="CustomTableName"></param>
        /// <param name="ItemID"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static object GetValueFromCustomTableByItemID(string CustomTableName, string ItemID, string ColumnName)
        {

            if (string.IsNullOrEmpty(CustomTableName) || string.IsNullOrEmpty(ItemID) || string.IsNullOrEmpty(ColumnName))
                return null;

            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(CustomTableName);

            if (customTable != null)
            {
                var ds = CustomTableItemProvider.GetItems(CustomTableName)
                                                             .Column(ColumnName)
                                                            .WhereEquals("ItemID", ItemID)
                                                            .TopN(1);

                if (!DataHelper.DataSourceIsEmpty(ds) && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0];
                }
            }

            return null;
        }

        /// <summary>
        /// Get Value From CustomTable By ItemGUID
        /// </summary>
        /// <param name="CustomTableName"></param>
        /// <param name="ItemGUID"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static object GetValueFromCustomTableByItemGUID(string CustomTableName, string ItemGUID, string ColumnName)
        {

            if (string.IsNullOrEmpty(CustomTableName) || string.IsNullOrEmpty(ItemGUID) || string.IsNullOrEmpty(ColumnName))
                return null;

            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(CustomTableName);

            if (customTable != null)
            {
                var ds = CustomTableItemProvider.GetItems(CustomTableName)
                                                             .Column(ColumnName)
                                                            .WhereEquals("ItemGUID", ItemGUID)
                                                            .TopN(1);

                if (!DataHelper.DataSourceIsEmpty(ds) && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0];
                }
            }

            return null;

        }

    }
}

