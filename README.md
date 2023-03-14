# PDF Storage API
This ASP.NET Web API allows users to transfer PDF files from one folder to another using REST API calls.

## Getting Started
To get started, clone this repository to your local machine and open the solution file in Visual Studio. You will need to have .NET Framework installed.

## Usage

Once you have the solution open, you can start the Web API project and make requests to the following endpoints:

1. POST /upload-pdf: Uploads a PDF file to the server folder specified in post parameter. The request body should include the PDF file to upload, and the `folderName`.
2. GET /get-pdf: Get the file specified by the `filename` parameter from the folder specified by `folderName` parameter.
3. DELETE /delete-pdf: Delete the file specified by the `filename` parameter from the folder specified by `folderName` parameter.
4. GET /list-files: List all the pdf files in the folder specified by `folderName` parameter.
