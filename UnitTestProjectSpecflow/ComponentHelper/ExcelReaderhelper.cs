using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2.ExcelDataReader
{
    public class ExcelReaderhelper

    {
        private static Dictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReaderhelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        public  static object GetCellData(string xlPath, string sheetName, int row, int column)
        {

            IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
            DataTable table = _reader.AsDataSet().Tables[sheetName];
            return GetData(table.Rows[row][column].GetType(), table.Rows[row][column]);
                
        }

        public static object GetCellData(string xlPath, string sheetName, int row, string columnname)
        {

            IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
            DataTable table = _reader.AsDataSet().Tables[sheetName];
            return GetData(table.Rows[row][columnname].GetType(), table.Rows[row][columnname].ToString());

        }

        private static IExcelDataReader GetExcelReader(string xlPath, string sheetName)
        {
            if (_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }
            
            return reader;
        }
        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Integer":
                    return Convert.ToInt64(data);

                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
                
            }
        }


    }
}
