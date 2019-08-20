using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APICourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(soma.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(soma.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(soma.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                try
                {
                    var soma = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(soma.ToString());
                }
                catch (DivideByZeroException ex)
                {
                     BadRequest("Não tem como dividir por 0 burro!");
                }

            }
            return BadRequest("Entrada inválida");
        }
        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
