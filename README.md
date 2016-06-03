# Stormpath ASP.NET Core Example Application

Example web application using ASP.NET Core MVC 6 and Stormpath. Clone it and kick the tires!

## Getting Started

1. **[Sign up](https://api.stormpath.com/register) for Stormpath**

2. **Get your API credentials**

  1. Log in to the [Stormpath Admin Console](https://api.stormpath.com/).
  2. Click the **Create API Key** or **Manage Existing Keys** under Developer Tools on the right side of the page. 
  3. Scroll down to Security Credentials and click **Create API Key**. This will generate your API Key and download it to your computer as an `apiKey.properties` file.

3. **Store your key as environment variables**

  Open your key file and grab the **API Key ID** and **API Key Secret**, then run these commands in PowerShell (or the Windows Command Prompt) to save them as environment variables:

  ```
  setx STORMPATH_CLIENT_APIKEY_ID "[value from properties file]"
  setx STORMPATH_CLIENT_APIKEY_SECRET "[value from properties file]"
  ```
  
4. **Store your Stormpath Application href in an environment variable**

  Grab the `href` (called **REST URL** in the Stormpath Console UI) of your Application. It should look something like this:

  `https://api.stormpath.com/v1/applications/q42unYAj6PDLxth9xKXdL`

  Save this as an environment variable:

  ```
  setx STORMPATH_APPLICATION_HREF "[your Application href]"
  ```

5. **Clone this repository**

  ```
  git clone https://github.com/stormpath/stormpath-aspnetcore-example.git
  ```
  
6. **Build and run!**
  ```
  cd stormpath-aspnetcore-example
  cd src\StormpathExample
  dotnet restore
  dotnet run
  ```
  
  Try navigating to the protected route `http://localhost:5000/Manage`. You should be redirected to the login page, where you can log in or create an account. Once you are logged in, you'll be able to access the route.
