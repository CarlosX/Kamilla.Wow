﻿
namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class MoveStop : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_STOP; }
        }

        protected override TransferDirection Direction
        {
            get { return TransferDirection.ToServer; }
        }

        protected override MovementStatusElements[] Elements
        {
            get
            {
                return new MovementStatusElements[]
                {
                };
            }
        }
    }
}
