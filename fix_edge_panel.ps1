# Script untuk menambahkan panelEdgeContainer ke panelSidebarRight
$designerFile = "C:\Users\TUF GAMING\Source\Repos\PengolahanCitra\PengolahanCitra\Form1.Designer.cs"

# Backup file
Copy-Item $designerFile "$designerFile.backup_$(Get-Date -Format 'yyyyMMdd_HHmmss')"

# Baca konten
$content = Get-Content $designerFile -Raw

# Cek apakah sudah ada panelEdgeContainer di Controls
if ($content -notmatch 'this\.panelSidebarRight\.Controls\.Add\(this\.panelEdgeContainer\)') {
    # Tambahkan panelEdgeContainer sebelum panelFilterContainer
    $content = $content -replace '(this\.panelSidebarRight\.Controls\.Add\(this\.panelFilterContainer\);)', "this.panelSidebarRight.Controls.Add(this.panelEdgeContainer);`r`n            `$1"
    
    # Simpan
    $content | Set-Content $designerFile -Encoding UTF8
    Write-Host "? panelEdgeContainer berhasil ditambahkan ke panelSidebarRight!" -ForegroundColor Green
} else {
    Write-Host "? panelEdgeContainer sudah ada di panelSidebarRight" -ForegroundColor Yellow
}

# Set initial values untuk Canny thresholds jika belum ada
if ($content -notmatch 'numericCannyLowThreshold\.Value') {
    $content = Get-Content $designerFile -Raw
    $content = $content -replace '(this\.numericCannyLowThreshold\.TextAlign = System\.Windows\.Forms\.HorizontalAlignment\.Center;)', "`$1`r`n            this.numericCannyLowThreshold.Value = new decimal(new int[] { 50, 0, 0, 0 });"
    $content = $content -replace '(this\.numericCannyHighThreshold\.TextAlign = System\.Windows\.Forms\.HorizontalAlignment\.Center;)', "`$1`r`n            this.numericCannyHighThreshold.Value = new decimal(new int[] { 150, 0, 0, 0 });"
    $content | Set-Content $designerFile -Encoding UTF8
    Write-Host "? Canny threshold initial values telah ditambahkan!" -ForegroundColor Green
}

Write-Host "`n????????????????????????????????????????" -ForegroundColor Cyan
Write-Host "Perbaikan selesai! Silakan rebuild solution." -ForegroundColor Cyan
Write-Host "????????????????????????????????????????" -ForegroundColor Cyan
