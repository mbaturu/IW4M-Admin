﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IW4MAdmin.Application.EventParsers
{
    class T5MEventParser : IW4EventParser
    {
        public T5MEventParser() : base()
        {
            Configuration.GameDirectory = "v2";
        }
    }
}
