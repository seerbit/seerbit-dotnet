# seerbit-dotnet

<div align="center">
 <img width="400" valign="top" src="https://assets.seerbitapi.com/images/seerbit_logo_type.png">
</div>

Features
The Library supports all APIs under the following services:

Payment via API (card and account)
Disputes
Refunds
Transaction Status
Getting Started
A full getting started guide for integrating SeerBit can be found at getting started docs.

Documentation
The documentation, installation guide, detailed description of the SeerBit API and all of its features is available on the documentation website

Requirements
DontNet core verson 21.
Installation

Add this dependency to your startup file:

    services.AddScoped<IAccount, AccountService>();
    services.AddScoped<IAuthentication, AuthenticationService>();
    services.AddScoped<IAuthorise, AuthoriseService>();
    services.AddScoped<ICard, CardService>();
    services.AddScoped<IMomo, MomoService>();
    services.AddScoped<INon3DS, Non3DSService>();
    services.AddScoped<IOrderCheckOut, OrderCheckOutService>();
    services.AddScoped<IPaymentMethod, PaymentMethodService>();
    services.AddScoped<IPreAuthorization, PreAuthorizationService>();
    services.AddScoped<IRecurrent, RecurrentService>();
    services.AddScoped<IStandardCheckOut, StandardCheckOutService>();
    services.AddScoped<ITokenize, TokenizeService>();
    services.AddHttpClient<Interchange>();
    services.Configure<SeerBitSettingsModel>(Configuration.GetSection("seerBitSettings"));

Add this dependency to your appsetting file:

    "seerBitSettings": 
    {
        "TestBaseUrl": "https://seerbitapi.com/api/v2/",
        "LiveBaseUrl": "https://seerbitapi.com/api/v2/",
        "PilotBaseUrl": "https://seerbitapi.com/api/v2/",
        "Environment": "TEST"
    }

Contributing
You can contribute to this repository so that anyone can benefit from it:

Improved features
Resolved bug fixes and issues
Examples
You can also check the src/main/java/com/seerbit/demo folder in this repository for more examples of usage.

Using the Library

Initiate Account Transaction
Instantiate a client and set the parameters. Then perform service authentication by instantiating the authentication service object and passing the client to it in its constructor. Retrieve your token by calling the getToken() method.
        
private readonly IAuthentication _IAuthentication;
private readonly IStandardCheckOut _IStandardCheckOut;

    public ClassConstructor(IAuthentication iAuthentication, IStandardCheckOut iStandardCheckOut)
    {
         _IAuthentication = iAuthentication;
         this._IStandardCheckOut = iStandardCheckOut;
    }

    public async Task<string> TestMethod()
    {
     var token = await _IAuthentication.Token(privateKey, publicKey);

//After retrieving your token following authentication proceed to pass it to the StandardCheckOut constructor along with your client object. You can then construct your payload and call the Payment() method of the StandardCheckOut class.

     var request = new StandardCheckPaymentRequest
                {
                    amount = "",
                    callbackUrl = "",
                    country = "",
                    currency = "",
                    email = "",
                    hashType = "",
                    paymentReference = "",
                    productDescription = "",
                    productId = "",
                    publicKey = ""
                };
     
     var result = await this._IStandardCheckOut.Payment(request, token);
     return result;
   }
  
Find more examples here.

Licence
GNU General Public License. For more information, see the LICENSE file.

Website
https://seerbit.com
