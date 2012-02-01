﻿using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class ForceKnockBack : ForcePacket
    {
        public float TransferDirectionCos { get; set; }
        public float TransferDirectionSin { get; set; }
        public float HorizontalSpeed { get; set; }
        public float VerticalSpeed { get; set; }

        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 1, 0, 5, 7, 3, 4, 6, 2 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { -2, -3, -5, 5, 6, -1, -4, 1, 0, 2, 4, 3, 7 }; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            switch (index)
            {
                case -2:
                    this.TransferDirectionCos = reader.ReadSingle();
                    break;
                case -3:
                    this.TransferDirectionSin = reader.ReadSingle();
                    break;
                case -4:
                    this.HorizontalSpeed = reader.ReadSingle();
                    break;
                case -5:
                    this.VerticalSpeed = reader.ReadSingle();
                    break;
                default:
                    base.ElementRead(reader, index);
                    break;
            }
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            switch (index)
            {
                case -2:
                    writer.WriteSingle(this.TransferDirectionCos);
                    break;
                case -3:
                    writer.WriteSingle(this.TransferDirectionSin);
                    break;
                case -4:
                    writer.WriteSingle(this.HorizontalSpeed);
                    break;
                case -5:
                    writer.WriteSingle(this.VerticalSpeed);
                    break;
                default:
                    base.ElementRead(writer, index);
                    break;
            }
        }

        public override void ToString(StringBuilder builder)
        {
            base.ToString(builder);

            builder
                .AppendLine("TransferDirection Cos: " + TransferDirectionCos)
                .AppendLine("TransferDirection Sin: " + TransferDirectionSin)
                .AppendLine("Horizontal Speed: " + HorizontalSpeed)
                .AppendLine("Vertical Speed: " + VerticalSpeed);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_KNOCK_BACK, TransferDirection.ToClient);
        }
    }
}
