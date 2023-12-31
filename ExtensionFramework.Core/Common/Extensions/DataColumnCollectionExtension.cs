﻿using System.Data;

namespace ExtensionFramework.Core.Common.Extensions;

public static class DataColumnCollectionExtension
{
    public static string ToCsv(this DataColumnCollection collection, string separator)
    {
        return collection.OfType<DataColumn>().Select(x => x.ColumnName).JoinString(separator);
    }
}