using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLocation.Type.Commons
{
    public class Rental
    {

        public int Id;
        public String carReg;
        public String CustName;
        public DateTime RentDate;
        public DateTime ReturnDate;
        public int RentFee;





        public static int INC_ID;

        public Rental(String carReg , String CustName , DateTime RentDate , DateTime ReturnDate , int RentFee)
        { 

            this.carReg = carReg;
            this.CustName = CustName;
            this.RentDate = RentDate;
            this.ReturnDate = ReturnDate;
            this.RentFee = RentFee;
            this.Id = ++INC_ID;
        }



        public bool IsNull()
        {
            return this == null;
        }


    }
}
