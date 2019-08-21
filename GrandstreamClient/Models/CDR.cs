using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandstreamClient.Models
{
    public class CDR
    {
        public string cdr { get; set; }
        public string AcctId { get; set; }
        public string accountcode { get; set; }
        public string src { get; set; }
        public string dst { get; set; }
        public string dcontext { get; set; }
        public string clid { get; set; }
        public string channel { get; set; }
        public string dstchannel { get; set; }
        public string lastapp { get; set; }
        public string lastdata { get; set; }
        public string start { get; set; }
        public string answer { get; set; }
        public string end { get; set; }
        public string duration { get; set; }
        public string billsec { get; set; }
        public string disposition { get; set; }
        public string amaflags { get; set; }
        public string uniqueid { get; set; }
        public string userfield { get; set; }
        public string channel_ext { get; set; }
        public string dstchannel_ext { get; set; }
        public string service { get; set; }
        public string caller_name { get; set; }
        public string recordfiles { get; set; }
        public string dstanswer { get; set; }
        public string chanext { get; set; }
        public string dstchanext { get; set; }
        public string session { get; set; }
        public string action_owner { get; set; }
        public string action_type { get; set; }
        public string src_trunk_name { get; set; }
        public string dst_trunk_name { get; set; }

        public CDR main_cdr { get; set; }
        public CDR sub_cdr_1 { get; set; }
        public CDR sub_cdr_2 { get; set; }
        public CDR sub_cdr_3 { get; set; }
        public CDR sub_cdr_4 { get; set; }

    }

    public class RootObject
    {
        public List<CDR> cdr_root { get; set; }
    }
}
