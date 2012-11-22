using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDS.DomainModel
{

    public enum QueueStates
    {
        RxEntry = 1000,
        ThirdPartyRejects = 1001, // Insurance Rejected, Resubmittal required
        DUE = 1002, // Insurance passed, required DUE
        PrintLabel = 1003, // Insurance and DUE passed ready for printing
        RPHVerificaiton = 1004, // Print label done, ready for RPH Verification
        WillCall = 1005, // Verfiication done, in will call bin
        Sold = 1006 //Sold, ready for refill


    }
}
