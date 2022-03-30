using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;


public class UserModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set;}
    public int Identity { get; set; } = 0;

    public bool IsAuthenticated()
    {
        return Identity != 0;
    }
}
