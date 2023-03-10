using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CRS_COMMON
{
    public class Helpers
    {
        public string ObjectToJsonString(object entity)
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }

        public T JsonStringToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
