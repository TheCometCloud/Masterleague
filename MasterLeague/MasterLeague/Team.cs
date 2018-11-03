using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Region { get; private set; }
        public string Url { get; private set; }

        public Team(JObject ideal)
        {
            foreach (JProperty property in ideal.Properties())
            {
                switch (property.Name.ToLower())
                {
                    case "id":
                        Id = (int) property.Value;
                        break;
                    case "name":
                        Name = (string) property.Value;
                        break;
                    case "region":
                        Region = (int) property.Value;
                        break;
                    case "url":
                        Url = (string) property.Value;
                        break;
                }
            }
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}, ID: {Id}, Region: {Region}, Url: {Url}";
        }
    }
}
