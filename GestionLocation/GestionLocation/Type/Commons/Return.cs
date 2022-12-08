using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Type.Commons
{
    public class Return
    {


        public int Id;
        public String carReg;
        public String CustName;
        public DateTime ReturnDate;
        public DateTime Delay;

        public int Fine;


        public static int INC_ID;

        public Return(String carReg, String CustName , DateTime ReturnDate , DateTime Delay , int Fine)
        {
            this.carReg = carReg;
            this.CustName = CustName;
            this.ReturnDate = ReturnDate;
            this.Delay = Delay;
            this.Fine = Fine;
            this.Id = ++INC_ID;
        }



        public bool IsNull()
        {
            return this == null;
        }

    }
}
