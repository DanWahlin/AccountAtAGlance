using AccountAtAGlance.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAtAGlance.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ValidAccountNumber_ReturnsNoModelStateError()
        {
            string accountNum = "Z12345";
            var account = new BrokerageAccount { AccountNumber = accountNum };
            var errors = GetModelValidationErrors(account);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void InValidAccountNumber_ReturnsModelStateError()
        {
            string accountNum = "12345";
            var account = new BrokerageAccount { AccountNumber = accountNum };
            var errors = GetModelValidationErrors(account);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void SecuritySymbolLengthIsNot5_ReturnsError()
        {
            string symbol = "FDGFXZ";
            var stock = new Stock { Symbol = symbol };
            var errors = GetPropertyValidationErrors(stock, "Symbol");
            Assert.AreEqual(1, errors.Count);
        }

        private IList<string> GetModelValidationErrors(object instance)
        {
            return GetValidationErrors(instance, null);
        }

        private IList<string> GetPropertyValidationErrors(object instance, string propertyName)
        {
            return GetValidationErrors(instance, propertyName);
        }

        private IList<string> GetValidationErrors(object instance, string propertyName)
        {
            var props = from prop in TypeDescriptor.GetProperties(instance).Cast<PropertyDescriptor>()
                        select prop;

            if (!String.IsNullOrEmpty(propertyName))
            {
                props = props.Where(p => p.Name == propertyName);
            }

            var errors = (from prop in props
                          from attribute in prop.Attributes.OfType<ValidationAttribute>()
                          where !attribute.IsValid(prop.GetValue(instance))
                          select attribute.FormatErrorMessage(prop.DisplayName)).ToList();
            return errors;
        }
    }
}
