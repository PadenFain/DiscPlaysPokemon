using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscPlaysPokemon.config
{
    internal class Keyreader
    {
        public string Token { get; set; }
        public async Task ReadJson()
        {
            using (StreamReader sr = new StreamReader("key.json"))
            {
                string json = await sr.ReadToEndAsync();
                JStructure data = JsonConvert.DeserializeObject<JStructure>(json);
                this.Token = data.Token;
            }
        }
    }

    internal sealed class JStructure
    {
        public string Token { get; set; }
    }
}
