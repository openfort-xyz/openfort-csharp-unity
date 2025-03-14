/*
 * Openfort API
 *
 * Complete Openfort API references and guides can be found at: https://openfort.xyz/docs
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: founders@openfort.xyz
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// BalanceResponse
    /// </summary>
    [DataContract(Name = "BalanceResponse")]
    public partial class BalanceResponse : IEquatable<BalanceResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BalanceResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        /// <param name="balance">balance (required).</param>
        /// <param name="expenses">expenses (required).</param>
        /// <param name="payments">payments (required).</param>
        public BalanceResponse(Money balance = default(Money), Money expenses = default(Money), Money payments = default(Money))
        {
            // to ensure "balance" is required (not null)
            if (balance == null)
            {
                throw new ArgumentNullException("balance is a required property for BalanceResponse and cannot be null");
            }
            this.Balance = balance;
            // to ensure "expenses" is required (not null)
            if (expenses == null)
            {
                throw new ArgumentNullException("expenses is a required property for BalanceResponse and cannot be null");
            }
            this.Expenses = expenses;
            // to ensure "payments" is required (not null)
            if (payments == null)
            {
                throw new ArgumentNullException("payments is a required property for BalanceResponse and cannot be null");
            }
            this.Payments = payments;
        }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>
        [DataMember(Name = "balance", IsRequired = true, EmitDefaultValue = true)]
        public Money Balance { get; set; }

        /// <summary>
        /// Gets or Sets Expenses
        /// </summary>
        [DataMember(Name = "expenses", IsRequired = true, EmitDefaultValue = true)]
        public Money Expenses { get; set; }

        /// <summary>
        /// Gets or Sets Payments
        /// </summary>
        [DataMember(Name = "payments", IsRequired = true, EmitDefaultValue = true)]
        public Money Payments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BalanceResponse {\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Expenses: ").Append(Expenses).Append("\n");
            sb.Append("  Payments: ").Append(Payments).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BalanceResponse);
        }

        /// <summary>
        /// Returns true if BalanceResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of BalanceResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BalanceResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Balance == input.Balance ||
                    (this.Balance != null &&
                    this.Balance.Equals(input.Balance))
                ) &&
                (
                    this.Expenses == input.Expenses ||
                    (this.Expenses != null &&
                    this.Expenses.Equals(input.Expenses))
                ) &&
                (
                    this.Payments == input.Payments ||
                    (this.Payments != null &&
                    this.Payments.Equals(input.Payments))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Balance != null)
                {
                    hashCode = (hashCode * 59) + this.Balance.GetHashCode();
                }
                if (this.Expenses != null)
                {
                    hashCode = (hashCode * 59) + this.Expenses.GetHashCode();
                }
                if (this.Payments != null)
                {
                    hashCode = (hashCode * 59) + this.Payments.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
