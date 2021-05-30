using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    class JsonSerialize
    {
        //Добавить  [DataContract] и  [DataMember]
        private Storage _storege;
        Stream file;
        public JsonSerialize(Storage storege)
        {
            _storege = storege;
        }

        public void Serializ()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<IDrawable>));

            using (file = new FileStream("Figuras.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, _storege);
            }

            using (file = new FileStream("Figuras.json", FileMode.OpenOrCreate)) 
            {
                var _storege = jsonFormatter.ReadObject(file) as List<IDrawable>; //Это передать в нью сторедж 

            }

        }
    }
}
