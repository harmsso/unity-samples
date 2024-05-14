#region

using System.Reflection;

#endregion

namespace CSVFileParser
{
    public static class ExtensionMethods
    {
        public static bool IsNumber(this FieldInfo fieldInfo)
        {
            return (fieldInfo.FieldType == typeof(int) || fieldInfo.FieldType == typeof(long) ||
                    fieldInfo.FieldType == typeof(short));
        }
    }
}