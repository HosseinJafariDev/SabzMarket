using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.findUsersChatted
{
    public interface IChatQueryService
    {
        Task<List<findUsersChattedOutputDTO>> findUsersChattedWith(long id);
    }
}
