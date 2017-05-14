using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    public partial class Methods
    {
        public void Serialise(Settings S)
        {
            using (var fs = new FileStream("settings.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Settings));
                xml.Serialize(fs, S);
            }
        }

        public Settings DeSerialise()
        {
            Settings S;

            using (var fs = new FileStream("settings.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Settings));
                return S = (Settings)xml.Deserialize(fs);
            }
        }
    }
}
