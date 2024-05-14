#region

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

#endregion

namespace CSVFileParser
{
    /// <summary>
    /// Serializes and deserializes .csv-files. Original functionality was not written by Sophie Harms.
    /// Refactoring done by Sophie Harms.
    /// </summary>
    public class CSVSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Deserialize<T>(string text, char separator)
        {
            return (T[])CreateArray(typeof(T), ParseCSV(text, separator));
        }

        private static object CreateArray(Type type, List<string[]> rows)
        {
            var array_value = Array.CreateInstance(type, rows.Count - 1);
            var table = new Dictionary<string, int>();

            for (var i = 0; i < rows[0].Length; i++)
            {
                var id = rows[0][i];
                var id2 = "";
                for (var j = 0; j < id.Length; j++)
                {
                    id2 = IdentifyCharacter(id, j, id2);
                }

                table.Add(id, i);
                table.TryAdd(id2, i);
            }

            for (var i = 1; i < rows.Count; i++)
            {
                var rowdata = Create(rows[i], table, type);
                array_value.SetValue(rowdata, i - 1);
            }

            return array_value;
        }

        private static string IdentifyCharacter(string id, int j, string id2)
        {
            if ((id[j] >= 'a' && id[j] <= 'z') || (id[j] >= '0' && id[j] <= '9'))
                id2 += id[j].ToString();
            else if (id[j] >= 'A' && id[j] <= 'Z')
                id2 += ((char)(id[j] - 'A' + 'a')).ToString();
            return id2;
        }

        private static object Create(string[] cols, Dictionary<string, int> table, Type type)
        {
            var v = Activator.CreateInstance(type);

            var fieldinfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var tmp in fieldinfo)
            {
                if (table.TryGetValue(tmp.Name, out var idx))
                {
                    if (idx < cols.Length)
                        SetValue(v, tmp, cols[idx]);
                }
            }

            return v;
        }

        private static void SetValue(object v, FieldInfo fieldInfo, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            object trueValue;

            if (fieldInfo.FieldType.IsArray)
            {
                trueValue = ParseArray(fieldInfo, value);
            }
            else if (fieldInfo.FieldType.IsEnum)
            {
                trueValue = Enum.Parse(fieldInfo.FieldType, value);
            }
            else if (value.IndexOf('.') != -1 && fieldInfo.IsNumber())
            {
                var f = (float)Convert.ChangeType(value, typeof(float));
                trueValue = Convert.ChangeType(f, fieldInfo.FieldType);
            }
            else if (fieldInfo.FieldType == typeof(string))
            {
                trueValue = value;
            }
            else
            {
                trueValue = Convert.ChangeType(value, fieldInfo.FieldType);
            }

            fieldInfo.SetValue(v, trueValue);
        }

        private static Array ParseArray(FieldInfo fieldinfo, string value)
        {
            var elementType = fieldinfo.FieldType.GetElementType();
            var elem = value.Split(',');
            var array_value = Array.CreateInstance(elementType, elem.Length);
            for (var i = 0; i < elem.Length; i++)
            {
                array_value.SetValue(
                    elementType == typeof(string) ? elem[i] : Convert.ChangeType(elem[i], elementType), i);
            }

            return array_value;
        }

        private static List<string[]> ParseCSV(string text, char separator)
        {
            var lines = new List<string[]>();
            var line = new List<string>();
            var token = new StringBuilder();
            var quotes = false;

            for (var i = 0; i < text.Length; i++)
                if (quotes)
                {
                    i = ParseQuote(text, separator, i, line, ref token, ref quotes);
                }
                else if (IsLineBreak(text, i))
                {
                    token = StartNewLine(token, line, lines);
                }
                else if (text[i] == separator)
                {
                    line.Add(token.ToString());
                    token = new StringBuilder();
                }
                else if (text[i] == '\"')
                {
                    quotes = true;
                }
                else
                {
                    token.Append(text[i]);
                }

            if (token.Length > 0) line.Add(token.ToString());
            if (line.Count > 0) lines.Add(line.ToArray());
            return lines;
        }

        private static StringBuilder StartNewLine(StringBuilder token, List<string> line, List<string[]> lines)
        {
            if (token.Length > 0)
            {
                line.Add(token.ToString());
                token = new StringBuilder();
            }

            if (line.Count > 0)
            {
                lines.Add(line.ToArray());
                line.Clear();
            }

            return token;
        }

        private static int ParseQuote(string text, char separator, int i, List<string> line, ref StringBuilder token,
            ref bool quotes)
        {
            if (IsSlashOrDoubleQuote(text, i))
            {
                token.Append('\"');
                i++;
            }
            else if (IsLineBreak(text, i))
            {
                token.Append('\n');
                i++;
            }
            else if (text[i] == '\"')
            {
                line.Add(token.ToString());
                token = new StringBuilder();
                quotes = false;
                if (i + 1 < text.Length && text[i + 1] == separator)
                    i++;
            }
            else
            {
                token.Append(text[i]);
            }

            return i;
        }

        private static bool IsSlashOrDoubleQuote(string text, int i)
        {
            return (text[i] == '\\' && i + 1 < text.Length && text[i + 1] == '\"') ||
                   (text[i] == '\"' && i + 1 < text.Length && text[i + 1] == '\"');
        }

        private static bool IsLineBreak(string text, int i)
        {
            return text[i] == '\r' || text[i] == '\n' || text[i] == '\\' && i + 1 < text.Length && text[i + 1] == 'n';
        }
    }
}