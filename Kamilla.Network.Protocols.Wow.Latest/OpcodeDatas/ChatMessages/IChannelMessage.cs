﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Latest.Game;

namespace Kamilla.Network.Protocols.Wow.Latest.OpcodeDatas.ChatMessages
{
    /// <summary>
    /// Represents a channel chat message.
    /// </summary>
    public interface IChannelMessage : IClientChatMessage
    {
        /// <summary>
        /// Gets or sets the channel name.
        /// </summary>
        string ChannelName { get; set; }
    }
}
