using System;
using Microsoft.AspNetCore.Mvc;
using Verity.BankAPI.Services.CurrentAccountService;
using Verity.BankAPI.Entities.CurrentAccount;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Verity.BankAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {

        private readonly ICurrentAccountService _currentAccountService;
        public CurrentAccountController(ICurrentAccountService currentAccountService)
        {
            _currentAccountService = currentAccountService;
        }

        /// <summary>
        /// Do transactions to given account
        /// </summary>
        /// <param name="model">Transaction object</param>
        /// <returns>message of type string</returns>
        [HttpPost("Transaction")]
        public ActionResult<string[]> Transaction([FromBody]Transaction model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _currentAccountService.Transaction(model);

                    if (result)
                    {
                        return new string[] { "Your transaction was made successfully" };
                    }
                    else
                    {
                        return new string[] { "Something went wrong with the transaction" };
                    }
                }
                catch (Exception ex)
                {
                    return new string[] { "Something went wrong with the transaction - " + ex.Message };
                }
            }
            else
            {
                return new string[] { "Parameters sent are null or invalid" };
            }
        }

        /// <summary>
        /// Get statement from given current account
        /// </summary>
        /// <param name="model">CurrentAccount object</param>
        /// <returns>statement from current account</returns>
        [HttpGet("statement")]
        public ActionResult<string[]> Statement([FromBody]CurrentAccount model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return new string[] { "Your current statement is " + _currentAccountService.Statement(model) };
                }
                catch (Exception ex)
                {
                    return new string[] { "Something went wrong while getting the statement " + ex.Message };
                }
            } else {
                return new string[] { "Parameters sent are null or invalid" };
            }
        }

    }
}
