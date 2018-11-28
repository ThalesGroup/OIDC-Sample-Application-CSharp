# OIDC-Sample-Application
This sample code will help customer's integrating their third party solution with Gemalto's Access management(STA) solution using OIDC protocol.

# Prerequisites
1. .NET Core SDK 2.1.
2. A text editor or code editor of your choice.
3. You already created a Application in your Identity Provider(IDP) and have ClientId, ClientSecret, Authority URL

# Configuring the Application
1. open ..\OIDCSampleApplication\OIDCSampleApplication\appsettings.json in the text Editor
2. Configure ClientId, ClientSecret, Authority
3. Ex: 
				"OIDCConfig": {
						"ClientId": "XXXXXXXX",
						"ClientSecret": "MySecret",
						"Authority": "http://{hostname}/auth/realms/{RealmName}"
					}

# How To Run
1. Navigate to ..\OIDCSampleApplication\OIDCSampleApplication via cmd
2. dotnet Build
3. dotnet Run
4. Application will Start running at some localhost port Ex: http://localhost:55074/
5. Copy the Url and Open it in Browser to Authenticate

# Alternate way to Run the App
1. Install Visual Studio 2017 Community or Professional or Above version
2. Open OIDCSampleApplication.sln in the visual Studio
3. Run the Application from Visual Studio by pressing F5 key
4. Application will open in browser to Authenticate
