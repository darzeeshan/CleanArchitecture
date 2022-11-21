﻿namespace Cone.InventoryManagement.Web.Contracts.Infrastructure.DataTypes
{
    public class EnumDataTypes
    {
        public enum bytStatuses : byte
        {
            Active = 1, //<i class="fa-solid fa-siren-on"></i>
            Inactive,   //<i class="fa-thin fa-siren-on"></i>
            Pending,    //<i class="fa-duotone fa-siren-on"></i>
            Deleted     //<i class="fa-regular fa-siren-on"></i>
        }

        public enum bytFileTypes : byte
        {
            XML = 1,
            Excel,
            CSV,
            EDI850,
            EDI214,
            EDI856
        }

        public enum bytConnectionTypes : byte
        {
            Key = 1,
            JWT,
            FTP
        }
    }
}