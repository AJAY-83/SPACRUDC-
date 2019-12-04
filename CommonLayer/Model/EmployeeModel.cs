// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Ajay Lodale"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// EmployeeModel here have the all properties of employee
    /// like id, name, email, gender
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// Required is use the this field is compulsory to write
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required is use the this field is compulsory to write
        /// </summary
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Required is use the this field is compulsory to write
        /// </summary
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Required is use the this field is compulsory to write
        /// </summary
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Salary { get; set; }

        /// <summary>
        /// Required is use the this field is compulsory to write
        /// </summary
        [Required]
        public string Gender { get; set; }

    }
}
