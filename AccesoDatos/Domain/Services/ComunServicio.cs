using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Domain.Services
{
    public class ComunServicio
    {
        public static T ObtenerDtoFromString<T>(string item)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(item)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

    }
}
