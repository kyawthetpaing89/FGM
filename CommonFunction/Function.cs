using Newtonsoft.Json;
using System.Data;

namespace CommonFunction
{
    public class Function
    {
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
