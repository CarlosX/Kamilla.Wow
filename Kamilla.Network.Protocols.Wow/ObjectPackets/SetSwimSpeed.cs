﻿
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SetSwimSpeed : MoveSetPacket
    {
        protected override MovementStatusElements[] Elements
        {
            get
            {
                return new MovementStatusElements[]
                {
                };
            }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_UPDATE_SWIM_SPEED; }
        }
    }
}
