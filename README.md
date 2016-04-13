# Stormpath ASP.NET Core Example Application

Example web application using ASP.NET Core MVC 6 and Stormpath. Clone it and kick the tires!

## Getting Started

1. **[Sign up](https://api.stormpath.com/register) for Stormpath**

2. **Get your key file**

  [Download your key file](https://support.stormpath.com/hc/en-us/articles/203697276-Where-do-I-find-my-API-key-) from the Stormpath Console.

3. **Store your key as environment variables**

  Open your key file and grab the **API Key ID** and **API Key Secret**, then run these commands in PowerShell (or the Windows Command Prompt) to save them as environment variables:

  ```
  setx STORMPATH_CLIENT_APIKEY_ID "[value-from-properties-file]"
  setx STORMPATH_CLIENT_APIKEY_SECRET "[value-from-properties-file]"
  ```

4. **Clone this repository**

  ```
  git clone https://github.com/stormpath/stormpath-aspnetcore-example.git
  ```
  
5. **Edit the configuration**

  In `Startup.cs`, edit the `stormpathConfiguration` declaration to point to the name or `href` of the Stormpath Application you want to use for the demo. If the Stormpath default "My Application" in  is fine, you can leave the configuration as-is.
  
  > :bulb: You can also set the environment variable STORMPATH_APPLICATION_HREF instead of configuring in code.
  
6. **Build and run!**
  ```
  cd stormpath-aspnetcore-example
  cd src\StormpathExample
  dnu restore
  dnx web
  ```
  
  Try navigating to the protected route `http://localhost:5000/Manage`. You should be redirected to the login page, where you can log in or create an account. Once you are logged in, you'll be able to access the route.
