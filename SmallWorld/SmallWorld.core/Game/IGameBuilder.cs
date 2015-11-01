using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface IGameBuilder
    {
        Game build();
        IGameBuilder settings(GameSettings settings);
    }
}