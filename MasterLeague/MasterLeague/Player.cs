using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MasterLeague
{
    public class Player
    {
        public int Id { get; set; }
        public int? Team { get; set; }
        public int Region { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Country { get; set; }
        public int Role { get; set; }
        public string Url { get; set; }

        public dynamic Photo { get; set; }

        public string SmallPhoto
        {
            get { return Photo.small; }
        }

        public string BigPhoto
        {
            get { return Photo.big; }
        }

        public string MediumPhoto
        {
            get { return Photo.medium; }
        }

        public override string ToString()
        {
            if (RealName != null)
            {
                return $"{RealName}, aka {NickName}";
            }
            else
            {
                return NickName;
            }
        }
    }
}
