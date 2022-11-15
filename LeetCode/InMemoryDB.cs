using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class InMemoryDB
    {
        string[] solution(string[][] queries)
        {
            List<string> result = new List<string>();
            List<dbRecord> records = new List<dbRecord>();

            foreach (var query in queries)
            {
                switch (query[0].ToUpper())
                {
                    case "SET_OR_INC":
                        int intVal = Convert.ToInt32(query[3]);

                        var record = GetDbRecord(records, query[1], query[2]);

                        if (record == null)
                        {
                            records.Add(new dbRecord()
                            {
                                Key = query[1],
                                Field = query[2],
                                Value = intVal
                            });
                        }
                        else
                        {
                            intVal += record.Value;
                            record.Value = intVal;
                        }
                        result.Add(intVal.ToString());
                        break;
                    case "GET":
                        var rec = GetDbRecord(records, query[1], query[2]);
                        if (rec == null)
                            result.Add("");
                        else
                            result.Add(rec.Value.ToString());
                        break;
                    case "DELETE":
                        var delRec = GetDbRecord(records, query[1], query[2]);
                        if (delRec != null)
                        {
                            records.Remove(delRec);
                            result.Add("true");
                        }
                        else
                        {
                            result.Add("false");
                        }
                        break;
                }
            }
            return result.ToArray();
        }

        public dbRecord? GetDbRecord(List<dbRecord> records, string key, string field)
        {
            return records.Where(x => x.Key == key)
                            .Where(x => x.Field == field)
                            .FirstOrDefault();
        }
    }

    public class dbRecord
    {
        public string Key { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public int Value { get; set; }
    }
}
