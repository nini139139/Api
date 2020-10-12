using Api.Domain.Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Interfaces.UserInterface
{
   public interface ITokenService
    {
        string CreateTOken(User user);
    }
}
