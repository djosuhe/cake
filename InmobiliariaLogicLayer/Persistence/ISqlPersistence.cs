﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaLogicLayer.Persistence
{
    public interface ISqlPersistence: ISelectAll, ISelectForId, ISave, IUpdate, IDelete
    {
    }
}
