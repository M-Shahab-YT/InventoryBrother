$ErrorActionPreference = "Stop"

Write-Host "Building InventoryBrother ERP for Release..." -ForegroundColor Cyan

# Clean previous builds
if (Test-Path "publish") {
    Remove-Item "publish" -Recurse -Force
}

# Publish Desktop App
$project = "src/InventoryBrother.Desktop/InventoryBrother.Desktop.csproj"
$output = "publish/win-x64"

dotnet publish $project -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o $output

if ($LASTEXITCODE -eq 0) {
    Write-Host "Build Successful!" -ForegroundColor Green
    Write-Host "Output located at: $output\InventoryBrother.Desktop.exe" -ForegroundColor Green
} else {
    Write-Host "Build Failed!" -ForegroundColor Red
    exit 1
}
