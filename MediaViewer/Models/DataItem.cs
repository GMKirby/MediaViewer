﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaViewer.Models
{
    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public string Title
        {
            get;
            private set;
        }
    }
}
