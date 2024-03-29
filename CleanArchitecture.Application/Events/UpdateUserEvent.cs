﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Events
{
    public class UpdateUserEvent : INotification
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
