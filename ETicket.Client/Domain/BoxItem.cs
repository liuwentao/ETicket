using System;
using System.Collections.Generic;
using System.Text;

namespace ETicket.Client.Domain
{
    public class BoxItem
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Text) ? "" : Text;
        }

    }
}
