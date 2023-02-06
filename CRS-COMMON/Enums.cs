using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_COMMON
{
    public enum RoleTypes
    {
        Administrator = 1,
        Professor = 2,
        Student = 3
    }

    public enum DepartmentTypes
    {
        Biology = 1,
        Psychology = 2,
        Business = 3,
        MathematicsPhysics = 4,
        Communications = 5,
        English = 6,
        Art = 7,
        Engineering = 8,
        ComputerScience = 9
    }

    public enum MajorTypes
    {
        Biology = 13,
        Psychology = 14,
        Economics = 15,
        Mathematics  = 16,
        Physics = 17,
        Communications = 18,
        Literature = 19,
        English = 20,
        Dance = 21,
        Fashion = 22,
        Architecture = 23,
        Engineering = 24,
        ComputerScience = 25
    }

    public enum PaymentMethodTypes
    {
        Credit = 1,
        Debit = 2,
        Cash = 3,
        Scholarship = 4,
        FinancialAid = 5,
        DirectDeposit = 6,
        WireTransfer = 7
    }
}
