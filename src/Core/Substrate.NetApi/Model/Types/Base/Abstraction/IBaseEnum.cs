﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Model.Types.Base.Abstraction
{
    public interface IBaseEnum : IType
    {
        Enum GetEnum();
        IType GetValues();
    }
}
