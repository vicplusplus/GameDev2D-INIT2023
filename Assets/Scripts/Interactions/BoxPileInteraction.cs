using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interactions
{
    internal class BoxPileInteraction : Interaction
    {
        public override void Enact(Character callingCharacter)
        {
            print("ZAMN");
        }

        public override bool Verify(Character callingCharacter)
        {
            return callingCharacter.Controller.GetType() == typeof(RoadWorkerController);
        }
    }
}
