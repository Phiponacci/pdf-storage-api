# PDF Storage API
This ASP.NET Web API allows users to transfer PDF files from one folder to another using REST API calls.

## Getting Started
To get started, clone this repository to your local machine and open the solution file in Visual Studio. You will need to have .NET 6 or above installed.

## Usage

Once you have the solution open, you can start the Web API project and make requests to the following endpoints:

1. POST /upload-pdf: Uploads a PDF file to the server folder specified in post parameter. The request body should include the PDF file to upload, and the `folderName`.
2. GET /get-pdf: Get the file specified by the `filename` parameter from the folder specified by `folderName` parameter.
3. DELETE /delete-pdf: Delete the file specified by the `filename` parameter from the folder specified by `folderName` parameter.
4. GET /list-files: List all the pdf files in the folder specified by `folderName` parameter.

# Reach us on Fiverr & Upwork

[![Fiverr](https://img.shields.io/badge/Fiverr-1DBF73.svg?style=for-the-badge&logo=Fiverr&logoColor=white)](https://www.fiverr.com/phiponatchi)
[![Upwork](https://img.shields.io/badge/Upwork-6FDA44.svg?style=for-the-badge&logo=Upwork&logoColor=white)](https://www.upwork.com/freelancers/~01556fb0a54a5fa971)
[![Portfolio](https://img.shields.io/badge/GitHub%20Pages-222222.svg?style=for-the-badge&logo=GitHub-Pages&logoColor=white)](https://phiponacci.github.io/portfolio/)

# Donations

If you found ***PDF-Storage-API*** useful, please consider making a donation to support its ongoing development. Your contribution will help ensure that we can continue to provide updates and improvements to the app.

Developer paypal email: <leo.phibonacci@gmail.com>

[![Donate with PayPal](https://raw.githubusercontent.com/stefan-niedermann/paypal-donate-button/master/paypal-donate-button.png)](https://www.paypal.com)

Thank you for your support!
