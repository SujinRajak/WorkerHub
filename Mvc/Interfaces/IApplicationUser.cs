﻿using Mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Interfaces
{
    public interface IApplicationUser
    {
        void SendEmail(EmailConfirmationModel emailConfirmationModel, string emailTemplatePath);
    }
}
