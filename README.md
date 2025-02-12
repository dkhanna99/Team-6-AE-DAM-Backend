# 🚀 Digital Asset Management (DAM) API

A **.NET 8.0 Web API** for managing digital assets (images, videos) with **Azure SQL** and **Azure Blob Storage**.

## 🛠 Tech Stack
- **Backend**: .NET 8.0 (ASP.NET Core Web API)
- **Database**: Azure SQL
- **Storage**: Azure Blob Storage
- **Authentication**: Microsoft Entra ID (Azure AD)
- **Hosting**: Azure App Service

## ⚙️ Setup & Run Locally
1. **Clone the Repo**  
   ```sh
   git clone https://github.com/your-repo-name/DAMBackend.git
   cd DAMBackend

2. **Update `appsettings.json` with Azure SQL connection**
```json

"ConnectionStrings": {
    "DefaultConnection": "Server=tcp:yourserver.database.windows.net,1433;Database=DAMDB;User ID=youradmin;Password=yourpassword;Encrypt=True;TrustServerCertificate=False;"
}
```

3. **Run Database Migrations**
```sh

dotnet ef database update
```
4. **Start the API**
```sh

dotnet run
```

## 🚀 Deploy to Azure

### 1️⃣ Deploy Using Visual Studio
- **Right-click the project** → **Publish**
- Select **Azure App Service**
- Click **Finish** → **Publish**
- Visit **`https://your-app-name.azurewebsites.net/swagger`** to verify deployment.

### 2️⃣ Deploy Using GitHub Actions (CI/CD)
Add the following workflow to `.github/workflows/deploy.yml`:

```yaml
- uses: azure/webapps-deploy@v2
  with:
    app-name: "dam-backend-app"
