﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Crear las interfaces (en class library): 
    ///#.-ISerializa -> Xml() : bool
    ///              -> Path{ get; } : string
    
    public interface ISerializa
    {
        bool Xml();
        string Path { get; }
    }
}
