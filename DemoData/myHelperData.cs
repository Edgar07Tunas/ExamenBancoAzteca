using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoData
{
    public class myHelperData
    {

        ADNEntities mycontex;
        public myHelperData()
        {
           
            mycontex = new ADNEntities();

        }

        public List<TaAlfabeto> GeTAlfabeto()
        {
            return mycontex.TaAlfabeto.ToList();
        }

        
    }
}
