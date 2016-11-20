using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
    public class Customer
    {
        //("@CustomerID", SqlDbType.UniqueIdentifier).Value = new Guid(CustID.PadLeft(32, '0'));
        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
        //            cmd.Parameters.Add("@HPIN", SqlDbType.NVarChar).Value = hPin;
        //            cmd.Parameters.Add("@HFinger", SqlDbType.NVarChar).Value = hFinger;
        //            cmd.Parameters.Add("@HFace", SqlDbType.NVarChar).Value = hFace;
        //            cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = balance;
        public Guid CustomerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String HPIN { get; set; }
        public String finger_path { get; set; }
        public String face_path { get; set; }
        public double balance { get; set; }
    }
}
