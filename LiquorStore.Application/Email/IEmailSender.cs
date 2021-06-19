using LiquorStore.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquorStore.Application.Email
{
    public interface IEmailSender
    {
        void Send(EmailDto dto);
    }
}
