﻿using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class MoveTimeSkippedServer : PackedData
    {
        public WowGuid Unit { get; set; }
        public uint Time { get; set; }

        protected override int[] MaskSequence
        {
            get { return new[] { 1, 0, 3, 7, 6, 2, 4, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new[] { 6, 1, 2, 5, -1, 4, 0, 3, 7 }; }
        }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            this.Time = reader.ReadUInt32();
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            writer.WriteUInt32(this.Time);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            this.Unit = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(this.Unit);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Unit:  " + this.Unit);
            builder.AppendLine("Time:  " + this.Time);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_SKIP_TIME, TransferDirection.ToClient);
        }
    }
}
