using System.Collections.Generic;

namespace dk.via.ftc.businesslayer.Data.Sockets.SocketModels
{
    public class DrugRoot
    {
        public Drug[] drugs;
        public DrugRoot(int count)
        {
            drugs = new Drug[count];
        }
        
    }
}