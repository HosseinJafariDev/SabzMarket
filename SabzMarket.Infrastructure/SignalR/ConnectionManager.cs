using SabzMarket.Application.Interfaces.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.SignalR
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly ConcurrentDictionary<string, string> _userToConnection =
        new ConcurrentDictionary<string, string>();

        private readonly ConcurrentDictionary<string, string> _connectionToUser =
            new ConcurrentDictionary<string, string>();

        public void AddOrUpdate(string userId, string connectionId)
        {
            if (_userToConnection.TryGetValue(userId, out var oldConn))
            {
                _connectionToUser.TryRemove(oldConn, out _);
            }

            _userToConnection[userId] = connectionId;
            _connectionToUser[connectionId] = userId;
        }

        public void RemoveByConnectionId(string connectionId)
        {
            if (_connectionToUser.TryRemove(connectionId, out var userId))
            {
                _userToConnection.TryRemove(userId, out _);
            }
        }

        public string? GetConnectionId(string userId)
        {
            return _userToConnection.TryGetValue(userId, out var conn) ? conn : null;
        }
        public string? GetUserId(string connection)
        {
            return _connectionToUser.TryGetValue(connection, out var conn) ? conn : null;
        }
    }
}
