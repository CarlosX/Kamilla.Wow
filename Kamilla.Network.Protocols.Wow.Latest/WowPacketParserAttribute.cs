﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.Network.Parsing;

namespace Kamilla.Network.Protocols.Wow.Latest
{
    class WowPacketParserAttribute : PacketParserAttribute
    {
        static readonly Type s_protocol = typeof(WowLatestProtocol);

        public WowPacketParserAttribute(WowOpcodes opcode)
            : base(s_protocol, (uint)opcode)
        {
        }
    }
}
