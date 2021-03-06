﻿using System;
using System.ComponentModel.DataAnnotations;
using Beginor.AppFx.Core;

namespace Beginor.OwinApp.Model {

    public class ApplicationUserModel : BaseEntity<string> {

        #region "ASP.NET Identity属性"
        /// <summary>[UserName]</summary>
        [Required]
        public virtual string UserName { get; set; }

        /// <summary>[Email]</summary>
        [Required]
        public virtual string Email { get; set; }

        /// <summary>[EmailConfirmed]</summary>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>[PhoneNumber]</summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>[PhoneNumberConfirmed]</summary>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>[TwoFactorEnabled]</summary>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>[LockoutEndDateUtc]</summary>
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>[LockoutEnabled]</summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>[AccessFailedCount]</summary>
        public virtual int AccessFailedCount { get; set; }
        #endregion
    }
}
