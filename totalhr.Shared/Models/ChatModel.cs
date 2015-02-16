﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.Resources;

namespace totalhr.Shared.Models
{
    public class ChatModel
    {
        /// <summary>
        /// Users that have connected to the chat
        /// </summary>
        public List<ChatUser> Users;

        /// <summary>
        /// Messages by the users
        /// </summary>
        public List<ChatMessage> ChatHistory;
        
        public ChatModel()
        {
            Users = new List<ChatUser>();
            ChatHistory = new List<ChatMessage>
                {
                    new ChatMessage()
                        {
                            Message = string.Format(Common.V_Chat_Server_Started_At, DateTime.Now)
                        }
                };
        }

        public class ChatRoom
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public string Creator { get; set; }

            public int CreatorId { get; set; }

            public DateTime CreatedOn { get; set; }

            public bool Private { get { return InvitedUserIds != null && InvitedUserIds.Count > 0; } }

            public List<int> InvitedUserIds { get; set; } 
        }

        public class ChatUser
        {
            public string NickName;
            public int Userid;
            public DateTime LoggedOnTime;
            public DateTime LastPing;
        }

        public class ChatMessage
        {
            /// <summary>
            /// If null, the message is from the server
            /// </summary>
            public ChatUser ByUser;

            public DateTime When = DateTime.Now;

            public string Message ="";

        }
    }
}
