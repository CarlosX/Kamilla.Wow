﻿using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class ThreatHighestUpdate : ThreatUpdate
    {
        public WowGuid Target { get; set; }

        public override void Read(StreamHandler reader)
        {
            this.Unit = reader.ReadPackedGuid();
            this.Target = reader.ReadPackedGuid();

            var count = reader.ReadInt32();
            this.ThreatList = new ThreatUpdatePair[count];
            for (int i = 0; i < count; ++i)
                this.ThreatList[i] = new ThreatUpdatePair { Unit = reader.ReadPackedGuid(), Threat = reader.ReadUInt32() };
        }

        public override void Save(StreamHandler writer)
        {
            writer.WritePackedGuid(this.Unit);
            writer.WritePackedGuid(this.Target);
            writer.WriteInt32(ThreatList.Length);
            for (int i = 0; i < ThreatList.Length; ++i)
            {
                writer.WritePackedGuid(ThreatList[i].Unit);
                writer.WriteUInt32(ThreatList[i].Threat);
            }
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Aggressor: " + this.Unit);
            builder.AppendLine("Victim: " + this.Target);

            for (int i = 0; i < ThreatList.Length;++i)
                builder.AppendFormatLine("Threat: {0}   Unit: {1}", ThreatList[i].Threat, ThreatList[i].Unit);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_HIGHEST_THREAT_UPDATE, TransferDirection.ToClient);
        }
    }
}
