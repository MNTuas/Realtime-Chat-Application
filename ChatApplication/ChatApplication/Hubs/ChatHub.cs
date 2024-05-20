using ChatApplication.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinChat(UserConnection conn)
        {
            await Clients.All.SendAsync(method: "ReciveMessage", arg1: "admin", arg2:$"{conn.Username} has joined");
        }

        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName: conn.ChatRoom);
            await Clients.Groups(conn.ChatRoom)
                .SendAsync(method: "ReciveMessage", arg1: "admin", arg2: $"{conn.Username} has joined {conn.ChatRoom}");
        }
    }
}
