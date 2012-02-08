﻿
namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class SetCollisionHeight : MoveSetPacket
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
            get { return WowOpcodes.SMSG_MOVE_UPDATE_COLLISION_HEIGHT; }
        }
    }
}
