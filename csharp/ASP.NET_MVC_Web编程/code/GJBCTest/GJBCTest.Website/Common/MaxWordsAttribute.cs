﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Common
{
    public class MaxWordsAttribute:ValidationAttribute,IClientValidatable
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords):base("{0} has too many words!") {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value != null) {
                var valuestr = value.ToString();
                if (valuestr.Split(' ').Length > _maxWords) {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
            rule.ValidationParameters.Add("wordcount", _maxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}