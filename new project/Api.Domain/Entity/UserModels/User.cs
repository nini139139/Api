using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entity.UserModels
{
    public class User
    {
        [Key]
        public  int  Id { get; set; }
        
        public string UserName  { get; set; }
        public byte[] PasswordHash{ get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
