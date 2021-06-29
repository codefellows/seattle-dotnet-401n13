using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using PaymentsDemo.Payments.Models;
using PaymentsDemo.Payments.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsDemo.Services.Payments
{
  public class AuthnetPaymentService : IPayment
  {

    IConfiguration Configuration { get; set; }
    public AuthnetPaymentService(IConfiguration config)
    {
      Configuration = config;
    }
    public PaymentResponse ProcessPayment(Payment payment)
    {

      string ApiLoginId = Configuration["AuthorizeNet:ApiLoginId"];
      string ApiTransactionKey = Configuration["AuthorizeNet:TransactionKey"];

      ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

      // define the merchant information (authentication / transaction id)
      ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
      {
        name = ApiLoginId,
        ItemElementName = ItemChoiceType.transactionKey,
        Item = ApiTransactionKey,
      };

      var creditCard = new creditCardType
      {
        cardNumber = payment.CardNumber,
        expirationDate = payment.Expiration,
        cardCode = payment.Cvv
      };

      var billingAddress = new customerAddressType
      {
        firstName = payment.FirstName,
        lastName = payment.LastName,
        address = payment.BillingAddress,
        city = payment.BillingCity,
        zip = payment.BillingZip,
      };

      //standard api call to retrieve response
      var paymentType = new paymentType { Item = creditCard };

      var transactionRequest = new transactionRequestType
      {
        transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // charge the card

        amount = payment.Amount,
        payment = paymentType,
        billTo = billingAddress,
      };

      var request = new createTransactionRequest { transactionRequest = transactionRequest };

      // instantiate the controller that will call the service
      var controller = new createTransactionController(request);
      controller.Execute();

      // get the response from the service (errors contained if any)
      var gatewayResponse = controller.GetApiResponse();

      var response = new PaymentResponse();
      response.Success = gatewayResponse.messages.resultCode == messageTypeEnum.Ok;

      // validate response
      if (gatewayResponse != null)
      {
        if (gatewayResponse.messages.resultCode == messageTypeEnum.Ok)
        {
          if (gatewayResponse.transactionResponse.messages != null)
          {
            response.TransactionId = gatewayResponse.transactionResponse.transId;
            response.Code = gatewayResponse.transactionResponse.responseCode;
            response.Message = gatewayResponse.transactionResponse.messages[0].code;
            response.Description = gatewayResponse.transactionResponse.messages[0].description;
          }
          else
          {
            if (gatewayResponse.transactionResponse.errors != null)
            {
              response.Code = gatewayResponse.transactionResponse.errors[0].errorCode;
              response.Message = gatewayResponse.transactionResponse.errors[0].errorText;
            }
          }
        }
        else
        {
          if (gatewayResponse.transactionResponse != null && gatewayResponse.transactionResponse.errors != null)
          {
            response.Code = gatewayResponse.transactionResponse.errors[0].errorCode;
            response.Message = gatewayResponse.transactionResponse.errors[0].errorText;
          }
          else
          {
            response.Code = gatewayResponse.messages.message[0].code;
            response.Message = gatewayResponse.messages.message[0].text;
          }
        }
      }

      return response;
    }

  }
}
