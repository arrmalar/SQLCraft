using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace SQLCraft.Utility.DataTableParser
{
    public static class DataTableParser
    {
        public static DataTable FromJson(string jsonString)
        {
            // Deserialize directly into a list of dictionaries (representing rows)
            var rows = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonString);

            // Initialize a new DataTable
            DataTable dt = new DataTable();
            dt.Clear();

            if (rows == null || rows.Count == 0)
            {
                return dt; // Return empty DataTable if no rows
            }

            // Get the first row to extract column names
            var firstRow = rows[0];

            // Add columns to the DataTable based on the keys (column names) in the first row
            foreach (var column in firstRow.Keys)
            {
                dt.Columns.Add(column);
            }

            // Loop through each row and populate the DataTable
            foreach (var jsonRow in rows)
            {
                DataRow row = dt.NewRow();

                // Add each value to the corresponding column
                foreach (var column in jsonRow.Keys)
                {
                    row[column] = jsonRow[column] ?? DBNull.Value;
                }

                dt.Rows.Add(row);
            }

            return dt; // Return the populated DataTable
        }
    }
}
